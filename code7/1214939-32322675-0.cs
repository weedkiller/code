    DataTable Dt18 = new DataTable();
    Dt18.Columns.Add("Dosage", typeof(int));
    Dt18.Columns.Add("Drug", typeof(string));
    Dt18.Rows.Add(0, "Indocin");
    Dt18.Rows.Add(1, "indocin");
    Dt18.Rows.Add(17, "Indocin");
    Dt18.Rows.Add(2, "Hydralazine");
    Dt18.Rows.Add(3, "Combivent");
    Dt18.CaseSensitive = true;
    DataView view = new DataView(Dt18);
    view.Sort = "Drug asc";
    DataTable dtSorted = view.ToTable();
