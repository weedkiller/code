    List<String> lst = new List<string>();
    private void searchDB()
    {
    	using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=|DataDirectory|/jarvisBrain.mdf;Integrated Security=True"))
    	{
    		connection.Open();
    		using (SqlCommand command = new SqlCommand("SELECT Word FROM ImportedWordList",connection))
    		using (SqlDataReader reader = command.ExecuteReader())
    		{
    			while (reader.Read())
    			{
    				lst.Add(reader.GetString(0));
    			}
    		}
    		richTextBox1.Lines = lst.ToArray();
    		connection.Close();
    	}
    	//code stops here!!
    	try
    	{
    		rec.RequestRecognizerUpdate();
    		rec.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(lst.ToArray()))));
    		rec.SpeechRecognized += rec_SpeechRecognized;
    		rec.SetInputToDefaultAudioDevice(); // sets to earplugs of speakers
    		rec.RecognizeAsync(RecognizeMode.Multiple);
    		// Set the speaking rate and volume
    		s.Rate = 0;
    		s.Volume = 100;
    	}
    }
