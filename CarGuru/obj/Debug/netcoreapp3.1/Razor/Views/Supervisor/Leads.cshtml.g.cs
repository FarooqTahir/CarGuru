#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43278aec23b34b10c3277f4c082b2b72408813a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Supervisor_Leads), @"mvc.1.0.view", @"/Views/Supervisor/Leads.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43278aec23b34b10c3277f4c082b2b72408813a5", @"/Views/Supervisor/Leads.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Supervisor_Leads : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarGuru.ViewModels.SupervisorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
  
    ViewData["Title"] = "ServiceOrderList";
    var role = x.GetUserRoleId();
    Layout = CommonData.GetUserLayoutByRoleId(role);

#line default
#line hidden
#nullable disable
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#LeadsTable').DataTable({
                ""bSort"": false,
                ""searching"": false,
                ""responsive"": true,
                dom: 'Bfrtip',
                buttons: []
            });
        });
    </script>
");
            }
            );
            WriteLiteral("<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-8 col-md-8\">\r\n");
#nullable restore
#line 26 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                 if (!(Model.AgentName == null))
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h1>");
#nullable restore
#line 29 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                   Write(Model.AgentName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Leads</h1>\r\n");
#nullable restore
#line 30 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1>Leads</h1>\r\n");
#nullable restore
#line 34 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div class=""col-sm-4 col-md-6"">

            </div>
        </div>
    </div>
</section>
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card"">
                    <div class=""card-body leads table-responsive p-0"">
");
#nullable restore
#line 49 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                         if (!(@Model.Leads == null))
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                             if (!(@Model.Leads.Count == 0))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <table class=""table table-striped""  id=""LeadsTable"" style=""width:100%"">
                                    <thead class=""bg-colorBlack"">
                                        <tr>
                                            <th>Customer</th>
                                            <th>Email</th>
                                            <th>Phone</th>
                                            <th>Address</th>
                                            <th>Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 64 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                                         foreach (var item in @Model.Leads)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>");
#nullable restore
#line 67 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                                               Write(item.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 68 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                                               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 69 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                                               Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 70 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                                               Write(item.CustomerAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td id=\"status\">");
#nullable restore
#line 71 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                                                           Write(item.LeadStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                            </tr>\r\n");
#nullable restore
#line 74 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n");
#nullable restore
#line 77 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h3>No Record Found</h3>\r\n");
#nullable restore
#line 81 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3>No Record Found</h3>\r\n");
#nullable restore
#line 86 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\Leads.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                    <!-- /.card-body -->
                    <div class=""card-footer clearfix"">
                        <ul class=""pagination pagination-sm m-0 float-right"">
                           
                        </ul>
                    </div>
                </div>
                <!-- /.card -->
            </div>
            <!-- /.col -->
        </div>
    </div><!-- /.container-fluid -->
</section>
<div class=""modal fade"" id=""modal-Invoice"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header bg-colorBlack"">
                <h4 class=""modal-title"">Invoice</h4>
                <button type=""button"" class=""close text-white"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""row invoice-info"">
                    <div cla");
            WriteLiteral(@"ss=""col-sm-2""></div>

                    <h1>Service Orders</h1>

                </div>

                <div class=""Tables""></div>
            </div>
            <div class=""modal-footer justify-content-between"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarGuru.ViewModels.SupervisorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
