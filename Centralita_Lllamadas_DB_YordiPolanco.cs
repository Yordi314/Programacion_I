using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CentralitaTelefonica
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    
    public abstract class Llamada
    {
        protected string numeroOrigen;
        protected string numeroDestino;
        protected int duracion;

        public Llamada(string origen, string destino, int duracionSegundos)
        {
            numeroOrigen = origen;
            numeroDestino = destino;
            duracion = duracionSegundos;
        }

        public string NumeroOrigen { get { return numeroOrigen; } }
        public string NumeroDestino { get { return numeroDestino; } }
        public int Duracion { get { return duracion; } }

        public abstract double CalcularCoste();

        public override string ToString()
        {
            return $"Origen: {numeroOrigen}, Destino: {numeroDestino}, Duración: {duracion}s, Coste: {CalcularCoste():C}";
        }
    }

    public class LlamadaLocal : Llamada
    {
        private const double COSTE_POR_SEGUNDO = 0.15;

        public LlamadaLocal(string origen, string destino, int duracionSegundos)
            : base(origen, destino, duracionSegundos)
        {
        }

        public override double CalcularCoste()
        {
            return duracion * COSTE_POR_SEGUNDO;
        }
    }

    public enum FranjaHoraria
    {
        Franja1 = 1,
        Franja2 = 2,
        Franja3 = 3
    }

    public class LlamadaProvincial : Llamada
    {
        private FranjaHoraria franja;

        public LlamadaProvincial(string origen, string destino, int duracionSegundos, FranjaHoraria franjaHoraria)
            : base(origen, destino, duracionSegundos)
        {
            franja = franjaHoraria;
        }

        public FranjaHoraria GetFranjaHoraria()
        {
            return franja;
        }

        public override double CalcularCoste()
        {
            double costePorSegundo;

            switch (franja)
            {
                case FranjaHoraria.Franja1:
                    costePorSegundo = 0.20;
                    break;
                case FranjaHoraria.Franja2:
                    costePorSegundo = 0.25;
                    break;
                case FranjaHoraria.Franja3:
                    costePorSegundo = 0.30;
                    break;
                default:
                    costePorSegundo = 0.20;
                    break;
            }

            return duracion * costePorSegundo;
        }

        public override string ToString()
        {
            return base.ToString() + $", Franja: {franja}";
        }
    }

    public class Centralita
    {
        private List<Llamada> llamadas;

        public Centralita()
        {
            llamadas = new List<Llamada>();
        }

        public void RegistrarLlamada(Llamada llamada)
        {
            llamadas.Add(llamada);
            BaseDeDatos.GuardarLlamada(llamada);
        }

        public List<Llamada> ObtenerLlamadas()
        {
            return llamadas;
        }

        public int ObtenerNumeroTotalLlamadas()
        {
            return llamadas.Count;
        }

        public double ObtenerFacturacionTotal()
        {
            double total = 0;
            foreach (var llamada in llamadas)
            {
                total += llamada.CalcularCoste();
            }
            return total;
        }
    }

    public static class BaseDeDatos
    {
        private static string cadenaConexion = "Server=tcp:centralitallamadas.database.windows.net,1433;" +
                                               "Initial Catalog=centralita_llamadas;" +
                                               "Persist Security Info=False;" +
                                               "User ID=Administrador;" +
                                               "Password=Hola1919;" +
                                               "MultipleActiveResultSets=False;" +
                                               "Encrypt=True;" +
                                               "TrustServerCertificate=False;" +
                                               "Connection Timeout=30;";

        public static void GuardarLlamada(Llamada llamada)
        {
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var comando = new SqlCommand("INSERT INTO Llamadas (Origen, Destino, Duracion, Costo, Tipo, Franja) VALUES (@origen, @destino, @duracion, @costo, @tipo, @franja)", conexion);

                comando.Parameters.AddWithValue("@origen", llamada.NumeroOrigen);
                comando.Parameters.AddWithValue("@destino", llamada.NumeroDestino);
                comando.Parameters.AddWithValue("@duracion", llamada.Duracion);
                comando.Parameters.AddWithValue("@costo", llamada.CalcularCoste());

                if (llamada is LlamadaLocal)
                {
                    comando.Parameters.AddWithValue("@tipo", "Local");
                    comando.Parameters.AddWithValue("@franja", DBNull.Value);
                }
                else if (llamada is LlamadaProvincial provincial)
                {
                    comando.Parameters.AddWithValue("@tipo", "Provincial");
                    comando.Parameters.AddWithValue("@franja", provincial.GetFranjaHoraria().ToString());
                }

                comando.ExecuteNonQuery();
            }
        }
    }
}
