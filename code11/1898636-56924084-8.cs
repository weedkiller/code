    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.DisplayMember = "CountryAndCode";
        comboBox1.ValueMember = "CountryCode";
        comboBox1.DataSource = countryCodes;
        comboBox1.SelectedIndex = -1;
        comboBox1.SelectedIndexChanged += (o, ev) => {
            if (comboBox1.SelectedIndex < 0) return;
            comboBox1.BeginInvoke(new Action(() => {
                comboBox1.Text = comboBox1.SelectedValue.ToString();
            }));
        };
    }
    public class CoutryCode
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryAndCode => this.ToString();
        public override string ToString() => 
            this.CountryName + (char)32 + this.CountryCode;
    }
    private List<CoutryCode> countryCodes = new List<CoutryCode>() {
        new CoutryCode() { CountryName = "USA", CountryCode = "+1" },
        new CoutryCode() { CountryName = "Canada", CountryCode = "+1" },
        new CoutryCode() { CountryName = "Argentina", CountryCode = "+54"},
        new CoutryCode() { CountryName = "Brasil", CountryCode = "+55"}
    };
