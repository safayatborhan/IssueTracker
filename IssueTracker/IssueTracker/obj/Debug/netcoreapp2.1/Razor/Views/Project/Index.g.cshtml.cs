#pragma checksum "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26db4c5a094f9012156996ac49728314eb24ffaa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_Index), @"mvc.1.0.view", @"/Views/Project/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Project/Index.cshtml", typeof(AspNetCore.Views_Project_Index))]
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
#line 1 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\_ViewImports.cshtml"
using IssueTracker;

#line default
#line hidden
#line 2 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\_ViewImports.cshtml"
using IssueTracker.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26db4c5a094f9012156996ac49728314eb24ffaa", @"/Views/Project/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ba94f1c87410a469752601943342041e8c9d15b", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IssueTracker.Models.ProjectListingModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-left: -20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-xs btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(151, 52, true);
            WriteLiteral("\r\n<h2 class=\"text-center\">Projects</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(203, 144, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a149561f8344746a0d18ae236fd7506", async() => {
                BeginContext(278, 65, true);
                WriteLiteral("<i class=\"fa fa-plus-square-o\" aria-hidden=\"true\"></i> Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(347, 143, true);
            WriteLiteral("\r\n</p>\r\n<table id=\"dtProject\" class=\"ui celled table\" style=\"margin-left: 5px;\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(491, 40, false);
#line 17 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(531, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(587, 47, false);
#line 20 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(634, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(690, 47, false);
#line 23 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ProjectType));

#line default
#line hidden
            EndContext();
            BeginContext(737, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(793, 53, false);
#line 26 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.EndOfContractDate));

#line default
#line hidden
            EndContext();
            BeginContext(846, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 32 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(981, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1042, 39, false);
#line 36 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1081, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1149, 46, false);
#line 39 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(1195, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1263, 46, false);
#line 42 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ProjectType));

#line default
#line hidden
            EndContext();
            BeginContext(1309, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1377, 52, false);
#line 45 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.EndOfContractDate));

#line default
#line hidden
            EndContext();
            BeginContext(1429, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1496, 136, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b78ab2c13eaf4200bf7b05338cb0f016", async() => {
                BeginContext(1572, 56, true);
                WriteLiteral("<i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 48 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
                                                                          WriteLiteral(item.Id);

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
            BeginContext(1632, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 51 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Project\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1687, 28, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IssueTracker.Models.ProjectListingModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
