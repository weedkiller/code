    foreach (
    var customer in
        collListItem.Select(
            item =>
            new Customer
                {
                    Persona = item["Persona"].ToString(),
                    CustomerName = item["Title"].ToString()
                }).Dictinct())
    {
        customers.Add(customer);
    }
