using System;

namespace WpfApp2
{
    class ValidationModel
    {

        public bool isValidBirthDate(DateTime date)
        {
            int result = DateTime.Compare(DateTime.Today, date);
            if (result < 0 || DateTime.Today.Year - date.Year > 135) return false;
            return true;
        }

    }
}
