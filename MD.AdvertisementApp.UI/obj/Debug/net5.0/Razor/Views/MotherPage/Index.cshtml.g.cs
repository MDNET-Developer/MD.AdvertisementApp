#pragma checksum "D:\MyProjects\NEW\MD.AdvertisementApp\MD.AdvertisementApp.UI\Views\MotherPage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e35a8094075e2fd3fd1fdb8b614cd5d16076432b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MotherPage_Index), @"mvc.1.0.view", @"/Views/MotherPage/Index.cshtml")]
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
#line 1 "D:\MyProjects\NEW\MD.AdvertisementApp\MD.AdvertisementApp.UI\Views\_ViewImports.cshtml"
using MD.AdvertisementApp.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MyProjects\NEW\MD.AdvertisementApp\MD.AdvertisementApp.UI\Views\_ViewImports.cshtml"
using MD.AdvertisementApp.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MyProjects\NEW\MD.AdvertisementApp\MD.AdvertisementApp.UI\Views\_ViewImports.cshtml"
using MD.AdvertisementApp.UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e35a8094075e2fd3fd1fdb8b614cd5d16076432b", @"/Views/MotherPage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4daefef28f7d6b6d3e13b33392a3a61e345583ad", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_MotherPage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProvidedServiceListDto>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\MyProjects\NEW\MD.AdvertisementApp\MD.AdvertisementApp.UI\Views\MotherPage\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_mainLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Xidm??tl??rimiz</h1>\r\n<Div class=\"row\">\r\n\r\n\r\n");
#nullable restore
#line 11 "D:\MyProjects\NEW\MD.AdvertisementApp\MD.AdvertisementApp.UI\Views\MotherPage\Index.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-sm\">\r\n    <div style=\"width:15.5cm;height:5cm;\" class=\"card bg-dark text-white\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 325, "\"", 346, 1);
#nullable restore
#line 15 "D:\MyProjects\NEW\MD.AdvertisementApp\MD.AdvertisementApp.UI\Views\MotherPage\Index.cshtml"
WriteAttributeValue("", 331, item.ImagePath, 331, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img\" alt=\"...\">\r\n        <div class=\"card-img-overlay\">\r\n            <h5 class=\"card-title\">");
#nullable restore
#line 17 "D:\MyProjects\NEW\MD.AdvertisementApp\MD.AdvertisementApp.UI\Views\MotherPage\Index.cshtml"
                              Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <p class=\"card-text\">");
#nullable restore
#line 18 "D:\MyProjects\NEW\MD.AdvertisementApp\MD.AdvertisementApp.UI\Views\MotherPage\Index.cshtml"
                            Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"card-text\">");
#nullable restore
#line 19 "D:\MyProjects\NEW\MD.AdvertisementApp\MD.AdvertisementApp.UI\Views\MotherPage\Index.cshtml"
                            Write(item.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n    </div>\r\n");
#nullable restore
#line 23 "D:\MyProjects\NEW\MD.AdvertisementApp\MD.AdvertisementApp.UI\Views\MotherPage\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</Div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProvidedServiceListDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
