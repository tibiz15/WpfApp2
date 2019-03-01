using WpfApp2.controlls;

namespace WpfApp2
{
    class ColorInputEmail : ColorControll
    {
      
        EmailModel model = new EmailModel();

        protected override bool ValidText(string text)
        {
            return model.IsValidEmail(text);
        }

    }
}

