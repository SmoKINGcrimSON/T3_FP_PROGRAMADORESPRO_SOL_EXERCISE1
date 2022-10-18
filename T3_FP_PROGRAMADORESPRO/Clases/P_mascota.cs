using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_FP_PROGRAMADORESPRO.Clases
{
    public class P_mascota
    {
        private static ObservableCollection<P_mascota> p_mascotasLista = new ObservableCollection<P_mascota>();
        public string P_nombre { get; set; }
        public byte P_edad { get; set; }
        public string P_raza { get; set; }
        public P_dueno P_dueno { get; set; }
        public static ObservableCollection<P_mascota> P_mascotasLista { get => p_mascotasLista;}
        public P_mascota(string p_nombre, byte p_edad, string p_raza, P_dueno p_dueno)
        {
            P_nombre = p_nombre;
            P_edad = p_edad;
            P_raza = p_raza;
            P_dueno = p_dueno;
        }
        public static void AgregarMascota(P_mascota mascota)
        {
            p_mascotasLista.Add(mascota);
        }
    }
}
