    partial class CreateCharacterWindow : Window {
        private Character character;
    
        public CreateCharacterWindow ()
            : this (null) { } 
    
        public CreateCharacterWindow (Character character)
        {
            this.character = character;
            InitializeComponent ();
        }
    }
    
    var spiderMan = new Character ();
    var charWindow = new CreateCharacterWindow (spiderMan);
