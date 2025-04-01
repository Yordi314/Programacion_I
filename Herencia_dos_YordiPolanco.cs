class Hamburguesa
{
    protected string TipoPan;
    protected string TipoCarne;
    protected double PrecioBase;
    protected Dictionary<string, double> IngredientesAdicionales;
    protected int MaxIngredientes;

    public Hamburguesa(string tipoPan, string tipoCarne, double precioBase, int maxIngredientes = 4)
    {
        TipoPan = tipoPan;
        TipoCarne = tipoCarne;
        PrecioBase = precioBase;
        IngredientesAdicionales = new Dictionary<string, double>();
        MaxIngredientes = maxIngredientes;
    }

    public bool AgregarIngrediente(string ingrediente, double precio)
    {
        if (IngredientesAdicionales.Count < MaxIngredientes)
        {
            IngredientesAdicionales[ingrediente] = precio;
            return true;
        }
        return false;
    }

    public virtual void MostrarPrecio()
    {
        double precioTotal = PrecioBase;
        Console.WriteLine($"Hamburguesa con {TipoPan} y {TipoCarne}");
        Console.WriteLine($"Precio base: ${PrecioBase}");
        
        foreach (var ingrediente in IngredientesAdicionales)
        {
            Console.WriteLine($"Ingrediente adicional: {ingrediente.Key} - ${ingrediente.Value}");
            precioTotal += ingrediente.Value;
        }
        Console.WriteLine($"Total: ${precioTotal}\n");
    }
}

class HamburguesaSaludable : Hamburguesa
{
    public HamburguesaSaludable(string tipoCarne, double precioBase)
        : base("Pan Integral", tipoCarne, precioBase, 6) { }
}

class HamburguesaPremium : Hamburguesa
{
    public HamburguesaPremium(string tipoCarne, double precioBase)
        : base("Pan Brioche", tipoCarne, precioBase, 0)
    {
        IngredientesAdicionales.Add("Papas fritas", 3.00);
        IngredientesAdicionales.Add("Bebida", 2.50);
    }
}

class Program
{
    static void Main()
    {
        Hamburguesa clasica = new Hamburguesa("Pan Blanco", "Res", 5.00);
        clasica.AgregarIngrediente("Lechuga", 0.50);
        clasica.AgregarIngrediente("Tomate", 0.75);
        clasica.MostrarPrecio();

        HamburguesaSaludable saludable = new HamburguesaSaludable("Pollo", 6.00);
        saludable.AgregarIngrediente("Aguacate", 1.50);
        saludable.AgregarIngrediente("Espinaca", 1.00);
        saludable.MostrarPrecio();

        HamburguesaPremium premium = new HamburguesaPremium("Angus", 8.00);
        premium.MostrarPrecio();
    }
}
