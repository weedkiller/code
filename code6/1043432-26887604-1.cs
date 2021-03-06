    public void ReadValueFromLoadedConfigData()
    {
        // Arrange.
        const string ExpectedValue = "Whatever";
    
        var sut = new ConfigFile();
    
        sut.loadConfigFile(@"C:\PathToTheConfigFile");
    
        // Act.
        string actual = sut.GetConfigValue();
    
        // Assert.
        Assert.AreEqual(ExpectedValue, actual);
    }
