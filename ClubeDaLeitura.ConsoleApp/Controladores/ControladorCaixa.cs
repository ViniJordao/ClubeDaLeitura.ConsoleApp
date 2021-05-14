using ClubeDaLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorCaixa : ControladorBase
    {
        public string RegistrarCaixa(int id, string cor, int numero,
          string etiqueta)
        {
            Caixa caixa = null;

            int posicao;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Caixa(id));
                caixa = (Caixa)registros[posicao];
            }

          caixa.cor = cor;
            caixa.numero = numero;
          caixa.etiqueta = etiqueta;


            string resultadoValidacao = caixa.Validar();

            if (resultadoValidacao == "CAIXA_VALIDO")
                registros[posicao] = caixa;

            return resultadoValidacao;
        }

        public Caixa SelecionarCaixaPorId(int id)
        {
            return (Caixa)SelecionarRegistroPorId(new Caixa(id));
        }

        public bool ExcluirCaixa(int idSelecionado)
        {
            return ExcluirRegistro(new Caixa(idSelecionado));
        }

        public Caixa[] SelecionarTodasCaixas()
        {
            Caixa[] caixaAux = new Caixa[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), caixaAux, caixaAux.Length);

            return caixaAux;
        }
    }

}
