    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            Window2 secondWindow;
            public MainWindow()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                secondWindow = new Window2();
                secondWindow.RaiseCustomEvent += new Window2.myCustomEventHandler(secondWindow_RaiseCustomEvent);
                secondWindow.ShowDialog();
            }
            void secondWindow_RaiseCustomEvent(object sender, myCustomEventArgs e)
            {
                scrollViewer1.Content = e.retrieveObject;
            }
        }
    }
