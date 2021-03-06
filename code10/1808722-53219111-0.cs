	private static IEnumerable<IPNetwork> GetNetworks(NetworkInterfaceType type)
	{
		foreach (var item in NetworkInterface.GetAllNetworkInterfaces()
			.Where(n => n.NetworkInterfaceType == type && n.OperationalStatus == OperationalStatus.Up)	// get all operational networks of a given type
			.Select(n => n.GetIPProperties())	// get the IPs
			.Where(n => n.GatewayAddresses.Any())) // where the IPs have a gateway defined
		{
			var ipInfo = item.UnicastAddresses.FirstOrDefault(i => i.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork); // get the first cluster-facing IP address
			if (ipInfo == null) { continue; }
			// convert the mask to bits
			var maskBytes = ipInfo.IPv4Mask.GetAddressBytes();
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(maskBytes);
			}
			var maskBits = new BitArray(maskBytes);
			var cidrMask = maskBits.Cast<bool>().Count(b => b); // count the number of "true" bits to get the CIDR mask
			// convert my application's ip address to bits
			var ipBytes = ipInfo.Address.GetAddressBytes();
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(maskBytes);
			}
			var ipBits = new BitArray(ipBytes);
			// and the bits with the mask to get the start of the range
			var maskedBits = ipBits.And(maskBits);
			
			// Convert the masked IP back into an IP address
			var maskedIpBytes = new byte[4];
			maskedBits.CopyTo(maskedIpBytes, 0);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(maskedIpBytes);
			}
			var rangeStartIp = new IPAddress(maskedIpBytes);
			// return the start IP and CIDR mask
			yield return new IPNetwork(rangeStartIp, cidrMask);
		}
	}
	
