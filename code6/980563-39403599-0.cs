        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { set; get; }
    }
    public enum SortType
    {
        ByID,
        BySalary
    }
        public class EmployeeDistinctEquality : IEqualityComparer<Employee>
        {
            public EmployeeDistinctEquality()
            {
            }
            public bool Equals(Employee x, Employee y)
            {
                if (x == null && x == null)
                    return true;
                else if (x == null || y == null)
                    return false;
                else if (x.Id == y.Id)
                    return true;
                else
                    return false;
            }
            public int GetHashCode(Employee obj)
            {
                return obj.Id.GetHashCode();
            }
        }
