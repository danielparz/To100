using System;

namespace To100
{
    class Program
    {        
        static void Main(string[] args)
        {
            int numbersAmount = 9;
            int wantedNumber = 100;

            Console.WriteLine("Wstawiając znak + lub - bądź łącząc ze sobą liczby, znajdź wszystkie rozwiązania poniższego równania:");
            for (int i = 1; i <= numbersAmount; i++)
                Console.Write($"{i} ");
            Console.Write($"= {wantedNumber}");

            Solver solver = new Solver(numbersAmount, wantedNumber);

            solver.GenerateVariantsTree(solver.Root);
            solver.ShowAnswer();
        }
    }
}
