#pragma checksum "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9098a00caa767f2006748078f239ea5b6b0d183d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reviews_UserReviews), @"mvc.1.0.view", @"/Views/Reviews/UserReviews.cshtml")]
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
#line 1 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\_ViewImports.cshtml"
using BookRecommendationWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\_ViewImports.cshtml"
using BookRecommendationWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9098a00caa767f2006748078f239ea5b6b0d183d", @"/Views/Reviews/UserReviews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f35c2b5a27a4798e93dcf5cb20a49135670c03f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Reviews_UserReviews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Review>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Books", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BookDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("review-book-title"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("review-cover-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<h1 style=\"margin:50px 22% 50px 22%\">Your reviews</h1>\r\n\r\n<ul class=\"review-list\">\r\n");
#nullable restore
#line 8 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
     if (Model.Any())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
         foreach (var review in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"review-list-item\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9098a00caa767f2006748078f239ea5b6b0d183d5694", async() => {
#nullable restore
#line 13 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
                                                                                                                               Write(review.Book.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-bookId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
                                                                         WriteLiteral(review.Book.BookId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["bookId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-bookId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["bookId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9098a00caa767f2006748078f239ea5b6b0d183d8583", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 471, "~/images/covers/", 471, 16, true);
#nullable restore
#line 14 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
AddHtmlAttributeValue("", 487, review.Book.ImageFile, 487, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <p class=\"review-book-author\">");
#nullable restore
#line 15 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
                                         Write(review.Book.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <div class=\"review-rating\">\r\n                    <p class=\"review-date\">");
#nullable restore
#line 17 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
                                      Write(review.Date.ToString("dd-MMM-yyyy", new CultureInfo("en-GB")));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 18 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
                     for (int i = 0; i < review.Rating; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"fa fa-star checked\"></span>\r\n");
#nullable restore
#line 21 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
                     for (int i = review.Rating; i < 5; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"fa fa-star\"></span>\r\n");
#nullable restore
#line 25 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </li>\r\n");
#nullable restore
#line 28 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
         
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"no-results-message\">No reviews found</p>\r\n");
#nullable restore
#line 33 "C:\Users\bstar\GitHub\BookRecommendationWebApp\BookRecommendationWebApp\BookRecommendationWebApp\Views\Reviews\UserReviews.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Review>> Html { get; private set; }
    }
}
#pragma warning restore 1591
