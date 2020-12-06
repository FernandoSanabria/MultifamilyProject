using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSTest.Models.Response
{
    public class Answer
    {
        public bool Successful { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }


        public Answer()
        {
            this.Successful = false;
        }
    }

}
