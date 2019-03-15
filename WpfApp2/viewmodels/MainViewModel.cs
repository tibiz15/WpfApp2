using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp2.exceptions;

namespace WpfApp2
{

    class MainViewModel : PropertyChanger
    {
        private DateTime? _birthDate = null;
        private string _nameText;
        private string _surnameText;
        private string _emailText;

        private bool[] _validFields = new bool[4];
        private bool[] ValidFields { get => _validFields; set => _validFields = value; }

        private ICommand _proceedCommand;

        public DateTime BirthDate { get => (DateTime)_birthDate; set => _birthDate = value; }
        public string NameText { get => _nameText; set => _nameText = value; }
        public string SurnameText { get => _surnameText; set => _surnameText = value; }
        public string EmailText { get => _emailText; set => _emailText = value; }

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

        public ICommand ProceedCommand
        {
            get => _proceedCommand;
            set
            {
                _proceedCommand = value;
            }
        }

        public MainViewModel()
        {
            ProceedCommand = new RelayCommand(new Action<object>(ProceedAction));
        }

        private async void ProceedAction(object obj)
        {
            await Task.Run(() => UpdateInfo());
        }

        void UpdateInfo()
        {
            try
            {
                //throws exceptions if invalid parameters
                Person p = new Person(NameText, SurnameText, BirthDate, EmailText);

                //open result screen
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    ActionCompleteWindow window = new ActionCompleteWindow(p);
                    window.ShowDialog();
                });
            }
            catch(FutureBirthDateException e)
            {
                MessageBox.Show("Future birth date selected: " + e.InvalidBirthDate.ToLongDateString());
            }
            catch(DeadPersonBirthDateException e)
            {
                MessageBox.Show("Dead person birth date selected: " + e.InvalidBirthDate.ToLongDateString());
            }
            catch(InvalidEmailException e) // for email
            {
                MessageBox.Show(e.Message);
            }
            catch (ArgumentException e) // name and surname
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
