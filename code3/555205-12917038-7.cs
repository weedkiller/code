    public string GetCallingCode(Guid countryId)
    {
        var country = GetCountry(countryId);
        country.AssertIsValid(); //throws if the country is not defined
        
        switch (country)
        {
            case Country.UnitedStates:
                return "1";
            case Country.Mexico:
                return "52";
        }
    }
