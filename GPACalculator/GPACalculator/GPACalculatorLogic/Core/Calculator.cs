using GPACalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculator.Logic.Core
{
    public class Calculator
    {


        // calculate quality Point
        public List<CourseRecord> CalculateQualityPoint(List<CourseRecord> records)
        {
            if (records == null)
                throw new Exception("Null entry");

            foreach (var record in records)
            {
                record.QualityPoint = record.CourseUnit * record.GradeUnit;
            }
            return records;
        }


        // calucluate GPA
        public string CalculateGPA(List<CourseRecord> records)
        {
            if (records == null)
                throw new Exception("Null entry");

            double totalQualityPoint = 0;
            double totalCourseUnit = 0;

            foreach(var record in records)
            {
                totalQualityPoint += record.QualityPoint;
                totalCourseUnit += record.CourseUnit;
            }

            var gpa = totalQualityPoint / totalCourseUnit;
            // decimal.Round(yourValue, 2, MidpointRounding.AwayFromZero); if i want to return the value in decimal format
            //return gpa.ToString("0.##");    with this formatting I can set to any decimal place. Just depends on the number of # I add after the dot      
            return gpa.ToString("F");
        }



        // grade score
        public List<CourseRecord> GetGrade(List<CourseRecord> records)
        {
            if (records == null)
                throw new Exception("Null entry");

            var gradeSystem = GradeSystem.Grades;
            var found = false;

            foreach(var record in records)
            {
                for(int i = 0; i < gradeSystem.Count; i++)
                {
                    if (record.Score >= gradeSystem[i].MinScore && record.Score <= gradeSystem[i].MaxScore)
                    {
                        record.Grade = gradeSystem[i].Grade;
                        record.GradeUnit = gradeSystem[i].GradePoint;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    throw new Exception("No matching grade found for "+ record.Score);
                }
                
            }

            return records;
            
        }



        // grade student
        public Result GetResult(List<CourseRecord> records)
        {
            if (records == null)
                throw new Exception("Null entry");

            // Grade score
            var gradedResult = GetGrade(records);

            // calculate Quality Point
            var calculatedQP = CalculateQualityPoint(gradedResult);

            // calculate GPA
            var calculatedGPA = CalculateGPA(calculatedQP);

            var rs = new Result
            {
                CourseRecords = calculatedQP,
                GPA = calculatedGPA
            }; 

            return rs;

        }
    }
}
