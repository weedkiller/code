    [Activity(Theme = "@style/MyTheme.Splash1",NoHistory = true)]
    public class Activity2 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Timer timer = new Timer();
            timer.Interval = 3000; // 3 sec.
            timer.AutoReset = false; // Do not reset the timer after it's elapsed
            timer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                StartActivity(typeof(MainActivity));
            };
            timer.Start();
        }
    }
