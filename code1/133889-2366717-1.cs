        public static void databaseFileRead(string varID, string varPathToNewLocation) {
            using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetailsDZP))
            using (var sqlQuery = new SqlCommand(@"SELECT [RaportPlik] FROM [dbo].[Raporty] WHERE [RaportID] = @varID", varConnection)) {
                sqlQuery.Parameters.AddWithValue("@varID", varID);
                using (var sqlQueryResult = sqlQuery.ExecuteReader()) {
                    if (sqlQueryResult != null) {
                        sqlQueryResult.Read();
                        byte[] blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                        sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                        using (FileStream fs = new FileStream(varPathToNewLocation, FileMode.Create, FileAccess.Write)) {
                            fs.Write(blob, 0, blob.Length);
                        }
                    }
                }
            }
        }
