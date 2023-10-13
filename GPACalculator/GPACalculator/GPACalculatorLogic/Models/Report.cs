using GPACalculator.Logic.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculator.Logic.Models
{
    public class Report
    {
        private string _studentName;
        public string StudentName {
            get { return _studentName; }
            set {
                _studentName = Utilities.RemoveDigitFromStart(value.Trim());
                _studentName = Utilities.FirstCharacterToUpper(_studentName);
            } 
        }

        public List<Result> Results;

        public Report()
        {
            Results = new List<Result>();
        }
    }
}
