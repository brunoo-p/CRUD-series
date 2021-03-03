using System;
using CRUD_series.Model;
using CRUD_series.Repository;

namespace CRUD_series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        public static string opcao;

        static void Main(string[] args)
        {
            do{
                opcao = "";
                opcao = ObterOpcaoUsuario();
                switch(opcao)
                {
                    case "1":
                        var list = repository.List();
                        if(list.Count <= 0)
                        {
                            Console.WriteLine("Nenhuma Série Cadastrada.");
                            for(int i = 0; i < 25; i++){ Console.Write("-");}
                            Console.WriteLine("\nPressione Qualquer Tecla.");
                            Console.ReadLine();
                        }else{
                            ListarSeries();
                        }
                        break;
                    case "2":
                        CadastrarSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            }while(opcao.ToUpper() != "X");
        }

        private static void ListarSeries()
        {
            Console.WriteLine("--- Listar Séries ---");
            var list = repository.List();

            foreach (var serie in list)
            {
                var excluded = serie.ReturnIsExcluded();
                if(!excluded)
                {
                    Console.WriteLine("#ID {0} - {1}", serie.ReturnId(), serie.ReturnTitle());
                }
            }
        }

        private static void CadastrarSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.WriteLine("Digite o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Faça uma breve descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(),
                                       genero: (Genero) entradaGenero,
                                       title: entradaTitulo,
                                       year: entradaAno,
                                       description: entradaDescricao
                                       );
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int idSerie = int.Parse(Console.ReadLine());
            var list = repository.List();
            
            if(idSerie >= list.Count)
            {
                Console.WriteLine("Este ID não existe.");
                return;
            }

            foreach ( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.WriteLine("Digite o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Faça uma breve descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie updateSerie = new Serie(id: idSerie,
                                       genero: (Genero) entradaGenero,
                                       title: entradaTitulo,
                                       year: entradaAno,
                                       description: entradaDescricao
                                       );
            repository.Update(idSerie, updateSerie );
        }

        private static void ExcluirSerie()
        {   
            Console.WriteLine("Digite o ID da Série: ");
            int idSerie = int.Parse(Console.ReadLine());
            var list = repository.List();
            if(idSerie >= list.Count)
            {
                Console.WriteLine("Este ID não existe.");
                return;
            }
            repository.Exclude(idSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int idSerie = int.Parse(Console.ReadLine());
            var list = repository.List();
            if(idSerie >= list.Count)
            {
                Console.WriteLine("Este ID não existe.");
                return;
            }
            Console.WriteLine(repository.FindByID(idSerie));
        }
        private static string ObterOpcaoUsuario()
        {
            
            Console.WriteLine("------ MENU ------");
            Console.WriteLine("1 - Listar Todas as Séries.");
            Console.WriteLine("2 - Cadastrar Nova Série.");
            Console.WriteLine("3 - Atualizar Informações de uma Série.");
            Console.WriteLine("4 - Excluir uma Série.");
            Console.WriteLine("5 - Visualizar uma Série.");
            Console.WriteLine("0 - Sair.");
            var opcao = Console.ReadLine();
            return opcao;
        }

    }
}

