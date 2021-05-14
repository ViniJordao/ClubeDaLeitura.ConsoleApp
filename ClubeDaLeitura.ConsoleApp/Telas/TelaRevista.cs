using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Controladores;
using System.Collections.Generic;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaRevista : TelaBase
    {
        private ControladorRevista controladorRevista;
        public TelaRevista(ControladorRevista controlador)
            : base("Cadastro de Revista")
        {
            controladorRevista = controlador;
        }

        public override void CadastraRegistro()
        {
            ConfigurarTela("Inserindo um novo revista...");

            bool gravou = GravarRevista(0);

            if (gravou)
                ApresentarMensagem("Revista inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir o revista", TipoMensagem.Erro);
                CadastraRegistro();
            }
        }
        public override string ObterOpcao()
        {
        
            Console.Clear();
            Console.WriteLine("Digite 1 para inserir uma revista");
            Console.WriteLine("Digite 2 para visualizar as revistas");
            Console.WriteLine("Digite 3 para editar uma revista");
            Console.WriteLine("Digite 4 para excluir uma revista");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public override void EditarRegistro()
        {
            ConfigurarTela("Editando um revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do revista que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool gravou = GravarRevista(id);

            if (gravou)
                ApresentarMensagem("Revista editada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar o revista", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public override void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo uma revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da revista que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool excluiu = controladorRevista.ExcluirRevista(idSelecionado);

            if (excluiu)
                ApresentarMensagem("Revista excluída com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir a revista", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando revista...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35} | {3,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Revista[] revista = controladorRevista.SelecionarTodasRevistas();

            if (revista.Length == 0)
            {
                ApresentarMensagem("Nenhuma revista cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < revista.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   revista[i].id, revista[i].TipoColecao, revista[i].numeroEdicao, revista[i].anoDaRevista, revista[i].CaixaOndeEsta);
            }
        }

        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Tipo Coleção", "Nuemero Edição", "Ano da Revista","Caixa onde está");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarRevista(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o tipo da coleção: ");
            string TipoColecao = Console.ReadLine();

            Console.Write("Digite o ano do revista: ");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ano da revista: ");
            double anoDaRevista = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite a caixa onde está: ");
            string CaixaOndeEsta = Console.ReadLine();

            resultadoValidacao = controladorRevista.RegistrarRevista(
                id, TipoColecao, numeroEdicao, anoDaRevista, CaixaOndeEsta);

            if (resultadoValidacao != "REVISTA_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }



        #endregion
    }
}
