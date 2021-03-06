    var dictShort = dsShort.Tables[0].AsEnumerable()
                .GroupBy(row => tokens.Select(token => row[token]).ToArray(),
                    DataRowComparer.Default)
                .Where(g => exp.GroupSizeOk((uint)g.Count()))
                .OrderBy(g => g.Count())
                .ToDictionary(g => string.Join(", ", g.Key), g => g.ToList());
