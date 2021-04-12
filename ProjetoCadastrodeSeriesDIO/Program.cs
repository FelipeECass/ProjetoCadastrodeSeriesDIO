using System;

namespace ProjetoCadastrodeSeriesDIO
{
	class Program
	{
		static SerieRepositorio repositorio = new SerieRepositorio();
		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!\r\n" +
							"Digite o correto para a opção desejada:\r\n" +
							"1 - Listar séries\r\n" +
							"2 - Inserir nova série\r\n" +
							"3 - Atualizar série\r\n" +
							"4 - Excluir série\r\n" +
							"5 - Visualizar série\r\n" +
							"X - Sair");

			string var= Console.ReadLine().ToUpper();
			Console.Clear();
			Console.WriteLine();
			return var;
		}
		static void Main(string[] args)
		{
			string Opcao = ObterOpcaoUsuario();

			while (Opcao.ToUpper() != "X")
			{
				switch (Opcao)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
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
						throw new ArgumentOutOfRangeException();
				}
				Console.Clear();
				Opcao = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.WriteLine("Precione qualquer botão para encerrar.");
			Console.ReadLine();
		}
		private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.Clear();
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
			Console.WriteLine("Precione qualquer botão para prosseguir.");
			Console.ReadKey();
		}

		private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();
			Console.Clear();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();
			Console.Clear();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}
		private static void AtualizarSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();
			Console.Clear();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();
			Console.Clear();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
		private static void ExcluirSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			Console.WriteLine("Série exlcuida com sucesso!");
			Console.WriteLine("Precione qualquer botão para prosseguir.");
			Console.ReadKey();
			repositorio.Exclui(indiceSerie);
		}
		private static void VisualizarSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
			Console.WriteLine("Precione qualquer botão para prosseguir.");
			Console.ReadKey();
		}
	}
}
