    using (StreamReader reader = OpenYourInputFile())
    using (StreamWriter writer = OpenYourOutputFile())
    {
       TimeSpan? lastTime;
       TimeSpan currentTime, maxDiff = TimeSpan.FromSeconds(1);
       string lastValue, currentline, currentValue, format = "{0:hhmmss} {1}";
    
       while( (currentLine = reader.ReadLine()) != null)
       {
          string[0] s = currentLine.Split(' ');
          currentTime = DateTime.ParseExact("hhmmss", s[0] CultureInfo.InvariantCulture).TimeOfDay;
          currentValue = s[1];
    
          if (lastTime.HasValue && currentTime - lastTime.Value > maxDiff) writer.WriteLine(string.Format(format, DateTime.Today.Add(lastTime).Add(maxDiff), lastValue);
    
          writer.WriteLine(string.Format(format, DateTime.Today.Add(currentTime), currentValue);
    
          lastTime = currentTime;
          lastValue = currentValue;
       }
    
    }
