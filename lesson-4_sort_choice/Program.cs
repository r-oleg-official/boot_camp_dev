/*
[6, 15, 2, 9, -3]
min = 6
6 < 15
6 > 2 
min = 2
2 < 9
2 > -3
min = -3
[-3, 6, 15, 2, 9]
[6, 15, 2, 9] - для нас в голове
min = 6
6 < 15
6 > 2
min = 2
2 < 9
[-3, 2, 6, 15, 9]
min = 6
6 < 15
6 < 9
[-3, 2, 6, 15, 9]
min = 15
15 > 9
[-3, 2, 6, 9, 15]
*/
/*
Console.Write("Enter a number elements of a array: ");
int n = Convert.ToInt32(Console.ReadLine());
int [] array = new int[n];
// Fill array
for (int i = 0; i < n; i++)
{
    array[i] = Convert.ToInt32(Console.ReadLine());
}
// int[] array = {6, 15, 2, 9, -3};
// int n = 5;

Console.WriteLine();
Console.WriteLine("Source array [" + string.Join(", ", array) + "]");
// Sort of the array
for (int i = 0; i < n - 1; i++) // послед не учитывается
{
    int minIndex = i;
    for (int j = i + 1; j < n; j++) // здесь вся логика, array[n-1] может быть не макс. 
    {
        if(array[j] < array[minIndex]) minIndex = j;
    }
    int temp;
    temp = array[minIndex];
    array[minIndex] = array[i];
    array[i] = temp;
}
Console.WriteLine("Sort array [" + string.Join(", ", array) + "]");
*/

// Codepage UTF-8
char[] array = new char[5];
for (int i = 0; i < 5; i++)
{
    array[i] = 'a';
}
Console.WriteLine("" + string.Join(", ", array) + "]");


string[] array = new string[5];
for (int i = 0; i < 5; i++)
{
    array[i] = Console.ReadLine();
}
Console.WriteLine("" + string.Join(", ", array) + "]");
// Sort of the string array by length of rows.
for (int i = 0; i < 4; i++) // послед не учитывается
{
    int minIndex = i;
    for (int j = i + 1; j < 5; j++) // здесь вся логика, array[n-1] может быть не макс. 
    {
        if(array[j].Length < array[minIndex].Length) minIndex = j;
    }
    string temp;
    temp = array[minIndex];
    array[minIndex] = array[i];
    array[i] = temp;
}
Console.WriteLine("Sort array [" + string.Join(", ", array) + "]");
