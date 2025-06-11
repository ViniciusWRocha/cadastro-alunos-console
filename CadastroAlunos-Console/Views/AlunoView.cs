using CadastroAlunos_Console.Controller;
using CadastroAlunos_Console.Models;

namespace CadastroAlunos_Console.Views
{
    internal class AlunoView
    {
        private AlunoController controller = new();
        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.WriteLine("=== Cadrasto do Aluno no Senac ===");
                Console.WriteLine("1 - Cadastrar Aluno");
                Console.WriteLine("2 - Listar Aluno");
                Console.WriteLine("3 - Atualizar Aluno");
                Console.WriteLine("4 - Excluir Aluno");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao) 
                {
                    case 1: CadastrarAluno(); break;
                    case 2: ListarAlunos(); break;
                    case 3: AtualizarAluno(); break;
                    case 4: ExcluirAluno(); break;
                }

                Console.WriteLine("\nPressione Enter para continuar...");
                Console.ReadLine();

            } while (opcao != 0);
        }
        private void CadastrarAluno()
        {
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("CPF: ");
            string cpf = Console.ReadLine();
           Console.WriteLine("Curso: ");
            string curso = Console.ReadLine();
            Console.WriteLine("Data de Nascimento: (dd/mm/aaaa)");
            DateTime data = DateTime.Parse(Console.ReadLine());

            controller.CadastrarAluno(nome, cpf, curso, data);
            Console.WriteLine("Aluno cadastrado com sucesso");
        }

        private void ListarAlunos()
        {
            List<Aluno> alunos = controller.ListarAlunos();
            Console.WriteLine("\nLista de alunos:");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"ID: {aluno.Id} \nNome: {aluno.Nome} \nCPF: {aluno.CPF} \nCurso: {aluno.Curso} \nData de nascimento: {aluno.DataNascimento}\n ----------------------------");
            }
        }
        public void AtualizarAluno()
        {
            Console.WriteLine("Digite o Id do aluno a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Novo nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Novo CPF: ");
            string cpf = Console.ReadLine();

            Console.WriteLine("Novo Curso: ");
            string curso = Console.ReadLine();

            Console.WriteLine("Nova data de nascimento:");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            bool atualizado = controller.AtualizarAluno(id, nome, cpf, curso, data);
            Console.WriteLine(atualizado ? "Aluno cadastrado com sucesso" : "Aluno não encotrado");

        }

        public void ExcluirAluno()
        {
            Console.WriteLine("Digite o Id do aluno a ser excluido: ");
            int Id = int.Parse(Console.ReadLine()); 

            bool excluido = controller.ExcluirAluno(Id);
            Console.WriteLine(excluido? "Aluno excluido com sucesso" : "Aluno não excluido");
        }

    }

}
