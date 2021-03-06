	namespace TwitchCSharp.Clients
	{
		public class TwitchDataClient : ITwitchClient
		{
			public readonly RestClient restClient;
			public TwitchDataClient(string url = TwitchHelper.twitchStaticDataUrl)
			{
				restClient = new RestClient(url);
				restClient.AddHandler("application/json", new DynamicJsonDeserializer());
				restClient.AddHandler("text/html", new DynamicJsonDeserializer());
				restClient.AddDefaultHeader("Accept", TwitchHelper.twitchAcceptHeader);
			}
			public ViewerList GetChannelViewers(string channel)
			{
				var request = new RestRequest("group/user/{channel}/chatters");
				request.AddUrlSegment("channel", channel);
				return restClient.Execute<ViewerList>(request).Data;
			}
			public RestRequest GetRequest(string url, Method method)
			{
				return new RestRequest(url, method);
			}
		}
	}
