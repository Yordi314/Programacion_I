abstract class Llamada
{
    public string NumOrigen { get; set; }
    public string NumDestino { get; set; }
    public double Duracion { get; set; }

    public Llamada(string numOrigen, string numDestino, double duracion)
    {
        NumOrigen = numOrigen;
        NumDestino = numDestino;
        Duracion = duracion;
    }
    
    public abstract double CalculatePrecio();
}

class LlamadaLocal : Llamada
{
    private const double PrecioPorSegundo = 0.15;

    public LlamadaLocal(string numOrigen, string numDestino, double duracion)
        : base(numOrigen, numDestino, duracion)
    {
    }

    public override double CalculatePrecio()
    {
        return Duracion * PrecioPorSegundo;
    }

    public override string ToString()
    {
        return $"Llamada Local - Origen: {NumOrigen}, Destino: {NumDestino}, Duración: {Duracion} segundos, Coste: {CalculatePrecio():C}";
    }
}

class LlamadaProvincial : Llamada
{
    private static readonly double[] PreciosPorFranja = { 0.20, 0.25, 0.30 };
    public int Franja { get; set; }

    public LlamadaProvincial(string numOrigen, string numDestino, double duracion, int franja)
        : base(numOrigen, numDestino, duracion)
    {
        Franja = franja;
    }

    public override double CalculatePrecio()
    {
        if (Franja < 1 || Franja > 3)
        {
            throw new ArgumentException("La franja horaria debe ser 1, 2 o 3.");
        }
        return Duracion * PreciosPorFranja[Franja - 1];
    }

    public override string ToString()
    {
        return $"Llamada Provincial - Origen: {NumOrigen}, Destino: {NumDestino}, Duración: {Duracion} segundos, Franja: {Franja}, Coste: {CalculatePrecio():C}";
    }
}

class Centralita
{
    private int ContadorLlamadas { get; set; }
    private double AcumuladorCostes { get; set; }
    private List<Llamada> Llamadas { get; set; }

    public Centralita()
    {
        Llamadas = new List<Llamada>();
        ContadorLlamadas = 0;
        AcumuladorCostes = 0;
    }

    public void RegistrarLlamada(Llamada llamada)
    {
        Llamadas.Add(llamada);
        ContadorLlamadas++;
        AcumuladorCostes += llamada.CalculatePrecio();
        Console.WriteLine(llamada.ToString());
    }

    public void GenerarInforme()
    {
        Console.WriteLine("\n--- Informe de la Centralita ---");
        Console.WriteLine($"Total de llamadas: {ContadorLlamadas}");
        Console.WriteLine($"Facturación total: {AcumuladorCostes:C}");
    }
}

class Practica2
{
    static void Main(string[] args)
    {
        Centralita centralita = new Centralita();
        
        centralita.RegistrarLlamada(new LlamadaLocal("123456789", "987654321", 120));
        centralita.RegistrarLlamada(new LlamadaProvincial("123456789", "555555555", 180, 1));
        centralita.RegistrarLlamada(new LlamadaLocal("111111111", "222222222", 60));
        centralita.RegistrarLlamada(new LlamadaProvincial("333333333", "444444444", 240, 3));
        
        centralita.GenerarInforme();
    }
}