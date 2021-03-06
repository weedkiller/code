    public static int CalcYears(DateTime fromDate) {
        int years = 0;
        DateTime toDate = DateTime.Now;
        for ( ; (toDate.AddYears(-1) < fromDate); ) {
            years++;
            toDate = toDate.AddYears(-1);
        }
        return years;
    }
