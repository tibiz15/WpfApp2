using System;


namespace WpfApp2
{
    enum ChineseZodiac { Rat = 4, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Goat, Monkey = 0, Rooster, Dog, Pig };

    public class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;

        private Person(string name,string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Person(string name,string surname,string email) : this(name, surname)
        {
            Email = email;
        }

        public Person(string name, string surname, DateTime birthDate) : this(name, surname)
        {
            BirthDate = birthDate;
        }

        public Person(string name, string surname, DateTime birthDate,string email) : this(name,surname,email)
        {
            BirthDate = birthDate;
        }

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }

        public bool IsAdult
        {
            get
            {
                var age = DateTime.Today.Year - BirthDate.Year;
                if (BirthDate > DateTime.Today.AddYears(-age)) age--;
                if (age >= 18) return true;
                return false;
            }
        }

        public string SunSign
        {
            get
            {
                int month = BirthDate.Month;
                int day = BirthDate.Day;
                switch (month)
                {
                    case 1:
                        if (day <= 19)
                            return "Capricorn";
                        else
                            return "Aquarius";

                    case 2:
                        if (day <= 18)
                            return "Aquarius";
                        else
                            return "Pisces";
                    case 3:
                        if (day <= 20)
                            return "Pisces";
                        else
                            return "Aries";
                    case 4:
                        if (day <= 19)
                            return "Aries";
                        else
                            return "Taurus";
                    case 5:
                        if (day <= 20)
                            return "Taurus";
                        else
                            return "Gemini";
                    case 6:
                        if (day <= 20)
                            return "Gemini";
                        else
                            return "Cancer";
                    case 7:
                        if (day <= 22)
                            return "Cancer";
                        else
                            return "Leo";
                    case 8:
                        if (day <= 22)
                            return "Leo";
                        else
                            return "Virgo";
                    case 9:
                        if (day <= 22)
                            return "Virgo";
                        else
                            return "Libra";
                    case 10:
                        if (day <= 22)
                            return "Libra";
                        else
                            return "Scorpio";
                    case 11:
                        if (day <= 21)
                            return "Scorpio";
                        else
                            return "Sagittarius";
                    case 12:
                        if (day <= 21)
                            return "Sagittarius";
                        else
                            return "Capricorn";
                }
                return "Error";                
            }
        }

        public string ChineseSign
        {
            get
            {
                return ((ChineseZodiac)(BirthDate.Year % 12)).ToString();
            }
        }

        public bool IsBirthday
        {
            get
            {
                return (BirthDate.Day == DateTime.Today.Day) && (BirthDate.Month == DateTime.Today.Month);
            }
        }

    }
}
