#pragma checksum "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Shared\Components\Notification\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "164f8e8b9772986e0f62a2474951a723cf796a32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Notification_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Notification/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Notification/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Notification_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"164f8e8b9772986e0f62a2474951a723cf796a32", @"/Views/Shared/Components/Notification/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ba94f1c87410a469752601943342041e8c9d15b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Notification_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IssueTracker.Models.NotificationListingModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("User Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "InvolvedPerson", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "NotificationHit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 237, true);
            WriteLiteral("<!-- Messages: style can be found in dropdown.less-->\r\n<li class=\"dropdown messages-menu\">\r\n    <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">\r\n        <i class=\"fa fa-bell-o\"></i>\r\n        <span class=\"label label-success\">");
            EndContext();
            BeginContext(291, 23, false);
#line 6 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Shared\Components\Notification\Default.cshtml"
                                     Write(Model.NotificationCount);

#line default
#line hidden
            EndContext();
            BeginContext(314, 87, true);
            WriteLiteral("</span>\r\n    </a>\r\n    <ul class=\"dropdown-menu\">\r\n        <li class=\"header\">You have ");
            EndContext();
            BeginContext(402, 23, false);
#line 9 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Shared\Components\Notification\Default.cshtml"
                               Write(Model.NotificationCount);

#line default
#line hidden
            EndContext();
            BeginContext(425, 125, true);
            WriteLiteral(" Notifications</li>\r\n        <li>\r\n            <!-- inner menu: contains the actual data -->\r\n            <ul class=\"menu\">\r\n");
            EndContext();
#line 13 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Shared\Components\Notification\Default.cshtml"
                 foreach (var notification in Model.Notifications)
                {

#line default
#line hidden
            BeginContext(637, 98, true);
            WriteLiteral("                    <li>\r\n                        <!-- start message -->\r\n                        ");
            EndContext();
            BeginContext(735, 540, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c87cfc2766c4c7696fb4bb2371b3b3f", async() => {
                BeginContext(831, 87, true);
                WriteLiteral("\r\n                            <div class=\"pull-left\">\r\n                                ");
                EndContext();
                BeginContext(918, 80, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "daf2457739b04d678f827013914ca120", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 928, "~/uploads/", 928, 10, true);
#line 19 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Shared\Components\Notification\Default.cshtml"
AddHtmlAttributeValue("", 938, notification.ImageUrl, 938, 22, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(998, 104, true);
                WriteLiteral("\r\n                            </div>\r\n                            <h4>\r\n                                ");
                EndContext();
                BeginContext(1103, 19, false);
#line 22 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Shared\Components\Notification\Default.cshtml"
                           Write(notification.Header);

#line default
#line hidden
                EndContext();
                BeginContext(1122, 97, true);
                WriteLiteral("\r\n                            </h4>\r\n                            <p style=\"white-space: normal;\">");
                EndContext();
                BeginContext(1220, 21, false);
#line 24 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Shared\Components\Notification\Default.cshtml"
                                                       Write(notification.Messages);

#line default
#line hidden
                EndContext();
                BeginContext(1241, 30, true);
                WriteLiteral("</p>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 17 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Shared\Components\Notification\Default.cshtml"
                                                                                          WriteLiteral(notification.Id);

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
            BeginContext(1275, 71, true);
            WriteLiteral("\r\n                    </li>\r\n                    <!-- end message -->\r\n");
            EndContext();
#line 28 "D:\WORKS\IssueTracker\IssueTracker\IssueTracker\Views\Shared\Components\Notification\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(1365, 50, true);
            WriteLiteral("            </ul>\r\n        </li>\r\n    </ul>\r\n</li>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IssueTracker.Models.NotificationListingModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
