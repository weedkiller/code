    using System;
    using System.Text;
    using System.Security.Cryptography;
    using Flurl;
    using Flurl.Http;
    using Newtonsoft.Json;
    using System.Linq;
    
    namespace demibyte.coinbase
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			var host = "https://api.coinbase.com/";
    			var apiKey = "myApiKey";
    			var apiSecret = "myApiSecret";
    			
    			var unixTimestamp = (Int32)(DateTime.UtcNow.Subtract (new DateTime (1970, 1, 1))).TotalSeconds;
    			var currency = "AUD";
    			var apiVersion = "2018-01-13";  // check value from https://www.coinbase.com/settings/api - it is the build date of Coinbase API (not our Application!) 
    			var message = string.Format ("{0}GET/v2/prices", unixTimestamp.ToString ());
    
    			byte[] secretKey = Encoding.UTF8.GetBytes (apiSecret);
    			HMACSHA256 hmac = new HMACSHA256 (secretKey);
    			
    			hmac.Initialize ();
    			byte[] bytes = Encoding.UTF8.GetBytes (message);
    			byte[] rawHmac = hmac.ComputeHash (bytes);
    			var signature = rawHmac.ByteArrayToHexString ();
    
    			var jsonCodeBTC = host
			        .AppendPathSegment ("v2/prices/BTC-AUD/spot")
			        .WithHeader ("CB-VERSION", apiVersion)                                          
				    .WithHeader ("CB-ACCESS-SIGN", signature)
				    .WithHeader ("CB-ACCESS-TIMESTAMP", unixTimestamp)
				    .WithHeader ("CB-ACCESS-KEY", apiKey)
				    .GetJsonAsync<dynamic> ()
				    .Result;
    
    			Console.WriteLine (price.ToString (Formatting.None));
    			Console.WriteLine();
    			
    			message = string.Format ("{0}GET/v2/accounts", unixTimestamp.ToString ());
    
    			bytes = Encoding.UTF8.GetBytes (message);
    			rawHmac = hmac.ComputeHash (bytes);
    			signature = rawHmac.ByteArrayToHexString ();
    			
    			var jsonCode = host
    				.AppendPathSegment ("v2/accounts")
    				.WithHeader ("CB-ACCESS-SIGN", signature)
    				.WithHeader ("CB-ACCESS-TIMESTAMP", unixTimestamp)
    				.WithHeader ("CB-ACCESS-KEY", apiKey)
    			    .WithHeader ("CB-VERSION", apiVersion)
    				.GetJsonAsync<dynamic> ()
    				.Result;
    
    	        Console.WriteLine (jsonCode.ToString (Formatting.None));
    
               dynamic stuff = null;
               try {
                   stuff = JsonConvert.DeserializeObject(jsonCode.ToString (Formatting.None));
               }
               catch(Exception) {
                   Console.Write("Error deserializing");
               }
    
               int count = stuff.data.Count;
    
               for(int i = 0; i < count; i++) {
                    string currAmount = stuff.data[i].balance.amount;
                    string currCode = stuff.data[i].balance.currency;
                    Console.WriteLine(currCode + ": " + currAmount);
               }
    
               Console.ReadLine ();
    		}
    	}
    }
