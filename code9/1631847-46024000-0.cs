        Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
            // setting items
            dictionary.Add("stats", new[]
                {
                    "Attack", "Defence", "Strength",
                    "Hitpoints", "Ranged", "Prayer",
                    "Fletching", "Fishing", "Firemaking",
                    "Crafting", "Smithing", "Mining"
                }
            );
            dictionary.Add("minigames", new[]
                {
                    "Duel Tournaments", "Bounty Hunters",
                    "Bounty Hunter Rogues", "Fist of Guthix",
                    "Mobilising Armies", "B.A Attackers",
                    "B.A Defenders", "B.A Healers",
                    "Castle Wars Games", "Conquest"
                }
            );
            // getting items
            foreach (var value in dictionary["stats"])
            {
                Console.WriteLine(value);
            }
