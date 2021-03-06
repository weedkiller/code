    public static XmlNamespaceManager AttachNamespaces(ref XmlDocument xmldoc)
        {
            System.Xml.XmlNamespaceManager NS = default(System.Xml.XmlNamespaceManager);
            XmlNode rootnode = default(XmlNode);
            string strTest = null;
            string attrname = null;
            string ns = null;
            NS = new System.Xml.XmlNamespaceManager(xmldoc.NameTable);
            rootnode = xmldoc.DocumentElement;
            strTest = ts.XML.GetAttribute(ref rootnode, "xmlns");
            if (string.IsNullOrEmpty(strTest))
            {
                NS.AddNamespace("mysite", "http://www.mysite.com/");
            }
            else
            {
                NS.AddNamespace("mysite", strTest);
            }
            // Add namespaces from XML root tag
            foreach (XmlAttribute attr in rootnode.Attributes)
            {
                attrname = attr.Name;
                if (attrname.IndexOf("xmlns:") == 0 && !string.IsNullOrEmpty(attrname))
                {
                    ns = attrname.Substring(7);
                    NS.AddNamespace(ns, attr.Value);
                }
            }
            return NS;
    }
