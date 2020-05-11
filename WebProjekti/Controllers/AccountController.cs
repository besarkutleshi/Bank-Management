using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Persons;
using EntityLayer.Persons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebProjekti.Models.Account;

namespace WebProjekti.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ClientRepository _clientRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly ILogger<AccountController> logger;
        public static Clients CurrentClient = null;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger,
            IConfiguration configuration,ClientRepository clientRepository,EmployeeRepository employee)
        {
            this._employeeRepository = employee;
            this._clientRepository = clientRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this._config = configuration;
        }


        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Clients client = _clientRepository.GetClientEmail(model.Email);
                Employees employees = null;
                if(client == null)
                {
                    employees = _employeeRepository.GetEmailEmployee(model.Email);
                }

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email};

                if(client == null && employees == null)
                {
                    ViewBag.ErrorTitle = "Not Successful";
                    ViewBag.ErrorMessage = "This email not exist to our clients";
                    return View("Error");
                }
                if(client == null)
                {
                    user.ClientID = (int)employees.PersonId;
                }
                else
                {
                    user.ClientID = (int)client.PersonId;
                }

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                    logger.Log(LogLevel.Warning, confirmationLink);

                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }

                    ViewBag.ErrorTitle = "Registration successful";
                    ViewBag.ErrorMessage = "Please confrim your email, by clicking on the confirmation link we have emailed you";
                    return View("Error");
                }
                string error = null;
                foreach (var item in result.Errors)
                {
                    error += item.Description;
                }
                ViewBag.ErrorTitle = "Registration Not Successful";
                ViewBag.ErrorMessage = error;
                return View("Error");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                RedirectToAction("index", "home");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"The user with id {userId} not found";
                return View("Not Found");
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }

            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel loginView = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(loginView);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Account", new { ReturnUrl = returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallBack(string returnUrl, string remoteError)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            LoginViewModel loginView = new LoginViewModel()
            {
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: { remoteError }");
                return View("Login", loginView);
            }

            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login information");
                return View("Login", loginView);
            }

            Clients client = null;
            Employees employees = null;
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            ApplicationUser user = null;
            if (email != null)
            {
                user = await userManager.FindByEmailAsync(email);
                client = _clientRepository.GetClientEmail(email);
                employees = _employeeRepository.GetEmailEmployee(email);
                if(client == null && employees == null)
                {
                    ViewBag.ErrorTitle = "Not Successful";
                    ViewBag.ErrorMessage = "This email not exist to our clients";
                    return View("Error");
                }
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("", "Email not confirmed yet");
                    return View("Login", loginView);
                }
            }

            var signiInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signiInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                if (email != null)
                {
                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };
                        if (employees == null)
                            user.ClientID = (int)client.PersonId;
                        else
                            user.ClientID = (int)employees.PersonId;
                        await userManager.CreateAsync(user);

                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirmationLink = Url.Action("ConfirmEmail", "Account",
                            new { userId = user.Id, token = token }, Request.Scheme);

                        logger.Log(LogLevel.Warning, confirmationLink);

                        ViewBag.ErrorTitle = "Registration successful";
                        ViewBag.ErrorMessage = "Please confrim your email, by clicking on the confirmation link we have emailed you";
                        return View("Error");
                    }
                    if (!user.EmailConfirmed)
                    {
                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirmationLink = Url.Action("ConfirmEmail", "Account",
                            new { userId = user.Id, token = token }, Request.Scheme);

                        logger.Log(LogLevel.Warning, confirmationLink);
                        return View("Login");
                    }
                    await userManager.AddLoginAsync(user, info);
                    await signInManager.SignInAsync(user, isPersistent: false);


                    return Redirect(returnUrl);
                }
                ViewBag.ErrorTitle = $"Email claim not received from : {info.LoginProvider}";
                ViewBag.Error = "Please contact support on besarkutla.7@gmail.com";
                return View("Error");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            model.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed &&
                                    (await userManager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError("", "Email not confirmed yet");
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { userId = user.Id, token = token }, Request.Scheme);

                    logger.Log(LogLevel.Warning, confirmationLink);
                    return View(model);
                }


                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);


                if (result.Succeeded)
                {
                    CurrentClient = await _clientRepository.GetCurrentClient(user.ClientID);
                    var us = await userManager.FindByEmailAsync(model.Email);
                    var roles = await userManager.GetRolesAsync(us);
                    foreach (var item in roles)
                    {
                        if (item == "Admin" || item == "Super Admin")
                        {
                            return RedirectToAction("AdminIndex", "Home");
                        }
                    }

                    if (User.IsInRole("Super Admin"))
                    {
                        return RedirectToAction("AdminIndex", "Home");
                    }

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ViewBag.ErrorTitle = $"Email or password is incorrect";
            ViewBag.ErrorMessage = "If you want to reset password, click forgot password link";
            return View("Error");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                        new { email = model.Email, token = token }, Request.Scheme);

                    logger.Log(LogLevel.Warning, passwordResetLink);
                    return View("ForgotPasswordConfirmation");
                }
                if (!user.EmailConfirmed)
                {
                    ModelState.AddModelError("", "Email not confirmed yet , please confirm your email");
                }
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        ViewBag.Success = true;
                        return View("ResetPasswordConfirmation");
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }
                return View("ResetPasswordConfirmation");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                var result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
                await signInManager.RefreshSignInAsync(user);
                return View();
            }
            return View(model);
        }
    }
}