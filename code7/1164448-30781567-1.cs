    public partial class Form1 : Form
    {
        private void btn_Click(object sender, EventArgs e)
        {
            A obj = new A();
            obj.foo(Test);
        }
        
        public string Test(string par)
        {
            //to_stuff
        }
    }
    class A
    {
        public void foo(Func<string, string> callback)
            //Do_stuff
            //...
            if (callback != null)
            {
                callback(Par);
            }
            //Do...
        }
    }
