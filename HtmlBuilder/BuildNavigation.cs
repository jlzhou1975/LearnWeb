using HtmlBuilder.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlBuilder
{
    public class BuildNavigation
    {
        private BuildNavigation() { }

        public static string Request(string rootId, List<NavigationData> navigationDatas)
        {
            StringBuilder builder = new StringBuilder();
            List<NavigationData> rootList = (from c in navigationDatas where c.ParentKey == rootId select c).ToList();
            builder.AppendLine("<ul class='navbar-nav  flex-column'>");
            foreach (NavigationData data in rootList)
            {
                builder.AppendLine("<li class='nav-item'>");
                builder.AppendLine($"<a class='nav-link font-weight-bold' href='{data.Href}'>{data.Value}</a>");
                List<NavigationData> itemList = (from c in navigationDatas where c.ParentKey == data.Key select c).ToList();
                if (itemList.Count > 0)
                {
                    builder.AppendLine("<ul style='list-style:none;'>");
                    foreach (NavigationData item in itemList)
                    {
                        builder.AppendLine("<li class='nav-item' style='margin-left:-10px'>");
                        builder.AppendLine($"<a class='nav-link' href='{item.Href}'>{item.Value}</a>");
                        builder.AppendLine("</li>");
                    }
                    builder.AppendLine("</ul>");
                }
                builder.AppendLine("</li>");
            }
            builder.AppendLine("</ul>");

            return builder.ToString();
        }
    }
}
