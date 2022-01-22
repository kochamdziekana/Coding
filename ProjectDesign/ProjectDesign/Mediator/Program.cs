using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator
{
    public class Program // działa na zasadzie elementu zarządzającego komunikacją poszczególnych elementów między sobą
    {
        public static void Main(string[] args)
        {
            Button submitButton = new Button();
            Checkbox clientType = new Checkbox();

            new RegisterClientView(clientType, submitButton);

            clientType.Select(); // dzięki Notify sie wyswietla nawet bez deklaracji zmiennej
            submitButton.Click();
        }

    }
}