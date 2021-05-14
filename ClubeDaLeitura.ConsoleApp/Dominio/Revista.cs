using System;
using System.Collections.Generic;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Revista
    {
       public int id; 
       public string TipoColecao;
       public int numeroEdicao;
       public double anoDaRevista;
       public string CaixaOndeEsta;

        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }

        public Revista(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";
            return resultadoValidacao;
        }
    }
}
