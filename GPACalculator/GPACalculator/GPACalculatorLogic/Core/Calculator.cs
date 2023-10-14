using GPACalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculator.Logic.Core
{
    public class Calculator
    {


        // calculate quality Point
        public CourseRecord CalculateQualityPoint(CourseRecord record)
        {
            if (record == null)
                throw new Exception("Null entry");
            record.QualityPoint = record.CourseUnit * record.GradeUnit;
            return record;
        }


        // grade score
        public CourseRecord GetGrade(CourseRecord record)
        {
            if (record == null)
                throw new Exception("Null entry");

            var gradeSystem = GradeSystem.Grades;
            var found = false;
            for (int i = 0; i < gradeSystem.Count; i++)
            {
                if (record.Score >= gradeSystem[i].MinScore && record.Score <= gradeSystem[i].MaxScore)
                {
                    record.Grade = gradeSystem[i].Grade;
                    record.GradeUnit = gradeSystem[i].GradePoint;
                    found = true;
                }
                if (found)
                    break;
            }

            return record;

        }


        // calucluate GPA
        public Result CalculateGPA(List<CourseRecord> records)
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
            
            var output =  gpa.ToString("F");
            var rs = new Result
            {
                CourseRecords = records,
                GPA = output
            };

            return rs;
        }

    }
}
