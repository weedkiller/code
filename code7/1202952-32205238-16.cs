    using System;
    using Microsoft.Office.Interop.Excel;
    
    namespace ConsoleApplication5
    {
    class Program
    {
    static void Main(string[] args)
    {
        RunVBATest();
    }
    
    public static void RunVBATest()
    {
        Application oExcel = new Application();
        oExcel.Visible = true;
        Workbooks oBooks = oExcel.Workbooks;
        _Workbook oBook = null;
        oBook = oBooks.Open("C:\\temp\\Book1.xlsm");
    
        // Run the macro.
        RunMacro(oExcel, new Object[] { "TestMsg" });
    
        // Quit Excel and clean up (its better to use the VSTOContrib by Jake Ginnivan).
        oBook.Saved = true;
        oBook.Close(false);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oBooks);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
    }
    
    private static void RunMacro(object oApp, object[] oRunArgs)
    {
        oApp.GetType().InvokeMember("Run",
            System.Reflection.BindingFlags.Default |
            System.Reflection.BindingFlags.InvokeMethod,
            null, oApp, oRunArgs);
        //Your call looks a little bit wack in comparison, are you using an instance of the app?
        //Application.GetType().InvokeMember(qualifiedMemberName.MemberName, BindingFlags.InvokeMethod, null, Application, null);
    }
    }
    }
    }
