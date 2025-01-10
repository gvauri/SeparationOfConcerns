namespace SeparationOfConcerns;

public class MultiplicationTable
{
    public static void For(List<int> numbers)
    {
        var table = CalculateMultiplicationTable(numbers);

        PrintMultiplicationTable(numbers, table);
    }

    private static void PrintMultiplicationTable(List<int> numbers, List<List<int>> table)
    {
        var biggest = numbers.Max();
        var biggestResult = biggest * biggest;
        var magnitude = 0;
        while (biggestResult > 0)
        {
            magnitude++;
            biggestResult /= 10;
        }
        magnitude++; 

        var titleRow = "*".PadLeft(magnitude) + " ||";
        foreach (var col in numbers)
        {
            titleRow += $"{col}".PadLeft(magnitude) + " |";
        }
        Console.WriteLine(titleRow);

        for (var i = 0; i < titleRow.Length; i++)
        {
            Console.Write("=");
        }
        Console.WriteLine();

        foreach (var row in table)
        {
            Console.Write($"{numbers[table.IndexOf(row)]}".PadLeft(magnitude) + " ||");
            foreach (var product in row)
            {
                Console.Write($"{product}".PadLeft(magnitude) + " |");
            }
            Console.WriteLine();
        }
    }
    private static List<List<int>> CalculateMultiplicationTable(List<int> numbers)
    {
        var table = new List<List<int>>();
        foreach (var row in numbers)
        {
            var rowValues = new List<int>();
            foreach (var col in numbers)
            {
                rowValues.Add(row * col);
            }
            table.Add(rowValues);
        }
        return table;
    }

}
