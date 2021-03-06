#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99373415df917dfb06136611bc4bb907921ae2a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer__Invoice), @"mvc.1.0.view", @"/Views/Customer/_Invoice.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99373415df917dfb06136611bc4bb907921ae2a5", @"/Views/Customer/_Invoice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer__Invoice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarGuru.ViewModels.CustomerViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <section class=\"content mt-2\">\r\n        <div class=\"row contacts\">\r\n            <div class=\"col invoice-details\">\r\n                <h4 class=\"invoice-id\">INVOICE-");
#nullable restore
#line 5 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                          Write(Model.Invoice.ServiceOrderNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                <div class=\"date\"><strong>Customer: </strong>");
#nullable restore
#line 6 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                                        Write(Model.Invoice.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"phone\"><strong>Phone: </strong>");
#nullable restore
#line 7 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                                      Write(Model.Invoice.CustomerPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"email\"><strong>Email: </strong>");
#nullable restore
#line 8 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                                      Write(Model.Invoice.CustomerEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            </div>\r\n            <div class=\"col invoice-to mt-4\">\r\n                <div class=\"date\"><strong>Technician: </strong>");
#nullable restore
#line 11 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                                          Write(Model.Invoice.Technician);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 12 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                 if (Model.Invoice.VehicleMake!=null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"date\"><strong>Vehicle: </strong>");
#nullable restore
#line 14 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                                           Write(Model.Invoice.VehicleMake);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 14 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                                                                      Write(Model.Invoice.VehicleModel);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 14 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                                                                                                  Write(Model.Invoice.VehicleYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 15 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"date\"><strong>Date Received: </strong>");
#nullable restore
#line 17 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                                             Write(Model.Invoice.ReceivedDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
            </div>
            
        </div>
        <div class=""order"">
            <h4>Services</h4>
        </div>
        
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""table-responsive"">
                    <table id=""serviceTable"" class=""table table-striped table-bordered"">
                        <thead>
                            <tr>
                                <th>Service</th>
                                <th>Price</th>
                            </tr>
                        </thead>
                        <tbody id=""serviceTableBody"">
");
#nullable restore
#line 36 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                             if (Model.Invoice.Services != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                 foreach (var item in Model.Invoice.Services)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 41 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                       Write(item.ServiceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 42 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                       Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>

                </div>
            </div>
        </div>
    </section>

<section class=""content mt-2"">
    <div class=""order"">
        <h4>Products</h4>
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""table-responsive"">
                <table id=""productTable"" class=""table table-striped table-bordered"">
                    <thead>
                        <tr>
                            <th>Product</th>
                            <th>Quantity</th>
                            <th>Unit Price</th>
                            <th>Price</th>
                        </tr>
                    </thead>
                    <tbody id=""productTableBody"">
");
#nullable restore
#line 71 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                         if (Model.Invoice.Products!=null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                             foreach (var item in Model.Invoice.Products)
                            {
                                var unit = item.Price / item.Quantity;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 77 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 78 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                   Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 79 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                   Write(unit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 80 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                   Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 82 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
            <div class=""row"">

                <div class=""col-md-12"">

                    <div class=""row"">
                        <div class=""col-md-10"">
                            <span class=""float-right"">Product Cost:</span>
                        </div>
                        <div class=""col-md-2"">
                            <span class=""float-right"" id=""totalProductPrice"">");
#nullable restore
#line 96 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                                                        Write(Model.TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-10"">
                            <span class=""float-right"">Service Charges:</span>
                        </div>
                        <div class=""col-md-2"">
                            <span class=""float-right"" id=""totalServiceCharges"">");
#nullable restore
#line 104 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                                                          Write(Model.ServiceCharges);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-10"">
                            <span class=""font-weight-bold float-right"">Total Price:</span>
                        </div>
                        <div class=""col-md-2"">
                            <span class=""float-right"" id=""totalPrice"">");
#nullable restore
#line 112 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\_Invoice.cshtml"
                                                                 Write(Model.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarGuru.ViewModels.CustomerViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
