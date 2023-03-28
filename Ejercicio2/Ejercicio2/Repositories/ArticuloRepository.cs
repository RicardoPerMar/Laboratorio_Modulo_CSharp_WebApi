using Ejercicio2.Contracts;
using Ejercicio2.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        const string JSON_PATH = @"C:\Users\i40268\OneDrive - Verisk Analytics\Documents\C#\Laboratorio_Modulo_CSharp_WebApi\Ejercicio2\Ejercicio2\Resources\Articulo.json";
        public void AddArticulo(Articulo articulo)
        {
            var articulos = GetArticulos();
            var existArticulos = articulos.Exists(a => a.Id == articulo.Id);
            if (existArticulos)
            {
                throw new System.Exception("Ya existe un articulo con esa ID");
            }
            articulos.Add(articulo);
            UpdateJSON(articulos);
        }

        public void DecArticulo(int id, int cant)
        {

            var articulos = GetArticulos();
            var existArticulos = articulos.Exists(a => a.Id == id);
            if (!existArticulos)
            {
                throw new System.Exception("No existe un articulo con esa ID");
            }
            var temp = articulos.Find(a => a.Id == id);
            var articulo = articulos.Find(a => a.Id == id);
            if (articulo.Cantidad-cant >= 0)
            {
                articulo.Cantidad -= cant;
                articulos.Remove(temp);
                articulos.Add(articulo);
                UpdateJSON(articulos);
            }
            else
            {
                throw new System.Exception("BAD REQUEST. NO HAY EXISTENCIAS");
            }

        }

        public void IncArticulo(int id, int cant)
        {
            var articulos = GetArticulos();

            var existArticulos = articulos.Exists(a => a.Id == id);
            if (!existArticulos)
            {
                throw new System.Exception("No existe un articulo con esa ID");
            }
            var temp = articulos.Find(a => a.Id == id);
            var articulo = articulos.Find(a => a.Id == id);
            articulo.Cantidad = articulo.Cantidad + cant;
            articulos.Remove(temp);
            articulos.Add(articulo);
            UpdateJSON(articulos);
        }
        public List<Articulo> GetArticulos()
        {
            try
            {
                var articulosFromFile = GetArticuloFromFile();
                List<Articulo> listArticulos = JsonConvert.DeserializeObject<List<Articulo>>(articulosFromFile);
                return listArticulos;
            }
            catch (System.Exception)
            {
                throw;
            }

        }
        private string GetArticuloFromFile()
        {
            return File.ReadAllText(JSON_PATH);
        }

        private void UpdateJSON(List<Articulo> listArticulos)
        {
            var articulosJSON = JsonConvert.SerializeObject(listArticulos, Formatting.Indented);
            File.WriteAllText(JSON_PATH, articulosJSON);
        }
    }
}
