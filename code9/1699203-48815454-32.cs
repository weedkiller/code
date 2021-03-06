    public static List<T> ParseCsvInfo<T>(List<String[]> split) where T : new()
    {
        // No template row, or only a template row but no data. Abort.
        if (split.Count < 2)
            return new List<T>();
        String[] templateRow = split[0];
        // Create a dictionary of rows and their index in the file data.
        Dictionary<String, Int32> columnIndexing = new Dictionary<String, Int32>();
        for (Int32 i = 0; i < templateRow.Length; i++)
        {
            String colHeader = templateRow[i].Trim().ToUpper();
            if (!columnIndexing.ContainsKey(colHeader))
                columnIndexing.Add(colHeader, i);
        }
        // Prepare the arrays of property parse info. We set the length
        // so the highest found column index exists in it.
        Int32 numCols = columnIndexing.Values.Max() + 1;
        // Actual property to fill in
        PropertyInfo[] properties = new PropertyInfo[numCols];
        // Regex to validate the string before parsing
        Regex[] propValidators = new Regex[numCols];
        // Type converters for automatic parsing
        TypeConverter[] propconverters = new TypeConverter[numCols];
        // go over the properties of the given type, see which ones have a
        // CsvColumnAttribute, and put these in the list at their CSV index.
        foreach (PropertyInfo p in typeof(T).GetProperties())
        {
            object[] attrs = p.GetCustomAttributes(true);
            foreach (Object attr in attrs)
            {
                CsvColumnAttribute csvAttr = attr as CsvColumnAttribute;
                if (csvAttr == null)
                    continue;
                Int32 index;
                if (!columnIndexing.TryGetValue(csvAttr.Name.ToUpper(), out index))
                {
                    // If no valid column is found, and the regex for this property
                    // does not allow an empty value, then all lines are invalid.
                    if (!csvAttr.ValidationRegex.IsMatch(String.Empty))
                        return new List<T>();
                    // No valid column found: ignore this property.
                    break;
                }
                properties[index] = p;
                propValidators[index] = csvAttr.ValidationRegex;
                // automatic type converter.
                propconverters[index] = TypeDescriptor.GetConverter(p.PropertyType);
                break; // Only handle one CsvColumnAttribute per property.
            }
        }
        List<T> objList = new List<T>();
        // start from 1 since the first line is the template with the column names
        for (Int32 i = 1; i < split.Count; i++)
        {
            Boolean abortLine = false;
            String[] line = split[i];
            // make new object of the given type
            T obj = new T();
            Int32 col = 0;
            while (properties.Length > col)
            {
                String curVal = col < line.Length ? line[col] : String.Empty;
                PropertyInfo prop = properties[col];
                // this can be null if the column was not found.
                if (prop != null)
                {
                    // check validity. Abort if not valid.
                    Boolean valid = propValidators[col].IsMatch(curVal);
                    if (!valid)
                    {
                        // Add logging here? We have the line and column index.
                        abortLine = true;
                        break;
                    }
                    // Automated parsing. Make sure to use nullable types
                    // for nullable properties.
                    Object value = propconverters[col].ConvertFromString(curVal);
                    prop.SetValue(obj, value, null);
                }
                col++;
            }
            if (!abortLine)
                objList.Add(obj);
        }
        return objList;
    }
