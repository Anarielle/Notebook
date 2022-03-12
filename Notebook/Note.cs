using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    internal class Note
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        private int phoneNumber;

        public int PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Country { get; set; }
        public DateTime Birthday { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public int MyProperty { get; set; }
        public string Notes { get; set; }

        public void CreateNote()
        {
            Console.WriteLine("Введите фамилию:");
            LastName = Console.ReadLine();
            while (string.IsNullOrEmpty(LastName))
            {
                Console.WriteLine("Фамилия не введена, попробуйте ещё раз:");
                LastName = Console.ReadLine();
            }

            Console.WriteLine("Введите имя:");
            FirstName = Console.ReadLine();
            while (string.IsNullOrEmpty(FirstName))
            {                
                Console.WriteLine("Имя не введено, попробуйте ещё раз:");
                FirstName = Console.ReadLine();
            }

            Console.WriteLine("Введите номер телефона:");
            bool tryParse = int.TryParse(Console.ReadLine(), out phoneNumber);
            while (phoneNumber == 0 || tryParse);
            {                
                Console.WriteLine("Номер введен некорректно, попробуйте ещё раз:");
                tryParse = int.TryParse(Console.ReadLine(), out phoneNumber);
            }

            Console.WriteLine("Введите страну:");
            Country = Console.ReadLine();
            while (string.IsNullOrEmpty(Country))
            {
                Console.WriteLine("Вы не ввели страну, попробуйте ещё раз:");
                Country = Console.ReadLine();
            }


        }

        public void EditNote()
        {

        }

        public void RemoveNote()
        {

        }

        public void ShowNote()
        {

        }

        public void ShowAllNotes()
        {

        }
    }
}
