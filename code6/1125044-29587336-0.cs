        private void Logingo_Click(object sender, EventArgs e)
        {
            int studentiD = 1234;//Your ID
            string Password = "yourPass";//Your Password
            Student st = new Student(studentiD);
            if (st.getID() == studentiD && st.getPassword() == Password)
            {
                Console.WriteLine("Login Successed.");
                st.displays();//display ID,Password,Email,GPA
            }
            else
            {
                Console.WriteLine("Login Failed.");
            }
        }
