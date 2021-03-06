    public static class MyExtensions
    {
        public static string ToStringExtension(this object obj)
        {
            StringBuilder sb = new StringBuilder();
            foreach (System.Reflection.PropertyInfo property in obj.GetType().GetProperties())
            {                
                sb.Append(property.Name);
                sb.Append(": ");
                try
                {
                    sb.Append(property.GetValue(obj, null));
                }
                catch (System.Reflection.TargetParameterCountException)
                {
                    sb.Append("Indexed Property cannot be used");
                }   
             
                sb.Append(System.Environment.NewLine);
            }
            return sb.ToString();
        }
    }
