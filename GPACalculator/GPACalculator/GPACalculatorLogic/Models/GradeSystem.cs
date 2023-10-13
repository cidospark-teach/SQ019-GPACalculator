using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculator.Logic.Models
{
    public static class GradeSystem
    {
        public static List<GradeScheme> Grades { get; set; }
        static GradeSystem()
        {
            Grades = new List<GradeScheme>
            {
                new GradeScheme{ MinScore = 70, MaxScore = 100, Grade = 'A', GradePoint = 5, Remark = "Excellent"},
                new GradeScheme{ MinScore = 60, MaxScore = 69, Grade = 'B', GradePoint = 4, Remark = "Very Good"},
                new GradeScheme{ MinScore = 50, MaxScore = 59, Grade = 'C', GradePoint = 3, Remark = "Good"},
                new GradeScheme{ MinScore = 45, MaxScore = 49, Grade = 'D', GradePoint = 2, Remark = "Fair"},
                new GradeScheme{ MinScore = 40, MaxScore = 44, Grade = 'E', GradePoint = 1, Remark = "Pass"},
                new GradeScheme{ MinScore = 0,  MaxScore = 39, Grade = 'F', GradePoint = 0, Remark = "Fail"},
            };
        }
    }

    public class GradeScheme
    {
        public string Id = Guid.NewGuid().ToString();
        public int MinScore;
        public int MaxScore;
        public char Grade;
        public int GradePoint;
        public string Remark;
    }
}
