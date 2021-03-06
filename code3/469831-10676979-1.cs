    public double PropertyTaxRate
    {
        get { return _propertyTaxRate; }
        set { 
            if (value > 1) {
                value /= 100;
            }
            if (value != _propertyTaxRate) {
                SetValueAndNotify(() => PropertyTaxRate, ref _propertyTaxRate, value); 
                PropertyTaxYear = value * SharedValues.HomeValue;
            }
        }
    }
    public double PropertyTaxMonth
    {
        get { return _propertyTaxMonth; }
        set {
            if (value != _propertyTaxMonth) {
                SetValueAndNotify(() => PropertyTaxMonth, ref _propertyTaxMonth, value); 
                PropertyTaxYear = 12 * value;
            }
        }
    }
    public double PropertyTaxYear
    {
        get{ return _propertyTaxYear; }
        set { 
            if (value != _propertyTaxYear) {
                SetValueAndNotify(() => PropertyTaxYear, ref _propertyTaxYear, value);
                PropertyTaxMonth = value / 12;
                PropertyTaxRate = value / SharedValues.HomeValue;
            }
        }
    }
