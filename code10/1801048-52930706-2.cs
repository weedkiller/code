    /// <summary> Siblings including self </summary>
    public static IEnumerable<XElement> Siblings(this XElement xml) =>
        xml?.Parent?.Elements() ?? new List<XElement>();
    
    /// <summary> Ancestors, descendants and self </summary>
    public static IEnumerable<XElement> AncestorsDescendantsSelf(this XElement xml) =>
        xml?.DescendantsAndSelf()?.Union(xml?.Ancestors() ?? new List<XElement>()) ?? new List<XElement>();
    
    /// <summary> Compress the document by removing everything except the elemnents along selected paths </summary>
    /// <param name="xml">source document to be modified</param>
    /// <param name="whitelistedPaths">collection of xpath paths</param>
    public static void Compress(this XDocument xml, IEnumerable<string> whitelistedPaths) {
        var siblings = nodes.SelectMany(n => n.AncestorsAndSelf()).Aggregate((new List<XElement>()).AsEnumerable(), (n1,n2) => n1.Union(n2.Siblings()));
        var lineages = nodes.SelectMany(n => n.AncestorsDescendantsSelf());
        var nodesToDelete = siblings.Except(lineages).ToList();
        foreach (var element in nodesToDelete) {
            element.Remove();
        }
    }
