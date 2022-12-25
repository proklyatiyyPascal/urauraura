using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace ggwp
{
    public class admin: crud
    {
        private bool dsa = false; //незя удалить получается
        private string name;
        private int mesto;
        
        public admin(string imya) 
        {
            name = imya;
            menushka();
        }
        public void poisk(string found) 
        {
            Console.Clear();
            List<users> users1 = ewq.Deserializer<List<users>>("C:\\zxc\\qwe.json");
            List<users> sorted_users = new List<users>();
            foreach (users user in users1)
            {
                if (found.Equals(user.id) || found.Equals(user.role) || found.Equals(user.user)) 
                    //Определяет, равен ли указанный объект текущему объекту
                {
                    sorted_users.Add(user);
                }
            }
            int y = 0;
            foreach (var item in sorted_users)
            {
                Console.SetCursorPosition(3, y);
                Console.Write(item.user);
                Console.SetCursorPosition(20, y);
                Console.Write(item.role);
                Console.SetCursorPosition(40, y);
                Console.Write(item.id);
                y += 1;
            }
            y = 0;
            Console.SetCursorPosition(70, 0);
            Console.Write("f1 - добавить юзера");
            Console.SetCursorPosition(70, 1);
            Console.Write("f2 - удалить юзера");
            Console.SetCursorPosition(70, 3);
            Console.Write("f3 - поиск");
            Console.SetCursorPosition(70, 7);
            Console.Write("вы вошли. привет, " + name);
            Console.SetCursorPosition(3, sorted_users.Count + 3);
            Console.Write("логин");
            Console.SetCursorPosition(20, sorted_users.Count + 3);
            Console.Write("роль");
            Console.SetCursorPosition(40, sorted_users.Count + 3);
            Console.Write("id");
            int position = 0;
            Console.SetCursorPosition(0, position);
            Console.Write("->");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, position);
                    Console.Write("  ");
                    position -= 1;
                    if (position > sorted_users.Count - 1) { position = sorted_users.Count - 1; } 
                    if (position < 0) { position = 0; }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, position);
                    Console.Write("  ");
                    position += 1;
                    if (position > sorted_users.Count - 1) { position = sorted_users.Count - 1; }
                    if (position < 0) { position = 0; }
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    create();
                    Console.Clear();
                    menushka();
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    mesto = users1.IndexOf(sorted_users[position]);
                    delete();
                    break;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    mesto = users1.IndexOf(sorted_users[position]);
                    update();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    menushka();
                    break;
                }
                Console.SetCursorPosition(0, position);
                Console.Write("->");
            }
        }
        public void create()
        {
            List<users> users = ewq.Deserializer<List<users>>("C:\\zxc\\qwe.json");
            Console.Clear();
            Console.Write("введите имя: ");
            string name = Console.ReadLine();
            Console.Write("введите пароль: ");
            string password = Console.ReadLine();
            Console.Write("введите id: ");
            string id = Console.ReadLine();
            Console.Write("введите роль: ");
            string role = Console.ReadLine();
            users new_user = new users(name, password, role, id);
            users.Add(new_user);
            ewq.Serializer("C:\\zxc\\qwe.json", users);
            Console.Clear();
            menushka();
        }
        public void delete()
        {
            List<users> users = ewq.Deserializer<List<users>>("C:\\zxc\\qwe.json");
            if (users[mesto].user != name)
            {
                users.Remove(users[mesto]);
                ewq.Serializer("C:\\zxc\\qwe.json", users);
                menushka();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("суицыд не выход");
                Console.ReadLine();
                Console.Clear();
                menushka();
            }
        }
        public void read()
        {
            int y = 0;
            List<users> users = ewq.Deserializer<List<users>>("C:\\zxc\\qwe.json");
            foreach (var item in users)
            {
                Console.SetCursorPosition(3, y);
                Console.Write(item.user);
                Console.SetCursorPosition(20, y);
                Console.Write(item.role);
                Console.SetCursorPosition(40, y);
                Console.Write(item.id);
                y += 1;
            }
        }
        public void update()
        {
            Console.Clear();
            List<users> users = ewq.Deserializer<List<users>>("C:\\zxc\\qwe.json");
            Console.WriteLine($"   id: {users[mesto].id}\n   login: {users[mesto].user}\n   password: {users[mesto].parol}\n   role: {users[mesto].role}");
            // $- идентифицирует строковый литерал как интерполированную строку.
            // Интерполированная строка — это строковый литерал, который может содержать выражения интерполяции. 
            int pos = 0;
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("  ");
                    pos -= 1;
                    if (pos > 3) { pos = 3; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("  ");
                    pos += 1;
                    if (pos > 3) { pos = 3; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (pos == 0)
                    {
                        Console.SetCursorPosition(7, 0);
                        Console.Write("                             ");
                        Console.SetCursorPosition(7, 0);
                        string new_id = Console.ReadLine();
                        users[mesto].id = new_id;
                    }
                    else if (pos == 1)
                    {
                        Console.SetCursorPosition(10, 1);
                        Console.Write("                             ");
                        Console.SetCursorPosition(10, 1);
                        string new_login = Console.ReadLine();
                        users[mesto].user = new_login;
                    }
                    else if (pos == 2)
                    {
                        Console.SetCursorPosition(13, 2);
                        Console.Write("                             ");
                        Console.SetCursorPosition(13, 2);
                        string new_password = Console.ReadLine();
                        users[mesto].parol = new_password;
                    }
                    else if (pos == 3)
                    {
                        Console.SetCursorPosition(9, 3);
                        Console.Write("                             ");
                        Console.SetCursorPosition(9, 3);
                        string new_role = Console.ReadLine();
                        users[mesto].role = new_role;
                    }
                    Console.Clear();
                    Console.WriteLine($"   id: {users[mesto].id}\n   login: {users[mesto].user}\n   password: {users[mesto].parol}\n   role: {users[mesto].role}");
                }
                else if (key.Key == ConsoleKey.Escape) { ewq.Serializer("C:\\zxc\\qwe.json", users); menushka(); break; }
                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }
        }
        public void menushka() 
        {
            Console.Clear();
            List<users> users = ewq.Deserializer<List<users>>("C:\\zxc\\qwe.json");
            int pos = 0;
            read();
            Console.SetCursorPosition(60, 0);
            Console.Write("f1 - добаввить юзера");
            Console.SetCursorPosition(60, 1);
            Console.Write("f2 - удалить юзера");
            Console.SetCursorPosition(60, 5);
            Console.Write("вы вошли. привет, " + name);
            Console.SetCursorPosition(60, 2);
            Console.Write("f3 - поиск");
            Console.SetCursorPosition(3, users.Count + 2);
            Console.Write("логин");
            Console.SetCursorPosition(20, users.Count + 2);
            Console.Write("роль");
            Console.SetCursorPosition(40, users.Count + 2);
            Console.Write("id");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos += 1;
                    if (pos > users.Count - 1) { pos = users.Count - 1; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos -= 1;
                    if (pos > users.Count - 1) { pos = users.Count - 1; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    ewq.Serializer("C:\\zxc\\qwe.json", users);
                    Console.Clear();
                    login log = new login();
                    break;
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    create();
                    break;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    mesto = pos;
                    delete();
                    break;
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                    Console.WriteLine("Что-то , что нам поможет найти: ");
                    string edc = Console.ReadLine();
                    poisk(edc);
                    break;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    mesto = pos;
                    update();
                    break;
                }
                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }  
        }
    }
}