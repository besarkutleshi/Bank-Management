#pragma checksum "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d31701fc8fd4eac27714298fcc0627f4ef9edba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Credit_CreditDetails), @"mvc.1.0.view", @"/Views/Credit/CreditDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d31701fc8fd4eac27714298fcc0627f4ef9edba", @"/Views/Credit/CreditDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a78a38a60cf7bcc507145fc380ab22337670ba9", @"/Views/_ViewImports.cshtml")]
    public class Views_Credit_CreditDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Credits>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("lass", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/user-circle-solid.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/wallet-solid (1).svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PayCredit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Credit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("float-left text-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
  
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d31701fc8fd4eac27714298fcc0627f4ef9edba8619", async() => {
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
#line 17 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                                      Write(Model.Client.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                                                         Write(Model.Client.Surname);

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d31701fc8fd4eac27714298fcc0627f4ef9edba11000", async() => {
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
#line 29 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                                Write(Model.Balance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <p class=\"text-center\">Available Balance</p>\r\n                            <hr />\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d31701fc8fd4eac27714298fcc0627f4ef9edba12790", async() => {
                WriteLiteral("Pay Credit");
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
                                <p>Have questions or concerns regarding your credit ? <br /> Our experts are here to help you</p>
                            </div>
                            <br />
                            <div class=""text-center"">
                                <button class=""btn btn-success"">Chat with us</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </di");
            WriteLiteral(@"v>
        <div class=""col-sm-8"">
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""card"" style=""margin-bottom:15px"">
                        <div class=""card-body"">
                            <h5>Personal Details</h5>
                            <div class=""text-center"">
                                <p>Name :");
#nullable restore
#line 62 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                    Write(Model.Client.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 62 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                                       Write(Model.Client.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>Personal Number :");
#nullable restore
#line 63 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                               Write(Model.Client.PersonalNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>Address : Street Nr. ");
#nullable restore
#line 64 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                                   Write(Model.Client.StreetNr);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 64 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                                                          Write(Model.Client.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 64 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                                                                               Write(Model.Client.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 64 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                                                                                                    Write(Model.Client.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 64 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                                                                                                                             Write(Model.Client.Country);

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
                            <h5>Contract</h5>
                            <div class=""text-center"">
                                <p>Start Date : ");
#nullable restore
#line 74 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                           Write(Model.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>End Date : ");
#nullable restore
#line 75 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                         Write(Model.EndDate);

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
#line 85 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                      Write(Model.Client.Email);

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
#line 95 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                          Write(Model.Client.NrTel);

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
                            <h5>Interes</h5>
                            <div class=""text-center"">
                                <p>Interes : ");
#nullable restore
#line 105 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Credit\CreditDetails.cshtml"
                                        Write(Model.Interes);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Credits> Html { get; private set; }
    }
}
#pragma warning restore 1591