// 1. Leer 10 enteros, almacenarlos en un arreglo y determinar en qué posición del arreglo está el mayor número leído. //

Console.WriteLine("Ejercicio 1\n");

int[] enteroUno = new int[10];
int mayor, posicionUno;

for (int i = 0; i < 10; i++)
{
    Console.Write($"Ingrese el número {i + 1}: ");
    enteroUno[i] = int.Parse(Console.ReadLine());
}

mayor = enteroUno[0];
posicionUno = 0;

for (int i = 1; i < 10; i++)
{
    if (enteroUno[i] > mayor)
    {
        mayor = enteroUno[i];
        posicionUno = i;
    }
}

Console.WriteLine($"\nEl número mayor es {mayor} y se encuentra en la posición {posicionUno} del arreglo.");

// 2. Leer 10 enteros, almacenarlos en un arreglo y determinar en qué posición de del arreglo está el mayor número par leído. //

Console.WriteLine("\nEjercicio 2\n");

int[] enteroDos = new int[10];
int mayorPar, posicionDos;

for (int i = 0; i < 10; i++)
{
    Console.Write($"Ingrese el número {i + 1}: ");
    enteroDos[i] = int.Parse(Console.ReadLine());
}

mayorPar = enteroDos[0];
posicionDos = 0;

for (int i = 1; i < 10; i++)
{
    if (enteroDos[i] % 2 == 0 &&  enteroDos[i] > mayorPar)
    {
        mayorPar = enteroDos[i];
        posicionDos = i;
    }
}

Console.WriteLine($"\nEl número mayor par es {mayorPar} y se encuentra en la posición {posicionDos} del arreglo.");

// 3. Leer 10 enteros, almacenarlos en un arreglo y determinar en qué posición del arreglo está el mayor número primo leído. //

Console.WriteLine("\nEjercicio 3\n");

int[] enteroTres = new int[10];
int mayorPrimo = -1, posicion = -1;

for (int i = 0; i < 10; i++)
{
    Console.Write($"Ingrese el número {i + 1}: ");
    enteroTres[i] = Convert.ToInt32(Console.ReadLine());
}

bool EsPrimo(int num)
{
    if (num < 2) return false;
    for (int i = 2; i * i <= num; i++)
        if (num % i == 0) return false;
    return true;
}

for (int i = 0; i < 10; i++)
{
    if (EsPrimo(enteroTres[i]) && enteroTres[i] > mayorPrimo)
    {
        mayorPrimo = enteroTres[i];
        posicion = i;
    }
}

if (mayorPrimo != -1)
    Console.WriteLine($"\nEl número primo mayor es {mayorPrimo} y está en la posición {posicion}.");
else
    Console.WriteLine("\nNo se ingresaron números primos.");

// 4. Leer 10 números enteros, almacenarlos en un arreglo y determinar cuántos números de los almacenados en dicho arreglo comienzan en dígito primo //

Console.WriteLine("\nEjercicio 4\n");

int[] enteroCuatro = new int[10];
int contador = 0;

for (int i = 0; i < 10; i++)
{
    Console.Write($"Ingrese el número {i + 1}: ");
    enteroCuatro[i] = int.Parse(Console.ReadLine());
}

bool EsDigitoPrimo(char digito)
{
    return digito == '2' || digito == '3' || digito == '5' || digito == '7';
}

foreach (int num in enteroCuatro)
{
    char primerDigito = num.ToString()[0];
    if (EsDigitoPrimo(primerDigito))
    {
        contador++;
    }
}

Console.WriteLine($"\nCantidad de números que comienzan con un dígito primo: {contador}");

// 5. Leer 10 números enteros, almacenarlos en un arreglo y determinar en qué posiciones se encuentran los números con más de 3 dígitos //

Console.WriteLine("\nEjercicio 5\n");

int[] numeros = new int[10];

for (int i = 0; i < 10; i++)
{
    Console.Write($"Ingrese el número {i + 1}: ");
    numeros[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Los números con más de 3 dígitos se encuentran en las posiciones:");
bool encontrado = false;

for (int i = 0; i < 10; i++)
{
    if (Math.Abs(numeros[i]) >= 1000)
    {
        Console.WriteLine($"{i}");
        encontrado = true;
    }
}

if (!encontrado)
{
    Console.WriteLine("No hay números con más de 3 dígitos en la lista.");
}