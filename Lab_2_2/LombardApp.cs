using System;
using Lab_2_2.Services;

namespace Lab_2_2
{
    public class LombardApp
    {
        public static void RunLombard()
        {
            var service = new LombardService();
            service.GenerateTestData();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("          ЛОМБАРД - МЕНЮ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Показати всі речі");
                Console.WriteLine("2. Пошук по назві речі");
                Console.WriteLine("3. Пошук по прізвищу власника");
                Console.WriteLine("4. Фільтр по ціні");
                Console.WriteLine("5. Показати прострочені речі");
                Console.WriteLine("6. Показати активні речі");
                Console.WriteLine("0. Вихід");
                Console.WriteLine("====================================");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            ShowItems(service.GetAllItems(), "Всі речі");
                            break;

                        case "2":
                            Console.Write("Введіть назву: ");
                            string name = Console.ReadLine();
                            ShowItems(service.SearchByName(name), $"Пошук за назвою \"{name}\"");
                            break;

                        case "3":
                            Console.Write("Введіть прізвище: ");
                            string lastName = Console.ReadLine();
                            ShowItems(service.SearchByOwner(lastName), $"Пошук за власником \"{lastName}\"");
                            break;

                        case "4":
                            Console.Write("Мінімальна ціна: ");
                            if (!float.TryParse(Console.ReadLine(), out float minPrice))
                                throw new Exception("Некоректне число!");

                            Console.Write("Максимальна ціна: ");
                            if (!float.TryParse(Console.ReadLine(), out float maxPrice))
                                throw new Exception("Некоректне число!");

                            ShowItems(service.FilterByPrice(minPrice, maxPrice), $"Фільтр по ціні {minPrice} - {maxPrice}");
                            break;

                        case "5":
                            ShowItems(service.GetExpiredItems(), "Прострочені речі");
                            break;

                        case "6":
                            ShowItems(service.GetActiveItems(), "Активні речі");
                            break;

                        case "0":
                            Console.WriteLine("Вихід з програми...");
                            return;

                        default:
                            Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }

        private static void ShowItems(System.Collections.Generic.List<Models.ItemModel> items, string title)
        {
            Console.Clear();
            Console.WriteLine($"=== {title} ===");

            if (items.Count == 0)
            {
                Console.WriteLine("Немає результатів.");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} - {item.Price} грн");
                Console.WriteLine($"   Власник: {item.Owner.FirstName} {item.Owner.LastName}, {item.Owner.Age} років");
                Console.WriteLine($"   Отримано: {item.ReceivedDate:d}");
                Console.WriteLine($"   Безвідсотковий період до: {item.InterestFreePeriodEndDate:d}");
                Console.WriteLine($"   Дедлайн: {item.DeathLineDate:d}");
                Console.WriteLine($"   Відсоток/день: {item.InterestPerDay} грн\n");
            }
        }
    }
}
