    // signature: more natural have "parent, excluded":
    // "scan parent without excluded" 
    // IEnumerable<Control> - now I can pass almost any collection, say array
    public static bool Check_Inputs_Empty_Exception(Control parent, 
                                                    IEnumerable<Control> excluded) {
      if (null == parent)
        throw new ArgumentNullException(nameof(parent)); 
    
      // HashSet is more efficient (and convenient) for Contains than List 
      HashSet<Control> exceptions = excluded == null 
        ? new HashSet<Control>()
        : new HashSet<Control>(excluded);
    
      var empty = parent
        .Controls
        .OfType<Control>()
        .Where(control => !exceptions.Contains(control))
        .Where(control => string.IsNullOrEmpty(control.Text))
        .ToArray();
    
      foreach (Control ctrl in empty)
         MessageBox.Show($"{ctrl.Name} is empty");
     
      return empty.Any();
    }
    
    public static bool Check_Inputs_Empty_Exception(Control parent) =>
      Check_Inputs_Empty_Exception(parent, new Control[0]);
