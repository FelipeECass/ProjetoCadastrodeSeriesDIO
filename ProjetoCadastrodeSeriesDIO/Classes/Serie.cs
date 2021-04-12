using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastrodeSeriesDIO
{
    class Serie : EntidadeBase
    {
		private Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
		private bool Excluido { get; set; }
		public Serie(int id, Genero genero, string titulo, string descricao, int ano)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
			this.Excluido = false;
		}

		public override string ToString()
		{
			string Exc = "";
			if (this.Excluido == true)
			{
				Exc = "Sim";
			}
			else
            {
				Exc = "Não";
            }
			string retorno = "Gênero: " + this.Genero + Environment.NewLine +
				"Titulo: " + this.Titulo + Environment.NewLine +
				"Descrição: " + this.Descricao + Environment.NewLine +
				"Ano de Início: " + this.Ano + Environment.NewLine +
				"Excluido: " + Exc;   
			return retorno;
		}

		public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
		public bool retornaExcluido()
		{
			return this.Excluido;
		}
		public void Excluir()
		{
			this.Excluido = true;
		}
	}
}
