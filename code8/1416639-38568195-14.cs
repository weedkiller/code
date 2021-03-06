    public static Vector3 GetSystemDrawingColorFromHexString(string hexString)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(hexString, @"[#]([0-9]|[a-f]|[A-F]){6}\b"))
                    throw new ArgumentException();
                int red = int.Parse(hexString.Substring(1, 2), NumberStyles.HexNumber);
                int green = int.Parse(hexString.Substring(3, 2), NumberStyles.HexNumber);
                int blue = int.Parse(hexString.Substring(5, 2), NumberStyles.HexNumber);
                return new Vector3(red, green, blue);
            }
