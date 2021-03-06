                var st = old.Trim().Split(new char[] { '\t' });
                bool hasDeleteMatch = false;
                //loop through all the columns starting at 0 and up to 1 (inclusive)
                for (int col = 0; col < st.Length && col<=1; col++) 
                {
                    var tempCode = st[col].Substring(1, st[col].Length - 2);
                    if (!deleteCodeList.Contains(tempCode))
                    {
                        hasDeleteMatch = true; //we found a match, don't append to the new file
                        break;
                    }
                }
                if (!hasDeleteMatch) sb.AppendLine(old);
