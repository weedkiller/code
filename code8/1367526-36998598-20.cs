    public partial class UCBind : UserControl
    {
        ImageList imgList { get; set; }
        public UCBind()
        {
            InitializeComponent();
        }
        public UCBind(DataRow row, ImageList imglist)
        {
            InitializeComponent();
            if (row != null)
            {
                imgList = imglist;
                DisplayData(row);
            }
        }
        public void DisplayData(DataRow row)
        {
            lbl_field1.Text = row.Field<int>(0) + "";
            lbl_field2.Text = row.Field<string>(1);
            lbl_field3.Text = row.Field<string>(2);
            if (imgList != null) BackgroundImage = imgList.Images[row.Field<string>(3)];
        }
    }
