#pragma checksum "D:\ASC_Task_Planning_V9\ASC_Task_Planning\ASC_TASK_PLAN\CoreApp\Views\Shared\EditorTemplates\GridForeignKey.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6cd1fb741d9e44e288b5893d69bfd963ae4e6f98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_GridForeignKey), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/GridForeignKey.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cd1fb741d9e44e288b5893d69bfd963ae4e6f98", @"/Views/Shared/EditorTemplates/GridForeignKey.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37e33255dd0f58295d578403c46696e37e808753", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_GridForeignKey : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<object>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("           \n");
#nullable restore
#line 3 "D:\ASC_Task_Planning_V9\ASC_Task_Planning\ASC_TASK_PLAN\CoreApp\Views\Shared\EditorTemplates\GridForeignKey.cshtml"
Write(
 Html.Kendo().DropDownListFor(m => m)        
        .BindTo((SelectList)ViewData[ViewData.TemplateInfo.GetFullHtmlFieldName("") + "_Data"])
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<object> Html { get; private set; }
    }
}
#pragma warning restore 1591
