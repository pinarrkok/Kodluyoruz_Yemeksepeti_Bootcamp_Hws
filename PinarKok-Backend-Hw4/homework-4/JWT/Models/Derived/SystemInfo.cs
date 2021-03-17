using JWT.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models.Derived
{
    public class SystemInfo : Resource
    {
        public string Title { get; set; }
        public string Website { get; set; }
    }
}
