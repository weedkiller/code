    public static class UIExtensionMethods
    {
        public static async Task<bool> DoneTyping(this TextBox txb)
        {
            string txt = txb.Text;
            await Task.Delay(500);
            return txt == txb.Text;
        }
    }
