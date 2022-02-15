using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission7_Higbee.Models.ViewModels;


namespace Mission7_Higbee.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-blah")] //what tag to target, which attributes it has
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory uhf;
        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]

        public ViewContext vc { get; set; } //view context allows us to see details per page

        public PageInfo PageBlah { get; set; } //page info used in controller
        public string PageAction { get; set; } //what to do for the page

        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);
            TagBuilder final = new TagBuilder("div"); //creates new tag helper for the div

            for (int i = 1; i<= PageBlah.TotalPages; i++) //what to do for the # of pages
            {
                TagBuilder tb = new TagBuilder("a"); //new tag builder for a tag

                tb.Attributes["href"]= uh.Action(PageAction, new { pageNum = i }); //what to include
                tb.InnerHtml.Append(i.ToString()+ "   "); //appends page number
                tb.AddCssClass("btn btn-dark"); //styles the button
                final.InnerHtml.AppendHtml(tb); //appends final button
            }
            tho.Content.AppendHtml(final.InnerHtml); //appends final innerhtml
        }
    }
}
