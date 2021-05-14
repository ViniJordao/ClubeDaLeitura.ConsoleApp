using System;
using System.Collections.Generic;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Crianca
    {
        public int id;
        public string nome;
        public string nomeDoResponsavel;
        public int telefone;
        public string ondeEh;

        public Crianca(int idSelecionado)
        {
            id = idSelecionado;
        }
        public Crianca()
        {
            id = GeradorId.GerarIdRevista();
        }
        public string Validar()
        {
            string resultadoValidacao = "";
            return resultadoValidacao;
        }
    }
    
    
}
