#pragma checksum "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ce66bd7fb8ea33361a22ca0b1d9d73975465d97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SurveyStatistic__Responses), @"mvc.1.0.view", @"/Views/SurveyStatistic/_Responses.cshtml")]
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
#line 1 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\_ViewImports.cshtml"
using SV.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\_ViewImports.cshtml"
using SV.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\_ViewImports.cshtml"
using SV.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\_ViewImports.cshtml"
using SV.WebApp.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ce66bd7fb8ea33361a22ca0b1d9d73975465d97", @"/Views/SurveyStatistic/_Responses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1190a92d7293542a140bd67903d20c4c77e3e4b1", @"/Views/_ViewImports.cshtml")]
    public class Views_SurveyStatistic__Responses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SurveyResponseProfile>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Preview", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("View Response"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
  
    ViewData["Title"] = ViewBag.Survey.Name + " - Responses";
    int counter = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"box\">\r\n    <div class=\"header\">\r\n        <h4>\r\n            ");
#nullable restore
#line 11 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
       Write(ViewBag.Survey.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Responses (");
#nullable restore
#line 11 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
                                         Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n            <a class=\"btn btn-small pull-right poscenter\"");
            BeginWriteAttribute("href", " href=\"", 318, "\"", 370, 2);
            WriteAttributeValue("", 325, "/surveystatistic/dashboard/", 325, 27, true);
#nullable restore
#line 12 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
WriteAttributeValue("", 352, ViewBag.Survey.Id, 352, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Dashboard</a>\r\n        </h4>\r\n    </div>\r\n    <div class=\"content\">\r\n");
#nullable restore
#line 16 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""normal bt-dataTable"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""dataTable"">
            <thead>
                <tr>
                    <th>Sr No.</th>
                    <th>Response Date</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 27 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 30 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
                        Write(counter++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 31 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
                       Write(item.ResponseOn.ToString("dd MMM yyyy, hh':'mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"w80\">\r\n                            <ul class=\"table-actions\">\r\n                                <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ce66bd7fb8ea33361a22ca0b1d9d73975465d977474", async() => {
                WriteLiteral("<i class=\"icon-eye-open\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
                                                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n\r\n\r\n                            </ul>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 40 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 43 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"pad20\">No Responses found</p>\r\n");
#nullable restore
#line 47 "E:\Complete Systems\Survey Solution\SV\SV.WebApp\Views\SurveyStatistic\_Responses.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SurveyResponseProfile>> Html { get; private set; }
    }
}
#pragma warning restore 1591
