using System;
using System.Collections.Generic;

namespace ClinicalModel
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Problem> Problems { get; set; }

    }
    public class Problem
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
