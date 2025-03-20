class Autobus
{
    public string Nombre { get; set; }
    public int Capacidad { get; set; }
    public int AsientosDisponibles { get; set; }
    public int PrecioPasaje { get; set; }
    public int Ventas { get; private set; }
    
    public Autobus(string nombre, int capacidad, int asientosDisponibles, int precioPasaje)
    {
        Nombre = nombre;
        Capacidad = capacidad;
        AsientosDisponibles = asientosDisponibles;
        PrecioPasaje = precioPasaje;
        Ventas = 0;
    }
    
    public void VenderPasajes(int cantidad)
    {
        if (cantidad <= AsientosDisponibles)
        {
            AsientosDisponibles -= cantidad;
            Ventas += cantidad * PrecioPasaje;
            Console.WriteLine($"{cantidad} pasajes vendidos en {Nombre}.");
        }
        else
        {
            Console.WriteLine($"No hay suficientes asientos disponibles en {Nombre}.");
        }
    }
    
    public void MostrarEstado()
    {
        Console.WriteLine($"{Nombre} - Ventas: {Ventas}, Asientos disponibles: {AsientosDisponibles}");
    }
}

class RepasoDos_YordiPolanco
{
    static void Main()
    {
        Autobus platinum = new Autobus("Auto Bus Platinum", 22, 17, 1000);
        Autobus gold = new Autobus("Auto Bus Gold", 15, 12, 800);

        platinum.VenderPasajes(5);
        gold.VenderPasajes(3);
        
        platinum.MostrarEstado();
        gold.MostrarEstado();
    }
}