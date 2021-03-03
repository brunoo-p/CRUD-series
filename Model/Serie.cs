using System;

namespace CRUD_series.Model
{
    public class Serie : Base
    {
        private Genero Genero { get; set; }
        private string Title { get; set; }
        private int Year { get; set; }
        private string Description { get; set; }
        private int NextId { get; set; }
        private bool isExcluded {get; set;}
    
        public Serie(int id, Genero genero, string title, int year, string description)
        {
            this.Id = id;
            this.Genero = genero;
            this.Title = title;
            this.Year = year;
            this.Description = description;
            this.isExcluded = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno +="Gênero: " + this.Genero + Environment.NewLine;
            retorno +="Titulo: " + this.Title + Environment.NewLine;
            retorno +="Descrição: " + this.Description + Environment.NewLine;
            retorno +="Ano de Início: " + this.Year + Environment.NewLine;
            retorno +="Excluído: " + this.isExcluded + Environment.NewLine;
            return retorno;
        }
        public void Excluir()
            {
                this.isExcluded = true;
            }

        public string ReturnTitle()
            {
                return this.Title;
            }
        public bool ReturnIsExcluded()
        {
            return this.isExcluded;
        }

        public int ReturnId()
            {
                return this.NextId;
            }
    
    }
}