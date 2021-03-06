#pragma checksum "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\MySetting.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aeccbd8cc790c83fef04a2bc5f3fbf4325bbf61f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_MySetting), @"mvc.1.0.view", @"/Views/ServiceProvider/MySetting.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aeccbd8cc790c83fef04a2bc5f3fbf4325bbf61f", @"/Views/ServiceProvider/MySetting.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5f94cf04a7ec23f27ac33992ef127038e0b3154", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_MySetting : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\MySetting.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<table class=""tabs"">
    <tr>
        <td>
            <div id=""Tab1"" class=""tab active-tab"" onclick=""Tab1Clicked()"">My Details</div>
        </td>
        <td>
            <div id=""Tab2"" class=""tab"" onclick=""Tab2Clicked()"">Change Password</div>
        </td>
    </tr>
</table>

<div id=""tabContent"">
    <br /><br />
    <div id=""TabContent1"">

    </div>
    <div id=""TabContent2"" style=""display:none;"">
    </div>

</div>

<script>
    var selctedAvtar;
    $(document).ready(function () {
        $(""#TabContent1"").show().load('");
#nullable restore
#line 28 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\MySetting.cshtml"
                                  Write(Url.Action("MyDetails", "ServiceProvider"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    });\r\n    function Tab1Clicked() {\r\n        $(\"#Tab1\").addClass(\"active-tab\");\r\n        $(\"#Tab2\").removeClass(\"active-tab\").addClass(\"tab\");\r\n\r\n        $(\"#TabContent2\").hide();\r\n        $(\"#TabContent1\").show().load(\'");
#nullable restore
#line 35 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\MySetting.cshtml"
                                  Write(Url.Action("MyDetails", "ServiceProvider"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    }\r\n    function Tab2Clicked() {\r\n        $(\"#Tab2\").addClass(\"active-tab\");\r\n        $(\"#Tab1\").removeClass(\"active-tab\").addClass(\"tab\");\r\n\r\n        $(\"#TabContent1\").hide();\r\n        $(\"#TabContent2\").show().load(\'");
#nullable restore
#line 42 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\MySetting.cshtml"
                                  Write(Url.Action("ChangePassword", "Customer"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
    }
    function AvtarClicked(val) {
        const ex = document.getElementsByClassName(""avtar_image"");
        for (let i = 0; i < ex.length; i++) {
            ex[i].style.border = ""1px solid #B0C9CE"";
        }
        document.getElementById(val.id).style.border = ""3px solid #1D7A8C"";
        var img_id = ""#Avtar"" + val.id;
        var partsArr = $(img_id).attr(""src"").split('/');
        var imgName = partsArr[partsArr.length - 1];
        selctedAvtar = imgName;
    }
    function SubmitDetailForm() {
        $(""#DetailForm"").submit(function (e) {
            e.preventDefault();
            var formvalues = $(this).serializeArray();
            formvalues.push({ name: ""UserProfilePicture"", value: selctedAvtar });
            $.post(""/ServiceProvider/MyDetails"", formvalues , function (data) {
                if (data == true) {
                    alert(""Details Updated Successfully."");
                    Tab2Clicked();
                }
                else {
              ");
            WriteLiteral(@"      $(""#ErrorFromDetails"").empty();
                    for (var i = 0; i < Object.keys(data).length; i++) {
                        $(""#ErrorFromDetails"").append(""<li>"" + data[i] + ""</li>"");
                    }
                }
            });
        } );
    }

    function PasswordChangeClick() {

        $(""#ChangePassForm"").submit(function (e) {
            e.preventDefault();
            var actionurl = '");
#nullable restore
#line 79 "C:\xampp\htdocs\tatvasoft\Helperland\Views\ServiceProvider\MySetting.cshtml"
                        Write(Url.Action("ChangePassword", "Customer"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';

            var formData = new FormData();
            formData.append(""OldPassword"", $(""#OldPassword"").val());
            formData.append(""Password"", $(""#Pass"").val());
            formData.append(""Confirmpwd"", $(""#Cpass"").val());

            $.ajax({
                type: 'post',
                url: actionurl,
                data: formData,
                processData: false,
                contentType: false
            }).done(function (response) {
                if (response == true) {
                    alert(""successfully password Changed."");
                    Tab1Clicked();
                }
                else if (response == false) {
                    $(""#ErrorMsg"").html(""OldPassword Doesn't Match.Please Enter Again"");
                }
                else {
                    $(""#ErrorMsg"").empty();
                    for (var i = 0; i < Object.keys(response).length; i++) {
                        $(""#ErrorMsg"").append(""<li>"" + response[i] + ""</li>"");
   ");
            WriteLiteral("                 }\r\n\r\n                }\r\n            });\r\n        });\r\n    }\r\n\r\n</script>");
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
