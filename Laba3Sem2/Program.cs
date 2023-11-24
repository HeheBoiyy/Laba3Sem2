using System.Diagnostics;

namespace Laba3Sem2
{
    internal class Program 
    {
        delegate bool IsCanAddTeacher(string name,List<Prepod> prepods);
        IsCanAddTeacher iscan = (name,list) => //делегат через лямбду
        {
            foreach (Prepod prepod in list)
            {
                if (name == prepod.Name)
                {
                    return false;
                }
            }
            return true;
        };


        public static void Main(string[] args)
        {
            List<Prepod> prepods = new List<Prepod> // Задаём начальный список преподов
            {
                new Prepod("Жуков", "Егор", "Александрович", "ИСИ", "Zoom"),
                new Prepod("Махонин", "Дмитрий", "Александрович", "ИТиСУ", "WebinarSFU"),
                new Prepod("Яврумян", "Нарек", "Вачаканович", "ИКИТ", "Discord"),
                new Prepod("Дарбинян", "Давид", "Арманович", "ИКИТ", "Discord"),
            };

            List<TopService> topservices = TopService.TOP(prepods);
            DefaultMenuWrite(prepods,topservices);
            var program = new Program();
            program.Choose(topservices,prepods);
        }
        public void Choose(List<TopService> topServices,List<Prepod> prepods)
        {
            Console.WriteLine();
            Console.WriteLine("Выберите действие:\n1.Добавить Преподователя \n2.Выйти");
            int switcher = Convert.ToInt16(Console.ReadLine());
            switch (switcher)
            {
                case 1:
                    Console.WriteLine("Введите Имя,Фамилию,Отчество,Институт,Сервис с новой строки");
                    string n = Console.ReadLine();
                    string s = Console.ReadLine();
                    string m = Console.ReadLine();
                    string inst = Console.ReadLine();
                    string serv = Console.ReadLine();
                    if (TopService.IsService(serv))
                    {
                        if (iscan(n, prepods))
                        {
                            prepods.Add(new Prepod(s, n, m, inst, serv));
                        }
                        else
                        {
                            Console.WriteLine("Данный пользователь уже зарегестрирован!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введённый сервис не поддерживается");
                    }
                    DefaultMenuWrite(prepods,topServices);
                    Choose(topServices,prepods);
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void DefaultMenuWrite(List<Prepod> prepods,List<TopService> topServices)
        {
            string Prepodstr = "=======Преподователи========";  //-------------------------|
            string chert1 = "----------------------------";     //Функциональные переменные|
            string chert2 = "===Топ 3 Любимых сервисов===";     //-------------------------|
            Console.WriteLine(Prepodstr);
            foreach (Prepod prepod in prepods)
            {
                Console.Write($"{prepod.NameWrite()}    {prepod.Institute}     ");
                TopService.ColorChange(prepod.Service);
                Console.WriteLine();
            }
            Console.WriteLine(chert1 + Environment.NewLine + Environment.NewLine);
            Console.WriteLine(chert2);
            List<TopService> topservices = TopService.TOP(prepods);
            foreach (TopService topservice in topservices)
            {
                TopService.ColorChange(topservice.Name);
                Console.WriteLine($"     Количество использований:{topservice.amount}");
            }
            Console.WriteLine(chert1);
        }
    }
}
