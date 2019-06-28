using HtmlBuilder.Structure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Front.Ajax
{
    /// <summary>
    /// Navigation 的摘要说明
    /// </summary>
    public class Ajax_Navigation : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            string root = string.IsNullOrEmpty(context.Request["Root"])? "root":context.Request["Root"].ToString();
            string result = HtmlBuilder.BuildNavigation.Request(root,GetData());
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

        //private string BuildHtml(string root)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    List<NavigationData> navigationDatas = GetData();
        //    List<NavigationData> rootList = (from c in navigationDatas where c.ParentKey == root select c).ToList();
        //    builder.AppendLine("<ul class='navbar-nav  flex-column'>");
        //    foreach(NavigationData data in rootList)
        //    {
        //        builder.AppendLine("<li class='nav-item'>");
        //        builder.AppendLine($"<a class='nav-link font-weight-bold' href='{data.Href}'>{data.Value}</a>");
        //        List<NavigationData> itemList = (from c in navigationDatas where c.ParentKey == data.Key select c).ToList();
        //        if (itemList.Count > 0)
        //        {
        //            builder.AppendLine("<ul style='list-style:none;'>");
        //            foreach (NavigationData item in itemList)
        //            {
        //                builder.AppendLine("<li class='nav-item' style='margin-left:-10px'>");
        //                builder.AppendLine($"<a class='nav-link' href='{item.Href}'>{item.Value}</a>");
        //                builder.AppendLine("</li>");
        //            }
        //            builder.AppendLine("</ul>");
        //        }
        //        builder.AppendLine("</li>");
        //    }
        //    builder.AppendLine("</ul>");

        //    return builder.ToString();
        //}
        
        //测试用
        private List<NavigationData> GetData()
        {
            return new List<NavigationData>()
            {
                new NavigationData()
                {
                    Key="group1",
                    ParentKey="root",
                    Value="卡务中心",
                    Icon="",
                    Kind="group",
                    Href="#"
                },
                new NavigationData()
                {
                    Key="item1",
                    ParentKey="group1",
                    Value="部门档案",
                    Icon="",
                    Kind="item",
                    Href="#"
                },
                new NavigationData()
                {
                    Key="item2",
                    ParentKey="group1",
                    Value="人员档案",
                    Icon="",
                    Kind="item",
                    Href="#"
                },
                new NavigationData()
                {
                    Key="group2",
                    ParentKey="root",
                    Value="消费系统",
                    Icon="",
                    Kind="group",
                    Href="#"
                },
                new NavigationData()
                {
                    Key="group3",
                    ParentKey="root1",
                    Value="考勤系统",
                    Icon="",
                    Kind="group",
                    Href="#"
                },
            };
        }
    }
    
}