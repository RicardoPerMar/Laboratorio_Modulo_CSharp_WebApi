using Ejercicio1.Contracts;
using Ejercicio1.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using System.Numerics;
using System.Linq;

namespace Ejercicio1.Repositories
{
    public class ActorRepository : IActorRepository
    {
        const string JSON_PATH = @"C:\Users\i40268\OneDrive - Verisk Analytics\Documents\C#\Laboratorio_Modulo_CSharp_WebApi\Ejercicio1\Ejercicio1\Resources\Actores.json";
        public void AddActor(Actor actor)
        {
            var actors = GetActors();
            var existActor = actors.Exists(a => a.Id == actor.Id);
            if (existActor)
            {
                throw new Exception("Ya existe un autor con esa id");
            }
            actors.Add(actor);
            UpdateActors(actors);
        }

        public void DeleteActor(int id)
        {
            var actors = GetActors();
            var actor = actors[id - 1];
            actors.Remove(actor);
            UpdateActors(actors);
        }

        public void UpdateActor(Actor actor)
        {
            var actors = GetActors();//.Find(a => a.Id == actor.Id)
            var actorSearched = actors.Find(a => a.Id == actor.Id);
            var existActor = actors.Exists(a => a.Id == actor.Id);
            if (!existActor)
            {
                throw new Exception("No existe un autor con esa id");
            }
            actors.Add(actor);
            actors.Remove(actorSearched);
            UpdateActors(actors);

        }

        public Actor GetActorById(int id)
        {
            var actors = GetActors();
            var actor = actors.Find(a => a.Id == id);
            return actor;
        }

        public List<Actor> GetActors()
        {
            try
            {
                var actoresFromFile = GetActorsFromFile();
                List<Actor> listActores = JsonConvert.DeserializeObject<List<Actor>>(actoresFromFile);
                return listActores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UpdateActors(List<Actor> actors)
        {
            var actorsJson = JsonConvert.SerializeObject(actors, Formatting.Indented);
            File.WriteAllText(JSON_PATH, actorsJson);
        }

        private string GetActorsFromFile()
        {
            return File.ReadAllText(JSON_PATH);
        }


    }

}
