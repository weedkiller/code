    SQLiteConnection connect = new SQLiteConnection();
    connect.ConnectionString = ("Data Source=data/lastix_db.s3db");
    connect.Open();
    string sql = "SELECT SUM(giris_adet) - SUM(cikis_adet) as mevcutstok from stok where malzeme_kodu = 651";
    SQLiteCommand cmd = new SQLiteCommand(sql, connect);
    Int32 totalp = Convert.ToInt32(cmd.ExecuteScalar());
    cmd.Dispose();
    baglan.Close();
    //MessageBox.Show("Your Balance is: " + totalp);
    label16.Text = Convert.ToString(totalp);
