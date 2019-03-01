using System.Windows;

namespace WpfApp2
{
    class PersonDataViewModel 
    {
        private Person _personData;

        public PersonDataViewModel(Person data)
        {
            PersonData = data;
           
            if (PersonData.IsBirthday)
            {
                MessageBox.Show("Happy BirthDay " + PersonData.Name + "!");
            }
        }

        public string PersonName { get => "Name: " + PersonData.Name; }

        public string PersonSurName { get => "Surname: " + PersonData.Surname; }

        public string PersonEmail { get => "Email: " + PersonData.Email; }

        public string PersonBirthDate { get => "Birth date: " + PersonData.BirthDate.ToLongDateString(); }

        public string PersonZodiac { get => "Sun sign: " + PersonData.SunSign; }

        public string PersonChineseZodiac { get => "Chinese sign: " + PersonData.ChineseSign; }

        public string PersonAdult { get => "Adult: " + (PersonData.IsAdult ? "Yes" : "No"); }

        public string PersonBirthDayToday { get => "Has birsthday today: " + (PersonData.IsBirthday ? "Yes, Happy Birthday!" : "No"); }

        private Person PersonData { get => _personData; set => _personData = value; }
    }
}
