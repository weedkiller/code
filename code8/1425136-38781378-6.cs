    /// <summary>
    /// http://stackoverflow.com/questions/38781377
    /// 1. Subtract 1 from the first (left) digit to give a new eleven digit number         
    /// 2. Multiply each of the digits in this new number by its weighting factor         
    /// 3. Sum the resulting 11 products         
    /// 4. Divide the total by 89, noting the remainder         
    /// 5. If the remainder is zero the number is valid          
    /// </summary>
    public bool IsValidAbn(string abn)
    {
        abn = abn?.Replace(" ", ""); // strip spaces
        int[] weight = { 10, 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
        int weightedSum = 0;
        //0. ABN must be 11 digits long
        if (string.IsNullOrEmpty(abn) || !Regex.IsMatch(abn, @"^\d{11}$"))
        {
            return false;
        }
        //Rules: 1,2,3                                  
        for (int i = 0; i < weight.Length; i++)
        {
            weightedSum += (int.Parse(abn[i].ToString()) - (i == 0 ? 1 : 0)) * weight[i];
        }
        //Rules: 4,5                 
        return weightedSum % 89 == 0;
    }
