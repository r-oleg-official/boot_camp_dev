/*
Step 1. arr = [1, 0, -6, 2, 5, 3, 2]
Step 2. choice last el-t. pivot (опор эл-т) = arr[6].
Step 3. вызвыть step 1, 2 для подмассивов слева и справа от pivot.

[1, 0, -6, 2, 2, 5, 3] - pivot arr[4] 
1. [1, 0, -6, 2] [5, 3]
2. pivot = arr[3] = 2.
3. Нужно поместить  pivot так, чтобы эл-ты < pivot были слева, а эл-ты > pivot справа.
 1.  [1, 0, -6]
 2. pivot = -6
 3. [-6, 1, 0]
  1. [1, 0]
  2. pivot = arr[1] = 0
  3. [0, 1]
правая часть [5, 3] сортируется также.
*/
int[] arr = {0, -5, 2, 3, 5, 9, -1, 7};
// int[] res = null;
// int[] res = QuickSort(arr, 0, arr.Length - 1); //по идее, изм-я уже будут в arr, т.к. массив - ссылочный тип
QuickSort(arr, 0, arr.Length - 1); // для void QuickSort
Console.WriteLine($"Отсортир-й массив {string.Join(", ", arr)}]");

void QuickSort(int[] inputArray, int minIndex, int maxIndex)
{
    if(minIndex >= maxIndex) return;
    int pivot = GetPivotIndex(inputArray, minIndex, maxIndex); // передача тех же арг-в что и для QuickSort
    QuickSort(inputArray, minIndex, pivot - 1);
    QuickSort(inputArray, pivot + 1, maxIndex);
    return;
}
int GetPivotIndex(int[] inputArray, int minIndex, int maxIndex)
{
    int pivotIndex = minIndex - 1;
    for (int i = minIndex; i <= maxIndex; i++)
    {
        if(inputArray[i] < inputArray[maxIndex])    // if i-й < того, что справа, то поменять их местами
        {
            pivotIndex++;
            // Swap(ref inputArray[pivotIndex], ref inputArray[i]); // либо передавать по индексам, либо по ссылкам
            Swap(inputArray, i, pivotIndex);
        }
    }
    pivotIndex++; // после прохода массива слева от pivot
    Swap(inputArray, pivotIndex, maxIndex); // maxIndex - меняем посл эл-т
    return pivotIndex; // получить сам pivotIndex
}

/*
void Swap(ref int leftValue, ref int rightValue)
{
    int temp = leftValue;
    leftValue = rightValue;
    rightValue = temp;
}
*/

// Swap с передачей ссылки на сам массив
void Swap(int[] inputArray, int leftValue, int rightValue)
{
    int temp = inputArray[leftValue];
    inputArray[leftValue] = inputArray[rightValue];
    inputArray[rightValue] = temp;
}
