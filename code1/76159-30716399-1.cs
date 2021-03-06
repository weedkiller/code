	private static HttpClient _client = null;
	private static void UploadDocument()
	{
		// Add test file 
		var httpContent = new MultipartFormDataContent();
		var fileContent = new ByteArrayContent(File.ReadAllBytes(@"File.jpg"));
		fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
		{
			FileName = "File.jpg"
		};
		httpContent.Add(fileContent);
		string requestEndpoint = "api/Post";
		var response = _client.PostAsync(requestEndpoint, httpContent).Result;
		if (response.IsSuccessStatusCode)
		{
			// ...
		}
		else
		{
			// Check response.StatusCode, response.ReasonPhrase
		}
	}
