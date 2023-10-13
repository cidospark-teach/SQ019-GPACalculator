using GPACalculator.Logic.Commons;
using System;

namespace GPACalculator.Logic.Models
{
    public class CourseRecord
    {
        public string Id = Guid.NewGuid().ToString();

        private string _courseName;
        public string CourseName
        {
            get { return _courseName; }
            set
            {
                _courseName = Utilities.RemoveDigitFromStart(value.Trim());
                _courseName = Utilities.FirstCharacterToUpper(_courseName);
            }
        }

        public int CourseUnit;
        public double Score;
        public char Grade;
        public int GradeUnit;
        public int QualityPoint;
    }
}