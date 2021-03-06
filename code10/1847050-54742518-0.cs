    private static void EncryptFile(string path, byte[] key)
    {
        byte[] iv = new byte[16];
        new RNGCryptoServiceProvider().GetBytes(iv);
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            long readPos = 0;
            long writePos = 0;
            long readLength = fs.Length;
            using (var aes = new RijndaelManaged()
            {
                Key = key,
                IV = iv,
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CFB,
            })
            using (var cs = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                while (readPos < readLength)
                {
                    fs.Position = readPos;
                    bytesRead = fs.Read(buffer, 0, buffer.Length);
                    readPos = fs.Position;
                    fs.Position = writePos;
                    cs.Write(buffer, 0, bytesRead);
                    writePos = fs.Position;
                }
                // In older versions .NET, CryptoStream doesn't have a ctor
                // with 'leaveOpen', so we have to do this instead.
                cs.FlushFinalBlock();
                // Write the IV to the end of the file
                fs.Write(iv, 0, iv.Length);
            }
        }
    }
