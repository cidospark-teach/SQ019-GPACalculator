using GPACalculator.Logic.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculator.UI.ViewModel
{
    public class InputForm
    {
        private string _studentName;
        public string StudentName
        {
            get { return _studentName; }
            set
            {
                _studentName = Utilities.RemoveDigitFromStart(value.Trim());
                _studentName = Utilities.FirstCharacterToUpper(_studentName);
            }
        }

        public List<ScoreInput> ScoreInputs;

        public InputForm()
        {
            ScoreInputs = new List<ScoreInput>();
        }
    }
}
