`
    class HexNumericUpDown2Digits : NumericUpDown
    {
        protected override void UpdateEditText()
        {
            if (Hexadecimal)
            {
				ChangingText = true;
                Text = $"0x{(int)Value:X2}";
            }
            else
            {
                base.UpdateEditText();
            }
        }
    }
`
