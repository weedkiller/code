    public IEnumerable<UserModule> GetUserModules()
    {
        using(var db = ....)
        db.setCommandText("SELECT * FROM USERMODULES");
        using (var reader = db.ExecuteReader())
        {
            while (reader.Read())
            {
                var userId = reader[...];
                var m_id = reader[...];
                var uma = reader[...];
                yield return new UserModule (userid, m_id, uma)
            }
        }
    }
    public IEnumerable<User> GetUsers()
    {
        var userModulesLookup = GetUserModules().ToLookup(x => x.UserId);
        using (var db = ...)
        {
            db.setCommandText("SELECT * FROM USERS");
            using (var reader = db.ExecuteReader())
            {
                while (reader.Read())
                {
                    var userId = reader["userId"];
                    ...blah blah blah...
                    var user = return new User();
                    user.Modules = new ObservableCollection<UserModule>
                                         (userModulesLookup[userId]);
                    ...blah blah blah...
                    yield return user;
                }
            }
        }
    }
    public void LoadUsers()
    {
        var users = GetUsers();
        foreach(var u in users)
            _users.Add(u);
    }
