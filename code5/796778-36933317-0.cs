              string pathfile = @"C:\\Users\\Public\\Documents\\Filepath.txt";
                if (!Directory.Exists(pathfile))
                {
                    File.SetAttributes(pathfile, FileAttributes.Normal);
                    File.Delete(pathfile);
                }
                    using (FileStream fs = File.Create(pathfile))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("What Ever Your Text is");
                                      
                        fs.Write(info, 0, info.Length);
                        File.SetAttributes(pathfile, FileAttributes.ReadOnly);
                        FileSecurity fsec = File.GetAccessControl(pathfile);
                        fsec.AddAccessRule(new FileSystemAccessRule("Everyone",
                        FileSystemRights.ReadData, AccessControlType.Allow));
                        File.SetAccessControl(pathfile, fsec);
                        
                    }
