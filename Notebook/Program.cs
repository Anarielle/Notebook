namespace Notebook
{
    class Notebook
    {
        static void Main(string[] args)
        {
            List<Note> notes = new List<Note>();
            Console.WriteLine("Выерите действие:\n1 - Добавить запись\n2 - Редактировать запись\n" +
                "3 - Удалить запись\n4 - Просмотр записи\n5 - Просмотр всех записей");
            Note note = new Note();
            note.CreateNote();
        }
    }    
}
