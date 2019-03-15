using System;

namespace WpfApp2.exceptions
{
    class InvalidEmailException : Exception
    {
        public InvalidEmailException(String email) : base("The email specified is invalid: " + email)
        {

        }
    }
}
