using System.Collections.Generic;

namespace GPACalculator.Logic.Models
{
    public class Result
    {
        public List<CourseRecord> CourseRecords;
        public string GPA;

        public Result()
        {
            CourseRecords = new List<CourseRecord>();
        }
    }
}