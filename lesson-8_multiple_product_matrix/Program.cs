
const int N = 100; //size matrix
const int THREADS_NUMBER = 10;
int[,] serialMulRes = new int[N, N]; // result product of the matrixes to the single thread.
int[,] threadMulRes = new int[N, N]; // result product of the matrixes to the multiple threads.

int[,] firstMatrix = MatrixGenerator(N,N);
int[,] secondMatrix = MatrixGenerator(N,N);

SerialMatrixMul(firstMatrix, secondMatrix);
PrepareParallelMatrixMul(firstMatrix, secondMatrix);
Console.WriteLine(EqualittyMatrix(serialMulRes, threadMulRes));

int[,] MatrixGenerator(int rows, int columns)
{
    Random _rand = new Random();
    int[,] res = new int[rows, columns];
    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            res[i, j] = _rand.Next(-100, 100);
        }
    }
    return res;
}

void SerialMatrixMul(int[,] a, int[,] b)
{
    if(a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножать такие матрицы!");
    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < a.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                serialMulRes[i,j] += a[i, k] * b[k, j];
            }
        }
    }
}

void PrepareParallelMatrixMul(int[,] a, int[,] b)
{
    if(a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножать такие матрицы!");
    int eachThreadCalc = N / THREADS_NUMBER; // опред кол-во опер на поток
    var threadsList = new List<Thread>(); // коллекция/список, здесь будут хран-ся потоки
    // Thread[] arr = new Thread[2]; // - аналогия пред строки
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        // if last thread
        if(i == THREADS_NUMBER) endPos = N;
        threadsList.Add(new Thread(() => ParallelMatrixMul(a, b, startPos, endPos)));
        threadsList[i].Start();
    }
    // цикл для ожидания завершения потоков
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        threadsList[i].Join(); // присоединить к главному потоку
    }
}

void ParallelMatrixMul(int[,] a, int[,] b, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                serialMulRes[i,j] += a[i, k] * b[k, j];
            }
        }
    }
}

bool EqualittyMatrix(int[,] fMatrix, int[,] sMatrix)
{
    bool res = true;
    for (int i = 0; i < fMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < fMatrix.GetLength(1); j++)
        {
            res = res && (fMatrix[i, j] == sMatrix[i, j]);
        }
    }
    return res;
}
