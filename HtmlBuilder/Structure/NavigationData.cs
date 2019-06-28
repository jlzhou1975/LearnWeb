using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlBuilder.Structure
{
    public class NavigationData
    {
        public string Key { get; set; }
        public string ParentKey { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
        public string Kind { get; set; }
        public string Href { get; set; }

    }
}