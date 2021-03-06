            public string PlaceOrder(IPOPPlaceOrderRequest order)
        {
            try
            {
                string storedProcedure = BuildSQLExecutionString<IPOPPlaceOrderRequest>(order, "exec @RetVal = Web_NewOrder");
                List<SqlParameter> parameters = BuildSQLParameters<IPOPPlaceOrderRequest>(order);
                var retVal = new SqlParameter("@RetVal", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output, DbType = System.Data.DbType.Int32};
                parameters.Add(retVal);
                var test = tOrderRepository.RunSqlStoredProcedureSingle<object>(storedProcedure, parameters.ToArray());
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
