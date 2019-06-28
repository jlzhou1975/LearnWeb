using HtmlBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Ajax
{
    /// <summary>
    /// Ajax_Pager 的摘要说明
    /// </summary>
    public class Ajax_Pager : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int recordCount = Convert.ToInt32(context.Request["RecordCount"]);
            int pageIndex = Convert.ToInt32(context.Request["PageIndex"]);
            int pageCount = Convert.ToInt32(context.Request["PageCount"]);
            context.Response.Write(BuildPager.Request(recordCount, pageIndex, pageCount));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}