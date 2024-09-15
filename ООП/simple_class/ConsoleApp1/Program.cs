public static class ConsoleApp1
{

    public static int SquareSum(int[] numbers)
    {
        int result = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            result += numbers[i];
        }
        return result;
    }

    public static void Main(string[] args)
    {
        int[] array1 = [1, 2, 2];

        Console.WriteLine(SquareSum(array1));
    }
}

