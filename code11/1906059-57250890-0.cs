    private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
    {
      await InitializeAsync();
    }
    private async Task InitializeAsync()
    {
      await Task.Run(
        () =>
        {
          AddBlackLine("");
          AddBlackLine("Checking if everything is ready...");
          AddBlackLine("");
          bool AdobeReady = false;
          bool SevenZipReady = false;
          bool JavaReady = false;
          bool EsetReady = false;
          if (Global_Action_Variables.Arta_Variables.ArtaAdobeSwitch == true)
          {
            AddBlackLine("Checking for Adobe installator...");
            bool CheckForAdobe = General_Functions.CheckIfFileExistsOnFTP("Ultra_Script/Basic_SW/Adobe_Reader.exe");
            if (CheckForAdobe == true)
            {
              AddGreenLine("Installer for Adobe accesible.");
              AdobeReady = true;
            }
            else
            {
              AddRedLine("Installer not accesible on FTP!!! Canceling job...");
              AddRedLine(
                "Check FTP repozitary if file in Ultra_Script/Basic_SW/Adobe_Reader.exe exists and ftp account have enough rights for this file.");
            }
          }
          if (Global_Action_Variables.Arta_Variables.ArtaSevenZip == true)
          {
            AddBlackLine("");
            AddBlackLine("");
            AddBlackLine("Checking for SevenZip installer...");
            bool CheckForSevenZip = General_Functions.CheckIfFileExistsOnFTP("Ultra_Script/Basic_SW/7zip.exe");
            if (CheckForSevenZip == true)
            {
              AddGreenLine("Installer for 7zip accesible.");
              SevenZipReady = true;
            }
            else
            {
              AddRedLine("Installer not accesible on FTP!!! Canceling job...");
              AddRedLine(
                "Check FTP repozitary if file in Ultra_Script/Basic_SW/7zip.exe exists and ftp account have enough rights for this file.");
            }
          }
          if (Global_Action_Variables.Arta_Variables.ArtaJava == true)
          {
            AddBlackLine("");
            AddBlackLine("");
            AddBlackLine("Checking for Java installer...");
            bool CheckForJava = General_Functions.CheckIfFileExistsOnFTP("Ultra_Script/Basic_SW/JaVa.exe");
            if (CheckForJava == true)
            {
              AddGreenLine("Installer for Java accesible");
              JavaReady = true;
            }
            else
            {
              AddRedLine("Installer not accesible on FTP!!! Canceling job...");
              AddRedLine(
                "Check FTP repozitary if file in Ultra_Script/Basic_SW/JaVa.exe exists and ftp account have enough rights for this file.");
            }
          }
          if (Global_Action_Variables.Arta_Variables.ArtaEset == true)
          {
            AddBlackLine("");
            AddBlackLine("");
            AddBlackLine("Checking for Arta ESET installer...");
            bool CheckForArtaEset = General_Functions.CheckIfFileExistsOnFTP("Ultra_Script/Basic_SW/Arta/ERA_ESET.exe");
            if (CheckForArtaEset == true)
            {
              AddGreenLine("Installer for ESET accesible");
              EsetReady = true;
            }
            else
            {
              AddRedLine("Installer not accesible on FTP!!! Canceling job...");
              AddRedLine(
                "Check FTP repozitary if file in UUltra_Script/Basic_SW/Arta/ERA_ESET.exe exists and ftp account have enough rights for this file.");
            }
          }
          if (AdobeReady == true)
          {
            AddBlackLine("");
            AddBlackLine("");
            AddBlackLine("Test");
            General_Functions.DownloadFileFromFTP("Ultra_Script/Basic_SW/Adobe_Reader.exe", "Adobe_Reader.exe");
          }
          else
          {
            AddBlackLine("");
            AddRedLine("Failed.");
          }
        });
    }
