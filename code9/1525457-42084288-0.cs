	var tbl = new DataTable();
	tbl.Columns.Add( "credit", typeof( decimal ) );
	tbl.Columns.Add( "debit", typeof( decimal ) );
	tbl.Columns.Add( "OpenBal", typeof( decimal ) );
	tbl.Rows.Add( 100, 0 );
	tbl.Rows.Add( 90, 0 );
	tbl.Rows.Add( 100, 0 );
	tbl.Rows.Add( 0, 50 );
	tbl.Rows.Add( 0, 100 );
	tbl.Rows.Add( 150, 0 );
