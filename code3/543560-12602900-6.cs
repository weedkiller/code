    System.Timers.Timer timer1 = new System.Timers.Timer ();
    timer1.Interval  = periodAfterToStopInMiliseconds;
    timer1.Elapsed += timer1_Elapsed;
    private void ActLikeIWant(double periodAfterToStopInMiliseconds)
    {
        timer1.Start();
    }
    void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
         var timer = (System.Timers.Timer) sender;
         timer.Stop();
         this.prevPanel.Visible = false;
         this.nextPanel.Visible = false;
    }
    private void myMouseHover(object sender, EventArgs e)
    {
        this.prevPanel.Visible = true;
        this.nextPanel.Visible = true;
        ActLikeIWant(periodAfterToStopInMiliseconds: 200);
    }
