using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Notebook
    {
        public Dictionary<int, Note> allNotes = new Dictionary<int, Note>();
        public List<string> commands = new List<string>() { "create", "show", "edit", "del", "all", "exit" };
        public static void Main(string[] args)
        {
            new Notebook().Action();
        }

        private static void Greetings()
        {
            Console.WriteLine("Добро пожаловать в нашу записную книжку!");
            Console.WriteLine("\t- для создания новой записи введите команду: create.");
            Console.WriteLine("\t- для просмотра записи введите команду: show.");
            Console.WriteLine("\t- для редактирования записи введите команду: edit.");
            Console.WriteLine("\t- для удаления записи введите команду: del.");
            Console.WriteLine("\t- для просмотра списка всех записей введите команду: all.");
            Console.WriteLine("\t- для выхода из программы введите команду: exit.");
        }

        private void Action()
        {
            while (true)
            {
                Greetings();
                Console.Write("Введите команду: ");
                string choice;
                while (true)
                {
                    choice = Console.ReadLine();

                    if (!commands.Contains(choice))
                    {
                        Console.Write("Данной команды не найдено! Попробуйте ещё раз: ");
                    }
                    else
                    {
                        break;
                    }
                }
                switch (choice)
                {
                    case "create":
                        CreateNote();
                        break;
                    case "show":
                        ReadNote();
                        break;
                    case "edit":
                        UpdateNote();
                        break;
                    case "del":
                        DeleteNote();
                        break;
                    case "all":
                        ShowAllNotes();
                        break;
                    case "exit":
                        return;
                }
            }
        }

        private int id = 0;
        private void CreateNote()
        {
            Note note = new Note() { Id = id };
            note.Surname = ReadUntilValidationPass("Surname");
            note.Name = ReadUntilValidationPass("Name");
            note.SecondName = ReadUntilValidationPass("SecondName");
            note.Phone = ReadUntilValidationPass("Phone");
            note.Country = ReadUntilValidationPass("Country");
            note.DateOfBirth = ReadUntilValidationPass("DateOfBirth");
            note.Organization = ReadUntilValidationPass("Organization");
            note.Position = ReadUntilValidationPass("Position");
            note.Remark = ReadUntilValidationPass("Remark");

            allNotes.Add(id, note);
            Console.WriteLine($"Запись успешно создана! Номер записи {id}\n");
            id++;
        }
        private void ReadNote()
        {
            if (allNotes.Count == 0)
            {
                Console.WriteLine($"Вы еще не создали ни одной записи!\n");
                return;
            }

            Console.Write("Введите Id записи: ");
            int id;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Введен некорректный идентификатор!");
                }
                else if (!allNotes.ContainsKey(id))
                {
                    Console.WriteLine("Данной записи не найдено!");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(allNotes[id]);
        }

        private void UpdateNote()
        {
            if (allNotes.Count == 0)
            {
                Console.WriteLine($"Вы еще не создали ни одной записи!\n");
                return;
            }

            Console.Write("Укажите ID записи для редактирования: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Введен некорректный идентификатор!");
            }            
            else if (!allNotes.ContainsKey(id))
            {
                Console.WriteLine("Данной записи не найдено!");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine(allNotes[id]);
                    Console.WriteLine("Какое поле необходимо отредактировать?");
                    Console.WriteLine($"\t1 - Фамилия\n\t2 - Имя\n\t3 - Отчество" + $"\n\t4 - Телефон\n\t5 - Страна" +
                        $"\n\t6 - Дата рождения\n\t7 - Организация\n\t8 - Должность\n\t9 - Примечание");
                    Console.Write("Введите цифру для выбора или cancel для завершения редактирования: ");

                    string choice;
                    string[] function = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "cancel" };
                    while (true)
                    {
                        choice = Console.ReadLine();
                        if (function.Contains(choice))
                        {
                            switch (choice)
                            {
                                case "1":
                                    allNotes[id].Surname = ReadUntilValidationPass("Surname");
                                    break;
                                case "2":
                                    allNotes[id].Name = ReadUntilValidationPass("Name");
                                    break;
                                case "3":
                                    allNotes[id].SecondName = ReadUntilValidationPass("SecondName");
                                    break;
                                case "4":
                                    allNotes[id].Phone = ReadUntilValidationPass("Phone");
                                    break;
                                case "5":
                                    allNotes[id].Country = ReadUntilValidationPass("Country");
                                    break;
                                case "6":
                                    allNotes[id].DateOfBirth = ReadUntilValidationPass("DateOfBirth");
                                    break;
                                case "7":
                                    allNotes[id].Organization = ReadUntilValidationPass("Organization");
                                    break;
                                case "8":
                                    allNotes[id].Position = ReadUntilValidationPass("Position");
                                    break;
                                case "9":
                                    allNotes[id].Remark = ReadUntilValidationPass("Remark");
                                    break;
                                case "cancel":
                                    return;
                            }
                            break;
                        }
                        else
                        {
                            Console.Write("Команда не найдена! Введите ещё раз: ");
                        }
                    }
                    Console.Write("Поле изменено! Продолжить редактирование записи? (yes/no): ");
                    string answer;
                    while (true)
                    {
                        answer = Console.ReadLine();
                        if (answer == "yes" || answer == "no")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Write("Пожалуйста введите yes или no: ");
                        }
                    }

                    if (answer == "no")
                    {
                        break;
                    }
                }
            }
        }
        private void DeleteNote()
        {
            if (allNotes.Count == 0)
            {
                Console.WriteLine($"Вы еще не создали ни одной записи!\n");
                return;
            }
            Console.Write("Введите Id записи для удаления: ");
            int id;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Введен некорректный идентификатор!");
                }                
                else if (!allNotes.ContainsKey(id))
                {
                    Console.WriteLine("Данной записи не найдено!");
                }
                else
                {
                    break;
                }
            }
            allNotes.Remove(id);
            Console.WriteLine($"Запись {id} удалена!\n");
            id--;
        }

        private void ShowAllNotes()
        {
            if (allNotes.Count == 0)
            {
                Console.WriteLine($"Вы еще не создали ни одной записи!\n");
                return;
            }
            else
            {
                foreach (var item in allNotes)
                {
                    Console.WriteLine(item.Value.ToShortString());
                }
            }
        }

        private string ReadUntilValidationPass(string property)
        {
            Console.Write($"Введите {property}: ");
            while (true)
            {
                string propValue = Console.ReadLine();
                if (Note.fieldsValidation[property].TryValidate(propValue, out string error))
                {
                    if (string.IsNullOrEmpty(propValue))
                    {
                        return null;
                    }
                    return propValue;
                }
                else
                {
                    Console.WriteLine(error);
                }
            }
        }
    }
}