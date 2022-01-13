using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface IUIElementFactory
    {
        IButton CreateButton();
        ITextbox CreateTextBox();
    } // niewiadomo jaki obiekt będzie implementować ta fabryka, wiadomo że przycisk, ale niewiadomo jaki
}
