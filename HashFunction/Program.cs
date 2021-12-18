using System;

namespace HashFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Hash hash = new Hash();

            while (true)
            {
                Console.WriteLine("Введите сообщение для хэширования");

                string message = Console.ReadLine();

                string hashCode = hash.GetHashCode(message);
                Console.WriteLine(hashCode + "\n");
            }
        }
    }

   class Hash
   {
        public string GetHashCode(string message)
        {
            int number = GetNumberOfSymbols(message);
            string result = GetHashTranslation(message, number);

            return result;
        }

        private string GetHashTranslation(string message, int numberOfSymbols)
        {
            string result = "";
            int totalNumber = 0;

            foreach (var symbol in message)
            {
                int currentNumber = Convert.ToInt32(symbol);

                currentNumber = (currentNumber ^ message.Length) | (currentNumber << 8);
                currentNumber += (currentNumber >> 15);

                totalNumber += currentNumber;

                result += ChangeOrder(totalNumber, numberOfSymbols);
            }

            return result;
        }

        private int GetNumberOfSymbols(string message)
        {
            int number = 0;

            foreach (var symbol in message)
                number += Convert.ToInt32(symbol);

            return number;
        }

        private string ChangeOrder(int totalNumber, int numberOfSymbols)
        {
            string currentNumbers = totalNumber.ToString();
            char[] orderChangedNumbers = new char[numberOfSymbols];

            for (int i = 1; i < currentNumbers.Length; i += 2)
            {
                orderChangedNumbers[i - 1] = currentNumbers[i];
                orderChangedNumbers[i] = currentNumbers[i - 1];
            }

            if (currentNumbers.Length % 2 != 0)
                orderChangedNumbers[^1] = currentNumbers[^1];

            return new string(orderChangedNumbers);
        }
    }
}