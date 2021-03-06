#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Agent\Employee.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4c3a08ab2840dd58b6b7109c40ffa53962a8971"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agent_Employee), @"mvc.1.0.view", @"/Views/Agent/Employee.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4c3a08ab2840dd58b6b7109c40ffa53962a8971", @"/Views/Agent/Employee.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Agent_Employee : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Agent\Employee.cshtml"
  
    ViewData["Title"] = "Employee";
    Layout = CommonData.GetUserLayoutByRoleId(x.GetUserRoleId());// "~/Views/Shared/_LayoutCallCenter.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-md-2\">\r\n                <h1>Employee</h1>\r\n            </div>\r\n            <div class=\"col-md-8\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4c3a08ab2840dd58b6b7109c40ffa53962a89714610", async() => {
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
            <div class=""col-md-2"">
                <button type=""submit"" class=""btn bg-colorBlack float-right"" data-toggle=""modal"" data-target=""#modal-addForm"">Add Employee</button>

            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card"">

                    <!-- /.card-header -->
                    <div class=""card-body call table-responsive p-0"">
                        <table class=""table table-striped"">
                            <thead class=""bg-colorBlack"">
                                <tr>
                                    <th>First name</th>
                                    <th>Last name</th>
                                    <th>Address</th>
                                    <th>Contact No</th>
                                    <th>Employee Type</th>
       ");
            WriteLiteral(@"                             <th>Action</th>
                                </tr>
                            </thead>
                            <tbody class=""employee"">
                                <tr>
                                    <td>Mohammed</td>
                                    <td>Manar</td>
                                    <td>UAE</td>
                                    <td>+0 122332 1211</td>
                                    <td>
                                        Employee

                                    </td>
                                    <td>
                                        <div class=""dropdown"">
                                            <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton2"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                View
                                            </button>
                                            <div cla");
            WriteLiteral(@"ss=""dropdown-menu"" aria-labelledby=""dropdownMenuButton2"">
                                                <ul style=""display:block; list-style:none;"">
                                                    <li>
                                                        <a href=""#"" data-toggle=""modal"" data-target=""#modalEdit""><i class=""fa fa-edit""></i>Edit</a>

                                                    </li>

                                                    <li>
                                                        <a hred=""#"" data-toggle=""modal"" data-target=""#modalEdit""><i class=""fas fa-archive""></i>Archive</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Khalid</td>
");
            WriteLiteral(@"                                    <td>Maya</td>
                                    <td>
                                        UAE
                                    </td>
                                    <td>+0 124322 1231</td>
                                    <td>
                                        Employee
                                    </td>
                                    <td>
                                        <div class=""dropdown"">
                                            <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton2"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                View
                                            </button>
                                            <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton2"">
                                                <ul style=""display:block; list-style:none;"">
                                        ");
            WriteLiteral(@"            <li>
                                                        <a href=""#"" data-toggle=""modal"" data-target=""#modalEdit""><i class=""fa fa-edit""></i>Edit</a>

                                                    </li>

                                                    <li>
                                                        <a hred=""#"" data-toggle=""modal"" data-target=""#modalEdit""><i class=""fas fa-archive""></i>Archive</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td>Jack</td>
                                    <td>Taif</td>
                                    <td>
                                        Fujairah
                                    </td>
       ");
            WriteLiteral(@"                             <td>+0 326232 9021</td>
                                    <td>
                                        Technician
                                    </td>
                                    <td>
                                        <div class=""dropdown"">
                                            <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton2"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                View
                                            </button>
                                            <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton2"">
                                                <ul style=""display:block; list-style:none;"">
                                                    <li>
                                                        <a href=""#"" data-toggle=""modal"" data-target=""#modalEdit""><i class=""fa fa-edit""></i>Edit</a>

                 ");
            WriteLiteral(@"                                   </li>

                                                    <li>
                                                        <a hred=""#"" data-toggle=""modal"" data-target=""#modalEdit""><i class=""fas fa-archive""></i>Archive</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Mustapha</td>
                                    <td>Maryam</td>
                                    <td>
                                        Ajman
                                    </td>
                                    <td>+0 426623 1181</td>
                                    <td>
                                        CallCenter Rep
                                 ");
            WriteLiteral(@"   </td>
                                    <td>
                                        <div class=""dropdown"">
                                            <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton2"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                View
                                            </button>
                                            <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton2"">
                                                <ul style=""display:block; list-style:none;"">
                                                    <li>
                                                        <a href=""#"" data-toggle=""modal"" data-target=""#modalEdit""><i class=""fa fa-edit""></i>Edit</a>

                                                    </li>

                                                    <li>
                                                        <a hred=""#"" data-toggle");
            WriteLiteral(@"=""modal"" data-target=""#modalEdit""><i class=""fas fa-archive""></i>Archive</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td>Oumar</td>
                                    <td>Mira</td>
                                    <td>
                                        Sharjah
                                    </td>
                                    <td>+0 475683 1041</td>
                                    <td>
                                        Technician
                                    </td>
                                    <td>
                                        <div class=""dropdown"">
                                            <button class=""btn dropdow");
            WriteLiteral(@"n-toggle"" type=""button"" id=""dropdownMenuButton2"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                View
                                            </button>
                                            <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton2"">
                                                <ul style=""display:block; list-style:none;"">
                                                    <li>
                                                        <a href=""#"" data-toggle=""modal"" data-target=""#modalEdit""><i class=""fa fa-edit""></i>Edit</a>

                                                    </li>

                                                    <li>
                                                        <a hred=""#"" data-toggle=""modal"" data-target=""#modalEdit""><i class=""fas fa-archive""></i>Archive</a>
                                                    </li>
                                                </");
            WriteLiteral(@"ul>
                                            </div>
                                        </div>
                                    </td>

                                </tr>

                            </tbody>
                        </table>
                    </div>
                    <!-- /.card-body -->
                    <div class=""card-footer clearfix"">
                        <ul class=""pagination pagination-sm m-0 float-right"">
                            <li class=""page-item""><a class=""page-link"" href=""#"">??</a></li>
                            <li class=""page-item""><a class=""page-link"" href=""#"">1</a></li>
                            <li class=""page-item""><a class=""page-link"" href=""#"">2</a></li>
                            <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
                            <li class=""page-item""><a class=""page-link"" href=""#"">??</a></li>
                        </ul>
                    </div>
                </div>
             ");
            WriteLiteral(@"   <!-- /.card -->
            </div>
            <!-- /.col -->
        </div>
    </div><!-- /.container-fluid -->
</section>


<div class=""modal fade"" id=""modal-addForm"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header bg-colorBlack"">
                <h4 class=""modal-title"">Add New Employee</h4>
                <button type=""button"" class=""close text-white"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4c3a08ab2840dd58b6b7109c40ffa53962a897118943", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label for=""exampleInputEmail1"">First Name</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 13210, "\"", 13215, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Enter First Name"">
                            </div>
                        </div>
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label for=""exampleInputPassword1"">Last Name</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 13577, "\"", 13582, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Enter Last Name"">
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label for=""exampleInputEmail1"">Address</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 14005, "\"", 14010, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Enter Address"">
                            </div>
                        </div>
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label for=""exampleInputPassword1"">Contact No</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 14370, "\"", 14375, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Enter Contact No"">
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label>Employee Type</label>
                                <select class=""reportDropDown form-control"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4c3a08ab2840dd58b6b7109c40ffa53962a897121750", async() => {
                    WriteLiteral("Select Employee Type");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4c3a08ab2840dd58b6b7109c40ffa53962a897123461", async() => {
                    WriteLiteral("Employee");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4c3a08ab2840dd58b6b7109c40ffa53962a897124514", async() => {
                    WriteLiteral("CallCenter Rep");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4c3a08ab2840dd58b6b7109c40ffa53962a897125573", async() => {
                    WriteLiteral("Technician");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                </select>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
                WriteLiteral("\r\n                    <!-- /.card-body -->\r\n                ");
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
                <button type=""button"" class=""btn btn-secondary"">Add</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>



<div class=""modal fade"" id=""modalEdit"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header bg-colorBlack"">
                <h4 class=""modal-title"">Edit Employee Information</h4>
                <button type=""button"" class=""close text-white"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4c3a08ab2840dd58b6b7109c40ffa53962a897128829", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label for=""exampleInputEmail1"">First Name</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 17686, "\"", 17691, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Enter First Name"">
                            </div>
                        </div>
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label for=""exampleInputPassword1"">Last Name</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 18053, "\"", 18058, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Enter Last Name"">
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label for=""exampleInputEmail1"">Address</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 18481, "\"", 18486, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Enter Address"">
                            </div>
                        </div>
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label for=""exampleInputPassword1"">Contact No</label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("id", " id=\"", 18846, "\"", 18851, 0);
                EndWriteAttribute();
                WriteLiteral(" placeholder=\"Enter Contact No\">\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n\r\n                    <!-- /.card-body -->\r\n                ");
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
                <button type=""button"" class=""btn btn-secondary"">Edit</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>");
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
