#pragma checksum "D:\ASC_Task_Planning_V9\ASC_Task_Planning\ASC_TASK_PLAN\CoreApp\Views\ACLNguoiDung\TrangChu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4bf280351dcb1f78b640f8de5440f239b38161d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ACLNguoiDung_TrangChu), @"mvc.1.0.view", @"/Views/ACLNguoiDung/TrangChu.cshtml")]
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
#line 1 "D:\ASC_Task_Planning_V9\ASC_Task_Planning\ASC_TASK_PLAN\CoreApp\Views\_ViewImports.cshtml"
using CoreApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASC_Task_Planning_V9\ASC_Task_Planning\ASC_TASK_PLAN\CoreApp\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bf280351dcb1f78b640f8de5440f239b38161d1", @"/Views/ACLNguoiDung/TrangChu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37e33255dd0f58295d578403c46696e37e808753", @"/Views/_ViewImports.cshtml")]
    public class Views_ACLNguoiDung_TrangChu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/asc_logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("40px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-left: 140px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n<div class=\"container\">\n    <div class=\"row\">\n        <div class=\"col-xs-12 col-sm-12 col-md-12 col-lg-12\">\n            <br />\n                    ");
#nullable restore
#line 6 "D:\ASC_Task_Planning_V9\ASC_Task_Planning\ASC_TASK_PLAN\CoreApp\Views\ACLNguoiDung\TrangChu.cshtml"
                Write(Html.Kendo().DropDownList()
                        .Name("dropdownlist")
                        .DataTextField("Text")
                        .DataValueField("Value")
                        .BindTo(new List<SelectListItem>() {
                            new SelectListItem() {
                                Text = "Hồ sơ người dùng",
                                Value = "1"
                            },
                            new SelectListItem() {
                                Text = "Đổi mật khẩu",
                                Value = "2"
                            },
                            new SelectListItem() {
                                Text = "Đăng xuất",
                                Value = "3"
                            }
                        })
                    .Value("1")
                    .HtmlAttributes(new {style="float :right; background-image: none;"})
                    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n                    <span style=\"float: right;\">");
#nullable restore
#line 28 "D:\ASC_Task_Planning_V9\ASC_Task_Planning\ASC_TASK_PLAN\CoreApp\Views\ACLNguoiDung\TrangChu.cshtml"
                                           Write(TempData["TenNhanSu"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\n                    <img  style=\"float: right;\"/> \n            <center> \n                <h3> \n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4bf280351dcb1f78b640f8de5440f239b38161d16374", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" <span style=\"margin-left: 40px;\"> ASC TASK PLANNING  </span>\n                    <br/>\n                    <br/>\n                    HỆ THỐNG QUẢN LÝ CÔNG VIỆC \n                    \n                </h3>\n                <br/>\n                <a");
            BeginWriteAttribute("href", " href=\"", 1624, "\"", 1631, 0);
            EndWriteAttribute();
            WriteLiteral("> Quản lí công việc  | </a> <a");
            BeginWriteAttribute("href", " href=\"", 1662, "\"", 1669, 0);
            EndWriteAttribute();
            WriteLiteral("> Tuần làm việc  | </a> <a");
            BeginWriteAttribute("href", " href=\"", 1696, "\"", 1703, 0);
            EndWriteAttribute();
            WriteLiteral("> Báo cáo hiệu suất công việc  | </a> <a");
            BeginWriteAttribute("href", " href=\"", 1744, "\"", 1751, 0);
            EndWriteAttribute();
            WriteLiteral(@"> Phân bổ công việc </a>
            </center>
            
        </div>

    </div>
</div>

<script> 
    $( document ).ready(function() {
    $(""span"").removeClass(""k-dropdown-wrap k-state-default"");
    const removeElements = (elms) => elms.forEach(el => el.remove());
    removeElements( document.querySelectorAll("".k-input"") );
    });

    
    

</script>");
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