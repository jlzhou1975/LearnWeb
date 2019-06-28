using HtmlBuilder;
using HtmlBuilder.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Ajax
{
    /// <summary>
    /// Table 的摘要说明
    /// </summary>
    public class Ajax_Table : IHttpHandler
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
            context.Response.ContentType = "text/plain";
            context.Response.Write(BuildHtml());
        }

        private string BuildHtml()
        {
            Dictionary<string, string> columnTitle = new Dictionary<string, string>()
            {
                {"Key","主键" },
                {"ParentKey","ParentKey" },
                {"Value","内容" },
                {"Icon", "Icon"},
                {"Kind", "类型"},
                {"Href", "Href"},
            };
            return BuildTable.Request(columnTitle, null, GetData());
        }


        //测试用
        private List<object> GetData()
        {
            return new List<object>()
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