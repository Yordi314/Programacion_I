namespace Actividad_2;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingresa un año: ");
        int añoComprobar = Convert.ToInt32(Console.ReadLine());

        while (añoComprobar < 1582)
        {
            Console.WriteLine("El año ingresado debe ser mayor a 1582.");
            Console.Write("Ingresa un año: ");
            añoComprobar = Convert.ToInt32(Console.ReadLine());
        }

        if (EsBisiesto(añoComprobar))
        {
            Console.WriteLine($"El año {añoComprobar} es bisiesto.");
        }
        else
        {
            Console.WriteLine($"El año {añoComprobar} no es bisiesto.");
        }
        
        bool EsBisiesto(int n)
        {
            if (n % 400 == 0)
            {
                return true;
            }
            else if (n % 100 == 0)
            {
                return false;
            }
            else if (n % 4 == 0)
            {
                return true;
            }
            return false;
        }
    }
}