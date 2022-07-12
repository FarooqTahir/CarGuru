#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e8c3a077334020a14d3571a32240a4e4a886afe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_PartialViews__EmployeeList), @"mvc.1.0.view", @"/Views/Employee/PartialViews/_EmployeeList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e8c3a077334020a14d3571a32240a4e4a886afe", @"/Views/Employee/PartialViews/_EmployeeList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_PartialViews__EmployeeList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarGuru.ViewModels.EmployeeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
 if (!(Model.EmployeesList == null))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table table-striped"" id=""EmployeeTable"" width=""100%"">
        <thead class=""bg-colorBlack"">
            <tr>
                <th>First name</th>
                <th>Last name</th>
                <th>Address</th>
                <th>Contact No</th>
                <th>Email</th>
                <th class=""actionColumn"">Action</th>
            </tr>
        </thead>
        <tbody id=""employeeTableBody"">


");
#nullable restore
#line 18 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
             foreach (var item in Model.EmployeesList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 21 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
                   Write(item.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
                   Write(item.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 24 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
                   Write(item.User.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>");
#nullable restore
#line 26 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
                   Write(item.User.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
                   Write(item.User.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-sm-3 viewModal\">\r\n                                <button class=\"btn\" type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1114, "\"", 1155, 3);
            WriteAttributeValue("", 1124, "ViewEmployee(", 1124, 13, true);
#nullable restore
#line 31 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
WriteAttributeValue("", 1137, item.User.UserId, 1137, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1154, ")", 1154, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">
                                    View
                                </button>
                            </div>
                            <div class=""col-sm-2"">
                                <div class=""dropdown"">
                                    <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                    </button>
                                    <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                        <a class=""dropdown-item"" href=""javascript:void()""");
            BeginWriteAttribute("onclick", " onclick=\"", 1804, "\"", 1848, 3);
            WriteAttributeValue("", 1814, "GetEmployeeById(", 1814, 16, true);
#nullable restore
#line 40 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
WriteAttributeValue("", 1830, item.User.UserId, 1830, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1847, ")", 1847, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-print\" aria-hidden=\"true\" style=\"margin-right:8px;\"></i>Edit</a>\r\n                                        <a class=\"dropdown-item\" href=\"javascript:void()\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2022, "\"", 2065, 3);
            WriteAttributeValue("", 2032, "DeleteEmployee(", 2032, 15, true);
#nullable restore
#line 41 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
WriteAttributeValue("", 2047, item.User.UserId, 2047, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2064, ")", 2064, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fas fa-archive"" aria-hidden=""true"" style=""margin-right:8px;""></i>Archive</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
");
#nullable restore
#line 48 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 53 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>No Record Found</h3>\r\n");
#nullable restore
#line 57 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Employee\PartialViews\_EmployeeList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarGuru.ViewModels.EmployeeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591