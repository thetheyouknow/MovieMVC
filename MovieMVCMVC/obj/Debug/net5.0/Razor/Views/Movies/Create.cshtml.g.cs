#pragma checksum "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/Movies/Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "291e73b9ec430da15f8679ea1d11cd04ab34268d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Create), @"mvc.1.0.view", @"/Views/Movies/Create.cshtml")]
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
#line 1 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/_ViewImports.cshtml"
using MovieMVCMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/_ViewImports.cshtml"
using MovieMVCMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"291e73b9ec430da15f8679ea1d11cd04ab34268d", @"/Views/Movies/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b82e32b1a8b0bcda5351fb68c1468ccef8ad542", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieMVCMVC.Models.MoviesModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString("selected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/Movies/Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "291e73b9ec430da15f8679ea1d11cd04ab34268d3892", async() => {
                WriteLiteral("\n    <meta name=\"viewport\" content=\"width=device-width\" />\n    <title>creation</title>\n\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "291e73b9ec430da15f8679ea1d11cd04ab34268d4934", async() => {
                WriteLiteral("\n");
#nullable restore
#line 12 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/Movies/Create.cshtml"
     using (Html.BeginForm("Create", "Movies", FormMethod.Post))
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <table cellpadding=\"7\" cellspacing=\"0\">\n            <tr>\n                <th colspan=\"3\" align=\"center\">Create new movie; next id is ");
#nullable restore
#line 16 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/Movies/Create.cshtml"
                                                                       Write(ViewData["nextID"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(";</th>\n            </tr>\n            <tr>\n                <td>Title: </td>\n                    <td>\n                        ");
#nullable restore
#line 21 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/Movies/Create.cshtml"
                   Write(Html.TextBoxFor(t => t.Title));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </td>\n            </tr>\n            <tr>\n                <td>Runtime:  </td>\n                    <td>\n                        ");
#nullable restore
#line 27 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/Movies/Create.cshtml"
                   Write(Html.TextBoxFor(t => t.Runtime));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </td>\n            </tr>\n             \n                <td>Director: </td>\n                    <td class = \"dropdown\">\n                        <select name=\"DirectorChoice\">\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "291e73b9ec430da15f8679ea1d11cd04ab34268d6923", async() => {
                    WriteLiteral(" Choose a Director");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 35 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/Movies/Create.cshtml"
                             foreach (var item in @Model.DirectorList)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "291e73b9ec430da15f8679ea1d11cd04ab34268d8348", async() => {
#nullable restore
#line 37 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/Movies/Create.cshtml"
                                                            Write(item.DirectorName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/Movies/Create.cshtml"
                                   WriteLiteral(item.DirectorID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 38 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/Movies/Create.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </select>\n                    </td>\n            <tr>\n                <td><input type=\"submit\" value=\"Submit\" class=\"btn btn-primary\"/></td>\n            </tr>\n        </table>\n");
#nullable restore
#line 45 "/Users/savittasivapalan/Desktop/VS/MovieProject/MovieMVCMVC/Views/Movies/Create.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieMVCMVC.Models.MoviesModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
