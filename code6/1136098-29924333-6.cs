    timer.Elapsed += ((source, e) =>
    {
        var INDEX = Form.ActiveForm.Controls.IndexOfKey("errorBox");
        Debug.WriteLine(Form.ActiveForm.Controls[INDEX]);
        Form.Invoke((MethodInvoker)delegate
        {
            Form.ActiveForm.Controls[INDEX].Text = "";
        });
        Debug.WriteLine("2" + Form.ActiveForm.Controls[INDEX]);
    });
    timer.Enabled = true;
    timer.Start();
