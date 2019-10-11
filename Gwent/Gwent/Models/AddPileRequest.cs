using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gwent.Models
{
    public class AddPileRequest
    {
        public string Op { get; set; }
        public string Path { get; set; }
        public int NumberOfCards { get; set; }
    }
}