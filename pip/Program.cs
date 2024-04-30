using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pip
{
       public interface IMenu
            {
            void Show(Operation[] operati);
            }

        public class Menu : IMenu
        {
            public void Show(Operation[] operati)
            {
                Console.WriteLine("======== КАЛЬКУЛЯТОР ========");
                for (var i = 0; i < operati.Length; i++)
                {
                    var operation = operati[i];
                    Console.WriteLine($"{i + 1}. ОПЕРАЦИЯ {operation.Name}; ");
                }
            }
        }

        public class Operation
        {
            public string Name { get; set; }
            public Func<int, int, int> OperationFunc { get; set; }

            public Operation(string name, Func<int, int, int> operationFunc)
            {
                Name = name;
                OperationFunc = operationFunc;
            }

            public int Run(int num1, int num2)
            {
                return OperationFunc(num1, num2);
            }
        }

        public class OperationProvider
        {
            public Operation[] Get()
            {
                return new Operation[]
                {
                new Operation("Вычитание", (num1, num2) => num1 - num2),
                new Operation("Сложение", (num1, num2) => num1 + num2),
                new Operation("Умножение", (num1, num2) => num1 * num2),
                new Operation("Деление", (num1, num2) => num1 / num2),
                };
            }
        }

        public class Program
        {
            public static void Main()
            {
                var operationProvider = new OperationProvider();
                var operations = operationProvider.Get();

                var menu = new Menu();
                menu.Show(operations.ToArray());

                Console.Write("Выберите действие: ");
                var operation = operations[Convert.ToInt32(Console.ReadLine()) - 1];


                Console.Write("Введите первое число: ");
                var num1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите второе число: ");
                var num2 = Convert.ToInt32(Console.ReadLine());


                var result = operation.Run(num1, num2);

                Console.WriteLine($"Результат: {result}"); 
               Console.WriteLine("Для выхода нажмите любую кнопку");
               Console.ReadLine();
               Environment.Exit(0);
            }
        }
}


