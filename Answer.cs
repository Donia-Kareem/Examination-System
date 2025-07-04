using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Answer
    {
        public string Answer_Id { get; set; }
        public string Answer_Text { get; set; }

        public Answer(string answerId, string answerText)
        {
            Answer_Id = answerId ?? throw new ArgumentNullException(nameof(answerId));
            Answer_Text = answerText ?? throw new ArgumentNullException(nameof(answerText));
        }

        public override string ToString()
        {
            return $"{Answer_Id}) {Answer_Text}";
        }
    }
}
