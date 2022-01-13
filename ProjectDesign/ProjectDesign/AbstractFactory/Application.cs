using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class Application
    {
        private IUIElementFactory _UIElementFactory;

        public Application(IUIElementFactory elementFactory)
        {
            _UIElementFactory = elementFactory;
        }

        public void RenderUI()
        {
            var createNewFileButton = _UIElementFactory.CreateButton();
            var textbox = _UIElementFactory.CreateTextBox();

            textbox.Render();
        }
    }
}
