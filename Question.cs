using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer CorrectAnswer { get; set; }
        public Answer UserAnswer { get; set; }


        protected Question(string header, string body, double mark, Answer[] answerList, Answer correctAnswer)
        {
            Header = header ?? throw new ArgumentNullException(nameof(header));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Mark = mark > 0 ? mark : throw new ArgumentException("Mark must be positive.");
            AnswerList = answerList ?? throw new ArgumentNullException(nameof(answerList));
            if (answerList.Length == 0)
                throw new ArgumentException("AnswerList cannot be empty.");
            CorrectAnswer = correctAnswer;
        }
        public abstract void Show();
        public abstract bool IsCorrectAnswer();
        public abstract void CollectUserAnswer();
    }

    public class TFQuestion : Question
    {
        public TFQuestion(string header, string body, double mark, Answer correctAnswer)
            : base(header, body, mark,
              new Answer[]
              {
                   new Answer("T", "True"),
                   new Answer("F", "False")
              },
              correctAnswer
             )
        {
            if (correctAnswer.Answer_Id != "T" && correctAnswer.Answer_Id != "F")
                throw new ArgumentException("CorrectAnswer Answer_Id must be 'T' or 'F'");
        }

        public override bool IsCorrectAnswer()
        {
            if (UserAnswer == null)
                return false;
            try
            {
                return UserAnswer != null && UserAnswer.Answer_Id == CorrectAnswer.Answer_Id;

            }
            catch (InvalidCastException)
            {
                return false;
            }
        }
        public override void Show()
        {
            Console.WriteLine($"[{Header}]");
            Console.WriteLine($"{Body} (True/False, {Mark} marks)");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine("Option: " + answer);
            }

            Console.WriteLine($"Your Answer: {(UserAnswer != null ? UserAnswer.ToString() : "Not answered")}");
            Console.WriteLine($"Correct Answer: {CorrectAnswer.ToString()}");
        }
        public override void CollectUserAnswer()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"[{Header}]");
                    Console.WriteLine($"{Body} (Enter T for True, F for False, {Mark} marks): ");
                    string input = Console.ReadLine()?.ToUpper();
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new InvalidAnswerException("Input cannot be empty.Please enter 'T' or 'F'");
                    }
                    bool isValid = false;
                    foreach (var answer in AnswerList)
                    {
                        if (answer.Answer_Id == input)
                        {
                            UserAnswer = answer;
                            isValid = true;
                            break;
                        }
                    }
                    if (!isValid)
                    {
                        throw new InvalidAnswerException("Invalid input. Please enter 'T' or 'F'.");
                    }

                    break;

                }
                catch (InvalidAnswerException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, double mark, Answer[] answerList, Answer correctAnswer)
         : base(header, body, mark, answerList, correctAnswer)
        {
            if (answerList.Length < 3)
                throw new ArgumentException("MCQQuestion must have at least three answers.");
        }
        public override bool IsCorrectAnswer()
        {
            if (UserAnswer == null)
                return false;
            try
            {
                return UserAnswer != null && UserAnswer.Answer_Id == CorrectAnswer.Answer_Id;
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }
        public override void CollectUserAnswer()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"[{Header}]");
                    Console.WriteLine($"{Body} ({Mark} marks)");
                    foreach (var answer in AnswerList)
                    {
                        Console.WriteLine("Option: " + answer);
                    }
                    string input = Console.ReadLine()?.ToUpper();

                    if (string.IsNullOrEmpty(input))
                    {
                        throw new InvalidAnswerException(" Please enter a valid option (e.g., A, B, C, D).");
                    }
                    bool isvalid = false;
                    foreach (var answer in AnswerList)
                    {
                        if (answer.Answer_Id==input)
                        {
                            UserAnswer = answer;
                            isvalid = true;
                            break;
                        }
                    }
                    if (!isvalid)
                    {
                        throw new InvalidAnswerException(" Please enter a valid option (e.g., A, B, C, D).");
                    }    
                    break;
                }
                catch(InvalidAnswerException ex) 
                { 
                Console.WriteLine(ex.Message);
                }
            }
        }           

        public override void Show()
        {
            Console.WriteLine($"[{Header}]");
            Console.WriteLine($"{Body} (True/False, {Mark} marks)");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine("Option: " + answer);
            }

            Console.WriteLine($"Your Answer: {(UserAnswer != null ? UserAnswer.ToString() : "Not answered")}");
            Console.WriteLine($"Correct Answer: {CorrectAnswer.ToString()}");
        }
    }
}




