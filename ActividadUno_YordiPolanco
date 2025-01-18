// 1. Leer un número entero de dos dígitos y determinar a cuánto es igual la suma de sus dígitos.

Console.WriteLine("Ejercicio 1");

Console.Write("Ingresa un primer número de dos dígitos: ");
int numeroUno = Convert.ToInt32(Console.ReadLine());

while (numeroUno < 10 || numeroUno > 99)
{
    Console.WriteLine("El numero debe ser de dos digitos.");
    Console.Write("Ingresa un primer número de dos dígitos: ");
    numeroUno = Convert.ToInt32(Console.ReadLine());
}

Console.Write("Ingresa un segundo número de dos dígitos: ");
int numeroDos = Convert.ToInt32(Console.ReadLine());

while (numeroDos < 10 || numeroDos > 99)
{
    Console.WriteLine("El numero debe ser de dos digitos.");
    Console.Write("Ingresa un segundo número de dos dígitos: ");
    numeroDos = Convert.ToInt32(Console.ReadLine());
}

int resultadoSuma = numeroUno + numeroDos;

Console.WriteLine($"El resultado de la suma de los dos numeros es: {resultadoSuma}");

// 2. Leer un número entero de dos dígitos y determinar si es primo y además si es negativo.

Console.WriteLine("Ejercicio 2");

Console.Write("Ingresa un número entero de dos dígitos: ");
int numeroEntero = Convert.ToInt32(Console.ReadLine());

while (numeroEntero < 10 || numeroEntero > 99)
{
    Console.WriteLine("El numero debe ser de dos digitos.");
    Console.Write("Introduce un número entero de dos dígitos: ");
    numeroEntero = Convert.ToInt32(Console.ReadLine());
}

bool esNegativo = numeroEntero < 0;

bool EsPrimo1(int n)
{
    if (n == 2 || n % 2 == 1)
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool esPrimo = EsPrimo(Math.Abs(numeroEntero));

Console.WriteLine($"El número {numeroEntero} es{(esNegativo ? " negativo" : " positivo")}.");
Console.WriteLine($"El número {numeroEntero} {(esPrimo ? "es primo." : "no es primo.")}");

// 3. Leer un número entero de dos dígitos y determinar si sus dos dígitos son primos.

Console.WriteLine("Ejercicio 3");

Console.Write("Ingresa un número entero de dos dígitos: ");
int numero = Convert.ToInt32(Console.ReadLine());

while (numero < 10 || numero > 99)
{
    Console.WriteLine("El numero debe ser de dos digitos.");
    Console.Write("Ingresa un número entero de dos dígitos: ");
    numero = Convert.ToInt32(Console.ReadLine());
}

int digito1 = numero / 10;
int digito2 = numero % 10;

if (EsPrimo(digito1) && EsPrimo(digito2))
    Console.WriteLine($"Ambos dígitos de {numero} son primos.");
else
    Console.WriteLine($"No ambos dígitos de {numero} son primos.");

bool EsPrimo(int n)
{
    return n == 2 || n == 3 || n == 5 || n == 7;
}

// 4. Leer dos números enteros de dos dígitos y determinar si la suma de los dos números origina un número par.

Console.WriteLine("Ejercicio 4");

Console.Write("Ingresa un primer número entero de dos dígitos: ");
int numero1 = Convert.ToInt32(Console.ReadLine());

while (numero1 < 10 || numero1 > 99)
{
    Console.WriteLine("El numero debe ser de dos digitos.");
    Console.Write("Ingresa un primer número entero de dos dígitos: ");
    numero1 = Convert.ToInt32(Console.ReadLine());
}

Console.Write("Ingresa un segundo número entero de dos dígitos: ");
int numero2 = Convert.ToInt32(Console.ReadLine());

while (numero2 < 10 || numero2 > 99)
{
    Console.WriteLine("El numero debe ser de dos digitos.");
    Console.Write("Ingresa un segundo número entero de dos dígitos: ");
    numero2 = Convert.ToInt32(Console.ReadLine());
}

int suma = numero1 + numero2;

if (EsPar(suma))
{
    Console.WriteLine($"La suma de {numero1} y {numero2} es {suma} y este es un número par.");
}
else
{
    Console.WriteLine($"La suma de {numero1} y {numero2} es {suma} y este no es un número par.");
}

bool EsPar(int n)
{
    return n % 2 == 0;
}

// 5. Leer un número entero de tres dígitos y determinar en qué posición está el mayor dígito.

Console.WriteLine("Ejercicio 5");

Console.Write("Ingresa un número de tres dígitos: ");
int DigitosTres = Convert.ToInt32(Console.ReadLine());

while (DigitosTres < 100 || DigitosTres > 999)
{
    Console.WriteLine("El numero debe ser de tres digitos.");
    Console.Write("Ingresa un número de tres dígitos: ");
    DigitosTres = Convert.ToInt32(Console.ReadLine());
}

int centena = DigitosTres / 100;          
int decena = (DigitosTres / 10) % 10;    
int unidad = DigitosTres % 10;   

int posicionMayor = 1;

if (decena > centena && decena > unidad)
{
    posicionMayor = 2;
}
else if (unidad > centena && unidad > decena)
{
    posicionMayor = 3;
}

Console.WriteLine($"El dígito mayor está en la posición {posicionMayor}");

// 6. Leer un número entero de tres dígitos y determinar si algún dígito es múltiplo de los otros.

Console.WriteLine("Ejercicio 6");

Console.Write("Ingresa un número de tres dígitos: ");
int tresDigitos = Convert.ToInt32(Console.ReadLine());

while (tresDigitos < 100 || tresDigitos > 999)
{
    Console.WriteLine("El numero debe ser de tres digitos.");
    Console.Write("Ingresa un número de tres dígitos: ");
    tresDigitos = Convert.ToInt32(Console.ReadLine());
}

int digitoUno = tresDigitos / 100;          
int digitoDos = (tresDigitos / 10) % 10;    
int digitoTres = tresDigitos % 10;          

Console.WriteLine($"Los dígitos son: {digitoUno}, {digitoDos}, {digitoTres}");

bool hayMultiplo = false;

if (digitoUno != 0 && digitoDos % digitoUno == 0)
{
    Console.WriteLine($"{digitoDos} es múltiplo de {digitoUno}");
    hayMultiplo = true;
}
if (digitoUno != 0 && digitoTres % digitoUno == 0)
{
    Console.WriteLine($"{digitoTres} es múltiplo de {digitoUno}");
    hayMultiplo = true;
}
if (digitoDos != 0 && digitoUno % digitoDos == 0)
{
    Console.WriteLine($"{digitoUno} es múltiplo de {digitoDos}");
    hayMultiplo = true;
}
if (digitoDos != 0 && digitoTres % digitoDos == 0)
{
    Console.WriteLine($"{digitoTres} es múltiplo de {digitoDos}");
    hayMultiplo = true;
}
if (digitoTres != 0 && digitoUno % digitoTres == 0)
{
    Console.WriteLine($"{digitoUno} es múltiplo de {digitoTres}");
    hayMultiplo = true;
}
if (digitoTres != 0 && digitoDos % digitoTres == 0)
{
    Console.WriteLine($"{digitoDos} es múltiplo de {digitoTres}");
    hayMultiplo = true;
}

if (!hayMultiplo)
{
    Console.WriteLine("Ningún dígito es múltiplo de otro");
}

// 7. Leer tres números enteros y determinar cuál es el mayor. Usar solamente dos variables.

Console.WriteLine("Ejercicio 7");

Console.Write("Ingrese tres números enteros: ");
int mayorTres = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < 2; i++)
{
    int numeroTres = Convert.ToInt32(Console.ReadLine());
    if (numeroTres > mayorTres)
    {
        mayorTres = numeroTres;
    }
}

Console.WriteLine($"El mayor número es: {mayorTres}");

// 8. Leer un número entero de cinco dígitos y determinar si es un número Capicúa.

Console.WriteLine("Ejercicio 8");

Console.Write("Ingresa un número entero de cinco dígitos: ");
int cincoDigitos = int.Parse(Console.ReadLine());

while (cincoDigitos < 10000 || cincoDigitos > 99999)
{
    Console.WriteLine("El numero debe contener cinco digitos.");
    Console.Write("Ingresa un número entero de cinco dígitos: ");
    cincoDigitos = int.Parse(Console.ReadLine());
}

bool EsCapicua(int n)
{
    string strNumero = Math.Abs(n).ToString();
    char[] arr = strNumero.ToCharArray();
    Array.Reverse(arr);
    string strReverso = new string(arr);
    return strNumero == strReverso;
}

bool esCapicua = EsCapicua(cincoDigitos);

Console.WriteLine($"El número {cincoDigitos} {(esCapicua ? "es un número Capicúa." : "no es un número Capicúa.")}");

// 9. Leer un número entero de cuatro dígitos y determinar si el segundo dígito es igual al penúltimo.

Console.WriteLine("Ejercicio 9");

Console.Write("Ingresa un número de cuatro dígitos: ");
int cuatroDigitos = Convert.ToInt32(Console.ReadLine());

while (cuatroDigitos < 1000 || cuatroDigitos > 9999)
{
    Console.WriteLine("El número debe contener cuatro dígitos.");
    Console.Write("Ingresa un número de cuatro dígitos: ");
    cuatroDigitos = Convert.ToInt32(Console.ReadLine());
}

int segundoDigito = (cuatroDigitos / 100) % 10;
int tercerDigito = (cuatroDigitos % 100) / 10;

if (segundoDigito == tercerDigito)
{
    Console.WriteLine($"En el numero {cuatroDigitos} el segundo dígito y el penúltimo son iguales");
}
else
{
    Console.WriteLine($"En el numero {cuatroDigitos} el segundo dígito y el penúltimo no son iguales");
}

//10. Leer dos números enteros y si la diferencia entre los dos es menor o igual a 10 entonces mostrar en pantalla todos los enteros comprendidos entre el menor y el mayor de los números leídos.

Console.WriteLine("Ejercicio 10");

Console.Write("Ingresa un primer número entero: ");
int primerEntero = Convert.ToInt32(Console.ReadLine());

Console.Write("Ingresa un segundo número entero: ");
int segundoEntero = Convert.ToInt32(Console.ReadLine());

int menorEntero = Math.Min(primerEntero, segundoEntero);
int mayorEntero = Math.Max(primerEntero, segundoEntero);

int diferenciaEntero = mayorEntero - menorEntero;

if (diferenciaEntero <= 10)
{
    Console.WriteLine($"Los números entre {menorEntero} y {mayorEntero} son:");
    for (int i = menorEntero; i <= mayorEntero; i++)
    {
        Console.Write($"{i} ");
    }
}
else
{
    Console.WriteLine($"La diferencia entre {primerEntero} y {segundoEntero} es {diferenciaEntero} que es mayor a 10.");
}
