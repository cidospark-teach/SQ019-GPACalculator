using GPACalculator.Logic.Commons;

namespace GPACalculator.UI.ViewModel
{
    public class ScoreInput
    {
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
    }
}
