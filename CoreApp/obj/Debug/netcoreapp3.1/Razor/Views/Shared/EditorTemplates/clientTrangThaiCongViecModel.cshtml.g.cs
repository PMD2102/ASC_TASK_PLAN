#pragma checksum "D:\ASC_Task_Planning_V9\ASC_Task_Planning\ASC_TASK_PLAN\CoreApp\Views\Shared\EditorTemplates\clientTrangThaiCongViecModel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c15f307a726472b7cfc02bc60b50679028c019b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_clientTrangThaiCongViecModel), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/clientTrangThaiCongViecModel.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c15f307a726472b7cfc02bc60b50679028c019b", @"/Views/Shared/EditorTemplates/clientTrangThaiCongViecModel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37e33255dd0f58295d578403c46696e37e808753", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_clientTrangThaiCongViecModel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoreApp.Models.TrangThaiCongViecModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\ASC_Task_Planning_V9\ASC_Task_Planning\ASC_TASK_PLAN\CoreApp\Views\Shared\EditorTemplates\clientTrangThaiCongViecModel.cshtml"
Write(Html.Kendo().DropDownListFor(m => m)
            .DataValueField("giaTriTrangThai")
            .DataTextField("tenTrangThai")
            .DataSource(d => d.Read(r => r.Action("GetAllTrangThai", "QuanLyCongViec"))
            )
);

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoreApp.Models.TrangThaiCongViecModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
