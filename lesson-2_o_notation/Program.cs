/*
int[] array = new int[5];
for (int i = 0; i < 5; i++)
    array[i] = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("[" + string.Join(", ", array) + "]");
Console.WriteLine(array[3]);
// Сложность алгоритма = О(1). Ввод данных не считается. Выполняется только 1-а строка кода.
*/


// [4, 5, 3, 1, 2]. Сколько операций нужно для подсчета суммы эл-тов? Ответ: 5 (кол-во эл-тов). 
int n = 5;
int[] array = new int[n];
for (int i = 0; i < n; i++)
    array[i] = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("[" + string.Join(", ", array) + "]");
// O(n)
// [1, 2, 3, 4, 5] - быстрая сортировка. O(n * log n)
