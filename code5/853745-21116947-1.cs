    int attributeId = 2147483645;
    List<string> values = _productAttributeParser.ParseValues(item.AttributesXml, attributeId);
            
    String docID = String.Empty;
    if(values.Count > 0)
    {
         docID = values.First();
    }
    cell = new PdfPCell(new Phrase(docID));
    cell.HorizontalAlignment = Element.ALIGN_CENTER;
    productsTable.AddCell(cell);
