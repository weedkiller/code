    foreach (ListViewItem item in listView1.SelectedItems)
            {
                var image = item.ImageList.Images[item.ImageKey]; //or imageIndex
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(@"C:\temp\ggg.jpeg", FileMode.Create, FileAccess.ReadWrite))
                    {
                        image?.Save(memory, ImageFormat.Jpeg);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            }
