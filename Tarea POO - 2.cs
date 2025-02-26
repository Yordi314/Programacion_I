using System;

class Motor
{
    private int litros_de_aceite;
    private int potencia;

    public Motor(int potencia)
    {
        this.potencia = potencia;
        this.litros_de_aceite = 0;
    }

    public int GetLitrosDeAceite() => litros_de_aceite;
    public int GetPotencia() => potencia;

    public void SetLitrosDeAceite(int litros) => litros_de_aceite = litros;
    public void SetPotencia(int potencia) => this.potencia = potencia;
}

class Coche
{
    private Motor motor;
    private string marca;
    private string modelo;
    private double precioAcumuladoAverias;

    public Coche(string marca, string modelo, int potencia)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.precioAcumuladoAverias = 0;
        this.motor = new Motor(potencia);
    }

    public string GetMarca() => marca;
    public string GetModelo() => modelo;
    public double GetPrecioAcumuladoAverias() => precioAcumuladoAverias;
    public Motor GetMotor() => motor;

    public void AcumularAveria(double importe)
    {
        precioAcumuladoAverias += importe;
    }
}

class Garaje
{
    private Coche cocheActual;
    private string averiaAsociada;
    private int cochesAtendidos;

    public Garaje()
    {
        cocheActual = null;
        averiaAsociada = "";
        cochesAtendidos = 0;
    }

    public bool AceptarCoche(Coche coche, string averia)
    {
        if (cocheActual != null)
        {
            return false;
        }
        
        cocheActual = coche;
        averiaAsociada = averia;
        cochesAtendidos++;
        
        Random random = new Random();
        double costeAveria = random.NextDouble() * 500;
        coche.AcumularAveria(costeAveria);
        
        if (averia == "aceite")
        {
            coche.GetMotor().SetLitrosDeAceite(coche.GetMotor().GetLitrosDeAceite() + 10);
        }
        
        return true;
    }

    public void DevolverCoche()
    {
        cocheActual = null;
        averiaAsociada = "";
    }
}

class PracticaPOO
{
    static void Main()
    {
        Garaje garaje = new Garaje();
        Coche coche1 = new Coche("Toyota", "Corolla", 120);
        Coche coche2 = new Coche("Ford", "Focus", 130);
        
        for (int i = 0; i < 2; i++)
        {
            if (garaje.AceptarCoche(coche1, "aceite"))
            {
                garaje.DevolverCoche();
            }
            if (garaje.AceptarCoche(coche2, "motor"))
            {
                garaje.DevolverCoche();
            }
        }
        
        Console.WriteLine($"Coche 1: {coche1.GetMarca()} {coche1.GetModelo()}, Precio Averías: {coche1.GetPrecioAcumuladoAverias()}, Litros Aceite: {coche1.GetMotor().GetLitrosDeAceite()}");
        Console.WriteLine($"Coche 2: {coche2.GetMarca()} {coche2.GetModelo()}, Precio Averías: {coche2.GetPrecioAcumuladoAverias()}, Litros Aceite: {coche2.GetMotor().GetLitrosDeAceite()}");
    }
}