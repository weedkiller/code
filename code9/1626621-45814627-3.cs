    public class MatchDetails{
        public int MatchId { get; set; }
        public string MatchName { get; set; }
        public int TeamId1 { get; set; }
        public int TeamId2 { get; set; }
        public virtual TeamDetails Team1 { get; set; } // One new navigation property
        public virtual TeamDetails Team2 { get; set; } // Another new navigation property
    }
