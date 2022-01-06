#pragma checksum "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7972bc58a86f8df6b37e55143dada2ab36dc90af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Manage/Views/Dashboard/Index.cshtml")]
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
#line 1 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\_ViewImports.cshtml"
using HarrierFinalProject.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\_ViewImports.cshtml"
using HarrierFinalProject.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\_ViewImports.cshtml"
using HarrierFinalProject.Data.Models.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7972bc58a86f8df6b37e55143dada2ab36dc90af", @"/Areas/Manage/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a274e9240ef55a57b54d7f94d89b863944a79e67", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Dashboard\Index.cshtml"
   
    double soldCars = Model.Cars.Where(x => x.CarSituationId == 0).Count();
    double generalCars = Model.Cars.Count();
    double sellingCars = Model.Cars.Where(x => x.CarSituationId == 1).Count();

    double soldCarsRatio = Math.Ceiling(soldCars / generalCars * 100);
    double sellingCarsRatio = Math.Ceiling(100 - soldCarsRatio);


    double cheapestCars = Model.Cars.Where(x => x.Price < 30000).Count();
    double expensiveCars = Model.Cars.Where(x => x.Price > 30000).Count();

    double cheapCarRatio = Math.Ceiling(cheapestCars / generalCars * 100);
    double expensiveCarRatio = Math.Ceiling(100 - cheapCarRatio);
 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!--main content start-->
<section id=""main-content"">
    <section class=""wrapper"">
        <div class=""row"">
            <div class=""col-lg-9 main-chart"">
                <!--CUSTOM CHART START -->
                <div class=""border-head"">
                    <h3>USER VISITS</h3>
                </div>
                <div class=""custom-bar-chart"">
                    <ul class=""y-axis"">
                        <li><span>10.000</span></li>
                        <li><span>8.000</span></li>
                        <li><span>6.000</span></li>
                        <li><span>4.000</span></li>
                        <li><span>2.000</span></li>
                        <li><span>0</span></li>
                    </ul>
                    <div class=""bar"">
                        <div class=""title"">JAN</div>
                        <div class=""value tooltips"" data-original-title=""8.500"" data-toggle=""tooltip"" data-placement=""top"">85%</div>
                    </div>
                    <div");
            WriteLiteral(@" class=""bar "">
                        <div class=""title"">FEB</div>
                        <div class=""value tooltips"" data-original-title=""5.000"" data-toggle=""tooltip"" data-placement=""top"">50%</div>
                    </div>
                    <div class=""bar "">
                        <div class=""title"">MAR</div>
                        <div class=""value tooltips"" data-original-title=""6.000"" data-toggle=""tooltip"" data-placement=""top"">60%</div>
                    </div>
                    <div class=""bar "">
                        <div class=""title"">APR</div>
                        <div class=""value tooltips"" data-original-title=""4.500"" data-toggle=""tooltip"" data-placement=""top"">45%</div>
                    </div>
                    <div class=""bar"">
                        <div class=""title"">MAY</div>
                        <div class=""value tooltips"" data-original-title=""3.200"" data-toggle=""tooltip"" data-placement=""top"">32%</div>
                    </div>
                    <div ");
            WriteLiteral(@"class=""bar "">
                        <div class=""title"">JUN</div>
                        <div class=""value tooltips"" data-original-title=""6.200"" data-toggle=""tooltip"" data-placement=""top"">62%</div>
                    </div>
                    <div class=""bar"">
                        <div class=""title"">JUL</div>
                        <div class=""value tooltips"" data-original-title=""7.500"" data-toggle=""tooltip"" data-placement=""top"">75%</div>
                    </div>
                </div>
                <!--custom chart end-->
                <div class=""row mt"">
                    <!-- SERVER STATUS PANELS -->
                    <div class=""col-md-4 col-sm-4 mb"">
                        <div class=""grey-panel pn donut-chart"">
                            <div class=""grey-header"">
                                <h5>Order LOAD</h5>
                            </div>
                            <canvas id=""serverstatus01"" height=""120"" width=""120""></canvas>
                           ");
            WriteLiteral(" <script>\r\n                    var doughnutData = [{\r\n                        value:  ");
#nullable restore
#line 76 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Dashboard\Index.cshtml"
                           Write(soldCarsRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n                       color: \"#FF6B6B\"\r\n                      },\r\n                      {\r\n                        value:  ");
#nullable restore
#line 80 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Dashboard\Index.cshtml"
                           Write(sellingCarsRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral(@",
                        color: ""#fdfdfd""
                      }
                    ];
                    var myDoughnut = new Chart(document.getElementById(""serverstatus01"").getContext(""2d"")).Doughnut(doughnutData);
                            </script>
                            <div class=""row"">
                                <div class=""col-sm-6 col-xs-6 goleft"">
                                    <p>Selling<br />Increase:</p>
                                </div>
                                <div class=""col-sm-6 col-xs-6"">
                                    <h2 class=""mt-4"" style=""font-size:30px"">");
#nullable restore
#line 91 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Dashboard\Index.cshtml"
                                                                       Write(soldCarsRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" %</h2>
                                </div>
                            </div>
                        </div>
                        <!-- /grey-panel -->
                    </div>
                    <!-- /col-md-4-->
                    <div class=""col-md-4 col-sm-4 mb"">
                        <div class=""darkblue-panel pn"">
                            <div class=""darkblue-header"">
                                <h5>DROPBOX STATICS</h5>
                            </div>
                            <canvas id=""serverstatus02"" height=""120"" width=""120""></canvas>
                            <script>
                    var doughnutData = [{
                        value: 60,
                        color: ""#1c9ca7""
                      },
                      {
                        value: 40,
                        color: ""#f68275""
                      }
                    ];
                    var myDoughnut = new Chart(document.getElementById(""serverstatus02"").getContext");
            WriteLiteral(@"(""2d"")).Doughnut(doughnutData);
                            </script>
                            <p>April 17, 2014</p>
                            <footer>
                                <div class=""pull-left"">
                                    <h5><i class=""fa fa-hdd-o""></i> 17 GB</h5>
                                </div>
                                <div class=""pull-right"">
                                    <h5>60% Used</h5>
                                </div>
                            </footer>
                        </div>
                        <!--  /darkblue panel -->
                    </div>
                    <!-- /col-md-4 -->
                    <div class=""col-md-4 col-sm-4 mb"">
                        <!-- REVENUE PANEL -->
                        <div class=""green-panel pn"">
                            <div class=""green-header"">
                                <h5>REVENUE</h5>
                            </div>
                            <div class=""cha");
            WriteLiteral(@"rt mt"">
                                <div class=""sparkline"" data-type=""line"" data-resize=""true"" data-height=""75"" data-width=""90%"" data-line-width=""1"" data-line-color=""#fff"" data-spot-color=""#fff"" data-fill-color="""" data-highlight-line-color=""#fff"" data-spot-radius=""4"" data-data=""[200,135,667,333,526,996,564,123,890,464,655]""></div>
                            </div>
                            <p class=""mt""><b>$ 17,980</b><br />Month Income</p>
                        </div>
                    </div>
                    <!-- /col-md-4 -->
                </div>
                <!-- /row -->
             
            </div>
            <!-- /row -->
            <div class=""row"">
                <div class=""col-lg-4 col-md-4 col-sm-4 mb"">
                    <div class=""product-panel-2 pn"">
                        <div class=""badge badge-hot"">HOT</div>
                        <img src=""img/product.jpg"" width=""200""");
            BeginWriteAttribute("alt", " alt=\"", 7631, "\"", 7637, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                        <h5 class=""mt"">Flat Pack Heritage</h5>
                        <h6>TOTAL SALES: 1388</h6>
                        <button class=""btn btn-small btn-theme04"">FULL REPORT</button>
                    </div>
                </div>
                <!-- /col-md-4 -->
                <!--  PROFILE 02 PANEL -->
                <!--/ col-md-4 -->
                <div class=""col-md-4 col-sm-4 col-lg-4 mb"">
                    <div class=""green-panel pn"">
                        <div class=""green-header"">
                            <h5 style=""color: #fffffd"">Qiymeti 30000 AZN-den asagi olan masinlar</h5>
                        </div>
                        <canvas id=""serverstatus03"" height=""120"" width=""120""></canvas>
                        <script>
                            var doughnutData = [{
                                value:  ");
#nullable restore
#line 168 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Dashboard\Index.cshtml"
                                   Write(expensiveCarRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ,\r\n                                color: \"#2b2b2b\"\r\n                            },\r\n                            {\r\n                                value: ");
#nullable restore
#line 172 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Dashboard\Index.cshtml"
                                  Write(cheapCarRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral(@",
                                color: ""#fffffd""
                            }
                            ];
                            var myDoughnut = new Chart(document.getElementById(""serverstatus03"").getContext(""2d"")).Doughnut(doughnutData);
                        </script>
                        <h3>");
#nullable restore
#line 178 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Dashboard\Index.cshtml"
                       Write(cheapCarRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" % Cheapest Cars</h3>
                    </div>
                </div>
            
                <!-- /col-md-4 -->
            </div>
            <!-- /row -->
        </div>
        <!-- /col-lg-9 END SECTION MIDDLE -->
        <!-- **********************************************************************************************************************************************************
            RIGHT SIDEBAR CONTENT
            *********************************************************************************************************************************************************** -->
        <div class=""ds d-flex justify-content-between"">
            <!--COMPLETED ACTIONS DONUTS CHART-->
            <div class=""donut-main col-4"">
                <h4>Qiymeti 30000 AZN-den cox olan masinlar</h4>
                <canvas id=""newchart"" height=""130"" width=""130""></canvas>
                <script>
                var doughnutData = [{
                    value: ");
#nullable restore
#line 197 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Dashboard\Index.cshtml"
                      Write(cheapCarRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ,\r\n                    color: \"#4ECDC4\"\r\n                  },\r\n                  {\r\n                    value: ");
#nullable restore
#line 201 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Dashboard\Index.cshtml"
                      Write(expensiveCarRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n                    color: \"#fdfdfd\"\r\n                  }\r\n                ];\r\n                var myDoughnut = new Chart(document.getElementById(\"newchart\").getContext(\"2d\")).Doughnut(doughnutData);\r\n                </script>\r\n                <h3>");
#nullable restore
#line 207 "C:\Users\binye\Desktop\Harrier-FinalProject-BackEnd\HarrierFinalProject\HarrierFinalProject\Areas\Manage\Views\Dashboard\Index.cshtml"
               Write(expensiveCarRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" % Expensive Cars</h3>
            </div>
            <!--NEW EARNING STATS -->
            <div class=""mb-0 panel terques-chart col-4"" style=""background-color:#797979"">
                <div class=""panel-body"">
                    <div class=""chart"">
                        <div class=""centered"">
                            <span style=""color:white"">TODAY EARNINGS</span>
                            <strong style=""color:white"">$ 890,00 | 15%</strong>
                        </div>
                        <br>
                        <div class=""sparkline"" data-type=""line"" data-resize=""true"" data-height=""75"" data-width=""90%"" data-line-width=""1"" data-line-color=""#fff"" data-spot-color=""#fff"" data-fill-color="""" data-highlight-line-color=""#fff"" data-spot-radius=""4"" data-data=""[200,135,667,333,526,996,564,123,890,564,455]""></div>
                    </div>
                </div>
            </div>
            <!--new earning end-->
        
          
            <!-- CALENDAR-->
            <div ");
            WriteLiteral(@"id=""calendar"" class=""mb-0 col-4"">
                <div class=""panel green-panel no-margin"">
                    <div class=""panel-body"">
                        <div id=""date-popover"" class=""popover top"" style=""cursor: pointer; disadding: block; margin-left: 33%; margin-top: -50px; width: 175px;"">
                            <div class=""arrow""></div>
                            <h3 class=""popover-title"" style=""disadding: none;""></h3>
                            <div id=""date-popover-content"" class=""popover-content""></div>
                        </div>
                        <div id=""my-calendar""></div>
                    </div>
                </div>
            </div>
            <!-- / calendar -->
        </div>
        <!-- /col-lg-3 -->
    </div>
    <!-- /row -->
</section>
</section>
<!--main content end-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DashViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
