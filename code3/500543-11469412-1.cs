    private static readonly string[] AllCountries = new string[] {
        "AF", "BD", "CA", "IN", "IR", "RO", "AN", "CY", "IL", "PH"
    };
    private bool CheckMemberCountry(string country) {
        return AllCountries.Contains(country);
    }
