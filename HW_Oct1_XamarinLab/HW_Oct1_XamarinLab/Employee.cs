using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HW_Oct1_XamarinLab
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public bool Hockey { get; set; }

        public bool Basketball { get; set; }

        public bool None { get; set; }

        public bool Day { get; set; }

        public bool Evening { get; set; }

        public string IsValid()
        {
            if (Name == null || Name.Length <= 0) return "Name must be inputed";

            if (Salary < 0) return "Salary cannot be negative";

            if (Salary > 100000) return "Salary is too expensive";

            if (!(Hockey || Basketball || None)) return "Must choose a sport";

            if (!Day && !Evening) return "Time must be set";

            return null;
        }
    }
}
