    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication132
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable Accounts = new DataTable();
                Accounts.Columns.Add("Account ID", typeof(int));
                Accounts.Columns.Add("Title", typeof(string));
                Accounts.Rows.Add(new object[] { 225, "Mushtaq" });
                Accounts.Rows.Add(new object[] { 2211, "Akram" });
                DataTable Arrival_Master = new DataTable();
                Arrival_Master.Columns.Add("Arrival ID", typeof(int));
                Arrival_Master.Columns.Add("Adate", typeof(DateTime));
                Arrival_Master.Columns.Add("RefDate", typeof(DateTime));
                Arrival_Master.Columns.Add("Party ID", typeof(int));
                Arrival_Master.Rows.Add(new object[] { 1, DateTime.Parse("9/25/2019"), DateTime.Parse("9/25/2019"), 225 });
                Arrival_Master.Rows.Add(new object[] { 2, DateTime.Parse("9/26/2019"), DateTime.Parse("9/26/2019"), 2211 });
                DataTable Arrival_Details = new DataTable();
                Arrival_Details.Columns.Add("Arrival ID", typeof(int));
                Arrival_Details.Columns.Add("ItemId", typeof(int));
                Arrival_Details.Columns.Add("ItemQty", typeof(int));
                Arrival_Details.Columns.Add("Amount", typeof(decimal));
                Arrival_Details.Rows.Add(new object[] { 1, 1, 15, 500 });
                Arrival_Details.Rows.Add(new object[] { 1, 2, 20, 400 });
                Arrival_Details.Rows.Add(new object[] { 1, 5, 12, 750 });
                Arrival_Details.Rows.Add(new object[] { 2, 7, 15, 150 });
                Arrival_Details.Rows.Add(new object[] { 2, 5, 17, 180 });
                DataTable Return_Master = new DataTable();
                Return_Master.Columns.Add("ReturnID", typeof(int));
                Return_Master.Columns.Add("Date", typeof(DateTime));
                Return_Master.Columns.Add("RefDate", typeof(DateTime));
                Return_Master.Columns.Add("Party ID", typeof(int));
                Return_Master.Rows.Add(new object[] { 1, DateTime.Parse("9/25/2019"), DateTime.Parse("9/25/2019"), 225 });
                Return_Master.Rows.Add(new object[] { 2, DateTime.Parse("9/26/2019"), DateTime.Parse("9/26/2019"), 2211 });
                DataTable Return_Details = new DataTable();
                Return_Details.Columns.Add("RetID", typeof(int));
                Return_Details.Columns.Add("ItemId", typeof(int));
                Return_Details.Columns.Add("ItemQty", typeof(int));
                Return_Details.Columns.Add("Amount", typeof(decimal));
                Return_Details.Rows.Add(new object[] { 1, 1, 15, 50 });
                Return_Details.Rows.Add(new object[] { 1, 2, 20, 40 });
                Return_Details.Rows.Add(new object[] { 2, 7, 15, 90 });
                Return_Details.Rows.Add(new object[] { 2, 5, 17, 80 });
                DataTable Summary = new DataTable();
                Summary.Columns.Add("Adate", typeof(DateTime));
                Summary.Columns.Add("RefDate", typeof(DateTime));
                Summary.Columns.Add("ArrivalID", typeof(int));
                Summary.Columns.Add("Title", typeof(string));
                Summary.Columns.Add("ArrivalAmount", typeof(decimal));
                Summary.Columns.Add("Return Amount", typeof(decimal));
                Summary.Columns.Add("Net Amount", typeof(decimal));
                var joins = (from acc in Accounts.AsEnumerable()
                             join am in Arrival_Master.AsEnumerable() on acc.Field<int>("Account ID") equals am.Field<int>("Party ID")
                             join ad in Arrival_Details.AsEnumerable().GroupBy(x => x.Field<int>("Arrival ID")) on am.Field<int>("Arrival ID") equals ad.Key
                             join rm in Return_Master.AsEnumerable() on acc.Field<int>("Account ID") equals rm.Field<int>("Party ID")
                             join rd in Return_Details.AsEnumerable().GroupBy(x => x.Field<int>("REtID")) on rm.Field<int>("ReturnID") equals rd.Key
                             select new { account = acc, arrivalMaster = am, arrivalDetails = ad, returnMaster = rm, returnDetails = rd }).ToList();
                var groups = joins.GroupBy(x => new { 
                    account = x.account.Field<int>("Account ID"), 
                    arrivalDate = x.arrivalMaster.Field<DateTime>("Adate"), 
                    refDate = x.arrivalMaster.Field<DateTime>("RefDate") }).ToList();
                foreach (var group in groups)
                {
                    DataRow newRow = Summary.Rows.Add();
                    newRow["Adate"] = group.Key.arrivalDate;
                    newRow["RefDate"] = group.Key.refDate;
                    newRow["ArrivalID"] = group.FirstOrDefault().arrivalMaster.Field<int>("Arrival ID");
                    newRow["Title"] = group.FirstOrDefault().account.Field<string>("Title");
                    newRow["ArrivalAmount"] = group.Sum(x => x.arrivalDetails.Sum(y => y.Field<decimal>("Amount")));
                    newRow["Return Amount"] = group.Sum(x => x.returnDetails.Sum(y => y.Field<decimal>("Amount")));
                    newRow["Net Amount"] = group.Sum(x => x.arrivalDetails.Sum(y => y.Field<decimal>("Amount"))) -
                       group.Sum(x => x.returnDetails.Sum(y => y.Field<decimal>("Amount")));
                }
            }
        }
    }
