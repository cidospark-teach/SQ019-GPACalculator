using GPACalculator.Logic.Commons;
using GPACalculator.Logic.Core;
using GPACalculator.Logic.Models;
using GPACalculator.UI.ViewModel;
using System;
using System.Collections.Generic;

namespace GPACalculator.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // user input
            var inputs = GetInputs();

            // map inputs to course records
            var records = new List<CourseRecord>();
            foreach(var record in inputs.ScoreInputs)
            {
                records.Add(new CourseRecord { CourseName = record.CourseName, CourseUnit = record.CourseUnit, Score = record.Score });
            }

            var cal = new Calculator();
            try
            {
                // grade student
                var result = cal.GetResult(records);

                // map result to report
                var report = new Report
                {
                    StudentName = inputs.StudentName,
                    Results = new List<Result> { result }
                };

                // print report
                DisplayReport(report);

            }
            catch(Exception e)
            {
                Console.WriteLine("Caught Error: "+ e.Message);
            }         


        }



        // Display report
        public static void DisplayReport(Report report)
        {

            if(report == null)
                Console.WriteLine("Report is enpty!");

            int widthOfTable = 85;
            Console.Clear();

            Utilities.PrintLine(widthOfTable);
            Utilities.PrintRow(widthOfTable, $"RESULT FOR {report.StudentName.ToUpper()}");
            Utilities.PrintLine(widthOfTable);

            Utilities.PrintRow(widthOfTable, "COURSE NAME", "COURSE UNIT", "SCORE", "GRADE", "GRADE POINT", "QUALITY POINT");
            Utilities.PrintLine(widthOfTable);
            
            foreach(var RP in report.Results[0].CourseRecords)
            {
                Utilities.PrintRow(widthOfTable, RP.CourseName, RP.CourseUnit.ToString(), RP.Score.ToString(), RP.Grade.ToString(), RP.GradeUnit.ToString(), RP.QualityPoint.ToString());
            }
            
            Utilities.PrintLine(widthOfTable);

            Console.WriteLine($"Your GPA is: "+ report.Results[0].GPA);

            Console.WriteLine($"\nGPA is calculated using the formula: ");
            Console.WriteLine("GPA = (total QP) / (total course units)");

            Console.ReadLine();
        }



        // get inputs
        public static InputForm GetInputs()
        {
            var input = new InputForm();

            try
            {
                Console.Write("\nEnter your name: ");
                input.StudentName = Console.ReadLine();


                Console.Write("\nEnter number of courses: ");
                var numberOfCourses = int.Parse(Console.ReadLine());

                for (int i = 0; i < numberOfCourses; i++)
                {
                    Console.Write($"\n\n({i+1}) Enter course name eg(Maths-101): ");
                    var courseName = Console.ReadLine();

                    Console.Write("\nEnter course unit: ");
                    var courseUnit = int.Parse(Console.ReadLine());

                    Console.Write("\nEnter score: ");
                    var score = int.Parse(Console.ReadLine());

                    input.ScoreInputs.Add(new ScoreInput { CourseName = courseName, CourseUnit = courseUnit, Score = score });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nCaught Error: " + e.Message);
            }

            return input;
        }
    }
}
