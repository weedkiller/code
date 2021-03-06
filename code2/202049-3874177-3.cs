    public static class ControlHelpers
    {
        public static void InvokeIfRequired(this Control control, Action<Control> action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action(control)));
            }
            else
            {
                action(control);
            }
        }
    }
