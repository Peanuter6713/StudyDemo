
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDemo.Utils.RazorExtension
{
    public static class HtmlHelperExtension
    {
        public static IHtmlContent Br(this IHtmlHelper helper)
        {
            return new HtmlString($"</br>");
        }

        public static IHtmlContent Img(this IHtmlHelper helper, string src)
        {
            return new HtmlString($"<img src='{src}'</img>");
        }
    }
}
