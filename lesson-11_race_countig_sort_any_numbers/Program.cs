
// counting sort any numbers and negative numbes.

// int[] array = {-10, -5, -9, 0, 2, 5, 1, 3, 1, 0, 1};
// int[] sortedArray = CountingSortExtended(array);

const int THREADS_NUMBERS = 8; // number of threads
const int N = 100000; // size of array
object locker = new object();


// create array random throught two rows:
Random rand = new Random();
int[] resSerial = new int[N].Select(r => rand.Next(0, 5)).ToArray(); // result for single thread
int[] resParallel = new int[N]; // result for multiple threads
Array.Copy(resSerial, resParallel, N); // copy array

CountingSortExtended(resSerial);
PrepareParallelCountingSort(resParallel);
// Console.WriteLine($"[" + string.Join(", ", resSerial) + "]");
// Console.WriteLine($"[" + string.Join(", ", resParallel) + "]");
Console.WriteLine(EqualittyMatrix(resSerial, resParallel));


void PrepareParallelCountingSort(int[] inputArray) // create of threads
{
    int max = inputArray.Max();
    int min = inputArray.Min();
    int  offset = -min; // смещение
    int[] counters = new int[max + offset + 1];
    
    //Thread 1 [0, ..., 50000] Thread 2 [50000, ..., 100000]
    int eachThreadCalc = N / THREADS_NUMBERS;
    var threadsParallel = new List<Thread>();

    for(int i = 0; i < THREADS_NUMBERS; i++) // start each thread
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        if(i == THREADS_NUMBERS - 1) endPos = N;
        threadsParallel.Add(new Thread(() => CountingSortParallel(inputArray, counters, offset, startPos, endPos)));
        threadsParallel[i].Start();
    }

    foreach (var thread in threadsParallel)
    {
        thread.Join();
    }
}

void CountingSortParallel(int[] inputArray, int[] counters, int offset, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        lock (locker)
        {
            counters[inputArray[i] + offset]++;
        }
    }
}

void CountingSortExtended(int[] inputArray) // с отриц числами
{
    int max = inputArray.Max();
    int min = inputArray.Min();
    int offset = -min;
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
            inputArray[index] = i - offset;
            index++;
        }
    }
}

bool EqualittyMatrix(int[] fMatrix, int[] sMatrix)
{
    bool res = true;
    for (int i = 0; i < fMatrix.GetLength(0); i++)
    {
        res = res && (fMatrix[i] == sMatrix[i]);
    }
    return res;
}
