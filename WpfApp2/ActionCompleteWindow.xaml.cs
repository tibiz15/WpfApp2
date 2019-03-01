
using System.Windows;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for ActionCompleteWindow.xaml
    /// </summary>
    public partial class ActionCompleteWindow : Window
    {
        public ActionCompleteWindow(Person data)
        {
           
            InitializeComponent();
            DataContext = new PersonDataViewModel(data); 

        } 
    }
}
