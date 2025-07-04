using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
   public class Subject
    {
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(string subjectId, string subjectName)
        {
            SubjectId = subjectId ?? throw new ArgumentNullException(nameof(subjectId));
            SubjectName = subjectName ?? throw new ArgumentNullException(nameof(subjectName));
        }
        public void CreateExam(string examType, int timeDuration)
        {
            if (examType.ToLower() == "final")
            {
                Exam = new FinalExam(timeDuration, this);
            }
            else if (examType.ToLower() == "practical")
            {
                Exam = new PracticalExam(timeDuration, this);
            }
            else
            {
                throw new ArgumentException("Invalid exam type. Use 'final' or 'practical'.");
            }
        }
    }
}
