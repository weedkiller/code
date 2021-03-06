    Dim dict = xDoc.Descendants(item).ToDictionary(Function(n) => n.Attribute("itemcode").Value)
    Using context As New QuotationDbContext
    For Each item In context.Items.Where(Function(i) i.Active)
        If dict.HasKey(item.ItemNumber) Then item.Stock = dict(item.ItemNumber).Attribute("stock").Value
    Next
    context.SaveChanges()
    End Using
