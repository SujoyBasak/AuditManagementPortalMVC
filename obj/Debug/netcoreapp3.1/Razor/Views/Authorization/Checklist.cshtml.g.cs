#pragma checksum "C:\Users\Sujoy Basak\source\repos\AuditManagementPortalMVC\Views\Authorization\Checklist.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94f5905c06414a64ab122226613fedd058d12882"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authorization_Checklist), @"mvc.1.0.view", @"/Views/Authorization/Checklist.cshtml")]
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
#line 1 "C:\Users\Sujoy Basak\source\repos\AuditManagementPortalMVC\Views\_ViewImports.cshtml"
using AuditManagementPortalMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Sujoy Basak\source\repos\AuditManagementPortalMVC\Views\_ViewImports.cshtml"
using AuditManagementPortalMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94f5905c06414a64ab122226613fedd058d12882", @"/Views/Authorization/Checklist.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9536eb6c77b97e39910b63159180d2e5e761407", @"/Views/_ViewImports.cshtml")]
    public class Views_Authorization_Checklist : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AuditManagementPortalMVC.Models.ChecklistQuestions>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Sujoy Basak\source\repos\AuditManagementPortalMVC\Views\Authorization\Checklist.cshtml"
  
    ViewData["Title"] = "Checklist";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Checklist</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\Sujoy Basak\source\repos\AuditManagementPortalMVC\Views\Authorization\Checklist.cshtml"
           Write(Html.DisplayNameFor(model => model.QuestionNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\Sujoy Basak\source\repos\AuditManagementPortalMVC\Views\Authorization\Checklist.cshtml"
           Write(Html.DisplayNameFor(model => model.Question));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 23 "C:\Users\Sujoy Basak\source\repos\AuditManagementPortalMVC\Views\Authorization\Checklist.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 26 "C:\Users\Sujoy Basak\source\repos\AuditManagementPortalMVC\Views\Authorization\Checklist.cshtml"
           Write(Html.DisplayFor(modelItem => item.QuestionNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 29 "C:\Users\Sujoy Basak\source\repos\AuditManagementPortalMVC\Views\Authorization\Checklist.cshtml"
           Write(Html.DisplayFor(modelItem => item.Question));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n        </tr>\r\n");
#nullable restore
#line 33 "C:\Users\Sujoy Basak\source\repos\AuditManagementPortalMVC\Views\Authorization\Checklist.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AuditManagementPortalMVC.Models.ChecklistQuestions>> Html { get; private set; }
    }
}
#pragma warning restore 1591
