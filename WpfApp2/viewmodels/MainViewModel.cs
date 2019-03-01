using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace WpfApp2
{
    class MainViewModel : PropertyChanger
    {
        private bool[] _validFields = new bool[4];
        private bool[] ValidFields { get => _validFields; set => _validFields = value; }

        public bool ValidName
        {
            get => ValidFields[0];
            set
            {
                ValidFields[0] = value;

                OnPropertyChanged("FilledFields");
            }
        }

        public bool ValidSurName
        {
            get => ValidFields[1];
            set
            {
                ValidFields[1] = value;

                OnPropertyChanged("FilledFields");
            }
        }

        public bool ValidEmail
        {
            get => ValidFields[2];
            set
            {
                ValidFields[2] = value;

                OnPropertyChanged("FilledFields");
            }
        }

        public bool ValidBirth
        {
            get => ValidFields[3];
            set
            {
                ValidFields[3] = value;

                OnPropertyChanged("FilledFields");
            }
        }

        public bool FilledFields
        {
            get
            {
                return ValidFields.All(x => x);
            }

        }

        private ICommand _proceedCommand;

        public MainViewModel()
        {
            ProceedCommand = new RelayCommand(new Action<object>(ProceedAction));
        }

        public ICommand ProceedCommand
        {
            get => _proceedCommand;
            set
            {
                _proceedCommand = value;
            }
        }
        private ValidationModel check = new ValidationModel();

        public DateTime BirthDate { get => (DateTime)_birthDate; set => _birthDate = value; }
        public string NameText { get => _nameText; set => _nameText = value; }
        public string SurnameText { get => _surnameText; set => _surnameText = value; }
        public string EmailText { get => _emailText; set => _emailText = value; }

        private DateTime? _birthDate = null;

        private string _nameText;

        private string _surnameText;

        private string _emailText;

        private void ProceedAction(object obj)
        {
            if(check.isValidBirthDate(BirthDate))
            {
                Person p = new Person(NameText, SurnameText, BirthDate, EmailText);
                
                ActionCompleteWindow window = new ActionCompleteWindow(p);
                window.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Invald date selected!");
            }
            
        }

    }
}
