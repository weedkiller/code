 c#
[Serializable]
public struct X
{
	public int N {get; set;}
	public string S {get; set;}
}
Read and write it using a BinaryFormatter:
 c#
string filename = @"c:\temp\list.bin";
var list = new List<X>();
list.Add(new X { N=1, S="No. 1"});
list.Add(new X { N=2, S="No. 2"});
list.Add(new X { N=3, S="No. 3"});
BinaryFormatter formatter = new BinaryFormatter();
System.IO.Stream ms = File.OpenWrite(filename);
formatter.Serialize(ms, list);
ms.Flush();
ms.Close();
ms.Dispose();
FileStream fs = File.Open(filename, FileMode.Open); 
object obj = formatter.Deserialize(fs);
var newlist = (List<X>)obj;
fs.Flush();
fs.Close();
fs.Dispose(); 
foreach (X x in list)
{
	Console.Out.WriteLine($"N={x.N}, S={x.S}");
}
The solution uses that the `List` class as well as the `X` struct is serializable.
