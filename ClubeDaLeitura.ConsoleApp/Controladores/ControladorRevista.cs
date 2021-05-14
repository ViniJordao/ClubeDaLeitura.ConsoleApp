using ClubeDaLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorRevista : ControladorBase
    {
        public string RegistrarRevista(int id, string TipoColecao, int numeroEdicao,
           double anoDaRevista, string CaixaOndeEsta)
        {
            Revista revista = null;

            int posicao;

            if (id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Revista(id));
                revista = (Revista)registros[posicao];
            }

           revista.TipoColecao = TipoColecao;
           revista.numeroEdicao = numeroEdicao;
           revista.anoDaRevista = anoDaRevista;
           revista.CaixaOndeEsta = CaixaOndeEsta;


            string resultadoValidacao = revista.Validar();

            if (resultadoValidacao == "REVISTA_VALIDO")
                registros[posicao] = revista;

            return resultadoValidacao;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistroPorId(new Revista(id));
        }

        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }

        public Revista[] SelecionarTodasRevistas()
        {
           Revista[] revistaAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistaAux, revistaAux.Length);

            return revistaAux;
        }
    }

}
