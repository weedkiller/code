    class Program
        {
            static void Main(string[] args)
            {
                using (TransactionScope transaction = new TransactionScope())
                    {
                        using (MusicContainer music = new MusicContainer())
                        {
                                UserContextInSomeOtherMethod(music);
             
                                Artist artist = new Artist { Name = "Test" };
                                music.Artists.AddObject(artist);
                                music.SaveChanges();
                        }
                    }
            }
        }
