     TextBlock txt1 = new TextBlock();
            txt1.Height = 72;
            txt1.Width = 72;
            txt1.Margin = new Thickness(193, 3, 0, 0);
            InputScope inputScope = new InputScope();
            InputScopeName inputScopeName = new InputScopeName();
            inputScopeName.NameValue = InputScopeNameValue.Number;
            
            inputScope.Names.Add(inputScopeName);
            txt1.InputScope = inputScope;
            SomeGrid.Children.Add(txt1); // somegrid is a parent control in which you wanted to add your textblock
