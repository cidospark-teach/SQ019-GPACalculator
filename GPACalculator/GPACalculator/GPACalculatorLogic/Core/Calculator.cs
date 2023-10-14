using GPACalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculator.Logic.Core
{
    public class Calculator
    {
        public double totalQualityPoint = 0;
        public double totalCourseUnit = 0;

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
        public void CummulatePoints(CourseRecord record)
        {
            if (record == null)
                throw new Exception("Null entry");

            totalQualityPoint += record.QualityPoint;
            totalCourseUnit += record.CourseUnit;

        }

        public string CalculateGPA()
        {
            var gpa = totalQualityPoint / totalCourseUnit;
            // decimal.Round(yourValue, 2, MidpointRounding.AwayFromZero); if i want to return the value in decimal format
            //return gpa.ToString("0.##");    with this formatting I can set to any decimal place. Just depends on the number of # I add after the dot      

            return gpa.ToString("F");
            
        }

    }
}
