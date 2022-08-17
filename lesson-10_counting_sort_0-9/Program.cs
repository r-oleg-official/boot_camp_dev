// Sort only digits: 0 - 9.

int[] array = {0, 2, 3, 2, 1, 5, 9, 1, 1, 1, 3, 6, 4, 8};

CountingSort(array);
Console.WriteLine(string.Join(", ", array));


void CountingSort(int[] inputArray)
{
    int[] counters = new int[10]; // массив повторений
    for (int i = 0; i < inputArray.Length; i++)
    {
        // counters[inputArray[i]]++;
        // or
        int ourNumber = inputArray[i];
        counters[ourNumber]++;
    }
    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i;
            index++;
        }
    }
}