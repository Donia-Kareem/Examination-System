using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public abstract class Exam
    {
        public int TimeDuration { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }
        public Subject Subject { get; set; }

        protected Exam(int timeDuration, Subject subject)
        {
            TimeDuration = timeDuration > 0 ? timeDuration : throw new ArgumentException("TimeDuration must be positive.");
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Questions = new List<Question>();
            NumberOfQuestions = 0;
        }
        public void TakeExam()
        {
            Console.WriteLine($"Starting {Subject.SubjectName} exam (Duration: {TimeDuration} minutes, Questions: {NumberOfQuestions})");
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}:");
                Questions[i].CollectUserAnswer();
            }
        }
        public abstract void ShowExam();

    }

    public class FinalExam : Exam
    {
        public double TotalGrade { get; private set; }

        public FinalExam(int timeDuration, Subject subject) : base(timeDuration, subject)
        {
        }
        public void AddQuestion(Question question)
        {
            Questions.Add(question);
            NumberOfQuestions = Questions.Count;
        }
        public void CalculateGrade()
        {
            double totalMarks = 0;
            double earnedMarks = 0;

            foreach (var question in Questions)
            {
                totalMarks += question.Mark;

                if (question.IsCorrectAnswer())
                {
                    earnedMarks += question.Mark;
                }
            }
            if (totalMarks > 0)
                TotalGrade = (earnedMarks / totalMarks) * 100;
            else
                TotalGrade = 0;
        }
        public override void ShowExam()
        {
            CalculateGrade();
            Console.WriteLine($"\n{Subject.SubjectName} Final Exam Results:");
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"\nQ{i + 1}:");
                Questions[i].Show();
            }
            Console.WriteLine($"\nTotal Grade: {TotalGrade}%");
        }
    }
    public class PracticalExam : Exam
    {
        public PracticalExam(int timeDuration, Subject subject) : base(timeDuration, subject) { }
       
        public void AddQuestion(MCQQuestion question)
        {
            Questions.Add(question);
            NumberOfQuestions = Questions.Count;
        }
        public override void ShowExam()
        {
            Console.WriteLine($"\n{Subject.SubjectName} Practical Exam Correct Answers:");
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"\nQ{i + 1}: {Questions[i].Body}");
                Console.WriteLine($"Correct Answer: {Questions[i].CorrectAnswer.ToString()}");
            }
        }
    }
}
