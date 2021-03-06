    public static class CultureHelper
    {
        public static IHtmlString RenderCulture(this HtmlHelper helper, string culture)
        {
            string path = GetPath(culture);
            return Styles.Render(path);
        }
        
        private static string GetPath(string culture)
        {
            switch (culture)
            {
                case "he-IL": return "~/Content/bootstarpRTL";
                default: return "~/Content/bootstarp";
            }
        }
    }
