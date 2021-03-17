using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteList.Data.Entities
{
    public class WhiteListDto
    {
        public string Ip { get; set; }

        public List<string> Allows { get; set; }

    }
}
