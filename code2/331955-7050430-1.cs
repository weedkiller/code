    //untested, incomplete
    class MyReader : StreamReader
    {
        public MyReader(Stream strm)
            : base(strm)
        {
        }
    
        private int lastChar = -1;
        public override int Read()
        {
            int ch;
    
            if (lastChar >= 0)
            {
                ch = lastChar;
                lastChar = -1;
            }
            else
            {
                ch = base.Read();  // could be -1 
            }
            return ch;
        }
    
        public void PushBack(char ch)  // char, don't allow Pushback(-1)
        {
            if (lastChar >= 0) 
              throw new InvalidOperation("PushBack of more than 1 char");
            lastChar = ch;
        }
    }
