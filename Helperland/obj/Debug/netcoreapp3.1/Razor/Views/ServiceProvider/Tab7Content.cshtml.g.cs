#pragma checksum "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab7Content.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0fd13488c1cfc49abeee55c33cf0f87c7f4482cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_Tab7Content), @"mvc.1.0.view", @"/Views/ServiceProvider/Tab7Content.cshtml")]
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
#line 1 "C:\xampp\htdocs\tatvasoft\Helperland\Views\_ViewImports.cshtml"
using Helperland;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\xampp\htdocs\tatvasoft\Helperland\Views\_ViewImports.cshtml"
using Helperland.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fd13488c1cfc49abeee55c33cf0f87c7f4482cb", @"/Views/ServiceProvider/Tab7Content.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5f94cf04a7ec23f27ac33992ef127038e0b3154", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_Tab7Content : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Helperland.Models.ViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/plugins/fontawesome/css/all.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/cap.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("center_img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab7Content.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0fd13488c1cfc49abeee55c33cf0f87c7f4482cb4740", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab7Content.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-4 float-left p-2\">\r\n        <div class=\"card text-center pt-3\">\r\n            <div class=\"avtar_image m-auto\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0fd13488c1cfc49abeee55c33cf0f87c7f4482cb6238", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 14 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab7Content.cshtml"
                                  Write(item.user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 14 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab7Content.cshtml"
                                                       Write(item.user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <button");
            BeginWriteAttribute("id", " id=\"", 557, "\"", 579, 1);
#nullable restore
#line 15 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab7Content.cshtml"
WriteAttributeValue("", 562, item.user.UserId, 562, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"cancel_btn\"");
            BeginWriteAttribute("onclick", " onclick=\"", 599, "\"", 642, 3);
            WriteAttributeValue("", 609, "BlockbtnClick(", 609, 14, true);
#nullable restore
#line 15 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab7Content.cshtml"
WriteAttributeValue("", 623, item.user.UserId, 623, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 640, ");", 640, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Block</button>\r\n                <script>\r\n                    $.post(\"/ServiceProvider/CheckBlock\", { Id: parseInt(");
#nullable restore
#line 17 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab7Content.cshtml"
                                                                    Write(item.user.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral(") }, function (data) {\r\n                        if (data == true) {\r\n                            var x = \"#\" + ");
#nullable restore
#line 19 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab7Content.cshtml"
                                     Write(item.user.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                            $(x).html(\"UnBlock\");\r\n                        }\r\n                        else {\r\n                            var x = \"#\" + ");
#nullable restore
#line 23 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab7Content.cshtml"
                                     Write(item.user.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                            $(x).html(\"Block\");\r\n                        }\r\n                    });\r\n                </script>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 31 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab7Content.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Helperland.Models.ViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
