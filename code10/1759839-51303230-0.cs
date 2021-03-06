     public static IHtmlString Image(this HtmlHelper helper, string src, string alt,string height, string width, params string[] allClasses)
            {
                TagBuilder tb = new TagBuilder("img");
                tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
                tb.Attributes.Add("alt", alt);
                tb.Attributes.Add("height", height);
                tb.Attributes.Add("width", width);
                if (allClasses?.Any() ?? false)
                 {
                 tb.Attributes.Add("class", string.Join(" ",allClasses));
                 }
    
                return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
            }
