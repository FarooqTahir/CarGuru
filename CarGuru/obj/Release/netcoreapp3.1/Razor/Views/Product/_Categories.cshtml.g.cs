#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13905606d2ecbd1e7f8d6db5792edd1168b98d5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product__Categories), @"mvc.1.0.view", @"/Views/Product/_Categories.cshtml")]
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
#line 1 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\_ViewImports.cshtml"
using CarGuru;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\_ViewImports.cshtml"
using CarGuru.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13905606d2ecbd1e7f8d6db5792edd1168b98d5b", @"/Views/Product/_Categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Product__Categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarGuru.ViewModels.ProductViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<ul class=\"list-group \" style=\"list-style:none;\">\r\n    <li onclick=\"GetProductListByCategory(\'0\')\" class=\"list-group-item productCategoryList\">\r\n        <a href=\"#\" class=\"productCategoryList\">All</a>\r\n    </li>\r\n");
#nullable restore
#line 7 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_Categories.cshtml"
     foreach (var item in Model.Categories)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li");
            BeginWriteAttribute("onclick", " onclick=\"", 322, "\"", 366, 3);
            WriteAttributeValue("", 332, "GetProductListByCategory(", 332, 25, true);
#nullable restore
#line 9 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_Categories.cshtml"
WriteAttributeValue("", 357, item.Id, 357, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 365, ")", 365, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item productCategoryList\">\r\n            <a href=\"#\" class=\"productCategoryList\">");
#nullable restore
#line 10 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_Categories.cshtml"
                                               Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n        </li>\r\n");
#nullable restore
#line 12 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_Categories.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</ul>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarGuru.ViewModels.ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
