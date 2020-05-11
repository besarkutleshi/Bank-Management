#pragma checksum "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Transaction\Balance.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a67539ff95424d720ecc59b997044f2d22196cb9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transaction_Balance), @"mvc.1.0.view", @"/Views/Transaction/Balance.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a67539ff95424d720ecc59b997044f2d22196cb9", @"/Views/Transaction/Balance.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2786f95c442e09840e5a247e9799270e0bdf9ec", @"/Views/_ViewImports.cshtml")]
    public class Views_Transaction_Balance : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Transaction\Balance.cshtml"
  
    ViewBag.Title = "My Balance";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-sm-4"">
            <br />
            <div class=""row"">
                <div class=""col-sm-12"">
                    <h3 class=""text-center"">My Balance</h3>
                    <h4 style=""color:Highlight"">$");
#nullable restore
#line 13 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Transaction\Balance.cshtml"
                                            Write(ViewBag.Balance);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                </div>
                <br />
            </div>
        </div>
        <div class=""col-sm-8"">
            <div id=""chartContainerDeposits"" style=""height: 300px; width: 100%;"">

            </div>
            <br />
            <br />
            <div id=""chartContainerTransfer"" style=""height: 300px; width: 100%;"">
                chartContainerDrawals
            </div>
            <br />
            <br />
            <div id=""chartContainerDrawals"" style=""height: 300px; width: 100%;"">
                
            </div>
        </div>
    </div>
</div>


");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        window.onload = function () {

        var chartDeposit = new CanvasJS.Chart(""chartContainerDeposits"", {
        animationEnabled: true,
        theme: ""light2"", // ""light1"", ""light2"", ""dark1"", ""dark2""
        title: {
        text: ""Deposit values for months""
        },
        data: [{
        type: ""column"",
        dataPoints: ");
#nullable restore
#line 49 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Transaction\Balance.cshtml"
               Write(Html.Raw(ViewBag.DataDeposits));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        }]
        });
        chartDeposit.render();
            var chartTransfer = new CanvasJS.Chart(""chartContainerTransfer"", {
        animationEnabled: true,
        theme: ""light2"", // ""light1"", ""light2"", ""dark1"", ""dark2""
        title: {
        text: ""Transfer values for months""
        },
        data: [{
        type: ""column"",
        dataPoints: ");
#nullable restore
#line 61 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Transaction\Balance.cshtml"
               Write(Html.Raw(ViewBag.DataTransfers));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        }]
        });
            chartTransfer.render();
        var chartDrawals = new CanvasJS.Chart(""chartContainerDrawals"", {
        animationEnabled: true,
        theme: ""light2"", // ""light1"", ""light2"", ""dark1"", ""dark2""
        title: {
        text: ""With Drawal values for months""
        },
        data: [{
        type: ""column"",
        dataPoints: ");
#nullable restore
#line 73 "C:\Users\Admin\Desktop\WebProjekti\WebProjekti\Views\Transaction\Balance.cshtml"
               Write(Html.Raw(ViewBag.DataDrawals));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        }]\r\n        });\r\n            chartDrawals.render();\r\n\r\n\r\n        }\r\n    </script>\r\n    <script src=\"https://canvasjs.com/assets/script/canvasjs.min.js\"></script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591