    double a = BitConverter.ToDouble(new byte[] { 156, 153, 153, 153, 153, 153, 33, 64, }, 0);
    double b = BitConverter.ToDouble(new byte[] { 155, 153, 153, 153, 153, 153, 33, 64, }, 0);
    double c = BitConverter.ToDouble(new byte[] { 154, 153, 153, 153, 153, 153, 33, 64, }, 0);
    double d = BitConverter.ToDouble(new byte[] { 153, 153, 153, 153, 153, 153, 33, 64, }, 0);
    double e = BitConverter.ToDouble(new byte[] { 152, 153, 153, 153, 153, 153, 33, 64, }, 0);
    Console.WriteLine(a.ToString("R"));
    Console.WriteLine(b.ToString("R"));
    Console.WriteLine(c.ToString("R"));
    Console.WriteLine(d.ToString("R"));
    Console.WriteLine(e.ToString("R"));
