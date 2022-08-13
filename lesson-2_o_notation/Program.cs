/*
int[] array = new int[5];
for (int i = 0; i < 5; i++)
    array[i] = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("[" + string.Join(", ", array) + "]");
Console.WriteLine(array[3]);
// Сложность алгоритма = О(1). Ввод данных не считается. Выполняется только 1-а строка кода.
*/

/*
// [4, 5, 3, 1, 2]. Сколько операций нужно для подсчета суммы эл-тов? Ответ: 5 (кол-во эл-тов). 
int n = 5;
int[] array = new int[n];
for (int i = 0; i < n; i++)
    array[i] = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("[" + string.Join(", ", array) + "]");
// O(n)
*/

/* [1, 2, 3, 4, 5] - быстрая сортировка. = O(n * log n)
((5 + 1) / 2) * 5 = O(1)
n < n * log(n) + 1
int summa = 0;
for (int i = 0; i < n; i++)
    summa += array[i];
*/

/*
// O(n^2)
int n = Convert.ToInt32(Console.ReadLine());
for(int i = 1; i <= n; i++)
{
    for (int j = 1; j <= n; j++)
    {
        Console.Write(i * j + "\t");
    }
    Console.WriteLine();
}
*/
/*
// O(n^2)
int n = Convert.ToInt32(Console.ReadLine());
int[, ] matrix = new int[n, n];
for(int i = 1; i <= n; i++)
{
    for (int j = 1; j <= n; j++)
    {
        if (i + j <= n)
        {
            matrix[i,j] = i *j;
            matrix[j,i] = i *j;
        }
        Console.Write(i * j + "\t");
    }
    Console.WriteLine();
}
*/



