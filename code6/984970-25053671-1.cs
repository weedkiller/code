    public class DoubleClickButton : System.Windows.Controls.Button
    {
        [DllImport("user32.dll")]
        static extern uint GetDoubleClickTime();
        // Note that the DoubleClickTime property gets 
        // the maximum number of milliseconds allowed between 
        // mouse clicks for a double-click to be valid.
        int previousClick = (int)GetDoubleClickTime();
        public event EventHandler DoubleClick;
        protected override void OnClick()
        {
            int now = System.Environment.TickCount;
            // A double-click is detected if the the time elapsed
            // since the last click is within DoubleClickTime.
            if (now - previousClick <= (int)GetDoubleClickTime())
            {
                // Raise the DoubleClick event.
                if (DoubleClick != null)
                    DoubleClick(this, EventArgs.Empty);
            }
            // Set previousClick to now so that 
            // subsequent double-clicks can be detected.
            previousClick = now;
            base.OnClick();
        }
        // Event handling code for the DoubleClick event.
        protected virtual void OnDoubleClick(EventArgs e)
        {
            if (DoubleClick != null)
                DoubleClick(this, e);
        }
    }
