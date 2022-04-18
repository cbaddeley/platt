using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlattCodingChallenge.DataAccess.Models
{
    public class ResponseBody<T>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public IEnumerable<T> results { get; set; }
    }
}
