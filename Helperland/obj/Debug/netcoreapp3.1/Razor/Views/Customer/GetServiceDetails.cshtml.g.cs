#pragma checksum "C:\xampp\htdocs\tatvasoft\Helperland\Views\Customer\GetServiceDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc6c55cb80206861f77156ae574dc3826e09bfbd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_GetServiceDetails), @"mvc.1.0.view", @"/Views/Customer/GetServiceDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc6c55cb80206861f77156ae574dc3826e09bfbd", @"/Views/Customer/GetServiceDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5f94cf04a7ec23f27ac33992ef127038e0b3154", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_GetServiceDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\xampp\htdocs\tatvasoft\Helperland\Views\Customer\GetServiceDetails.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""modal fade"" id=""ServiceDetails"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header border-0"">
                Service details
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <hr />
            </div>
            <div class=""modal-body my-2 border-0"">
                <p><b>Service Id: <span id=""ServiceId""></span></b></p>

                <p>
                    <b>Extra:</b>
");
#nullable restore
#line 22 "C:\xampp\htdocs\tatvasoft\Helperland\Views\Customer\GetServiceDetails.cshtml"
                     foreach (ServiceRequestExtra requestExtra in Model.ServiceRequests)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>");
#nullable restore
#line 24 "C:\xampp\htdocs\tatvasoft\Helperland\Views\Customer\GetServiceDetails.cshtml"
                         Write(requestExtra.ServiceRequestExtraId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ,</span>\r\n");
#nullable restore
#line 25 "C:\xampp\htdocs\tatvasoft\Helperland\Views\Customer\GetServiceDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </p>
            <p><b>Net Amount: <span id=""TotalCost""></span></b></p>
                <hr />
                <p><b>Service Address: </b></p>
                <p><b>Billing Address: </b></p>
                <p><b>Phone: </b></p>
                <p><b>Email: </b></p>
                <hr />
                <p><b>Comments: </b></p>
                <hr />
            </div>
            <div class=""modal-footer border-0"">
                <button class=""btn rounded-pill px-3 round_btn"">Reshedule</button>  <button class=""cancel_btn"">Cancel</button>
            </div>
        </div>
    </div>
</div>");
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
