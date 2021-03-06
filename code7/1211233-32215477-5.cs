    public class FocusTriggerAction : TriggerAction<SearchBar>
    {
    	public bool Focused { get; set; }
    
        protected override async void Invoke (SearchBar searchBar)
        {
        	await Task.Delay(1000);
        	
            if (Focused)
            {
            	searchBar.Focus();
            }
            else
            {
            	searchBar.UnFocus();
            }
        }
    }
    public class UnfocusedTriggerAction : TriggerAction<SearchBar>
    {
        protected override void Invoke (SearchBar searchBar)
        {
     		YourViewModel.ViewModelIsSearchBarFocused = false;
        }
    }
