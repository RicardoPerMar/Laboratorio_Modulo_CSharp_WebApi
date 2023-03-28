using System.Collections.Generic;
using Ejercicio2.Models;

namespace Ejercicio2.Contracts
{
    public interface IArticuloRepository
    {
        List<Articulo> GetArticulos();
        void AddArticulo(Articulo articulo);
        void IncArticulo(int id, int cant);
        void DecArticulo(int id, int cant);

    }
}
