     public int select_TicketId()
            {
                string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString.ToString();
                SqlConnection sqlCon = new SqlConnection(strConn);
                string getId = ("select TOP 1 Ticket_Id from tbl_Ticket where Client_EmailAdd='" + objNewTic_BAL.email + "' ");
                sqlCon.Open();
                SqlCommand cmd1 = new SqlCommand(getId, sqlCon);
                int i=Convert.ToInt32(cmd1.ExecuteScalar());
                return i;
    
            }
