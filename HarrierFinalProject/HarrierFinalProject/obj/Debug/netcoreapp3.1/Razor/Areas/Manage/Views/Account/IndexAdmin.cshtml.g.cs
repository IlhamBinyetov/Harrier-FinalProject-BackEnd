#pragma checksum "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Account\IndexAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4101b874541e258cb204e3c232a2a5cffd6e5ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Account_IndexAdmin), @"mvc.1.0.view", @"/Areas/Manage/Views/Account/IndexAdmin.cshtml")]
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
#line 1 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\_ViewImports.cshtml"
using HarrierFinalProject.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\_ViewImports.cshtml"
using HarrierFinalProject.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\_ViewImports.cshtml"
using HarrierFinalProject.Data.Models.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4101b874541e258cb204e3c232a2a5cffd6e5ca", @"/Areas/Manage/Views/Account/IndexAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a274e9240ef55a57b54d7f94d89b863944a79e67", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Account_IndexAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AdminViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size:12px; text-decoration:none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "createadmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Account\IndexAdmin.cshtml"
  
    ViewData["Title"] = "IndexAdmin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>IndexAdmin</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4101b874541e258cb204e3c232a2a5cffd6e5ca5241", async() => {
                WriteLiteral("Create New Admin");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 20 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Account\IndexAdmin.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <p style=\"font-size:14px\">");
#nullable restore
#line 24 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Account\IndexAdmin.cshtml"
                                         Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </td>\r\n                <td>\r\n                    <p style=\"font-size:14px\">");
#nullable restore
#line 27 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Account\IndexAdmin.cshtml"
                                         Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </td>\r\n                <td>\r\n                    <p style=\"font-size:14px\">");
#nullable restore
#line 30 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Account\IndexAdmin.cshtml"
                                         Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </td>\r\n                <td style=\"font-size:12px\">\r\n                    ");
#nullable restore
#line 33 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Account\IndexAdmin.cshtml"
               Write(Html.ActionLink("Edit", "EditAdmin", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("                    ");
#nullable restore
#line 35 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Account\IndexAdmin.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { name = item.UserName }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    \r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 39 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Account\IndexAdmin.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AdminViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
