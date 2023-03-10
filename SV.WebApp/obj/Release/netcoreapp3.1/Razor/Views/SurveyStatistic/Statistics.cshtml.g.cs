#pragma checksum "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf3d280c1bb31f1b5741880d1dbf6069182964d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SurveyStatistic_Statistics), @"mvc.1.0.view", @"/Views/SurveyStatistic/Statistics.cshtml")]
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
#line 1 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\_ViewImports.cshtml"
using SV.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\_ViewImports.cshtml"
using SV.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\_ViewImports.cshtml"
using SV.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\_ViewImports.cshtml"
using SV.WebApp.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf3d280c1bb31f1b5741880d1dbf6069182964d5", @"/Views/SurveyStatistic/Statistics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d25336d0c18f3e1fdf2947ea67e1c8f988f4f74", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SurveyStatistic_Statistics : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Answer>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
  
    ViewData["Title"] = "Survey Name";

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n<div id=\"main-content\">\r\n                        \r\n    <div class=\"notice_messages\"></div>\r\n");
#nullable restore
#line 10 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
     if(Model.Count() > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""normal bt-dataTable"" border=""0""  cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""dataTable"">
            <thead>
                <tr>
                    <th>Count</th>
                    <th>Answer</th>
                    <th>Percentage</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 21 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td class=\"w60\">");
#nullable restore
#line 24 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
                                   Write(Model.Where(r => r.AnswerText == item.AnswerText).Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 25 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
                       Write(item.AnswerText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"w80\">");
#nullable restore
#line 26 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
                                    Write(new Random().Next(100));

#line default
#line hidden
#nullable disable
            WriteLiteral("%</td>\r\n                    </tr>   \r\n");
#nullable restore
#line 28 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
                }	

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 31 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>No answers found for this question.</p>    \r\n");
#nullable restore
#line 35 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        
    <div class=""mb20""></div>
                                    
    <div class=""row-fluid grid-set"">
        <div class=""span6"">
            <div class=""box"">
                <div class=""header""><h4>Answer Fact</h4></div>
                <div class=""content pad"" id=""answers-table"">
");
#nullable restore
#line 44 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
                     if(Model.Count() > 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <ul class=\"unordered\">\r\n                            <li>");
#nullable restore
#line 47 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
                           Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(" answered this question</li>\r\n                            <li>Most of the users are from: Location</li>\r\n                            <li>The answer rate to this question is: ");
#nullable restore
#line 49 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
                                                                 Write(new Random().Next(100));

#line default
#line hidden
#nullable disable
            WriteLiteral("%</li>\r\n                        </ul>\r\n");
#nullable restore
#line 51 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p>No data found to render facts</p>   \r\n");
#nullable restore
#line 55 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>  
            </div>  
        </div>

                        
        <div class=""span6"">
            <div class=""box"">
                <div class=""header""><h4>Pie Chart</h4></div>
                <div class=""content pad"">
                    <div id=""flot-pie"" class=""flot-pie""></div>

");
            WriteLiteral("                </div> \r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n    \r\n");
#nullable restore
#line 75 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
     if(true)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <button class=\"btn input-block-level mb20\">Export to CSV</button>   \r\n");
#nullable restore
#line 78 "E:\Enum Solutions\SurveySolution\SV.WebApp\Views\SurveyStatistic\Statistics.cshtml"
    }                        

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Answer>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
