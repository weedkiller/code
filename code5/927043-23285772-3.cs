        private void txtBody_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                scrlView.UpdateLayout();
                scrlView.ScrollToVerticalOffset(scrlView.ExtentHeight);
            }
        }
