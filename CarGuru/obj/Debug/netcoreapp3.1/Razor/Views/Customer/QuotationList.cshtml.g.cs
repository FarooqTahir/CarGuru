#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a26c729ae664d714273d71ef572a12f6005763a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_QuotationList), @"mvc.1.0.view", @"/Views/Customer/QuotationList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a26c729ae664d714273d71ef572a12f6005763a5", @"/Views/Customer/QuotationList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_QuotationList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarGuru.ViewModels.CustomerViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
  
    ViewData["Title"] = "Scheduler";
    Layout = CommonData.GetUserLayoutByRoleId(x.GetUserRoleId());

    decimal Latitude = 0;
    decimal Longitude = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-8 col-md-8\">\r\n");
#nullable restore
#line 14 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                 if (!(Model.CustomerUpdate == null))
                {
                    var Name = Model.CustomerUpdate.User.FirstName + " " + Model.CustomerUpdate.User.LastName;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h1>");
#nullable restore
#line 17 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                   Write(Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Quotations</h1>\r\n");
#nullable restore
#line 18 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h1>Quotations</h1>\r\n");
#nullable restore
#line 22 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-sm-2 col-md-2\">\r\n\r\n            </div>\r\n");
            WriteLiteral(@"        </div>
    </div><!-- /.container-fluid -->
</section>
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card"">
                    <div class=""card-body leads table-responsive p-0"" id=""Table"">
                        <table class=""table table-striped"" id=""QTable"" width=""100%"" min-height=""350px"">
                            <thead class=""bg-colorBlack"">
                                <tr>
                                    <th>Quotation Id</th>
                                    <th>Customer Name</th>
                                    <th>Received Date</th>
                                    <th>Customer Email</th>
                                    <th>Total Price</th>
                                    <th class=""actionColumn"">Action</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 52 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                                 if (!(Model.Quotations is null) && Model.Quotations.Any())
                                {
                                    foreach (var request in Model.Quotations)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 57 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                                       Write(request.QuotationId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 58 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                                       Write(request.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 59 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                                       Write(request.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 61 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                                       Write(request.CustomerEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>$");
#nullable restore
#line 63 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                                        Write(request.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                        <th>
                                            <div class=""row"">
                                                <div class=""col-md-3 viewModal"">
                                                    <button class=""btn"" type=""button""");
            BeginWriteAttribute("onclick", " onclick=\"", 3104, "\"", 3173, 5);
            WriteAttributeValue("", 3114, "ViewQuotation(", 3114, 14, true);
#nullable restore
#line 67 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
WriteAttributeValue("", 3128, request.QuotationId, 3128, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3148, ",", 3148, 1, true);
#nullable restore
#line 67 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
WriteAttributeValue("", 3149, request.CustomerUserId, 3149, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3172, ")", 3172, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">
                                                        View
                                                    </button>
                                                </div>
                                                <div class=""col-md-2"">
                                                    <div class=""dropdown"">
                                                        <button class=""btn dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                        </button>
                                                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                                            <a class=""dropdown-item"" href=""javascript:void()""");
            BeginWriteAttribute("onclick", " onclick=\"", 4002, "\"", 4071, 5);
            WriteAttributeValue("", 4012, "EditQuotation(", 4012, 14, true);
#nullable restore
#line 76 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
WriteAttributeValue("", 4026, request.QuotationId, 4026, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4046, ",", 4046, 1, true);
#nullable restore
#line 76 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
WriteAttributeValue("", 4047, request.CustomerUserId, 4047, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4070, ")", 4070, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fas fa-edit"" aria-hidden=""true"" style=""margin-right:8px;""></i>Edit</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </th>
                                    </tr>
");
#nullable restore
#line 83 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>
                    </div>
                </div>
                <!-- /.card -->
            </div>
            <!-- /.col -->
        </div>
    </div><!-- /.container-fluid -->
</section>
<div class=""modal fade"" id=""modal-detailForm"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header bg-colorBlack"">
                <h4 class=""modal-title"">Quotation Detail</h4>
                <button type=""button"" class=""close text-white"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div id=""Quotation-detail-dataa"">

                </div>
            </div>
            <div class=""modal-footer"">
                <input type=""hidden"" id=""QCustomerId"">
                <input type=""hidden"" id=""QId"">
                <b");
            WriteLiteral(@"utton type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button type=""button"" id=""forward"" class=""btn btn-secondary"" onclick=""ForwardToClient()"" data-dismiss=""modal"">Forward to Client</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
</div>
<div class=""modal fade"" id=""modal-EditForm"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header bg-colorBlack"">
                <h4 class=""modal-title"">Quotation Edit</h4>
                <button type=""button"" class=""close text-white"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div id=""Quotation-detail-dataa"">

                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-d");
            WriteLiteral("ismiss=\"modal\">Add</button>\r\n\r\n            </div>\r\n        </div>\r\n        <!-- /.modal-content -->\r\n    </div>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#QTable').DataTable({
                ""bSort"": false,
                ""searching"": false,
                ""responsive"": true,
                dom: 'Bfrtip',
                buttons: []
            });
        });
        function SelectProduct(quotationId, quotationDetailId, productId) {
            UpdateProduct(quotationId, quotationDetailId, productId);
        }

        function ForwardToClient() {
            var customerId = $(""#QCustomerId"").val();
            var qoutationId = $(""#QId"").val();
            var description = $(""#QuotationDescription"").val();
            OpenChat(");
#nullable restore
#line 160 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                Write(x.GetUserId());

#line default
#line hidden
#nullable disable
                WriteLiteral(@", customerId, true)
            $(""#modal-detailForm"").modal('hide');
            $.ajax({
                url: ""../Management/ForwardQuotationToClient"",
                type: 'Post',
                data: {
                    UserId: customerId, Description: description, QoutationId: qoutationId
                },
                success: function (data) {
                    
                    var customerId = $(""#QCustomerId"").val();
                    OpenChat(");
#nullable restore
#line 171 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Customer\QuotationList.cshtml"
                        Write(x.GetUserId());

#line default
#line hidden
#nullable disable
                WriteLiteral(@", customerId,false)
                    $(""#QuotationTable"").html(data);
                    $(""#QCustomerId"").val(customerId);
                    $(""#modal-detailForm"").modal('hide');
                    $('#Qtable').DataTable({
                        ""bSort"": false,
                        ""searching"": false,
                        ""responsive"": true,
                        dom: 'Bfrtip',
                        buttons: [

                        ]
                    });
                },
                error: function (request, error) {

                }
            });
        }
        function ViewQuotation(quotationId, customerId) {
            $(""#QCustomerId"").val(customerId);
            $(""#QId"").val(quotationId);
            if (quotationId > 0) {
                $.ajax({
                    url: ""../Management/GetQuotationInfoById"",
                    type: 'Post',
                    data: {
                        quotationId: quotationId, isView: true
    ");
                WriteLiteral(@"                },
                    success: function (data) {
                        $(""#Quotation-detail-dataa"").html(data);
                        $(""#QCustomerId"").val(customerId);
                        $(""#modal-detailForm"").modal('show');
                    },
                    error: function (request, error){}
                });
            }
        }
        function EditQuotation(quotationId, customerId) {
            $(""#QCustomerId"").val(customerId);
            $(""#QId"").val(quotationId);
            if (quotationId > 0) {
                $.ajax({
                    url: ""../Management/GetQuotationInfoById"",
                    type: 'Post',
                    data: {
                        quotationId: quotationId, isView: false
                    },
                    success: function (data) {
                        $(""#Quotation-detail-dataa"").html(data);
                        $(""#modal-detailForm"").modal('show');
                    },
            ");
                WriteLiteral(@"        error: function (request, error) {

                    }
                });
            }
        }
        function UpdateProduct(quotationId, quotationDetailId, productId) {
            if (quotationId > 0 && quotationDetailId > 0 && productId > 0) {
                $.ajax({
                    url: ""../Management/UpdateQuotationProduct"",
                    type: 'Post',
                    data: {
                        quotationDetailId: quotationDetailId, productId: productId, quotationId: quotationId
                    },
                    success: function (data) {
                        
                        if (data.status == 1) {
                            
                            $(""#PP_"" + quotationDetailId).text(data.data.salePrice);
                            $(""#TotalPrice"").val(data.data.totalPrice);
                            $(""#TotalMargin"").val(data.data.margin);
                            $(""#TotalDiscount"").val(data.data.discountPrice);

");
                WriteLiteral("                        }\r\n                        else {\r\n\r\n                        }\r\n                    },\r\n                    error: function (request, error) {\r\n\r\n                    }\r\n                });\r\n            }\r\n        }\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarGuru.ViewModels.CustomerViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
