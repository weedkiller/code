        private async System.Threading.Tasks.Task Run()
        {
            String ownerPermissionId = "";
            String ownerEmail = "";
            String adminEmail = "abeer.qureshi@hidden.com";
            String adminPermissionId = "";
            String serviceAccountEmail = "895523393387-bpoaj0ekfgcort8tcqpqh661ceet9pqs@developer.gserviceaccount.com";
            var certificate = new X509Certificate2(@"key.p12", "notasecret", X509KeyStorageFlags.Exportable);
            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = Scopes
               }.FromCertificate(certificate)),
                ApplicationName = "Drive API Sample",
            });
            
            // Create admin impersonated service
            var adminService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = Scopes,
                   User = adminEmail
               }.FromCertificate(certificate)),
                ApplicationName = "Drive API Sample",
            });
            // this is the web reference object generated by Visual Studio
            SforceService sfservice = SForceLogin.Login();
            sfservice.Timeout = 60000;
             QueryResult result = sfservice.query("select Id, Name, DocId__c from G_Doc__c where PleaseDelete__c = true limit 200");
            List<String> toDelete = new List<String>();
            
            if (result.size > 0) 
            {
                sObject[] docs = result.records;
                foreach (sObject so in docs){
                    G_Doc__c d = (G_Doc__c)so;
                    try
                    {
                        IList<Permission> lstPermissions = RetrievePermissions(adminService, d.DocId__c);
                        if (lstPermissions == null)
                        {
                            toDelete.Add(d.Id);
                            continue;
                        }
                        foreach (Permission p in lstPermissions)
                        {
                            if (p.Role == "owner")
                            {
                               ownerEmail = p.EmailAddress;
                               ownerPermissionId = p.Id;
                            }
                            else if (p.EmailAddress == adminEmail)
                            {
                                adminPermissionId = p.Id;
                            }
                        }
                        // Create owner impersonated service.
                        var impersonatedService = new DriveService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
                        {
                            Scopes = Scopes,
                            User = ownerEmail
                        }.FromCertificate(certificate)),
                            ApplicationName = "Drive API Sample",
                        });
                        UpdatePermission(adminService, impersonatedService , d.DocId__c, adminPermissionId, "owner");
                        FilesResource.DeleteRequest request = adminService.Files.Delete(d.DocId__c);
                        String response = request.Execute();
                        if (String.IsNullOrEmpty(response))
                        {
                            Console.Out.WriteLine("Deleted " + d.Name);
                            toDelete.Add(d.Id);
                        }
                        else
                        {
                            Console.Out.WriteLine("Error Deleting " + d.Name + " : " + response);
                        }
                    }
                    catch (Exception ex) {
                        if (ex.Message.Contains("File not found"))
                        {
                            toDelete.Add(d.Id);
                            Console.Out.WriteLine("Error Deleting " + d.Name);
                        }
                        else
                        {
                            Console.Out.WriteLine("Error Deleting " + d.Name + " : " + ex.Message);
                        }
                    }
                }
                DeleteResult[] dr = sfservice.delete(toDelete.ToArray());
            }
        }
        // ...
        /// <summary>
        /// Retrieve a list of permissions.
        /// </summary>
        /// <param name="service">Drive API service instance.</param>
        /// <param name="fileId">ID of the file to retrieve permissions for.</param>
        /// <returns>List of permissions.</returns>
        public static IList<Permission> RetrievePermissions(DriveService service, String fileId)
        {
            try
            {
                PermissionList permissions = service.Permissions.List(fileId).Execute();
                return permissions.Items;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return null;
        }
        /// <summary>
        /// Update a permission's role.
        /// </summary>
        /// <param name="service">Drive API service instance.</param>
        /// <param name="fileId">ID of the file to update permission for.</param>
        /// <param name="permissionId">ID of the permission to update.</param>
        /// <param name="newRole">The value "owner", "writer" or "reader".</param>
        /// <returns>The updated permission, null is returned if an API error occurred</returns>
        public static Permission UpdatePermission(DriveService service, DriveService impersonatedService, String fileId,
            String permissionId, String newRole)
        {
            try
            {
                // First retrieve the permission from the API.
                Permission permission = service.Permissions.Get(fileId, permissionId).Execute();
                permission.Role = newRole;
                PermissionsResource.UpdateRequest request = impersonatedService.Permissions.Update(permission, fileId, permissionId);
                request.TransferOwnership = true;
                return request.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return null;
        }
