using Newtonsoft.Json;
namespace ggwp
{
    internal class login
    {
        private string path = "C:\\zxc\\qwe.json";
        public login (){zxc();}
        public void zxc()
        {
            Console.Clear();
            bool loser = true;
            Console.SetCursorPosition(3, 0);
            Console.Write("логин");
            Console.SetCursorPosition(3, 1);
            Console.Write("пароль");
            Console.SetCursorPosition(3, 2);
            Console.Write("войти");
            Console.SetCursorPosition(3, 3);
            Console.Write("выход из этой ужасной проги");
            int mesto = 0;
            Console.SetCursorPosition(0, mesto);
            Console.WriteLine("->");
            string password = "";
            string loign = "";
            while (true) 
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, mesto);
                    Console.Write("  ");
                    mesto -= 1;
                    if (mesto > 3) { mesto =  3; }
                    if (mesto < 0) { mesto = 0; } 
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, mesto);
                    Console.Write("  ");
                    mesto += 1;
                    if (mesto > 3) { mesto = 3; }
                    if (mesto < 0) { mesto = 0; }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (mesto == 0)
                    {
                        Console.SetCursorPosition(9, 0);
                        loign = Console.ReadLine();
                    }
                    else if (mesto == 1)
                    {
                        Console.SetCursorPosition(10, 1);
                        password = Console.ReadLine();
                    }
                    else if (mesto == 2)
                    {
                        string text = File.ReadAllText(path);
                        List<users>qaz = JsonConvert.DeserializeObject<List<users>>(text);
                        foreach(users user in qaz)
                        {
                            if ((loign == user.user)&&(password == user.parol))
                            {
                                if (user.role == "admin") { loser = false; admin wsx = new admin(user.user); }
                            }
                        }
                        if (loser == true) 
                        {
                            Console.Clear();
                            Console.WriteLine("Блин, что-то пошло не так. ну хз трайни еще разок или бан?(q/ другая буква) ");
                            string answer = Console.ReadLine();
                            if (answer == "q") 
                            { 
                                zxc();break;
                            }
                            else
                            { 
                                break; 
                            }
                        }
                    }
                    else if (mesto == 3)
                    {
                        Console.Clear();
                        break;
                    }
                }
                Console.SetCursorPosition(0, mesto);
                Console.WriteLine("->");
            }
        }
    }
}