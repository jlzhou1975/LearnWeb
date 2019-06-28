using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlBuilder
{
    public class BuildPager
    {
        private BuildPager() { }

        public static string Request(int recordCount, int pageIndex, int pageCount)
        {
            if (recordCount < 0 || pageIndex < 0 || pageCount < 0) throw new ArgumentOutOfRangeException("参数不允许<0");
            if (pageIndex > pageCount) pageIndex = pageCount;
            int startIndex = (pageIndex - 2 >= 1) ? pageIndex - 2 : 1;
            int endIndex = startIndex + 4 > pageCount ? pageCount : startIndex + 4;
            startIndex = endIndex - 4 > 0 ? endIndex - 4 : 1;
            bool ellipsis1 = (startIndex > 2) ? true : false;
            bool ellipsis2 = endIndex < pageCount - 1 ? true : false;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<nav class='d-flex justify-content-end'>");
            builder.AppendLine("<ul class='pagination pagination-sm form-inline'>");
            builder.AppendLine("<li class='page-item form-inline small' style='margin: 0 5px 0 0;'>");
            builder.AppendLine("<span>共</span>");
            builder.AppendLine($"<span style = 'margin:0 5px;' > {recordCount} </ span >");
            builder.AppendLine("<span> 条 </span>");
            builder.AppendLine("</li>");
            if (pageCount > 1)
            {
                if (pageIndex > 1)
                {
                    builder.AppendLine("<li class='page-item'>");
                    builder.AppendLine("<a class='page-link text-dark' href='#'>上一页</a>");
                    builder.AppendLine("</li>");
                }
                if(startIndex>1)
                {
                    if (pageIndex != 1)
                    {
                        builder.AppendLine("<li class='page-item'><a class='page-link text-dark' href='#'>1</a></li>");
                    }
                    else
                    {
                        builder.AppendLine("<li class='page-item active'><a class='page-link text-dark' href='#'>1</a></li>");
                    }
                }
                if (ellipsis1)
                {
                    builder.AppendLine("<li class='page-item small' style='margin:0 3px;'>…</li>");
                }
                for (int index = startIndex; index <= endIndex; index++)
                {
                    if (index == pageIndex)
                    {
                        builder.AppendLine($"<li class='page-item active'><a class='page-link text-dark' href='#'>{index}</a></li>");
                    }
                    else
                    {
                        builder.AppendLine($"<li class='page-item'><a class='page-link text-dark' href='#'>{index}</a></li>");
                    }
                }
                if (ellipsis2)
                {
                    builder.AppendLine("<li class='page-item small' style='margin:0 3px;'>…</li>");
                }
                if (endIndex < pageCount)
                {
                    builder.AppendLine($"<li class='page-item'><a class='page-link text-dark' href='#'>{pageCount}</a></li>");
                }
                if (pageIndex < pageCount)
                {
                    builder.AppendLine("<li class='page-item'><a class='page-link text-dark' href='#'>下一页</a></li>");
                }
                if (pageCount > 1)
                {
                    builder.AppendLine("<li class='page-item form-inline small' style='margin:0 10px;'>");
                    builder.AppendLine("<span>到第</span>");
                    builder.AppendLine("<input type = 'text' class='page-link text-dark' style='width:40px;text-align:center;margin:0 5px;' />");
                    builder.AppendLine("<span>页</span>");
                    builder.AppendLine("<a class='page-link text-dark' style='margin:0 5px;'>跳转</a>");
                    builder.AppendLine("</li>");
                }
            }
            builder.AppendLine("</ul>");
            builder.AppendLine("</nav>");
            return builder.ToString();
        }
    }
}
