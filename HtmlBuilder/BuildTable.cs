using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace HtmlBuilder
{
    /// <summary>
    /// 从DataTable中构建Table的HTML
    /// </summary>
    public class BuildTable
    {
        private BuildTable() { }
        /// <summary>
        /// 构建TableHtml
        /// </summary>
        /// <param name="columnTitles">字段和标题</param>
        /// <param name="columnDatas">引用的字段放在[]之间，不能有<td>标签，因为已经创建了<td></td></td></param>
        /// <param name="dataTable"></param>
        /// <param name="tableCss">table额外的CSS</param>
        /// <returns></returns>
        public static string Request(Dictionary<string, string> columnTitles, Dictionary<string, string> columnDatas, List<object> datas)
        {
            StringBuilder builder = new StringBuilder();
            //最初只是设置width，对chrome有效，IE系列无效，后发现是bootstrap中设置了max-width:100%，所以需要覆盖
            string width = columnTitles.Count > 20 ? "style= \"min-width:" + columnTitles.Count * 100 + "px;max-width:10000px\"" : "";
            builder.AppendLine($"<table {width} class='table table-hover table-sm table-bordered'>");
            builder.AppendLine("<thead class='thead-light'>");
            builder.AppendLine("<tr>");
            foreach (string columnTitle in columnTitles.Values)//表头
            {
                builder.AppendLine("<th>" + columnTitle + "</th>");
            }
            builder.AppendLine("</tr>");
            builder.AppendLine("</thead>");
            builder.AppendLine("<tbody>");
            if (datas.Count == 0)//无数据
            {
                builder.AppendLine($"<tr><td colspan='{columnTitles.Count}'> 无数据!</td></tr></table>");
                return builder.ToString();
            }
            foreach (object data in datas)//表体
            {
                builder.AppendLine("<tr>");
                foreach (string columnName in columnTitles.Keys)
                {
                    builder.Append("<td style='vnd.ms-excel.numberformat:@'>");//身份证不显示为科学计数
                    string columnValue = "";
                    PropertyInfo property = data.GetType().GetProperty(columnName);
                    if (property != null)
                    {
                        columnValue = property.GetValue(data).ToString();
                        if (columnDatas != null && columnDatas.ContainsKey(columnName))
                        {
                            columnValue = BuildColumnValue(columnDatas[columnName], data);
                        }
                        builder.Append(columnValue);
                    }
                    builder.Append("</td>");
                }
                builder.Append("</tr>");
            }
            builder.Append("</tbody></table>");
            return builder.ToString();
        }

        private static string BuildColumnValue(string columnData, object data)
        {
            int posBegin = columnData.IndexOf("[");
            if (posBegin < 0) return columnData;
            int posEnd = columnData.IndexOf("]", posBegin);
            if (posEnd < 0) return columnData;
            string columnName = columnData.Substring(posBegin + 1, posEnd - posBegin - 1).Trim();
            PropertyInfo property = data.GetType().GetProperty(columnName);
            if (property != null)
            {
                columnData = columnData.Substring(0, posBegin) + property.GetValue(data).ToString() + columnData.Substring(posEnd + 1);
            }
            return BuildColumnValue(columnData, data);
        }
    }
}
