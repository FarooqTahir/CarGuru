#pragma checksum "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19b23caf71c99215e1e46dced550db854bcf00c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Supervisor__SupervisorDashboard), @"mvc.1.0.view", @"/Views/Supervisor/_SupervisorDashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19b23caf71c99215e1e46dced550db854bcf00c5", @"/Views/Supervisor/_SupervisorDashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6a444c5013a2caa2b0f73ecf9ecf67a7be6ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Supervisor__SupervisorDashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarGuru.ViewModels.CustomerViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml"
 if (Model.Analytics != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script>
        $(function () {




            //-------------
            //- BAR CHART -
            //-------------

            var barChartLeadData = {
                labels: ['Total Lead'],
                datasets: [
                    {
                        label: 'Quotation',
                        backgroundColor: 'rgba(105,205,250,0.7)',
                        borderColor: 'rgba(60,141,188,0.8)',
                        pointRadius: false,
                        pointColor: '#3b8bba',
                        pointStrokeColor: 'rgba(60,141,188,1)',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(60,141,188,1)',
                        data: [");
#nullable restore
#line 26 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml"
                          Write(Convert.ToInt32(Model.Analytics.Leads.QuotationRequest));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]
                    },
                    {
                        label: 'Converted Lead',
                        backgroundColor: 'rgba(105,205,250,0.7)',
                        borderColor: 'rgba(210, 214, 222, 1)',
                        pointRadius: false,
                        pointColor: 'rgba(210, 214, 222, 1)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(2ss20,220,220,1)',
                        data: [");
#nullable restore
#line 37 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml"
                          Write(Convert.ToInt32(Model.Analytics.Leads.ServiceRequest));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]
                    },
                    {
                        label: 'Total Leads',
                        backgroundColor: 'rgba(105,205,250,0.7)',
                        borderColor: '#2da44a',
                        pointRadius: false,
                        pointColor: '#f39c12',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: '#f39c12',
                        data: [");
#nullable restore
#line 48 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml"
                          Write(Convert.ToInt32(Model.Analytics.Leads.NewLeads));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]
                    },
                ]
            }
            var barChartCanvas = $('#barChart').get(0).getContext('2d')
            var barChartData = jQuery.extend(true, {}, barChartLeadData)
            var temp0 = barChartLeadData.datasets[0]
            var temp1 = barChartLeadData.datasets[1]
            var temp2 = barChartLeadData.datasets[2]
            barChartData.datasets[0] = temp2
            barChartData.datasets[1] = temp1
            barChartData.datasets[2] = temp0

            var barChartOptions = {
                responsive: true,
                maintainAspectRatio: false,
                datasetFill: false
            }

            var barChart = new Chart(barChartCanvas, {
                type: 'bar',
                data: barChartData,
                options: barChartOptions
            })
            //---------------
            var barChartLeadData = {
                labels: ['Pending Orders'],
                datasets: [
                    ");
            WriteLiteral(@"{
                        label: 'Technician Name',
                        backgroundColor: 'rgba(117,209,218,0.7)',
                        borderColor: 'rgba(60,141,188,0.8)',
                        pointRadius: false,
                        pointColor: '#3b8bba',
                        pointStrokeColor: 'rgba(60,141,188,1)',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(60,141,188,1)',
                        data: [28]
                    },
                    {
                        label: 'No. OF Technician',
                        backgroundColor: 'rgba(117,209,218,0.7)',
                        borderColor: 'rgba(210, 214, 222, 1)',
                        pointRadius: false,
                        pointColor: 'rgba(210, 214, 222, 1)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(220,220,220,1)',
         ");
            WriteLiteral(@"               data: [65]
                    },
                    {
                        label: 'Technicians on duty',
                        backgroundColor: 'rgba(117,209,218,0.7)',
                        borderColor: '#2da44a',
                        pointRadius: false,
                        pointColor: '#f39c12',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: '#f39c12',
                        data: [70]
                    },
                ]
            }
            var barChartCanvas = $('#PendingOrders').get(0).getContext('2d')
            var barChartData = jQuery.extend(true, {}, barChartLeadData)
            var temp0 = barChartLeadData.datasets[0]
            var temp1 = barChartLeadData.datasets[1]
            var temp2 = barChartLeadData.datasets[2]
            barChartData.datasets[0] = temp2
            barChartData.datasets[1] = temp1
            barChartD");
            WriteLiteral(@"ata.datasets[2] = temp0

            var barChartOptions = {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                },
                responsive: true,
                maintainAspectRatio: false,
                datasetFill: false
            }

            var barChart = new Chart(barChartCanvas, {
                type: 'bar',
                data: barChartData,
                options: barChartOptions
            })

            //---------------

            var barChartProductData = {
                labels: ['Service Order'],
                datasets: [
                    {
                        label: 'Total Service Order',
                        backgroundColor: 'rgba(111,205,152,0.7)',
                        borderColor: 'rgba(210, 214, 222, 1)',
                        pointRadius: false,
                        pointColo");
            WriteLiteral("r: \'rgb(13, 90, 135)\',\r\n                        pointStrokeColor: \'#c1c7d1\',\r\n                        pointHighlightFill: \'#fff\',\r\n                        pointHighlightStroke: \'rgb(13, 90, 135)\',\r\n                        data: [");
#nullable restore
#line 153 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml"
                          Write(Convert.ToInt32(Model.Analytics.ServiceOrder.TotalServiceOrder));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]

                    },
                    {
                        label: 'Complete Service Order',
                        backgroundColor: 'rgba(111,205,152,0.7)',
                        borderColor: 'rgba(210, 214, 222, 1)',
                        pointRadius: false,
                        pointColor: 'rgba(210, 214, 222, 1)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(220,220,220,1)',
                        data: [");
#nullable restore
#line 165 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml"
                          Write(Convert.ToInt32(Model.Analytics.ServiceOrder.CompleteServiceOrder));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]
                    },
                    {
                        label: 'Incomplete Service Order',
                        backgroundColor: 'rgba(111,205,152,0.7)',
                        borderColor: '#2da44a',
                        pointRadius: false,
                        pointColor: '#3b8bba',
                        pointStrokeColor: '#f39c12',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: '#f39c12',
                        data: [");
#nullable restore
#line 176 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml"
                          Write(Convert.ToInt32(Model.Analytics.ServiceOrder.IncompleteServiceOrder));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]
                    },
                ]
            }
            var barChartCanvas2 = $('#barChart2').get(0).getContext('2d')
            var barChartData2 = jQuery.extend(true, {}, barChartProductData)
            var temp0 = barChartProductData.datasets[0]
            var temp1 = barChartProductData.datasets[1]
            var temp2 = barChartProductData.datasets[2]
            barChartData2.datasets[0] = temp2
            barChartData2.datasets[1] = temp1
            barChartData2.datasets[2] = temp0

            var barChartOptions2 = {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                },
                responsive: true,
                maintainAspectRatio: false,
                datasetFill: false
            }

            var barChart2 = new Chart(barChartCanvas2, {
                type: 'bar',
                data: barCh");
            WriteLiteral(@"artData2,
                options: barChartOptions2
            })

            //----------------------------------

            var barChartTechData = {
                labels: ['Tecnician'],
                datasets: [
                    {
                        label: 'Job Failed',
                        backgroundColor: 'rgba(111,205,152,0.7)',
                        borderColor: 'rgba(210, 214, 222, 1)',
                        pointRadius: false,
                        pointColor: 'rgb(13, 90, 135)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgb(13, 90, 135)',
                        data: [");
#nullable restore
#line 222 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml"
                          Write(Convert.ToInt32(Model.Analytics.Technicians.JobFailed));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]
                    },
                    {
                        label: 'Late Job',
                        backgroundColor: 'rgba(111,205,152,0.7)',
                        borderColor: 'rgba(210, 214, 222, 1)',
                        pointRadius: false,
                        pointColor: 'rgba(210, 214, 222, 1)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(220,220,220,1)',
                        data: [");
#nullable restore
#line 233 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml"
                          Write(Convert.ToInt32(Model.Analytics.Technicians.LateJob));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]
                    },
                    {
                        label: 'Complete Job',
                        backgroundColor: 'rgba(111,205,152,0.7)',
                        borderColor: '#2da44a',
                        pointRadius: false,
                        pointColor: '#3b8bba',
                        pointStrokeColor: '#f39c12',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: '#f39c12',
                        data: [");
#nullable restore
#line 244 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml"
                          Write(Convert.ToInt32(Model.Analytics.Technicians.CompleteJobs));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]
                    },
                ]
            }
            var barChartCanvas3 = $('#tech').get(0).getContext('2d')
            var barChartData3 = jQuery.extend(true, {}, barChartTechData)
            var temp0 = barChartTechData.datasets[0]
            var temp1 = barChartTechData.datasets[1]
            var temp2 = barChartTechData.datasets[2]
            barChartData3.datasets[0] = temp2
            barChartData3.datasets[1] = temp1
            barChartData3.datasets[2] = temp0

            var barChartOptions3 = {
                responsive: true,
                maintainAspectRatio: false,
                datasetFill: false
            }

            var barChart2 = new Chart(barChartCanvas3, {
                type: 'bar',
                data: barChartData3,
                options: barChartOptions3
            })
        })
    </script>
");
#nullable restore
#line 270 "C:\Users\Zahid\source\repos\CarGuru\CarGuru\Views\Supervisor\_SupervisorDashboard.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"">
    <!-- BAR CHART -->
    <div class=""col-md-6"">
        <div class=""card card-success"">
            <div class=""card-header bg-colorBlack"">
                <h3 class=""card-title"">Leads</h3>
            </div>
            <div class=""card-body"">
                <div class=""chart"">
                    <div class=""chartjs-size-monitor""><div class=""chartjs-size-monitor-expand""><div");
            BeginWriteAttribute("class", " class=\"", 11919, "\"", 11927, 0);
            EndWriteAttribute();
            WriteLiteral("></div></div><div class=\"chartjs-size-monitor-shrink\"><div");
            BeginWriteAttribute("class", " class=\"", 11986, "\"", 11994, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div></div></div>
                    <canvas id=""barChart"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%; display: block; width: 487px;"" width=""487"" height=""250"" class=""chartjs-render-monitor""></canvas>
                </div>
            </div>
            <!-- /.card-body -->
        </div>
    </div>
    <!-- /.card -->
    <div class=""col-md-6"">
        <div class=""card card-success"">
            <div class=""card-header bg-colorBlack"">
                <h3 class=""card-title"">Service Orders</h3>
            </div>
            <div class=""card-body"">
                <div class=""chart"">
                    <div class=""chartjs-size-monitor""><div class=""chartjs-size-monitor-expand""><div");
            BeginWriteAttribute("class", " class=\"", 12735, "\"", 12743, 0);
            EndWriteAttribute();
            WriteLiteral("></div></div><div class=\"chartjs-size-monitor-shrink\"><div");
            BeginWriteAttribute("class", " class=\"", 12802, "\"", 12810, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div></div></div>
                    <canvas id=""barChart2"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%; display: block; width: 487px;"" width=""487"" height=""250"" class=""chartjs-render-monitor""></canvas>
                </div>
            </div>
            <!-- /.card-body -->
        </div>
    </div>
</div>
<div class=""row"">
    <!-- BAR CHART -->
    <!-- /.card -->
    <div class=""col-md-6"">
        <div class=""card card-success "">
            <div class=""card-header bg-colorBlack"">
                <h3 class=""card-title"">Technician</h3>

            </div>
            <div class=""card-body"">
                <div class=""chart"">
                    <div class=""chartjs-size-monitor""><div class=""chartjs-size-monitor-expand""><div");
            BeginWriteAttribute("class", " class=\"", 13602, "\"", 13610, 0);
            EndWriteAttribute();
            WriteLiteral("></div></div><div class=\"chartjs-size-monitor-shrink\"><div");
            BeginWriteAttribute("class", " class=\"", 13669, "\"", 13677, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div></div></div>
                    <canvas id=""tech"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%; display: block; width: 487px;"" width=""487"" height=""250"" class=""chartjs-render-monitor""></canvas>
                </div>
            </div>
            <!-- /.card-body -->
        </div>
    </div>
    <div class=""col-md-6"">
        <div class=""card card-success"" style=""display:none;"">
            <div class=""card-header bg-colorBlack"">
                <h3 class=""card-title"">Pending Orders</h3>


            </div>
            <div class=""card-body"">
                <div class=""chart"">
                    <div class=""chartjs-size-monitor""><div class=""chartjs-size-monitor-expand""><div");
            BeginWriteAttribute("class", " class=\"", 14419, "\"", 14427, 0);
            EndWriteAttribute();
            WriteLiteral("></div></div><div class=\"chartjs-size-monitor-shrink\"><div");
            BeginWriteAttribute("class", " class=\"", 14486, "\"", 14494, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div></div></div>
                    <canvas id=""PendingOrders"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%; display: block; width: 487px;"" width=""487"" height=""250"" class=""chartjs-render-monitor""></canvas>
                </div>
            </div>

        </div>
    </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarGuru.ViewModels.CustomerViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
