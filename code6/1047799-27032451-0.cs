    public string NextValue(string Counting)
    {
        int nextVal;
        if(int.TryParse(Counting, out nextVal))
        {
            return ++nextVal;
        }
        else
        {
            // Invalid string. your error handling code
        }    
    }
