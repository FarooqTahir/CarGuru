#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Agent\Notification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "690c6ce769b3687b2758392e2f38cad01555ee50"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agent_Notification), @"mvc.1.0.view", @"/Views/Agent/Notification.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"690c6ce769b3687b2758392e2f38cad01555ee50", @"/Views/Agent/Notification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Agent_Notification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Agent\Notification.cshtml"
  
    ViewData["Title"] = "Notification";
    Layout = "~/Views/Shared/_LayoutCallCenter.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-md-2\">\r\n                <h1>Notifications</h1>\r\n            </div>\r\n            <div class=\"col-md-10\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "690c6ce769b3687b2758392e2f38cad01555ee504145", async() => {
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
                    <div class=""card-header bg-colorBlack"">
                        <h3>Select Notification Option.</h3>
                    </div>

                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-md-12"">
                                <div>
                                    <p>Select notification for Customer and Technician below.(Leave blank to not send any notification).</p>
                                </div>
                                <div class=""row"">
                                    <div class=""col-md-4"">
                                        <a class=""dropdown-item"" href=""#"" style=""margin-left:-15px;""><i class=""fas fa-user"" aria-hidden=""true"" style");
            WriteLiteral(@"=""margin-right:8px;""></i>Call Center(Optional)</a>

                                        <div class=""custom-control custom-switch"" style=""margin-top:10px;"">
                                            <input type=""checkbox"" class=""custom-control-input"" id=""customSwitch17"" unchecked>
                                            <label class=""custom-control-label"" for=""customSwitch17"">Email</label>
                                        </div>
                                        <div class=""custom-control custom-switch"" style=""margin-top:10px;"">
                                            <input type=""checkbox"" class=""custom-control-input"" id=""customSwitch18"" unchecked>
                                            <label class=""custom-control-label"" for=""customSwitch18"">SMS</label>
                                        </div>
                                        <div class=""custom-control custom-switch"" style=""margin-top:10px;"">
                                            <input type=""chec");
            WriteLiteral(@"kbox"" class=""custom-control-input"" id=""customSwitch23"" unchecked>
                                            <label class=""custom-control-label"" for=""customSwitch23"">InApp</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section class=""Content1"" style=""margin-top:10px; padding-left:10px; padding-right:10px;"">
    <div class=""card"">
      
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div>
                        <p>*Note:You must have a notification option selected above to schedule appointment notification.</p>
                    </div>

                    <div class=""row"">
                      
                        <div class=""col-md-4"">
     ");
            WriteLiteral(@"                       <a class=""dropdown-item"" href=""#"" style=""margin-left:-15px;""><i class=""fas fa-user"" aria-hidden=""true"" style=""margin-right:8px;""></i>Call Center</a>

                            <div class=""custom-control custom-switch"" style=""margin-top:10px;"">
                                <input type=""checkbox"" class=""custom-control-input"" id=""customSwitch13"" unchecked>
                                <label class=""custom-control-label"" for=""customSwitch13"">Service Request</label>
                            </div>
                            <div class=""custom-control custom-switch"" style=""margin-top:10px;"">
                                <input type=""checkbox"" class=""custom-control-input"" id=""customSwitch14"" unchecked>
                                <label class=""custom-control-label"" for=""customSwitch14"">Quotation Request</label>
                            </div>
                            <div class=""custom-control custom-switch"" style=""margin-top:10px;"">
                        ");
            WriteLiteral(@"        <input type=""checkbox"" class=""custom-control-input"" id=""customSwitch15"" unchecked>
                                <label class=""custom-control-label"" for=""customSwitch15"">Follow Up</label>
                            </div>
                            <div class=""custom-control custom-switch"" style=""margin-top:10px;"">
                                <input type=""checkbox"" class=""custom-control-input"" id=""customSwitch01"" unchecked>
                                <label class=""custom-control-label"" for=""customSwitch01"">Late Technician</label>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<div class="" clearfix mt-1"">
    <button type=""button"" class=""btn btn-secondary mb-2 mr-2"" style=""float:right;"">Save</button>
</div>
   


");
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