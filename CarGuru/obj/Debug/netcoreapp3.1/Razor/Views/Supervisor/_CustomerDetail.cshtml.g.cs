#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_CustomerDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "615b8e7c3adb13026b1bcf35784082a60c26ceb9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Supervisor__CustomerDetail), @"mvc.1.0.view", @"/Views/Supervisor/_CustomerDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"615b8e7c3adb13026b1bcf35784082a60c26ceb9", @"/Views/Supervisor/_CustomerDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Supervisor__CustomerDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_CustomerDetail.cshtml"
  
    ViewData["Title"] = "_CustomerDetail";
    Layout = "~/Views/Shared/_LayoutSupervisor.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-8 col-md-10"">
                <h1>Customer Information</h1>
            </div>
            <div class=""col-sm-4 col-md-2"">
                <a");
            BeginWriteAttribute("href", " href=\"", 389, "\"", 433, 1);
#nullable restore
#line 14 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_CustomerDetail.cshtml"
WriteAttributeValue("", 396, Url.Action("Customer", "Supervisor"), 396, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn float-right pt-0 pr-0"" style=""font-size: 20px;"">
                    <i class=""fas fa-arrow-left""></i>

                </a>

            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-sm-12"">
                <div class=""card "">

                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-5 col-sm-2"">
                                <div class=""nav flex-column nav-tabs h-100"" id=""vert-tabs-tab"" role=""tablist"" aria-orientation=""vertical"">
                                    <a class=""nav-link active"" id=""vert-tabs-home-tab"" data-toggle=""pill"" href=""#vert-tabs-home"" role=""tab"" aria-controls=""vert-tabs-home"" aria-selected=""true"">Customer</a>
                                    <a class=""nav-link"" id=""vert-tabs-messages-tab"" data-toggle=""pill"" href=""#vert-tabs-messages"" role=""");
            WriteLiteral(@"tab"" aria-controls=""vert-tabs-messages"" aria-selected=""false"">History</a>
                                </div>
                            </div>
                            <div class=""col-7 col-sm-10"">
                                <div class=""tab-content"" id=""vert-tabs-tabContent"">
                                    <div class=""tab-pane text-left fade active show"" id=""vert-tabs-home"" role=""tabpanel"" aria-labelledby=""vert-tabs-home-tab"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "615b8e7c3adb13026b1bcf35784082a60c26ceb96200", async() => {
                WriteLiteral(@"
                                            <h2>Customer</h2>
                                            <div class=""row"">

                                                <div class=""col-sm-6"">
                                                    <div class=""form-group"">
                                                        <label for=""exampleInputEmail1"">First Name</label>
                                                        <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 2454, "\"", 2459, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""Mohammed"" disabled>
                                                    </div>
                                                </div>
                                                <div class=""col-sm-6"">
                                                    <div class=""form-group"">
                                                        <label for=""exampleInputPassword1"">Last Name</label>
                                                        <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 2960, "\"", 2965, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""Manar"" disabled>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class=""row"">
                                                <div class=""col-sm-6"">
                                                    <div class=""form-group"">
                                                        <label for=""exampleInputEmail1"">Address</label>
                                                        <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 3573, "\"", 3578, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""UAE"" disabled>
                                                    </div>
                                                </div>
                                                <div class=""col-sm-6"">
                                                    <div class=""form-group"">
                                                        <label for=""exampleInputPassword1"">Contact No</label>
                                                        <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 4075, "\"", 4080, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""+0 122332 1211	"" disabled>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr />
                                            <h2>Vehicle</h2>
                                            <div class=""row"">

                                                <div class=""col-sm-6"">
                                                    <div class=""form-group"">
                                                        <label for=""exampleInputEmail1"">Licence Plate No.</label>
                                                        <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 4824, "\"", 4829, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""10234"" disabled>
                                                    </div>
                                                </div>
                                                <div class=""col-sm-6"">
                                                    <div class=""form-group"">
                                                        <label for=""exampleInputPassword1"">Make</label>
                                                        <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 5322, "\"", 5327, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""Honda"" disabled>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class=""row"">
                                                <div class=""col-sm-6"">
                                                    <div class=""form-group"">
                                                        <label for=""exampleInputEmail1"">Model</label>
                                                        <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 5933, "\"", 5938, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""Civic"" disabled>
                                                    </div>
                                                </div>
                                                <div class=""col-sm-6"">
                                                    <div class=""form-group"">
                                                        <label for=""exampleInputPassword1"">Year</label>
                                                        <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 6431, "\"", 6436, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""2018"" disabled>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class=""row"">
                                                <div class=""col-sm-6"">
                                                    <div class=""form-group"">
                                                        <label for=""exampleInputEmail1"">VIN No.</label>
                                                        <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 7043, "\"", 7048, 0);
                EndWriteAttribute();
                WriteLiteral(@" value=""SHHFK2760CU003289"" disabled>
                                                    </div>
                                                </div>
                                            </div>



                                            <!-- /.card-body -->
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
                                    <div class=""tab-pane fade"" id=""vert-tabs-messages"" role=""tabpanel"" aria-labelledby=""vert-tabs-messages-tab"">
                                        <div class=""card-body leads table-responsive p-0"">
                                            <table class=""table table-striped"">
                                                <thead class=""bg-colorBlack"">
                                                    <tr>
                                                        <th>Customer Name</th>
                                                        <th>Email</th>
                                                        <th>Service Type</th>
                                                        <th>Product</th>
                                                        <th>Date Receive</th>
                                                        <th class=""actionColumn"">Action</th>
                                            ");
            WriteLiteral(@"        </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>

                                                        <td>Mohammed Manar</td>
                                                        <td>m.manar@gmail.com</td>
                                                        <td>Oil Change</td>
                                                        <td>Honda</td>
                                                        <td>28 feb 2020</td>
                                                        <th>
                                                            <div class=""row"">
                                                                <div class=""col-sm-3 viewModal"">
                                                                    <button class=""btn"" type=""button"" data-toggle=""modal"" data-target=""#modal-viewForm"">
                                                 ");
            WriteLiteral(@"                       View
                                                                    </button>
                                                                </div>
                                                                <div class=""col-sm-2"">
                                                                    <div class=""dropdown"">
                                                                        <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                                        </button>
                                                                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                                                            <a class=""dropdown-item"" href=""javascript:void()"" data-toggle=""modal"" data-target=""#modal-editForm""><i class=""fas fa-edit"" aria-hidden=""true"" style=""marg");
            WriteLiteral(@"in-right:8px;""></i>Edit</a>
                                                                            <a class=""dropdown-item"" href=""javascript:void()""><i class=""fas fa-print"" aria-hidden=""true"" style=""margin-right:8px;""></i>Print</a>
                                                                            <a class=""dropdown-item"" href=""javascript:void()""><i class=""fa fa-file"" aria-hidden=""true"" style=""margin-right:8px;""></i>Download</a>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </th>

                                                    </tr>
                                                    <tr>

                                                        <td>Mohammed Manar</td>
             ");
            WriteLiteral(@"                                           <td>m.manar@gmail.com</td>
                                                        <td>Dashboard Cover</td>
                                                        <td>Engine</td>
                                                        <td>28 feb 2020</td>
                                                        <th>
                                                            <div class=""row"">
                                                                <div class=""col-sm-3 viewModal"">
                                                                    <button class=""btn"" type=""button"" data-toggle=""modal"" data-target=""#modal-viewForm"">
                                                                        View
                                                                    </button>
                                                                </div>
                                                                <div class=""col-sm-2"">
          ");
            WriteLiteral(@"                                                          <div class=""dropdown"">
                                                                        <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                                        </button>
                                                                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                                                            <a class=""dropdown-item"" href=""javascript:void()"" data-toggle=""modal"" data-target=""#modal-editForm""><i class=""fas fa-edit"" aria-hidden=""true"" style=""margin-right:8px;""></i>Edit</a>
                                                                            <a class=""dropdown-item"" href=""javascript:void()""><i class=""fas fa-print"" aria-hidden=""true"" style=""margin-right:8px;""></i>Print</a>
                                       ");
            WriteLiteral(@"                                     <a class=""dropdown-item"" href=""javascript:void()""><i class=""fa fa-file"" aria-hidden=""true"" style=""margin-right:8px;""></i>Download</a>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </th>

                                                    </tr>
                                                    <tr>

                                                        <td>Mohammed Manar</td>
                                                        <td>m.manar@gmail.com</td>
                                                        <td>Air fitter</td>
                                                        <td>Oil</td>
                                                        <td>");
            WriteLiteral(@"28 feb 2020</td>
                                                        <th>
                                                            <div class=""row"">
                                                                <div class=""col-sm-3 viewModal"">
                                                                    <button class=""btn"" type=""button"" data-toggle=""modal"" data-target=""#modal-viewForm"">
                                                                        View
                                                                    </button>
                                                                </div>
                                                                <div class=""col-sm-2"">
                                                                    <div class=""dropdown"">
                                                                        <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=");
            WriteLiteral(@"""false"">
                                                                        </button>
                                                                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                                                            <a class=""dropdown-item"" href=""javascript:void()"" data-toggle=""modal"" data-target=""#modal-editForm""><i class=""fas fa-edit"" aria-hidden=""true"" style=""margin-right:8px;""></i>Edit</a>
                                                                            <a class=""dropdown-item"" href=""javascript:void()""><i class=""fas fa-print"" aria-hidden=""true"" style=""margin-right:8px;""></i>Print</a>
                                                                            <a class=""dropdown-item"" href=""javascript:void()""><i class=""fa fa-file"" aria-hidden=""true"" style=""margin-right:8px;""></i>Download</a>
                                                                        </div>
                                  ");
            WriteLiteral(@"                                  </div>
                                                                </div>
                                                            </div>
                                                        </th>

                                                    </tr>
                                                    <tr>

                                                        <td>Mohammed Manar</td>
                                                        <td>m.manar@gmail.com</td>
                                                        <td>Denso Wiper Blade</td>
                                                        <td>Oil</td>
                                                        <td>28 feb 2020</td>
                                                        <th>
                                                            <div class=""row"">
                                                                <div class=""col-sm-3 viewModal"">
                      ");
            WriteLiteral(@"                                              <button class=""btn"" type=""button"" data-toggle=""modal"" data-target=""#modal-viewForm"">
                                                                        View
                                                                    </button>
                                                                </div>
                                                                <div class=""col-sm-2"">
                                                                    <div class=""dropdown"">
                                                                        <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                                        </button>
                                                                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                                ");
            WriteLiteral(@"                            <a class=""dropdown-item"" href=""javascript:void()"" data-toggle=""modal"" data-target=""#modal-editForm""><i class=""fas fa-edit"" aria-hidden=""true"" style=""margin-right:8px;""></i>Edit</a>
                                                                            <a class=""dropdown-item"" href=""javascript:void()""><i class=""fas fa-print"" aria-hidden=""true"" style=""margin-right:8px;""></i>Print</a>
                                                                            <a class=""dropdown-item"" href=""javascript:void()""><i class=""fa fa-file"" aria-hidden=""true"" style=""margin-right:8px;""></i>Download</a>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </th>

                                ");
            WriteLiteral(@"                    </tr>


                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!-- /.card -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>


<div class=""modal fade"" id=""modal-viewForm"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header bg-colorBlack"">
                <h4 class=""modal-title"">Service Order History</h4>
                <button type=""button"" class=""close text-white"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <section ");
            WriteLiteral(@"class=""content"" style=""width:100%;"">

                    <div class=""tbl"" style=""padding-left:25px;padding-right:25px;"">
                        <div class=""row"">
                            <div class=""col-md-12"">
                                <div>
                                    <table id=""productTable"" class=""table table-striped table-bordered"">
                                        <thead>
                                            <tr>
                                                <th>Service Type</th>
                                                <th>Type</th>
                                                <th>Quantity</th>
                                                <th>Price</th>
                                            </tr>
                                        </thead>
                                        <tbody id=""productTableBody"">
                                            <tr>
                                                <td>Osaka</td>
        ");
            WriteLiteral(@"                                        <td>Battery</td>
                                                <td>11</td>
                                                <td>$11</td>
                                            </tr>
                                            <tr>
                                                <td>Havoline</td>
                                                <td>Oil</td>
                                                <td>22</td>
                                                <td>$10</td>
                                            </tr>
                                        </tbody>
                                    </table>

                                    <div class=""row"">
                                        <div class=""col-sm-11"">
                                            <span class=""float-right"">Product Cost:</span>
                                        </div>
                                        <div class=""col-sm-1"">
                 ");
            WriteLiteral(@"                           <span class=""float-right"" id=""totalProductPrice"">$341</span>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-11"">
                                            <span class=""float-right"">Margin:</span>
                                        </div>
                                        <div class=""col-sm-1"">
                                            <span class=""float-right"">10%</span>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-11"">
                                            <span class=""float-right"">Service Charges:</span>
                                        </div>
                                        <div class=""col-sm-1"">
                        ");
            WriteLiteral(@"                    <span class=""float-right"" id=""totalServiceCharges"">$10</span>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-11"">
                                            <span class=""font-weight-bold float-right"">Total Price:</span>
                                        </div>
                                        <div class=""col-sm-1"">
                                            <span class=""float-right"">$317</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>

       ");
            WriteLiteral("     </div>\r\n        </div>\r\n        <!-- /.modal-content -->\r\n    </div>\r\n    <!-- /.modal-dialog -->\r\n</div>\r\n\r\n");
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