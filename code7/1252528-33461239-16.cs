        const string tales = "123.123.123.123 download.talesrunner.com";
        string[] lines = File.ReadAllLines(hostfile);
        if (!lines.Contains(tales))
        {
            File.AppendAllLines(hostfile, new String[] { tales });
        }
        else
        {
            if (lines.Contains("download.talesrunner.com"))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("download.talesrunner.com"))
                        lines[i] = tales;
                }
                File.WriteAllLines(hostfile, lines);
            }
        }
