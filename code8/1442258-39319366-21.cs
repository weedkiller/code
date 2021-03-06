    public class UserViewModel : BindableBase //use the BindableBase class
    {
        private ObservableCollection<UserModel> _userList;
        public ObservableCollection<UserModel> UserList
        {
            get
            {
                return _userList;
            }
            set
            {
                _userList = value;
            }
        }
        private User _selectedUser; //use the correct Model class (described below or Database.User)
        public User SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser)); // call the OnPropertyChanged of BindableBase (I would also recommend using nameof)
            }
        }
        public UserViewModel()
        {
            UserManager manager = new UserManager();
            var FilterCombo = new List<ComboItem> { 
                new ComboItem{Text = "Name", Value = "Name"},
                new ComboItem{Text = "Owner", Value = "Owner"},
                new ComboItem{Text = "Email", Value = "Email"},
                new ComboItem{Text = "Contact Number", Value = "Contact"},
                new ComboItem{Text = "Address", Value = "Address"},
            };
            var filter = new FilterModel
            {
                FilterItems = FilterCombo,
                FilterSelected = FilterCombo.Where(t => t.Text == "Name").FirstOrDefault(),
                FilterValue = ""
            };
            _userList = new ObservableCollection<User>(manager.GetList(filter).ToModels()); //this uses now the extension method (your manager should be doing this and return the model instead of the database user)
        }
    }
