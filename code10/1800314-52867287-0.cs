    private static HttpClient client = new HttpClient();
    public static async void GetResponse()
    {
    	string key = Properties.Settings.Default.Key;
    
    	Uri imageryRequest = new Uri($"https://dev.virtualearth.net/REST/v1/Imagery/Map/Road/Redmond Washington?ms=500,270&zl=12&&c=en-US&he=1&key={key}");
    
    	HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, imageryRequest);
    	HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
    
    	response.EnsureSuccessStatusCode();
    	
    	File.WriteAllBytes("test.png", await response.Content.ReadAsByteArrayAsync());
    }
