using System;
using System.Collections.Generic;

public class PrimeFactors
{
    // Funktion zum Berechnen der Primzahlen bis zur maximalen Zahl (Sieb des Eratosthenes)
    public static List<int> SieveOfEratosthenes(int maxNumber)
    {
        bool[] isPrime = new bool[maxNumber + 1];
        for (int i = 0; i <= maxNumber; i++)
            isPrime[i] = true;
        
        isPrime[0] = isPrime[1] = false; // 0 und 1 sind keine Primzahlen

        for (int i = 2; i <= Math.Sqrt(maxNumber); i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= maxNumber; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        List<int> primes = new List<int>();
        for (int i = 2; i <= maxNumber; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
            }
        }

        return primes;
    }

    // Funktion zur Faktorisierung einer Zahl
    public static List<int> GetPrimeFactors(int number, List<int> primes)
    {
        List<int> factors = new List<int>();

        foreach (int prime in primes)
        {
            while (number % prime == 0)
            {
                factors.Add(prime);
                number /= prime;
            }

            if (number == 1) break;
        }

        // Falls es ein verbleibender Primfaktor ist (größer als die Primzahlen, die wir geprüft haben)
        if (number > 1)
        {
            factors.Add(number);
        }

        return factors;
    }

    // Die Hauptmethode zur Verarbeitung einer Liste von Zahlen
    public static void Factor(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
        {
            throw new ArgumentException("Die Liste der Zahlen ist leer oder null.");
        }

        // Bestimme die größte Zahl, um den Siebbereich festzulegen
        int maxNumber = 0;
        foreach (int num in numbers)
        {
            if (num > maxNumber)
                maxNumber = num;
        }

        // Berechne alle Primzahlen bis zur größten Zahl
        List<int> primes = SieveOfEratosthenes(maxNumber);

        // Führe die Primfaktorzerlegung für jede Zahl durch
        foreach (int number in numbers)
        {
            if (number < 1)
            {
                throw new ArgumentException("Negative Zahlen sind nicht unterstützt");
            }

            List<int> factors = GetPrimeFactors(number, primes);

            // Ausgabe der Faktoren
            Console.Write($"{number}: ");
            foreach (int factor in factors)
            {
                Console.Write(factor + " ");
            }
            Console.WriteLine();
        }
    }
}
