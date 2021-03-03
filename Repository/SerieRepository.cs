using System.Collections.Generic;
using CRUD_series.Model;

namespace CRUD_series.Repository
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Exclude(int id)
        {
            listaSeries[id].Excluir();
        }

        public Serie FindByID(int id)
        {
            return listaSeries[id];
        }

        public void Insert(Serie entity)
        {
            listaSeries.Add(entity);
        }

        public List<Serie> List()
        {
            return listaSeries;
        }

        public int NextId()
        {
            return listaSeries.Count;
        }

        public void Update(int id, Serie entity)
        {
            listaSeries[id] = entity;
        }
    }
}