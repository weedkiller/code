    try
           {
               conn.Open();
             
               deletedCustomers = command.ExecuteNonQuery();
    
               if (deletedCustomers > 0) {
                   lblError.Text = "Deleted!";   
               }
               else
               {
                   lblError.Text = "Customer ID does not exist";
               }
    
               conn.Close();              
           }
