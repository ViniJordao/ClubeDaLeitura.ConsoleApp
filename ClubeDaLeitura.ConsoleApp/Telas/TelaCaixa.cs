using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Controladores;
using System.Collections.Generic;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaCaixa : TelaBase
    {
        private ControladorCaixa controladorCaixa;
        public TelaCaixa(ControladorCaixa controlador)
            : base("Cadastro de Caixa")
        {
            controladorCaixa = controlador;
        }

        public override void CadastraRegistro()
        {
            ConfigurarTela("Inserindo um nova caixa...");

            bool gravou = GravarCaixa(0);

            if (gravou)
                ApresentarMensagem("Caixa inserida com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir a caixa", TipoMensagem.Erro);
                CadastraRegistro();
            }
        }

        public override void EditarRegistro()
        {
            ConfigurarTela("Editando um caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool gravou = GravarCaixa(id);

            if (gravou)
                ApresentarMensagem("Caixa editada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar a Caixa", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public override void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo uma Caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da Caixa que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool excluiu = controladorCaixa.ExcluirCaixa(idSelecionado);

            if (excluiu)
                ApresentarMensagem("Caixa excluída com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir a Caixa", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando Caixa...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Caixa[] caixa = controladorCaixa.SelecionarTodasCaixas();

            if (caixa.Length == 0)
            {
                ApresentarMensagem("Nenhuma Caixa cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < caixa.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   caixa[i].id, caixa[i].cor, caixa[i].numero, caixa[i].etiqueta);
            }
        }

        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Cor", "Numero", "Etiqueta");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarCaixa(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Digite o numero da caixa: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a etiqueta : ");
            string etiqueta = Console.ReadLine();

            resultadoValidacao = controladorCaixa.RegistrarCaixa(
                id, cor, numero, etiqueta);

            if (resultadoValidacao != "CAIXA_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }



        #endregion
    }
}
