using System;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

Console.WriteLine("=== 1. Суммирование 0.1 десять раз ===");
double s = 0;
for (int i = 0; i < 10; i++)
    s += 0.1;
Console.WriteLine($"double: {s:R}");
Console.WriteLine($"s == 1.0: {s == 1.0}");

float sf = 0f;
for (int i = 0; i < 10; i++)
    sf += 0.1f;
Console.WriteLine($"float:  {sf:R}");

Console.WriteLine("\n=== 2. 0.1 + 0.2 ===");
Console.WriteLine($"double:  {0.1 + 0.2:R}");
Console.WriteLine($"decimal: {0.1m + 0.2m}");

Console.WriteLine("\n=== 3. Сравнение double через допуск ===");
double a = 0.1 + 0.2;
Console.WriteLine($"a == 0.3: {a == 0.3}");
Console.WriteLine($"Math.Abs(a - 0.3) < 1e-9: {Math.Abs(a - 0.3) < 1e-9}");

Console.WriteLine("\n=== 4. Потеря значимости при вычитании близких чисел ===");
double x = 4.321, y = 4.319;
Console.WriteLine($"x - y = {x - y:R}");

Console.WriteLine("\n=== 5. Квадратное уравнение x^2 - 10000x + 1 = 0 ===");
double aa = 1, bb = -10000, cc = 1;
double d = Math.Sqrt(bb * bb - 4 * aa * cc);
double x1 = (-bb + d) / (2 * aa);
double x2 = (-bb - d) / (2 * aa);
double x2v = cc / x1;
Console.WriteLine($"x1:  {x1:R}");
Console.WriteLine($"x2:  {x2:R}");
Console.WriteLine($"x2v: {x2v:R}");

Console.WriteLine("\n=== 6. Численное дифференцирование sin(x) в точке x=1 ===");
Console.WriteLine("Точное значение cos(1) = 0.5403023058681398");
Console.WriteLine($"{"h",-12} {"разность",-22} {"ошибка",-12}");
double[] steps = { 1e-1, 1e-3, 1e-5, 1e-7, 1e-8, 1e-10 };
foreach (double h in steps)
{
    double deriv = (Math.Sin(1 + h) - Math.Sin(1)) / h;
    double error = Math.Abs(deriv - Math.Cos(1));
    Console.WriteLine($"{h,-12:G3} {deriv,-22:R} {error,-12:E3}");
}

Console.WriteLine("\n=== 7. Накопление ошибки: миллион прибавлений 0.1 ===");
double sum = 0;
for (int i = 0; i < 1_000_000; i++)
    sum += 0.1;
Console.WriteLine($"sum = {sum:R}");
Console.WriteLine($"разница = {sum - 100000:E3}");

Console.WriteLine("\n=== 8. Порядок действий меняет результат ===");
double big = 1e16;
Console.WriteLine($"(big + 1.0) - big = {(big + 1.0) - big}");
Console.WriteLine($"(big - big) + 1.0 = {(big - big) + 1.0}");
