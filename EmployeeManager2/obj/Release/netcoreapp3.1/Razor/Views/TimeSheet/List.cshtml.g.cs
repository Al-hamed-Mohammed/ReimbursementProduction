#pragma checksum "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed81d235afb3410f267ff85a0e8783d549e54c1b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TimeSheet_List), @"mvc.1.0.view", @"/Views/TimeSheet/List.cshtml")]
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
#line 1 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\_ViewImports.cshtml"
using EmployeeManager2.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\_ViewImports.cshtml"
using EmployeeManager2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\_ViewImports.cshtml"
using EmployeeManager2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed81d235afb3410f267ff85a0e8783d549e54c1b", @"/Views/TimeSheet/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e322feb52d7927cd683d652238fb59407f744364", @"/Views/_ViewImports.cshtml")]
    public class Views_TimeSheet_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EmployeeManager2.Models.TimeSheet>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ddllastname"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_TimeSheetLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>List</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed81d235afb3410f267ff85a0e8783d549e54c1b5416", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n\r\n\r\n<div class=\"form-group row\">\r\n\r\n\r\n    <label class=\"col-sm-2 col-form-label\"> Search By Last Name: </label>\r\n    <div class=\"col-sm-6\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed81d235afb3410f267ff85a0e8783d549e54c1b6756", async() => {
                WriteLiteral("\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 23 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(ViewBag.Listofnames,"Value", "Text"));

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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


<div class=""form-group row"">


    <label class=""col-sm-2 col-form-label""> Search By First Name: </label>
    <div class=""col-sm-6"">
        <input type=""text"" name=""name"" id=""name"" placeholder=""Search by Name"" class=""form-control"">

    </div>
");
            WriteLiteral(@"</div>
<div class=""form-group row"">
    <label class=""col-sm-2 col-form-label""> Date (From) : </label>
    <div class=""col-sm-3"">
        <input type=""date"" asp-format=""{0:MM-dd-yyyy}"" name=""fromdate"" id=""fromdate"" placeholder=""From Date"" class=""form-control"">
    </div>

</div>
<div class=""form-group row"">
    <label class=""col-sm-2 col-form-label"">  Date (To) : </label>
    <div class=""col-sm-3"">
        <input type=""date"" asp-format=""{0:MM-dd-yyyy}"" name=""todate"" id=""todate"" placeholder=""To Date"" class=""form-control"">
    </div>
    <div class=""col-sm-1"">
        <input type=""submit"" class=""btn btn-primary"" id=""btndatesearch"" value=""Filter""");
            BeginWriteAttribute("onclick", " onclick=\"", 1672, "\"", 1867, 12);
            WriteAttributeValue("", 1682, "location.href=\'", 1682, 15, true);
#nullable restore
#line 53 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
WriteAttributeValue("", 1697, Url.Action("Search", "TimeSheet"), 1697, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1731, "?from=\'", 1731, 7, true);
            WriteAttributeValue(" ", 1738, "+", 1739, 2, true);
            WriteAttributeValue(" ", 1740, "$(\'#fromdate\').val()", 1741, 21, true);
            WriteAttributeValue(" ", 1761, "+", 1762, 2, true);
            WriteAttributeValue(" ", 1763, "\'&to=\'+$(\'#todate\').val()", 1764, 26, true);
            WriteAttributeValue(" ", 1789, "+", 1790, 2, true);
            WriteAttributeValue(" ", 1791, "\'&byfirstname=\'+$(\'#name\').val()", 1792, 33, true);
            WriteAttributeValue(" ", 1824, "+", 1825, 2, true);
            WriteAttributeValue(" ", 1826, "\'&bylastname=\'+$(\'#ddllastname\').val()", 1827, 39, true);
            WriteAttributeValue("  ", 1865, "", 1867, 2, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </div>\r\n    <input type=\"button\" class=\"col-sm-1 btn btn-light\" id=\"btnclear\" value=\"Clear\"");
            BeginWriteAttribute("onclick", "  onclick=\"", 1968, "\"", 2027, 3);
            WriteAttributeValue("", 1979, "location.href=\'", 1979, 15, true);
#nullable restore
#line 55 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
WriteAttributeValue("", 1994, Url.Action("list", "TimeSheet"), 1994, 32, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2026, "\'", 2026, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <div class=\"col-sm-5\" style=\"text-align:right;font-weight:bold\">\r\n        <label class=\" col-sm-4 col-form-label\"> Total Hours: </label>\r\n\r\n        ");
#nullable restore
#line 59 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
   Write(Html.Label("Name", (string)ViewBag.total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 69 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 72 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 75 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 78 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
           Write(Html.DisplayNameFor(model => model.Hours));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 84 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
         if (Model != null)
        {


            foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 93 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 96 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 99 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 102 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Hours));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 105 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { id = item.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 106 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id = item.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 107 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { id = item.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 110 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed81d235afb3410f267ff85a0e8783d549e54c1b16540", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<script type=\"text/javascript\">\r\n        $(function ()\r\n        {\r\n            \r\n            var name = \'");
#nullable restore
#line 121 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
                   Write(ViewBag.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            $(\"#name\").val(name);\r\n\r\n            var fromdate = \'");
#nullable restore
#line 124 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
                       Write(ViewBag.fromdate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            $(\"#fromdate\").val(fromdate);\r\n\r\n            var todate = \'");
#nullable restore
#line 127 "D:\New folder\IMCES-Employee-Management-system-Production\EmployeeManager2\Views\TimeSheet\List.cshtml"
                     Write(ViewBag.todate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            $(\"#todate\").val(todate);\r\n        });\r\n\r\n\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EmployeeManager2.Models.TimeSheet>> Html { get; private set; }
    }
}
#pragma warning restore 1591
