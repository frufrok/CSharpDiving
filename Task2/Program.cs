class Program
{
    static void Main(string[] args)
    {
        int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
        
        int rows = a.GetLength(0);
        int cols = a.GetLength(1);
        
        int[] vector = new int[a.Length];
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++) 
            {
                vector[i * cols + j] = a[i, j];
            }
        }
        
        Array.Sort(vector);
        
        int[,] result = new int[a.GetLength(0), a.GetLength(1)];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = vector[i * cols + j];
            }
        }
        PrintArray(result);
    }

    public static void PrintArray(int[,] a) 
    {
        int rows = a.GetLength(0);
        int cols = a.GetLength(1);
        List<string> firstRow = new List<string>() { "#" };
        List<string> secondRow = new List<string>() { " " };
        firstRow.AddRange(Enumerable.Range(0, cols).Select(x => x.ToString()));
        secondRow.AddRange(Enumerable.Range(0, cols).Select(x => "‾"));
        Console.WriteLine(String.Join("\t", firstRow));
        Console.WriteLine(String.Join("\t", secondRow));
        for (int i = 0; i < rows; i++)
        {
            List<string> row = new List<string>() { $"{i}|" };
            for (int j = 0; j < cols; j++) 
            {
                row.Add(a[i, j].ToString());
            }
            Console.WriteLine(String.Join("\t", row));
        }
    }
}