            //-----
            
            String path = Server.MapPath("~/content/public");
            if (Request.Files != null && Request.Files.Count > 0)
            {
                String fileExtension = System.IO.Path.GetExtension(Request.Files[0].FileName).ToLower();
                String[] allowedExtensions = new List<string>(){".gif", ".png", ".jpeg", ".jpg" };
              if (allowedExtensions.Contains(fileExtension))
                {
                    string fileName = new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd").ToString();
                    Request.Files[0].SaveAs(path + fileName);
                    product.ProductImg = fileName ;
                }
            }
           ///------
