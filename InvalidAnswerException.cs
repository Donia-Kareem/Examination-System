using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class InvalidAnswerException : Exception
    {
        public InvalidAnswerException(string message) : base(message) { }
    }
}
