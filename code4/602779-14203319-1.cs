    string delimiter = safeint + "}";
    string result = "{" + string.Join(delimiter,
        productfeature.Select(node => removeBraces(node.InnerText)).ToArray()) + "}";
    public static string removeBraces(string value)
    {
        return value.Replace("}", "").Replace("{", "");
    }
