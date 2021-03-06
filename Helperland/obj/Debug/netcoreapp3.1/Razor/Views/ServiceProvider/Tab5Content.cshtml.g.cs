#pragma checksum "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec1629d11ee544b72ac0885758d31d49a9e639da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_Tab5Content), @"mvc.1.0.view", @"/Views/ServiceProvider/Tab5Content.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec1629d11ee544b72ac0885758d31d49a9e639da", @"/Views/ServiceProvider/Tab5Content.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5f94cf04a7ec23f27ac33992ef127038e0b3154", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_Tab5Content : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Helperland.Models.ViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn rounded-pill px-3 round_btn mb-2 float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DownloadExcel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/calendar2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/layer-14.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/layer-15.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script type=""text/javascript"">
    $(document).ready(function () {
        $('#ServiceHistoryTable').DataTable({
            pageLength: 0,
            lengthMenu: [6, 10, 20, 50],

            searching: false,
            info: true,
            dom: '<""float-left""B><""float-right""f>rt<""row mt-2""<""col-sm-4""l><""col-sm-4""i><""col-sm-4""p>>',

            ""sPaginationType"": ""full_numbers"",
            language: {
                paginate: {
                    first: '<img src=""assets/img/first-page.png"">',
                    next: '<i class=""fas fa-angle-right""></i>',
                    previous: '<i class=""fas fa-angle-left""></i>',
                    last: '<img src=""assets/img/first-page.png"" style=""transform:rotate(180deg);"">',
                }
            }
        });

    });


</script>

<p class=""float-left"">Payment Status</p>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec1629d11ee544b72ac0885758d31d49a9e639da6157", async() => {
                WriteLiteral("Export");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<table id=""ServiceHistoryTable"" class=""table"">
    <thead class=""table_head"">
        <tr>
            <th>Service Id </th>
            <th>Service Date </th>
            <th>Customer Details</th>
        </tr>
    </thead>
    <tbody class=""table_body"">
");
#nullable restore
#line 42 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td");
            BeginWriteAttribute("onclick", " onclick=\"", 1401, "\"", 1462, 3);
            WriteAttributeValue("", 1411, "Hrowclicked(", 1411, 12, true);
#nullable restore
#line 45 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
WriteAttributeValue("", 1423, item.serviceRequest.ServiceRequestId, 1423, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1460, ");", 1460, 2, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 45 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
                                                                             Write(item.serviceRequest.ServiceRequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td");
            BeginWriteAttribute("onclick", " onclick=\"", 1527, "\"", 1588, 3);
            WriteAttributeValue("", 1537, "Hrowclicked(", 1537, 12, true);
#nullable restore
#line 46 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
WriteAttributeValue("", 1549, item.serviceRequest.ServiceRequestId, 1549, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1586, ");", 1586, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ec1629d11ee544b72ac0885758d31d49a9e639da9377", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 47 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
                                                      Write(item.serviceRequest.ServiceStartDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <br />");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ec1629d11ee544b72ac0885758d31d49a9e639da10745", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 48 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
                                                           Write(item.serviceRequest.ServiceStartDate.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 48 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
                                                                                                                       Write(item.serviceRequest.ServiceStartDate.AddHours(Convert.ToDouble(item.serviceRequest.SubTotal)).ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td");
            BeginWriteAttribute("onclick", " onclick=\"", 1992, "\"", 2053, 3);
            WriteAttributeValue("", 2002, "Hrowclicked(", 2002, 12, true);
#nullable restore
#line 50 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
WriteAttributeValue("", 2014, item.serviceRequest.ServiceRequestId, 2014, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2051, ");", 2051, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    &emsp;&ensp;");
#nullable restore
#line 51 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
                           Write(item.user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 51 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
                                                Write(item.user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ec1629d11ee544b72ac0885758d31d49a9e639da13686", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
#nullable restore
#line 52 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
                                                      Write(item.requestAddress.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 52 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
                                                                                        Write(item.requestAddress.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                    &emsp;&ensp;");
#nullable restore
#line 53 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
                           Write(item.requestAddress.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 53 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"
                                                           Write(item.requestAddress.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 56 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\Tab5Content.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<div class=""modal fade"" id=""HServiceDetails"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header border-0"">
                Service details
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <hr />
            </div>
            <div class=""modal-body py-0 border-0"">
                <div id=""HServiceData"" class=""font-weight-bold""></div>
                <hr />
                <p>Service Id: <span id=""HServiceId""></span></p>

                <p>Extra: <span id=""HExtra""></span></p>
                <p>Net Amount: <span id=""HTotalCost""></span></p>
                <hr />
                <p>Customer Name: <span id=""HCustomerName""></span></p>
            ");
            WriteLiteral(@"    <p>Service Address: <span id=""HServiceAddress""></span></p>
                <p>Distance: <span id=""HDistance""></span></p>
                <hr />
                <p>Comments: <span id=""HComments""></span></p>
                <hr />
            </div>
            <div class=""pl-2 pb-2"">
                <button class=""btn rounded-pill px-3 round_btn"" id=""Accept_btn""");
            BeginWriteAttribute("value", " value=\"", 3817, "\"", 3825, 0);
            EndWriteAttribute();
            WriteLiteral(" onclick=\"RescheduleService(this.value);\">Reshedule</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
