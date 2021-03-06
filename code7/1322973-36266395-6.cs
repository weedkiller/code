    public class Properties
    {
        #region Import Methods
        [DllImport("shell32.dll", SetLastError = true)]
        static extern int SHMultiFileProperties(IDataObject pdtobj, int flags);
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ILCreateFromPath(string path);
        [DllImport("shell32.dll", CharSet = CharSet.None)]
        public static extern void ILFree(IntPtr pidl);
        [DllImport("shell32.dll", CharSet = CharSet.None)]
        public static extern int ILGetSize(IntPtr pidl);
        #endregion
        #region Static Methods
        #region Private
        private static MemoryStream CreateShellIDList(StringCollection filenames)
        {
            // first convert all files into pidls list
            int pos = 0;
            byte[][] pidls = new byte[filenames.Count][];
            foreach (var filename in filenames)
            {
                // Get pidl based on name
                IntPtr pidl = ILCreateFromPath(filename);
                int pidlSize = ILGetSize(pidl);
                // Copy over to our managed array
                pidls[pos] = new byte[pidlSize];
                Marshal.Copy(pidl, pidls[pos++], 0, pidlSize);
                ILFree(pidl);
            }
            // Determine where in CIDL we will start pumping PIDLs
            int pidlOffset = 4 * (filenames.Count + 2);
            // Start the CIDL stream
            var memStream = new MemoryStream();
            var sw = new BinaryWriter(memStream);
            // Initialize CIDL witha count of files
            sw.Write(filenames.Count);
            // Calcualte and write relative offsets of every pidl starting with root
            sw.Write(pidlOffset);
            pidlOffset += 4; // root is 4 bytes
            foreach (var pidl in pidls)
            {
                sw.Write(pidlOffset);
                pidlOffset += pidl.Length;
            }
            // Write the root pidl (0) followed by all pidls
            sw.Write(0);
            foreach (var pidl in pidls) sw.Write(pidl);
            // stream now contains the CIDL
            return memStream;
        }
        #endregion
        #region Public 
        public static int Show(IEnumerable<string> Filenames)
        {
            StringCollection Files = new StringCollection();
            foreach (string s in Filenames) Files.Add(s);
            var data = new DataObject();
            data.SetFileDropList(Files);
            data.SetData("Preferred DropEffect", new MemoryStream(new byte[] { 5, 0, 0, 0 }), true);
            data.SetData("Shell IDList Array", Properties.CreateShellIDList(Files), true);
            return SHMultiFileProperties(data, 0);
        }
        public static int Show(params string[] Filenames)
        {
            return Properties.Show(Filenames as IEnumerable<string>);
        }
        #endregion
        #endregion
    }
