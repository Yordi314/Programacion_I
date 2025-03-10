using System;
public class Ave
{
    public string Nombre { get; set; }
    public string Color { get; set; }
    
    public Ave(string nombre, string color)
    {
        Nombre = nombre;
        Color = color;
    }
    
    public virtual void Volar()
    {
        Console.WriteLine($"{Nombre} está volando.");
    }

    public virtual void Comer()
    {
        Console.WriteLine($"{Nombre} está comiendo.");
    }

    public virtual void EmitirSonido()
    {
        Console.WriteLine($"{Nombre} está emitiendo un sonido.");
    }
}

public class Colibri : Ave
{
    public Colibri(string nombre, string color) : base(nombre, color) { }

    public override void Volar()
    {
        Console.WriteLine($"{Nombre} está volando rápidamente y en todas direcciones.");
    }

    public override void EmitirSonido()
    {
        Console.WriteLine($"{Nombre} está zumbando.");
    }
}

public class Cuervo : Ave
{
    public Cuervo(string nombre, string color) : base(nombre, color) { }

    public override void Comer()
    {
        Console.WriteLine($"{Nombre} está comiendo casi cualquier cosa.");
    }

    public override void EmitirSonido()
    {
        Console.WriteLine($"{Nombre} está graznando.");
    }
}

public class Flamenco : Ave
{
    public Flamenco(string nombre, string color) : base(nombre, color) { }

    public override void Volar()
    {
        Console.WriteLine($"{Nombre} está volando en formación.");
    }

    public override void EmitirSonido()
    {
        Console.WriteLine($"{Nombre} está haciendo sonidos de flamenco.");
    }
}

class PrácticaPolimorfismo_YordiPolanco
{
    static void Main(string[] args)
    {
        Ave colibri = new Colibri("Colibrí Esmeralda", "Verde");
        Ave cuervo = new Cuervo("Cuervo Negro", "Negro");
        Ave flamenco = new Flamenco("Flamenco Rosado", "Rosado");
        
        MostrarAcciones(colibri, "Colibrí");
        MostrarAcciones(cuervo, "Cuervo");
        MostrarAcciones(flamenco, "Flamenco");
    }
    
    static void MostrarAcciones(Ave ave, string tipoAve)
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine($"Acciones del {tipoAve}: {ave.Nombre} ({ave.Color})");
        Console.WriteLine(new string('-', 40));

        ave.Volar();
        ave.Comer();
        ave.EmitirSonido();

        Console.WriteLine("\n");
    }
}