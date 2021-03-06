	public class DateTimeRange : Range<DateTime>
	{
		
		public DateTimeRange(string source) : base(source)
		{
			
		}
		
		public DateTimeRange(DateTime lower, DateTime upper):base(lower, upper)
		{
			
		}
		
		public override string ValueToString(DateTime value) { return value.ToString("O"); }
		public override DateTime StringToValue(string source) { return DateTime.Parse(source); }
	}
