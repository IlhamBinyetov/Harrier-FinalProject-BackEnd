#pragma checksum "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c12da48bf76c190350b70b1750c36c10c0954fc7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Basket_Index), @"mvc.1.0.view", @"/Views/Basket/Index.cshtml")]
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
#line 1 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\_ViewImports.cshtml"
using HarrierFinalProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\_ViewImports.cshtml"
using HarrierFinalProject.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\_ViewImports.cshtml"
using HarrierFinalProject.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\_ViewImports.cshtml"
using HarrierFinalProject.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c12da48bf76c190350b70b1750c36c10c0954fc7", @"/Views/Basket/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef2c9e2f68a24466b088013401f05de414627c1b", @"/Views/_ViewImports.cshtml")]
    public class Views_Basket_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BasketViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<main>\r\n\r\n\r\n    <section class=\"cart-section\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c12da48bf76c190350b70b1750c36c10c0954fc75508", async() => {
                WriteLiteral(@"
            <table>
                <thead>
                    <tr>
                        <th></th>
                        <th>Product</th>
                        <th>Price</th>
                        <th>Subtotal</th>
                        <th></th>
                    </tr>
                </thead>
");
#nullable restore
#line 21 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
                 foreach (var item in Model.Cars)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tbody>\r\n                        <tr>\r\n                            <td>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c12da48bf76c190350b70b1750c36c10c0954fc76484", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 646, "~/assets/images/", 646, 16, true);
#nullable restore
#line 25 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
AddHtmlAttributeValue("", 662, item.CarImages.FirstOrDefault(c=>c.IsPoster==true).Image, 662, 57, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 26 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
                           Write(item.Brand.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 26 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
                                              Write(item.Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>£ ");
#nullable restore
#line 27 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
                             Write(item.Price.ToString("0.##"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>£ ");
#nullable restore
#line 28 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
                             Write(item.Price.ToString("0.##"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>\r\n                                <button><i class=\"far fa-trash-alt\"></i></button>\r\n                            </td>\r\n                        </tr>\r\n                    </tbody>\r\n");
#nullable restore
#line 34 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </table>

            <div class=""cart-totals"">
                <h2>Cart Totals</h2>
                <table>
                    <tbody>
                        <tr>
                            <th>Subtotal</th>
                            <td>£505.00</td>
                        </tr>
                        <tr>
                            <th>Total</th>
                            <td>£505.00</td>
                        </tr>
                    </tbody>
                </table>

                <div class=""checkout"">
                    <a");
                BeginWriteAttribute("href", " href=\"", 1763, "\"", 1770, 0);
                EndWriteAttribute();
                WriteLiteral("><i class=\"fas fa-check\"></i>Proceed To Checkout</a>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </section>\r\n\r\n    <section class=\"features-section\">\r\n        <div class=\"features d-flex\">\r\n");
#nullable restore
#line 62 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
             foreach (var item in Model.Advertisings)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"feature-element col-3 d-flex justify-content-evenly\">\r\n                    <div class=\"feature-icon\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c12da48bf76c190350b70b1750c36c10c0954fc712687", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2218, "~/assets/images/", 2218, 16, true);
#nullable restore
#line 66 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
AddHtmlAttributeValue("", 2234, item.Logo, 2234, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        <p class=\"feature-first-p\">");
#nullable restore
#line 69 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
                                              Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"feature-second-p\">");
#nullable restore
#line 70 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
                                               Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 73 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Views\Basket\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            
        </div>
    </section>

   

    <section class=""scroll-section"">
        <button type=""button""
                class=""btn btn-danger btn-floating btn-lg""
                id=""btn-back-to-top"">
            <i class=""fas fa-arrow-up""></i>
        </button>
    </section>
</main>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BasketViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
