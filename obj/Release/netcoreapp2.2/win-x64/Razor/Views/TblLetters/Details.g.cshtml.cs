#pragma checksum "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c9eb52d6c38e0da16a9c6849e6f31b8e672bd85"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TblLetters_Details), @"mvc.1.0.view", @"/Views/TblLetters/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TblLetters/Details.cshtml", typeof(AspNetCore.Views_TblLetters_Details))]
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
#line 1 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\_ViewImports.cshtml"
using Seeco;

#line default
#line hidden
#line 2 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\_ViewImports.cshtml"
using Seeco.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c9eb52d6c38e0da16a9c6849e6f31b8e672bd85", @"/Views/TblLetters/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff4b5106d5629a7a90e5aae2f79d07c7ded66950", @"/Views/_ViewImports.cshtml")]
    public class Views_TblLetters_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Seeco.Models.TblLetters>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_LayoutProject.cshtml";

#line default
#line hidden
            BeginContext(131, 131, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>TblLetters</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(263, 40, false);
#line 15 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(303, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(365, 36, false);
#line 18 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(401, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(462, 48, false);
#line 21 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateReceived));

#line default
#line hidden
            EndContext();
            BeginContext(510, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(572, 44, false);
#line 24 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateReceived));

#line default
#line hidden
            EndContext();
            BeginContext(616, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(677, 44, false);
#line 27 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IssuedBy));

#line default
#line hidden
            EndContext();
            BeginContext(721, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(783, 40, false);
#line 30 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayFor(model => model.IssuedBy));

#line default
#line hidden
            EndContext();
            BeginContext(823, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(884, 46, false);
#line 33 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DirectedTo));

#line default
#line hidden
            EndContext();
            BeginContext(930, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(992, 42, false);
#line 36 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayFor(model => model.DirectedTo));

#line default
#line hidden
            EndContext();
            BeginContext(1034, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1095, 43, false);
#line 39 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Subject));

#line default
#line hidden
            EndContext();
            BeginContext(1138, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1200, 39, false);
#line 42 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayFor(model => model.Subject));

#line default
#line hidden
            EndContext();
            BeginContext(1239, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1300, 44, false);
#line 45 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FilePath));

#line default
#line hidden
            EndContext();
            BeginContext(1344, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1406, 40, false);
#line 48 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayFor(model => model.FilePath));

#line default
#line hidden
            EndContext();
            BeginContext(1446, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1507, 48, false);
#line 51 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Descriptiopn));

#line default
#line hidden
            EndContext();
            BeginContext(1555, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1617, 44, false);
#line 54 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayFor(model => model.Descriptiopn));

#line default
#line hidden
            EndContext();
            BeginContext(1661, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1722, 43, false);
#line 57 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Project));

#line default
#line hidden
            EndContext();
            BeginContext(1765, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1827, 42, false);
#line 60 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
       Write(Html.DisplayFor(model => model.Project.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1869, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1916, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c9eb52d6c38e0da16a9c6849e6f31b8e672bd8510864", async() => {
                BeginContext(1962, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 65 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1970, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1978, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c9eb52d6c38e0da16a9c6849e6f31b8e672bd8513178", async() => {
                BeginContext(2029, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 66 "C:\Users\FATHY\source\repos\Seeco\Seeco\Views\TblLetters\Details.cshtml"
                             WriteLiteral(ViewBag.pid);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2045, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2072, 1, true);
                WriteLiteral(" ");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Seeco.Models.TblLetters> Html { get; private set; }
    }
}
#pragma warning restore 1591
