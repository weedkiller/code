    public SiteProfiles_ByProfileId()
    {
        Map = profiles => from profile in profiles
                       select new
                       {
                           profile.Id,
                           profile.Age
                       };
        Sort(x => x.Id, SortOptions.Int);
        Sort(x => x.Age, SortOptions.Int);
    }
