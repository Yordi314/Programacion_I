using System;

namespace HerenciaEjemplos
{
    // 1. Herencia Básica: Sistema de Vehículos
    public class Vehiculo
    {
        public string Marca { get; protected set; }
        public string Modelo { get; protected set; }

        public Vehiculo(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }

        public virtual string Describir()
        {
            return $"Vehículo {Marca} {Modelo}";
        }
    }

    public class Coche : Vehiculo
    {
        public int NumeroPuertas { get; private set; }

        public Coche(string marca, string modelo, int numeroPuertas) 
            : base(marca, modelo)
        {
            NumeroPuertas = numeroPuertas;
        }

        public override string Describir()
        {
            return $"{base.Describir()} de {NumeroPuertas} puertas";
        }
    }

    // 2. Herencia Múltiple (Implementación con Interfaces): Sistema de Empleados
    public interface ITrabajador
    {
        string Trabajar();
    }

    public interface IProgramador
    {
        string Programar();
    }

    public class Trabajador
    {
        public string Nombre { get; protected set; }
        public decimal Salario { get; protected set; }

        public Trabajador(string nombre, decimal salario)
        {
            Nombre = nombre;
            Salario = salario;
        }
    }

    public class EmpleadoTecnologico : Trabajador, ITrabajador, IProgramador
    {
        public string LenguajeProgramacion { get; private set; }

        public EmpleadoTecnologico(string nombre, decimal salario, string lenguajeProgramacion) 
            : base(nombre, salario)
        {
            LenguajeProgramacion = lenguajeProgramacion;
        }

        public string Trabajar()
        {
            return $"{Nombre} está trabajando";
        }

        public string Programar()
        {
            return $"Programando en {LenguajeProgramacion}";
        }

        public string DescripcionCompleta()
        {
            return $"{Nombre} - Salario: {Salario} - Lenguaje: {LenguajeProgramacion}";
        }
    }

    // 3. Herencia con Polimorfismo: Sistema de Figuras Geométricas
    public abstract class FiguraGeometrica
    {
        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();
    }

    public class Circulo : FiguraGeometrica
    {
        public double Radio { get; private set; }

        public Circulo(double radio)
        {
            Radio = radio;
        }

        public override double CalcularArea()
        {
            return Math.PI * Math.Pow(Radio, 2);
        }

        public override double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio;
        }
    }

    public class Rectangulo : FiguraGeometrica
    {
        public double Ancho { get; private set; }
        public double Alto { get; private set; }

        public Rectangulo(double ancho, double alto)
        {
            Ancho = ancho;
            Alto = alto;
        }

        public override double CalcularArea()
        {
            return Ancho * Alto;
        }

        public override double CalcularPerimetro()
        {
            return 2 * (Ancho + Alto);
        }
    }

    // 4. Herencia con Método Estático: Sistema de Animales
    public class Animal
    {
        private static int _totalAnimales = 0;
        public string Nombre { get; protected set; }

        public Animal(string nombre)
        {
            Nombre = nombre;
            _totalAnimales++;
        }

        public static int ContarAnimales()
        {
            return _totalAnimales;
        }
    }

    public class Perro : Animal
    {
        public string Raza { get; private set; }

        public Perro(string nombre, string raza) : base(nombre)
        {
            Raza = raza;
        }

        public string Ladrar()
        {
            return $"{Nombre} está ladrando";
        }
    }

    // 5. Herencia Jerárquica: Sistema de Dispositivos Electrónicos
    public class DispositivoElectronico
    {
        public string Marca { get; protected set; }
        public string Modelo { get; protected set; }

        public DispositivoElectronico(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }

        public virtual string Encender()
        {
            return "Dispositivo encendido";
        }

        public virtual string Apagar()
        {
            return "Dispositivo apagado";
        }
    }

    public class Smartphone : DispositivoElectronico
    {
        public string SistemaOperativo { get; private set; }

        public Smartphone(string marca, string modelo, string sistemaOperativo) 
            : base(marca, modelo)
        {
            SistemaOperativo = sistemaOperativo;
        }

        public string HacerLlamada()
        {
            return "Realizando llamada";
        }
    }

    public class Tablet : DispositivoElectronico
    {
        public double TamanoPantalla { get; private set; }

        public Tablet(string marca, string modelo, double tamanoPantalla) 
            : base(marca, modelo)
        {
            TamanoPantalla = tamanoPantalla;
        }

        public string Dibujar()
        {
            return "Dibujando en la tablet";
        }
    }

    // Clase principal para demostración
    class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo 1: Herencia Básica
            Console.WriteLine("1. Herencia Básica:");
            Coche miCoche = new Coche("Toyota", "Corolla", 4);
            Console.WriteLine(miCoche.Describir());

            // Ejemplo 2: Herencia Múltiple (con Interfaces)
            Console.WriteLine("\n2. Herencia Múltiple:");
            EmpleadoTecnologico dev = new EmpleadoTecnologico("Juan", 5000, "C#");
            Console.WriteLine(dev.Trabajar());
            Console.WriteLine(dev.Programar());
            Console.WriteLine(dev.DescripcionCompleta());

            // Ejemplo 3: Polimorfismo
            Console.WriteLine("\n3. Polimorfismo:");
            Circulo circulo = new Circulo(5);
            Rectangulo rectangulo = new Rectangulo(4, 6);
            Console.WriteLine($"Área del círculo: {circulo.CalcularArea()}");
            Console.WriteLine($"Perímetro del rectángulo: {rectangulo.CalcularPerimetro()}");

            // Ejemplo 4: Método Estático
            Console.WriteLine("\n4. Método Estático:");
            Perro perro1 = new Perro("Firulais", "Labrador");
            Perro perro2 = new Perro("Rex", "Pastor Alemán");
            Console.WriteLine($"Total de animales: {Animal.ContarAnimales()}");

            // Ejemplo 5: Herencia Jerárquica
            Console.WriteLine("\n5. Herencia Jerárquica:");
            Smartphone smartphone = new Smartphone("Apple", "iPhone 12", "iOS");
            Tablet tablet = new Tablet("Samsung", "Galaxy Tab", 10.1);
            Console.WriteLine(smartphone.Encender());
            Console.WriteLine(smartphone.HacerLlamada());
            Console.WriteLine(tablet.Dibujar());
        }
    }
}