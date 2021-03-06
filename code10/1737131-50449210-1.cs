    public async Task MyJson()//void if not async
    {
        string jsonUrl = "url-to-json";
        HttpContext.Response.ContentType = "application/json";
        using (var client = new HttpClient())
        {
            try
            {
                byte[] bytes = await client.GetByteArrayAsync(jsonUrl);
                //write to response stream aka Response.Body
                await HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }
            catch (Exception e)//404 or anything
            {
                HttpContext.Response.StatusCode = 400;//BadRequest
            }
            await HttpContext.Response.Body.FlushAsync();
            HttpContext.Response.Body.Close();
        }
    }
