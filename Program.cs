using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject programming = new Subject("CS101", "Introduction to Programming");
                                              // Create a Final Exam //
            programming.CreateExam("final", 60);
            FinalExam finalExam = (FinalExam)programming.Exam;

                                            // True / False questions
            finalExam.AddQuestion(new TFQuestion(
                header: "Question 1",
                body: "a variable must be declared before it is used?",
                mark: 5.0,
                correctAnswer: new Answer("T", "True")
            ));
            finalExam.AddQuestion(new TFQuestion(
                header: "Question 2",
                body: "The = operator in C# is used to compare two values?",
                mark: 5.0,
                correctAnswer: new Answer("F", "False")
            ));

                                                 // MCQ questions
            var mcqAnswers = new Answer[]
            {
                new Answer("A", "Container"),
                new Answer("B", "Function"),
                new Answer("C", "Loop"),
                new Answer("D", "Class")
            };
            finalExam.AddQuestion(new MCQQuestion(
                header: "Question 3",
                body: "What is a variable?",
                mark: 10.0,
                answerList: mcqAnswers,
                correctAnswer: mcqAnswers[0]
            ));
            var mcqAnswers2 = new Answer[]
            {
                 new Answer("A", "To read user input"),
                 new Answer("B", "To display text on the screen"),
                 new Answer("C", "To declare a loop"),
                 new Answer("D", "To define a class")
            };
            finalExam.AddQuestion(new MCQQuestion(
                header: "Question 4",
                body: "What is the purpose of Console.WriteLine() in C#?",
                mark: 10.0,
                answerList: mcqAnswers2,
                correctAnswer: mcqAnswers2[1]
            ));
                                            // Run the exam
            finalExam.TakeExam();
            finalExam.ShowExam();
            Console.WriteLine();
            //-----------------------------------------------------------------------------------------------//
                                            // Create a Practical Exam
            Console.WriteLine("practical Exam...");
            programming.CreateExam("practical", 30);
            PracticalExam practicalExam = (PracticalExam)programming.Exam;

                                                   //  MCQ questions
            var mcqAnswers3 = new Answer[]
           {
                  new Answer("A", "Collection of elements"),
                  new Answer("B", "Single variable"),
                  new Answer("C", "Function type"),
                  new Answer("D", "Class instance")
           };
            practicalExam.AddQuestion(new MCQQuestion(
                header: "Question 1",
                body: "What is an array?",
                mark: 10.0,
                answerList: mcqAnswers3,
                correctAnswer: mcqAnswers3[0]
            ));
            var mcqAnswers4 = new Answer[]
           {            new Answer("A", "int"),
                         new Answer("B", "string"),
                        new Answer("C", "bool"),
                        new Answer("D", "float")
           };
            practicalExam.AddQuestion(new MCQQuestion(
                header: "Question 2",
                body: "Which data type is used to store true or false values in C#?",
                mark: 10.0,
                answerList: mcqAnswers4,
                correctAnswer: mcqAnswers4[2]
            ));

            // Run the exam
            practicalExam.TakeExam();
            practicalExam.ShowExam();
        }
    }
    }
