using System;

namespace WpfApp2.exceptions
{
    class FutureBirthDateException : BirthDateException
    {
        public FutureBirthDateException(DateTime birthdate) 
            : base("Specified birth date is from the future!",birthdate)
        {

        }
    }
}
