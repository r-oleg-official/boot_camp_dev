// counting sort any numbers and negative numbes.
int[] array = {-10, -5, -9, 0, 2, 5, 1, 3, 1, 0, 1};
int[] sortedArray = CountingSortExtendedMin(array);

Console.WriteLine(string.Join(", ", sortedArray));


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

int[] CountingSortExtended(int[] inputArray)
{
    int max = inputArray.Max();
    int[] sortedArray = new int[inputArray.Length];
    int[] counters = new int[max + 1];

    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i]]++;
    }
    
    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            sortedArray[index] = i;
            index++;
        }
    }
    return sortedArray;
}


int[] CountingSortExtendedMin(int[] inputArray) // с отриц числами
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int  offset = -min; // смещение
    int[] sortedArray = new int[inputArray.Length];
    int[] counters = new int[max + offset + 1];

    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i] + offset]++;
    }
    
    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            sortedArray[index] = i - offset;
            index++;
        }
    }
    return sortedArray;
}