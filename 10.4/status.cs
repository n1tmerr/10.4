using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._4
{
     class statuses
    {
        public string Name { get; set; }
        public Status status { get; set; }
        public statuses(string name, Status st)
        {
            Name = name;
            status = st;
        }
    }
    public enum Status
    {
        Active,
        completed
    }
}

