    public event EventHandler TextChanged;
    private string _text;
    public string Text {
        get { return _text; }
        set {  _text = value; TextChanged.Raise(this);  }
    }
