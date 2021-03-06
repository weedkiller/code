    partial void DownloadPressed(NSObject sender)
    {
        Console.WriteLine("Pressed");
        DoDownloadAsync();
    }
    private async void DoDownloadAsync()
    {
        BeginInvokeOnMainThread(() => {
            Label1.StringValue = "Fetching Data";
            Label2.StringValue = "Fetching Data";
            Label3.StringValue = "Fetching Data";
        );
        await Task.Run(() => DownloadFromAzure());
        Label1.StringValue = "Phrases: " + psNet.Count;
        Label2.StringValue = "CategorySource: " + csNet.Count;
        Label3.StringValue = "CategoryGroupSource: " + cgsDb;
    }
