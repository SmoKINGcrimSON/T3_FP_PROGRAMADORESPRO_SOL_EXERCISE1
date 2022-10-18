using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace T3_FP_PROGRAMADORESPRO.Clases
{
    public class P_dueno
    {
        private static ObservableCollection<P_dueno> p_duenosLista = new ObservableCollection<P_dueno>();
        public string P_nombre { get; set; }
        public string P_direccion { get; set; }
        public string P_telefono { get; set; }
        public static ObservableCollection<P_dueno> P_duenosLista { get => p_duenosLista; }
        public P_dueno(string p_nombre, string p_direccion, string p_telefono)
        {
            P_nombre = p_nombre;
            P_direccion = p_direccion;
            P_telefono = p_telefono;
        }
        public static void AgregarDueno(P_dueno dueno)
        {
            p_duenosLista.Add(dueno);
        }
    }
}
