#pragma checksum "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7a019551196ca7d666944203296a45ab301dd66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Card_SavingAccountDetails), @"mvc.1.0.view", @"/Views/Card/SavingAccountDetails.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\_ViewImports.cshtml"
using WebProjekti;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\_ViewImports.cshtml"
using WebProjekti.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\_ViewImports.cshtml"
using WebProjekti.Models.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\_ViewImports.cshtml"
using DataAccessLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\_ViewImports.cshtml"
using WebProjekti.Models.Administration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\_ViewImports.cshtml"
using EntityLayer.Persons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\_ViewImports.cshtml"
using EntityLayer.Accounts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\_ViewImports.cshtml"
using EntityLayer.Transactions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\_ViewImports.cshtml"
using EntityLayer.Credits;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7a019551196ca7d666944203296a45ab301dd66", @"/Views/Card/SavingAccountDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a78a38a60cf7bcc507145fc380ab22337670ba9", @"/Views/_ViewImports.cshtml")]
    public class Views_Card_SavingAccountDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SavingAccounts>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("lass", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/user-circle-solid.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/wallet-solid (1).svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "WithDrawal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Transaction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("float-left text-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Deposit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("float-right text-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
  
    ViewBag.Title = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-sm-4"">
            <div class=""row"">
                <div class=""col-sm-12"" style=""margin-bottom:15px"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <div class=""text-center"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a7a019551196ca7d666944203296a45ab301dd669329", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                            <br />\r\n                            <h5 class=\"text-center\">Hello, ");
#nullable restore
#line 17 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                                      Write(Model.Account.Client.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                                                                 Write(Model.Account.Client.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div class=""col-sm-12"" style=""margin-bottom:15px"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <div class=""text-center"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a7a019551196ca7d666944203296a45ab301dd6611744", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                            <h3 class=\"text-center\">$");
#nullable restore
#line 29 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                                Write(Model.Account.Balance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <p class=\"text-center\">Available Balance</p>\r\n                            <hr />\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7a019551196ca7d666944203296a45ab301dd6613547", async() => {
                WriteLiteral("Withdraw");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7a019551196ca7d666944203296a45ab301dd6615022", async() => {
                WriteLiteral("Deposit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""col-sm-12"" style=""margin-bottom:15px"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <div class=""text-center"">
                                <i class='fas fa-comments' style='font-size:100px; color:black'></i>
                            </div>
                            <br />
                            <div class=""text-center"">
                                <p>Have questions or concerns regarding your account ? <br /> Our experts are here to help you</p>
                            </div>
                            <br />
                            <div class=""text-center"">
                                <button class=""btn btn-success"">Chat with us</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </d");
            WriteLiteral(@"iv>
        <div class=""col-sm-8"">
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""card"" style=""margin-bottom:15px"">
                        <div class=""card-body"">
                            <h5>Personal Details</h5>
                            <div class=""text-center"">
                                <p>Name :");
#nullable restore
#line 63 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                    Write(Model.Account.Client.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 63 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                                               Write(Model.Account.Client.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>Personal Number :");
#nullable restore
#line 64 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                               Write(Model.Account.Client.PersonalNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>Address : Street Nr. ");
#nullable restore
#line 65 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                                   Write(Model.Account.Client.StreetNr);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 65 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                                                                  Write(Model.Account.Client.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 65 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                                                                                               Write(Model.Account.Client.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 65 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                                                                                                                            Write(Model.Account.Client.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 65 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                                                                                                                                                             Write(Model.Account.Client.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-12"">
                    <div class=""card"" style=""margin-bottom:15px"">
                        <div class=""card-body"">
                            <h5>Account Details</h5>
                            <div class=""text-center"">
                                <p>Card Number : ");
#nullable restore
#line 75 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                            Write(Model.Account.CardNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>Account Number : ");
#nullable restore
#line 76 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                               Write(Model.Account.AccountNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-12"">
                    <div class=""card"" style=""margin-bottom:15px"">
                        <div class=""card-body"">
                            <h5>Email Address</h5>
                            <div class=""text-center"">
                                <p>Email : ");
#nullable restore
#line 86 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                      Write(Model.Account.Client.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-12"">
                    <div class=""card"" style=""margin-bottom:15px"">
                        <div class=""card-body"">
                            <h5>Phone Number</h5>
                            <div class=""text-center"">
                                <p>Phone Nr. : ");
#nullable restore
#line 96 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Card\SavingAccountDetails.cshtml"
                                          Write(Model.Account.Client.NrTel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script src=\'https://kit.fontawesome.com/a076d05399.js\'></script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SavingAccounts> Html { get; private set; }
    }
}
#pragma warning restore 1591
