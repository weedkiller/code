    try
    {
        //logic comes here
    }
    catch (WebException e)
    {
        var code = ((HttpWebResponse)e.Response).StatusCode;
        if(code == HttpStatusCode.BadRequest)
        {
            //some logic1
        }
        if(code == HttpStatusCode.InternalServerError)
        {
            //some logic2
        }
    }
