#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_ProductList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f693fe78c0d46acd90308adc5d557c63af7911fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product__ProductList), @"mvc.1.0.view", @"/Views/Product/_ProductList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f693fe78c0d46acd90308adc5d557c63af7911fb", @"/Views/Product/_ProductList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Product__ProductList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarGuru.ViewModels.ProductViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_ProductList.cshtml"
 if (Model != null && Model.Products.Count > 0)
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_ProductList.cshtml"
     foreach (var item in Model.Products)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-3 col-sm-6\">\r\n            <div class=\"product-grid\">\r\n                <div class=\"product-image\">\r\n                    <a href=\"#\">\r\n                        <img class=\"pic-1\"");
            BeginWriteAttribute("src", " src=\"", 350, "\"", 370, 1);
#nullable restore
#line 11 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_ProductList.cshtml"
WriteAttributeValue("", 356, item.ImageUrl, 356, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <img class=\"pic-2\"");
            BeginWriteAttribute("src", " src=\"", 416, "\"", 436, 1);
#nullable restore
#line 12 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_ProductList.cshtml"
WriteAttributeValue("", 422, item.ImageUrl, 422, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </a>\r\n                    <ul class=\"social\">\r\n                        <li");
            BeginWriteAttribute("onclick", " onclick=\"", 534, "\"", 571, 3);
            WriteAttributeValue("", 544, "showProductDetail(", 544, 18, true);
#nullable restore
#line 15 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_ProductList.cshtml"
WriteAttributeValue("", 562, item.Id, 562, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 570, ")", 570, 1, true);
            EndWriteAttribute();
            WriteLiteral("><a href=\"#modalProduct\" data-tip=\"View\" data-toggle=\"modal\"><i class=\"fa fa-eye\"></i></a></li>\r\n                    </ul>\r\n\r\n                </div>\r\n\r\n                <div class=\"product-content\">\r\n                    <h3 class=\"title\"><a href=\"#\">");
#nullable restore
#line 21 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_ProductList.cshtml"
                                             Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                    <div class=\"price\">\r\n                        $");
#nullable restore
#line 23 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_ProductList.cshtml"
                    Write(Convert.ToInt32(@item.SalePrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <span>$");
#nullable restore
#line 24 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_ProductList.cshtml"
                          Write(Convert.ToInt32(@item.RegularPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 29 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_ProductList.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Product\_ProductList.cshtml"
     

}

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarGuru.ViewModels.ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
