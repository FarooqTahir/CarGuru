#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Management\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efc94b1b2d63f42cce54add23f6c1a73475ab684"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Management_History), @"mvc.1.0.view", @"/Views/Management/History.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efc94b1b2d63f42cce54add23f6c1a73475ab684", @"/Views/Management/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Management_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Management\History.cshtml"
  
    ViewData["Title"] = "History";
    Layout = CommonData.GetUserLayoutByRoleId(x.GetUserRoleId()); //"~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-md-2\">\r\n                <h1>History</h1>\r\n            </div>\r\n            <div class=\"col-md-10\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efc94b1b2d63f42cce54add23f6c1a73475ab6844487", async() => {
                WriteLiteral(@"
                    <div class=""input-group bg-white"">
                        <input class=""form-control"" type=""search"" placeholder=""Search"" aria-label=""Search"">
                        <div class=""input-group-append"">
                            <button class=""btn btn-navbar "" type=""submit"">
                                <i class=""fas fa-search ""></i>
                            </button>
                        </div>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card"">
                    <div class=""card-body leads table-responsive p-0"">
                        <table class=""table table-striped"">
                            <thead class=""bg-colorBlack"">
                                <tr>
                                    <th>Customer Name</th>
                                    <th>Email</th>
                                    <th>Product</th>
                                    <th>Type</th>
                                    <th>Date Receive</th>
                                    <th class=""actionColumn"">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>

                                    <td>");
            WriteLiteral(@"John</td>
                                    <td>John@gmail.com</td>
                                    <td>Tyre</td>
                                    <td>Service</td>
                                    <td>28 feb 2020</td>
                                    <th>
                                        <div class=""row"">
                                            <div class=""col-md-3 viewModal"">
                                                <button class=""btn"" type=""button"" data-toggle=""modal"" data-target=""#modal-viewForm"">
                                                    View
                                                </button>
                                            </div>
                                            <div class=""col-md-2"">
                                                <div class=""dropdown"">
                                                    <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""tru");
            WriteLiteral(@"e"" aria-expanded=""false"">
                                                    </button>
                                                    <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                                        <a class=""dropdown-item"" href=""javascript:void()"" data-toggle=""modal"" data-target=""#modal-editForm""><i class=""fas fa-edit"" aria-hidden=""true"" style=""margin-right:8px;""></i>Edit</a>
                                                        <a class=""dropdown-item"" href=""javascript:void()""><i class=""fas fa-print"" aria-hidden=""true"" style=""margin-right:8px;""></i>Print</a>
                                                        <a class=""dropdown-item"" href=""javascript:void()""><i class=""fa fa-file"" aria-hidden=""true"" style=""margin-right:8px;""></i>Download</a>
                                                    </div>
                                                </div>
                                            </div>
                             ");
            WriteLiteral(@"           </div>
                                    </th>

                                </tr>
                                <tr>

                                    <td>John</td>
                                    <td>John@gmail.com</td>
                                    <td>Dashboard Cover</td>
                                    <td>Product</td>
                                    <td>28 feb 2020</td>
                                    <th>
                                        <div class=""row"">
                                            <div class=""col-md-3 viewModal"">
                                                <button class=""btn"" type=""button"" data-toggle=""modal"" data-target=""#modal-viewForm"">
                                                    View
                                                </button>
                                            </div>
                                            <div class=""col-md-2"">
                                             ");
            WriteLiteral(@"   <div class=""dropdown"">
                                                    <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                    </button>
                                                    <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                                        <a class=""dropdown-item"" href=""javascript:void()"" data-toggle=""modal"" data-target=""#modal-editForm""><i class=""fas fa-edit"" aria-hidden=""true"" style=""margin-right:8px;""></i>Edit</a>
                                                        <a class=""dropdown-item"" href=""javascript:void()""><i class=""fas fa-print"" aria-hidden=""true"" style=""margin-right:8px;""></i>Print</a>
                                                        <a class=""dropdown-item"" href=""javascript:void()""><i class=""fa fa-file"" aria-hidden=""true"" style=""margin-right:8px;""></i>Download</a>
   ");
            WriteLiteral(@"                                                 </div>
                                                </div>
                                            </div>
                                        </div>
                                    </th>

                                </tr>
                                <tr>

                                    <td>John</td>
                                    <td>John@gmail.com</td>
                                    <td>Air fitter</td>
                                    <td>Service</td>
                                    <td>28 feb 2020</td>
                                    <th>
                                        <div class=""row"">
                                            <div class=""col-md-3 viewModal"">
                                                <button class=""btn"" type=""button"" data-toggle=""modal"" data-target=""#modal-viewForm"">
                                                    View
                                   ");
            WriteLiteral(@"             </button>
                                            </div>
                                            <div class=""col-md-2"">
                                                <div class=""dropdown"">
                                                    <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                    </button>
                                                    <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                                        <a class=""dropdown-item"" href=""javascript:void()"" data-toggle=""modal"" data-target=""#modal-editForm""><i class=""fas fa-edit"" aria-hidden=""true"" style=""margin-right:8px;""></i>Edit</a>
                                                        <a class=""dropdown-item"" href=""javascript:void()""><i class=""fas fa-print"" aria-hidden=""true"" style=""margin-right:8px;""></i>Print</a>
     ");
            WriteLiteral(@"                                                   <a class=""dropdown-item"" href=""javascript:void()""><i class=""fa fa-file"" aria-hidden=""true"" style=""margin-right:8px;""></i>Download</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </th>

                                </tr>
                                <tr>

                                    <td>John</td>
                                    <td>John@gmail.com</td>
                                    <td>Denso Wiper Blade</td>
                                    <td>Product</td>
                                    <td>28 feb 2020</td>
                                    <th>
                                        <div class=""row"">
                                            <div class=""col-md-3 viewModal"">
                               ");
            WriteLiteral(@"                 <button class=""btn"" type=""button"" data-toggle=""modal"" data-target=""#modal-viewForm"">
                                                    View
                                                </button>
                                            </div>
                                            <div class=""col-md-2"">
                                                <div class=""dropdown"">
                                                    <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                    </button>
                                                    <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                                        <a class=""dropdown-item"" href=""javascript:void()"" data-toggle=""modal"" data-target=""#modal-editForm""><i class=""fas fa-edit"" aria-hidden=""true"" style=""margin-right:8px;""></i>Edit</a>");
            WriteLiteral(@"
                                                        <a class=""dropdown-item"" href=""javascript:void()""><i class=""fas fa-print"" aria-hidden=""true"" style=""margin-right:8px;""></i>Print</a>
                                                        <a class=""dropdown-item"" href=""javascript:void()""><i class=""fa fa-file"" aria-hidden=""true"" style=""margin-right:8px;""></i>Download</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </th>

                                </tr>


                            </tbody>
                        </table>

                        <div class=""card-footer clearfix"">
                            <ul class=""pagination pagination-sm m-0 float-right"">
                                <li class=""page-item""><a class=""page-link"" href=""#"">«</a></li>
                         ");
            WriteLiteral(@"       <li class=""page-item""><a class=""page-link"" href=""#"">1</a></li>
                                <li class=""page-item""><a class=""page-link"" href=""#"">2</a></li>
                                <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
                                <li class=""page-item""><a class=""page-link"" href=""#"">»</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>


<div class=""modal fade"" id=""modal-editForm"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header bg-colorBlack"">
                <h4 class=""modal-title"">Edit Product</h4>
                <button type=""button"" class=""close text-white"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-bo");
            WriteLiteral("dy\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efc94b1b2d63f42cce54add23f6c1a73475ab68418272", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label for=""exampleInputEmail1"">Customer Name</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 12577, "\"", 12582, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""John	"">
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label>Customer Email</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 12904, "\"", 12909, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""John@gmail.com"">
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label>Product</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 13233, "\"", 13238, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""Tyre"">
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label for=""exampleInputEmail1"">Product Type</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 13649, "\"", 13654, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""Service"">
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label for=""exampleInputEmail1"">Date Receive</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 14001, "\"", 14006, 0);
                EndWriteAttribute();
                WriteLiteral(" value=\"28 feb 2020\">\r\n                            </div>\r\n                        </div>\r\n\r\n                    </div>\r\n                    <input type=\"email\" class=\"form-control\"");
                BeginWriteAttribute("id", " id=\"", 14188, "\"", 14193, 0);
                EndWriteAttribute();
                WriteLiteral(" value=\"new\" style=\"visibility:hidden;\">\r\n\r\n\r\n                    <!-- /.card-body -->\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""modal-footer justify-content-between"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button type=""button"" class=""btn btn-secondary"">Save</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class=""modal fade"" id=""modal-viewForm"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header bg-colorBlack"">
                <h4 class=""modal-title"">View Product</h4>
                <button type=""button"" class=""close text-white"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efc94b1b2d63f42cce54add23f6c1a73475ab68423482", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label for=""exampleInputEmail1"">Customer Name</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 15513, "\"", 15518, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""John"" disabled>
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label>Customer Email</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 15848, "\"", 15853, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""John@gmail.com"" disabled>
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label>Product</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 16186, "\"", 16191, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""Tyre"" disabled>
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label for=""exampleInputEmail1"">Product Type</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 16611, "\"", 16616, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""Service"" disabled>
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label for=""exampleInputEmail1"">Date Receive</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 16972, "\"", 16977, 0);
                EndWriteAttribute();
                WriteLiteral(" value=\"28 feb 2020\" disabled>\r\n                            </div>\r\n                        </div>\r\n\r\n                    </div>\r\n                    <input type=\"email\" class=\"form-control\"");
                BeginWriteAttribute("id", " id=\"", 17168, "\"", 17173, 0);
                EndWriteAttribute();
                WriteLiteral(" value=\"new\" style=\"visibility:hidden;\">\r\n\r\n\r\n                    <!-- /.card-body -->\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>

            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>

");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CarGuru.Services.Interfaces.ISessionManager x { get; private set; }
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
