using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SportSore.WebUI.Models;

namespace SportSore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageInfo pageInfo,
            Func<int, string> pageUrl) {
            StringBuilder result = new StringBuilder();
            //creiamo per ogni pagina il tag <a href = url eccc /> 
            for (int i = 1; i <= pageInfo.TotalPgaes; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString(); 

                if( i == pageInfo.CurrentPage)
                {
                    //settiamo stile css per colore diverso 
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}