    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
                .AddXmlSerializerFormatters(); 
    }
