using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace temp
{
    public class IgraciVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int height { get; set; }
        public string brithplace { get; set; }

        public static List<IgraciVM> Get()
        {
            return new List<IgraciVM> { };
        }
    }
}