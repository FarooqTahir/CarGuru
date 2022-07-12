#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Management\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6edf296eba552c1ac10624d63980bf877835649f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Management_Orders), @"mvc.1.0.view", @"/Views/Management/Orders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6edf296eba552c1ac10624d63980bf877835649f", @"/Views/Management/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Management_Orders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarGuru.ViewModels.CustomerViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_OrderListing", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Management\Orders.cshtml"
  
    ViewData["Title"] = "Service Orders";
    Layout = CommonData.GetUserLayoutByRoleId(x.GetUserRoleId());//"~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#OrderTable').DataTable({
                ""bSort"": false,
                ""searching"": false,
                ""responsive"": true,
                dom: 'Bfrtip',
                buttons: [
                    
                ]
            });
        });
        function ShowInvoice(cId, Id) {
            $.ajax({
                url: ""../Customer/Invoice"",
                type: 'Post',
                data: {
                    CustomerId: cId, ServiceOrderId: Id
                },
                success: function (data) {
                    $(""#modal-Invoice"").modal('show');
                    $("".Tables"").html(data);
                }
            });
        }
        $(document).on('keypress', function (e) {
            if (e.which == 13) {
                SearchOrder();
            }
        });
        function SearchOrder() {
            var Name = $(""#Name"").val();
            $.ajax({
          ");
                WriteLiteral(@"      url: ""../ServiceOrder/SearchOrders"",
                type: 'Post',
                data: {
                    name: Name
                },
                success: function (data) {
                    $(""#OrdersList"").html(data)
                    $('#OrderTable').DataTable({
                        ""bSort"": false,
                        ""searching"": false,
                        ""responsive"": true,
                        dom: 'Bfrtip',
                        buttons: []
                    });
                },
                error: function (request, error) {

                }
            });
        }
    </script>
");
            }
            );
            WriteLiteral(@"<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-4 col-md-4"">
                <h1>Service Orders</h1>
            </div>
            <div class=""col-sm-6 col-md-8"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6edf296eba552c1ac10624d63980bf877835649f6482", async() => {
                WriteLiteral(@"
                    <div class=""input-group bg-white"">
                        <input class=""form-control"" id=""Name"" type=""search"" placeholder=""Search by Name or Number"" aria-label=""Search""style=""width: 230px;"">
                        <div class=""input-group-append"">
                            <button class=""btn btn-navbar "" onclick=""SearchOrder()"" type=""button"">
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
                <div class=""card "">
                    <div class=""card-body p-0 table-responsive"" id=""OrdersList"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6edf296eba552c1ac10624d63980bf877835649f8750", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 93 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Management\Orders.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                    <div class=""card-footer clearfix"">
                 
                    </div>
                </div>
            </div>
        </div>
    </div>
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
                <div class=""Tables""></div>
            </div>
            <div class=""modal-footer justify-content-between"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.mod");
            WriteLiteral("al-dialog -->\r\n</div>");
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
