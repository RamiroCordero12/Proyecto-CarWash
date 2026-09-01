using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public interface IABM<T, Tkey>
    {
        void Agregar(T cliente);
        void Eliminar(Tkey clave);
        void Modificar(T cliente);
        List<T> Listar();
    }
}
