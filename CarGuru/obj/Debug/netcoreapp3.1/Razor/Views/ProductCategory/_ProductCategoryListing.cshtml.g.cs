#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9253e3f354b1f134c14538d332ecdd0655293624"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductCategory__ProductCategoryListing), @"mvc.1.0.view", @"/Views/ProductCategory/_ProductCategoryListing.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9253e3f354b1f134c14538d332ecdd0655293624", @"/Views/ProductCategory/_ProductCategoryListing.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductCategory__ProductCategoryListing : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml"
 if (Model.Categories != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml"
     if (Model.Categories.Count > 0)
    {
        var count = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-striped"">
            <thead class=""bg-colorBlack"">
                <tr>
                    <th>Sr No</th>
                    <th>Name</th>
                    <th class=""actionColumn"">Action</th>
                </tr>
            </thead>
            <tbody>

");
#nullable restore
#line 16 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml"
                 foreach (var item in Model.Categories)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 19 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml"
                       Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 20 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml"
                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                        <th>
                            <div class=""row"">
                                <div class=""col-sm-2"">
                                    <div class=""dropdown"">
                                        <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                        </button>
                                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                            <a class=""dropdown-item"" href=""javascript:void()""");
            BeginWriteAttribute("onclick", " onclick=\"", 1225, "\"", 1254, 3);
            WriteAttributeValue("", 1235, "EditModal(", 1235, 10, true);
#nullable restore
#line 28 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml"
WriteAttributeValue("", 1245, item.Id, 1245, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1253, ")", 1253, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=\"#modal-warning\"><i class=\"fa fa-edit\" aria-hidden=\"true\" style=\"margin-right:8px;\"></i>Edit</a>\r\n                                            <a class=\"dropdown-item followUp\" href=\"javascript:void()\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1488, "\"", 1522, 3);
            WriteAttributeValue("", 1498, "DeleteCategory(", 1498, 15, true);
#nullable restore
#line 29 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml"
WriteAttributeValue("", 1513, item.Id, 1513, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1521, ")", 1521, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-trash"" aria-hidden=""true"" style=""margin-right:8px;""></i>Delete</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </th>
                    </tr>
");
#nullable restore
#line 36 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml"
                    count++;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 41 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3>No Record Found</h3>\r\n");
#nullable restore
#line 45 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\ProductCategory\_ProductCategoryListing.cshtml"
     
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
