﻿/* 
Типы алгоритмов:
1. константный алгоритм;
2. логарифметический;
3. линейно-логарифметический;
4. квадратичный;
5. кубический.
*/

// 1. константный алгоритм.
int n = 0;
if (n >= 0) n++;
else n *= 2;

/*
2. логарифметический.
Например, отгадывание числа от 0 до 100. Загадано = 67.
Алгоритм: Range/2, if <, >,...
1. 100 / 2
2. > 50?, yes
3. 50-100 / 2
4. > 75?, no
5. 50-75 / 2
6. > 62?, yes
7. 62-75 / 2
8. > 66?, yes

Или (log2(n)) - 7 ходов.
*/

// НОД (наибольший общий делитель). Алгоритм Евклида
int n = 140,
    m = 175;
while (n != m)
{
    if (n > m) n = n - m;
    else m = m - n;
}
Console.WriteLine(m); // or Console.WriteLine(n);

// НОК (наименьшее общее кратное)
int n = 140,
    m = 175,
    count = n * m;
while (n != m)
{
    if (n > m) n = n - m;
    else m = m - n;
}
Console.WriteLine(count / n); // or Console.WriteLine(count / m);
