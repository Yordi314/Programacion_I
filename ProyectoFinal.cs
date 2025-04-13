using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlEmpleados
{
    interface ICalculable
    {
        double CalcularSalario();
    }

    abstract class Empleado : ICalculable
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Cargo { get; set; }
        public double SalarioBase { get; set; }
        public int Antiguedad { get; set; }

        public Empleado(string nombre, string cedula, string cargo, double salarioBase, int antiguedad)
        {
            Nombre = nombre;
            Cedula = cedula;
            Cargo = cargo;
            SalarioBase = salarioBase;
            Antiguedad = antiguedad;
        }

        public abstract double CalcularSalario();

        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Cédula: {Cedula}");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Salario Base: ${SalarioBase}");
            Console.WriteLine($"Antigüedad: {Antiguedad} años");
            Console.WriteLine($"Salario Total: ${CalcularSalario():F2}");
            Console.WriteLine("-------------------------------------");
        }
    }

    class EmpleadoTiempoCompleto : Empleado
    {
        public EmpleadoTiempoCompleto(string nombre, string cedula, string cargo, double salarioBase, int antiguedad)
            : base(nombre, cedula, cargo, salarioBase, antiguedad) { }

        public override double CalcularSalario()
        {
            double bonificacion = 0.03 * Antiguedad * SalarioBase;
            return SalarioBase + bonificacion + 150.00; // Extra bono fijo
        }
    }

    class EmpleadoMedioTiempo : Empleado
    {
        public EmpleadoMedioTiempo(string nombre, string cedula, string cargo, double salarioBase, int antiguedad)
            : base(nombre, cedula, cargo, salarioBase, antiguedad) { }

        public override double CalcularSalario()
        {
            double bonificacion = 0.015 * Antiguedad * SalarioBase;
            return SalarioBase + bonificacion;
        }
    }

    class GestorEmpleados
    {
        private List<Empleado> empleados = new List<Empleado>();

        public void AgregarEmpleado(Empleado e)
        {
            empleados.Add(e);
        }

        public void ListarEmpleados()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            foreach (var e in empleados)
            {
                e.MostrarInfo();
            }
        }

        public void EliminarEmpleado(string cedula)
        {
            var emp = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (emp != null)
            {
                empleados.Remove(emp);
                Console.WriteLine("Empleado eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void EditarEmpleado(string cedula)
        {
            var emp = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (emp == null)
            {
                Console.WriteLine("Empleado no encontrado.");
                return;
            }

            Console.Write("Nuevo nombre: ");
            emp.Nombre = Console.ReadLine();

            Console.Write("Nuevo cargo: ");
            emp.Cargo = Console.ReadLine();

            Console.Write("Nuevo salario base: ");
            emp.SalarioBase = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nueva antigüedad (años): ");
            emp.Antiguedad = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Empleado actualizado.");
        }

        public void BuscarEmpleadoPorCedula(string cedula)
        {
            var emp = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (emp != null)
                emp.MostrarInfo();
            else
                Console.WriteLine("Empleado no encontrado.");
        }
    }

    class ProyectoFinal
    {
        static void Main(string[] args)
        {
            GestorEmpleados gestor = new GestorEmpleados();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n=== Menú de Control de Empleados ===");
                Console.WriteLine("1. Agregar empleado");
                Console.WriteLine("2. Listar empleados");
                Console.WriteLine("3. Buscar empleado por cédula");
                Console.WriteLine("4. Editar empleado");
                Console.WriteLine("5. Eliminar empleado");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Write("Tipo de empleado (1 = Tiempo completo, 2 = Medio tiempo): ");
                            string tipo = Console.ReadLine();

                            Console.Write("Nombre: ");
                            string nombre = Console.ReadLine();

                            Console.Write("Cédula: ");
                            string cedula = Console.ReadLine();

                            Console.Write("Cargo: ");
                            string cargo = Console.ReadLine();

                            Console.Write("Salario base: ");
                            double salario = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Antigüedad (años): ");
                            int antiguedad = Convert.ToInt32(Console.ReadLine());

                            Empleado emp;

                            if (tipo == "1")
                                emp = new EmpleadoTiempoCompleto(nombre, cedula, cargo, salario, antiguedad);
                            else
                                emp = new EmpleadoMedioTiempo(nombre, cedula, cargo, salario, antiguedad);

                            gestor.AgregarEmpleado(emp);
                            Console.WriteLine("Empleado agregado.");
                            break;

                        case "2":
                            gestor.ListarEmpleados();
                            break;

                        case "3":
                            Console.Write("Ingrese cédula: ");
                            string cedBuscar = Console.ReadLine();
                            gestor.BuscarEmpleadoPorCedula(cedBuscar);
                            break;

                        case "4":
                            Console.Write("Ingrese cédula del empleado a editar: ");
                            string cedEditar = Console.ReadLine();
                            gestor.EditarEmpleado(cedEditar);
                            break;

                        case "5":
                            Console.Write("Ingrese cédula del empleado a eliminar: ");
                            string cedEliminar = Console.ReadLine();
                            gestor.EliminarEmpleado(cedEliminar);
                            break;

                        case "6":
                            salir = true;
                            break;

                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("Gracias por usar el sistema.");
        }
    }
}
