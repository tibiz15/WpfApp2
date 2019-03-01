using WpfApp2.controlls;

namespace WpfApp2
{
    class ColorInputText : ColorControll
    {
        
        protected override bool ValidText(string text)
        {
            return (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text));
                
        }
    }
}
