using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMapperExample.Core
{
    public class Customer
    {
        public long ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string EmailAddress { get; set; }
        public int CustomerId { get; private set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
