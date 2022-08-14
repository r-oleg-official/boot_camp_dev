/*
[3, 1, 5, 0, 7, 9, 8]

1. [1, 3, 5, 0, 7, 9, 8]
2. [1, 3, 0, 5, 7, 9, 8]
3. [1, 0, 3, 5, 7, 9, 8]
4. [0, 1, 3, 5, 7, 9, 8]
5. [0, 1, 3, 5, 7, 8, 9] - заново проход массива на проверку.
После замены, цикл начинается сначала с 1-го эл-та дол след замены.
*/

Console.WriteLine("Enter a size array: ");
int n = Convert.ToInt32(Console.ReadLine());
int[] array = new int[n];
for(int i = 0; i < n; i++)
{
    Console.Write($"Enter a element {i + 1} array:");
    array[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Begin array: [" + string.Join(", ", array) + "]");
Console.WriteLine();
for (int i = 0; i < n; i++) // pass by all array. i - number of passes
{
    for (int j = 0; j < n - 1; j++) // 
    {
        if(array[j] > array[j + 1])
        {
            int temp  = array[j];
            array[j] = array[j + 1];
            array[j + 1] = temp;
        }
    }
    Console.WriteLine(i + " [" + string.Join(", ", array) + "]"); // output array. i - number of interation.
}
