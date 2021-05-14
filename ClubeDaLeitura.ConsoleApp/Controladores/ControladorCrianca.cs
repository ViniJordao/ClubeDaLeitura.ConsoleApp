using ClubeDaLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorCrianca : ControladorBase
    {
        public string RegistrarCrianca(int id, string nome, string nomeResponsavel,
          int telefone, string ondeEh)
        {
            Crianca crianca = null;

            int posicao;

            if (id == 0)
            {
                crianca = new Crianca();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Crianca(id));
                crianca = (Crianca)registros[posicao];
            }

            crianca.nome = nome;
            crianca.nomeDoResponsavel = nomeDoResponsavel;
            crianca.telefone = telefone;
            crianca.ondeEh = ondeEh;


            string resultadoValidacao = crianca.Validar();

            if (resultadoValidacao == "CAIXA_VALIDO")
                registros[posicao] = crianca;

            return resultadoValidacao;
        }

        public Crianca SelecionarCriancaPorId(int id)
        {
            return (Crianca)SelecionarRegistroPorId(new Crianca(id));
        }

        public bool ExcluirCrianca(int idSelecionado)
        {
            return ExcluirRegistro(new Crianca(idSelecionado));
        }

        public Crianca[] SelecionarTodasCriancas()
        {
            Crianca[] criancaAux = new Crianca[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), criancaAux, criancaAux.Length);

            return criancaAux;
        }
    }

}
