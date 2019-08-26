using ProjetoFinal.Modelo;
using ProjetoFinal.Servico;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();
            int opcaoMenuPrincipal = -1;
            while (opcaoMenuPrincipal != 0)
            {
                Console.WriteLine("Menu principal");
                Console.WriteLine("1 - Menu de Aluno");
                Console.WriteLine("2 - Menu de Professor");
                Console.WriteLine("3 - Menu de Curso");
                Console.WriteLine("4 - Gravar todos os dados em um arquivo txt");
                Console.Write("Insira o numero da opção desejada: ");
                opcaoMenuPrincipal = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();//Um espaço entre um menu e outro
                switch (opcaoMenuPrincipal)
                {
                    case 1:
                        int opcaoMenuAluno = -1;
                        while (opcaoMenuAluno != 0)
                        {
                            Console.WriteLine("SubMenu Aluno");
                            Console.WriteLine("1 - Cadastrar Aluno");
                            Console.WriteLine("2 - Listar Alunos");
                            Console.WriteLine("3 - Pesquisar Aluno");
                            Console.WriteLine("4 - Excluir Aluno");
                            Console.WriteLine("5 - Alterar Aluno");
                            Console.WriteLine("0 - Voltar ao menu principal");
                            Console.Write("Insira o numero da opção desejada: ");
                            opcaoMenuAluno = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            var aluno = new Aluno();
                            var alunoNegocio = new AlunoNegocio();
                            switch (opcaoMenuAluno)
                            {
                                case 1:
                                    var alunoCodigo = alunoNegocio.Listar().OrderBy(r => r.Codigo).LastOrDefault();
                                    if (alunoCodigo != null)
                                    {
                                        aluno.Codigo = alunoCodigo.Codigo + 1;
                                    }
                                    else
                                    {
                                        aluno.Codigo = 1;
                                    }
                                    Console.Write("Digite o nome: ");
                                    aluno.Nome = Console.ReadLine();
                                    Console.Write("Digite a idade: ");
                                    aluno.Idade = Console.ReadLine();
                                    Console.Write("Digite o RG: ");
                                    aluno.RG = Console.ReadLine();
                                    Console.Write("Digite o celular: ");
                                    aluno.Celular = Console.ReadLine();
                                    Console.Write("Digite o e-mail: ");
                                    aluno.Email = Console.ReadLine();
                                    Console.Write("Digite o codigo do curso, ou aperte enter para continuar: ");
                                    var cod = Console.ReadLine();
                                    if (string.IsNullOrEmpty(cod))
                                    {
                                        aluno.CodigoCurso = 0;
                                    }
                                    else
                                    {
                                        aluno.CodigoCurso = Convert.ToInt32(cod);
                                    }
                                    alunoNegocio.Incluir(aluno);
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    foreach (var item in alunoNegocio.Listar())
                                    {
                                        Console.WriteLine($"Código: {item.Codigo}");
                                        Console.WriteLine($"Nome: {item.Nome}");
                                        Console.WriteLine($"Idade: {item.Idade}");
                                        Console.WriteLine($"RG: {item.RG}");
                                        Console.WriteLine($"Celular: {item.Celular}");
                                        Console.WriteLine($"E-mail: {item.Email}");
                                        Console.WriteLine();
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("1 - Pesquisa pelo nome");
                                    Console.WriteLine("2 - Pesquisa pelo código");
                                    Console.Write("Insira o numero da opção desejada: ");
                                    var opPesquisaAluno = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (opPesquisaAluno == 1)
                                    {
                                        Console.Write("Digite o nome do aluno: ");
                                        var nome = Console.ReadLine();
                                        aluno = alunoNegocio.Listar().FirstOrDefault(r => r.Nome == nome);
                                    }
                                    else if (opPesquisaAluno == 2)
                                    {
                                        Console.WriteLine("Digite o código do aluno");
                                        var codigoAluno = Convert.ToInt32(Console.ReadLine());
                                        aluno = alunoNegocio.Selecionar(codigoAluno);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opção invalida");
                                    }
                                    if (aluno != null)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Código: {aluno.Codigo}");
                                        Console.WriteLine($"Nome: {aluno.Nome}");
                                        Console.WriteLine($"Idade: {aluno.Idade}");
                                        Console.WriteLine($"RG: {aluno.RG}");
                                        Console.WriteLine($"Celular: {aluno.Celular}");
                                        Console.WriteLine($"E-mail: {aluno.Email}");
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    Console.Write("Para excluir um aluno, digite o código dele: ");
                                    var codExcluirAluno = Convert.ToInt32(Console.ReadLine());
                                    aluno = alunoNegocio.Selecionar(codExcluirAluno);
                                    Console.WriteLine();
                                    if (aluno == null)
                                    {
                                        Console.WriteLine("Aluno não encontrado");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Código: {aluno.Codigo}");
                                        Console.WriteLine($"Nome: {aluno.Nome}");
                                        Console.WriteLine($"Idade: {aluno.Idade}");
                                        Console.WriteLine($"RG: {aluno.RG}");
                                        Console.WriteLine($"Celular: {aluno.Celular}");
                                        Console.WriteLine($"E-mail: {aluno.Email}");
                                        Console.Write("Digite confirmar para excluir: ");
                                        var desejaExcluirAluno = Console.ReadLine();
                                        if (desejaExcluirAluno.ToLower() == "confirmar")
                                        {
                                            alunoNegocio.Deletar(aluno);
                                            Console.WriteLine("Aluno excluido");
                                        }
                                    }
                                    Console.WriteLine();
                                    break;
                                case 5:
                                    Console.Write("Para alterar os dados de um aluno, digite o código dele: ");
                                    var codAlterarAluno = Convert.ToInt32(Console.ReadLine());
                                    aluno = alunoNegocio.Selecionar(codAlterarAluno);
                                    Console.WriteLine();
                                    if (aluno == null)
                                    {
                                        Console.WriteLine("Aluno não encontrado");
                                    }
                                    else
                                    {
                                        Console.Write("Digite o nome: ");
                                        aluno.Nome = Console.ReadLine();
                                        Console.Write("Digite a idade: ");
                                        aluno.Idade = Console.ReadLine();
                                        Console.Write("Digite o RG: ");
                                        aluno.RG = Console.ReadLine();
                                        Console.Write("Digite o celular: ");
                                        aluno.Celular = Console.ReadLine();
                                        Console.Write("Digite o e-mail: ");
                                        aluno.Email = Console.ReadLine();
                                        Console.Write("Digite o codigo do curso, ou aperte enter para continuar: ");
                                        alunoNegocio.Atualizar(aluno, aluno.Codigo);
                                    }
                                    Console.WriteLine();
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 2:
                        int opcaoMenuProfessor = -1;
                        while (opcaoMenuProfessor != 0)
                        {
                            Console.WriteLine("SubMenu Professor");
                            Console.WriteLine("1 - Cadastrar Professor");
                            Console.WriteLine("2 - Listar Professores");
                            Console.WriteLine("3 - Pesquisar Professor");
                            Console.WriteLine("3 - Excluir Professor");
                            Console.WriteLine("4 - Alterar Professor");
                            Console.WriteLine("0 - Voltar ao menu principal");
                            Console.Write("Insira o numero da opção desejada: ");
                            opcaoMenuProfessor = Convert.ToInt32(Console.ReadLine());
                            var professor = new Professor();
                            var professorNegocio = new ProfessorNegocio();
                            Console.WriteLine();
                            switch (opcaoMenuProfessor)
                            {
                                case 1:
                                    var professorCodigo = professorNegocio.Listar().OrderBy(r => r.Codigo).LastOrDefault();
                                    if (professorCodigo != null)
                                    {
                                        professor.Codigo = professorCodigo.Codigo + 1;
                                    }
                                    else
                                    {
                                        professor.Codigo = 1;
                                    }
                                    Console.Write("Digite o nome: ");
                                    professor.Nome = Console.ReadLine();
                                    Console.Write("Digite a idade: ");
                                    professor.Idade = Console.ReadLine();
                                    Console.Write("Digite o RG: ");
                                    professor.RG = Console.ReadLine();
                                    Console.Write("Digite o celular: ");
                                    professor.Celular = Console.ReadLine();
                                    Console.Write("Digite o e-mail: ");
                                    professor.Email = Console.ReadLine();
                                    Console.Write("Digite o codigo do curso, ou aperte enter para continuar: ");
                                    var cod = Console.ReadLine();
                                    if (string.IsNullOrEmpty(cod))
                                    {
                                        professor.CodigoCurso = 0;
                                    }
                                    else
                                    {
                                        professor.CodigoCurso = Convert.ToInt32(cod);
                                    }
                                    professorNegocio.Incluir(professor);
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    foreach (var item in professorNegocio.Listar())
                                    {
                                        Console.WriteLine($"Código: {item.Codigo}");
                                        Console.WriteLine($"Nome: {item.Nome}");
                                        Console.WriteLine($"Idade: {item.Idade}");
                                        Console.WriteLine($"RG: {item.RG}");
                                        Console.WriteLine($"Celular: {item.Celular}");
                                        Console.WriteLine($"E-mail: {item.Email}");
                                        Console.WriteLine();
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("1 - Pesquisa pelo nome");
                                    Console.WriteLine("2 - Pesquisa pelo código");
                                    Console.Write("Insira o numero da opção desejada: ");
                                    var opPesquisaAluno = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (opPesquisaAluno == 1)
                                    {
                                        Console.Write("Digite o nome do professor: ");
                                        var nome = Console.ReadLine();
                                        professor = professorNegocio.Listar().FirstOrDefault(r => r.Nome == nome);
                                    }
                                    else if (opPesquisaAluno == 2)
                                    {
                                        Console.WriteLine("Digite o código do professor");
                                        var codigoAluno = Convert.ToInt32(Console.ReadLine());
                                        professor = professorNegocio.Selecionar(codigoAluno);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opção invalida");
                                    }
                                    if (professor != null)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Código: {professor.Codigo}");
                                        Console.WriteLine($"Nome: {professor.Nome}");
                                        Console.WriteLine($"Idade: {professor.Idade}");
                                        Console.WriteLine($"RG: {professor.RG}");
                                        Console.WriteLine($"Celular: {professor.Celular}");
                                        Console.WriteLine($"E-mail: {professor.Email}");
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    Console.Write("Para excluir um professor, digite o código dele: ");
                                    var codExcluirAluno = Convert.ToInt32(Console.ReadLine());
                                    professor = professorNegocio.Selecionar(codExcluirAluno);
                                    Console.WriteLine();
                                    if (professor == null)
                                    {
                                        Console.WriteLine("Professor não encontrado");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Código: {professor.Codigo}");
                                        Console.WriteLine($"Nome: {professor.Nome}");
                                        Console.WriteLine($"Idade: {professor.Idade}");
                                        Console.WriteLine($"RG: {professor.RG}");
                                        Console.WriteLine($"Celular: {professor.Celular}");
                                        Console.WriteLine($"E-mail: {professor.Email}");
                                        Console.Write("Digite confirmar para excluir: ");
                                        var desejaExcluirAluno = Console.ReadLine();
                                        if (desejaExcluirAluno.ToLower() == "confirmar")
                                        {
                                            professorNegocio.Deletar(professor);
                                            Console.WriteLine("Professor excluido");
                                        }
                                    }
                                    Console.WriteLine();
                                    break;
                                case 5:
                                    Console.Write("Para alterar os dados de um professor, digite o código dele: ");
                                    var codAlterarAluno = Convert.ToInt32(Console.ReadLine());
                                    professor = professorNegocio.Selecionar(codAlterarAluno);
                                    Console.WriteLine();
                                    if (professor == null)
                                    {
                                        Console.WriteLine("Professor não encontrado");
                                    }
                                    else
                                    {
                                        Console.Write("Digite o nome: ");
                                        professor.Nome = Console.ReadLine();
                                        Console.Write("Digite a idade: ");
                                        professor.Idade = Console.ReadLine();
                                        Console.Write("Digite o RG: ");
                                        professor.RG = Console.ReadLine();
                                        Console.Write("Digite o celular: ");
                                        professor.Celular = Console.ReadLine();
                                        Console.Write("Digite o e-mail: ");
                                        professor.Email = Console.ReadLine();
                                        Console.Write("Digite o codigo do curso, ou aperte enter para continuar: ");
                                        professorNegocio.Atualizar(professor, professor.Codigo);
                                    }
                                    Console.WriteLine();
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 3:
                        int opcaoMenuCurso = -1;
                        while (opcaoMenuCurso != 0)
                        {
                            Console.WriteLine("SubMenu Curso");
                            Console.WriteLine("1 - Cadastrar Curso");
                            Console.WriteLine("2 - Listar Cursos");
                            Console.WriteLine("3 - Pesquisar Curso");
                            Console.WriteLine("4 - Excluir Curso");
                            Console.WriteLine("5 - Professor que ministra");
                            Console.WriteLine("6 - Lista de alunos");
                            Console.WriteLine("7 - Alterar Curso");
                            Console.WriteLine("0 - Voltar ao menu principal");
                            Console.Write("Insira o numero da opção desejada: ");
                            opcaoMenuCurso = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            var curso = new Curso();
                            var cursoNegocio = new CursoNegocio();
                            var professor = new Professor();
                            var professorNegocio = new ProfessorNegocio();
                            var aluno = new AlunoNegocio();
                            var alunoNegocio = new AlunoNegocio();
                            switch (opcaoMenuCurso)
                            {
                                case 1:
                                    var cursoCodigo = cursoNegocio.Listar().OrderBy(r => r.Codigo).LastOrDefault();
                                    if (cursoCodigo != null)
                                    {
                                        curso.Codigo = cursoCodigo.Codigo + 1;
                                    }
                                    else
                                    {
                                        curso.Codigo = 1;
                                    }
                                    Console.Write("Digite o nome: ");
                                    curso.Nome = Console.ReadLine();
                                    Console.Write("Digite o codigo do professor, ou aperte enter para continuar: ");
                                    var cod = Console.ReadLine();
                                    if (string.IsNullOrEmpty(cod))
                                    {
                                        curso.CodigoProfessor = 0;
                                    }
                                    else
                                    {
                                        curso.CodigoProfessor = Convert.ToInt32(cod);
                                    }
                                    cursoNegocio.Incluir(curso);
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    foreach (var item in cursoNegocio.Listar())
                                    {
                                        Console.WriteLine($"Código: {item.Codigo}");
                                        Console.WriteLine($"Nome: {item.Nome}");
                                        Console.WriteLine();
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("1 - Pesquisa pelo nome");
                                    Console.WriteLine("2 - Pesquisa pelo código");
                                    Console.Write("Insira o numero da opção desejada: ");
                                    var opPesquisaAluno = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (opPesquisaAluno == 1)
                                    {
                                        Console.Write("Digite o nome do curso: ");
                                        var nome = Console.ReadLine();
                                        curso = cursoNegocio.Listar().FirstOrDefault(r => r.Nome == nome);
                                    }
                                    else if (opPesquisaAluno == 2)
                                    {
                                        Console.WriteLine("Digite o código do curso");
                                        var codigoAluno = Convert.ToInt32(Console.ReadLine());
                                        curso = cursoNegocio.Selecionar(codigoAluno);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opção invalida");
                                    }
                                    if (curso != null)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Código: {curso.Codigo}");
                                        Console.WriteLine($"Nome: {curso.Nome}");
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    Console.Write("Para excluir um curso, digite o código dele: ");
                                    var codExcluirCurso = Convert.ToInt32(Console.ReadLine());
                                    curso = cursoNegocio.Selecionar(codExcluirCurso);
                                    Console.WriteLine();
                                    if (curso == null)
                                    {
                                        Console.WriteLine("Curso não encontrado");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Código: {curso.Codigo}");
                                        Console.WriteLine($"Nome: {curso.Nome}");
                                        Console.Write("Digite confirmar para excluir: ");
                                        var desejaExcluirCurso = Console.ReadLine();
                                        if (desejaExcluirCurso.ToLower() == "confirmar")
                                        {
                                            cursoNegocio.Deletar(curso);
                                            Console.WriteLine("Curso excluido");
                                        }
                                    }
                                    Console.WriteLine();
                                    break;
                                case 5:
                                    Console.Write("Para saber o nome do professor, digite o código do curso: ");
                                    var codCursoPesquisarProfessor = Convert.ToInt32(Console.ReadLine());
                                    curso = cursoNegocio.Selecionar(codCursoPesquisarProfessor);
                                    Console.WriteLine();
                                    if (curso == null)
                                    {
                                        Console.WriteLine("Curso não encontrado");
                                    }
                                    else
                                    {
                                        if (curso.CodigoProfessor != 0)
                                        {
                                            professor = professorNegocio.Selecionar(curso.CodigoProfessor);
                                            if (professor != null)
                                            {
                                                Console.WriteLine($"Código: {professor.Codigo}");
                                                Console.WriteLine($"Professor: {professor.Nome}");
                                                Console.WriteLine($"Celular: {professor.Celular}");
                                                Console.WriteLine($"E-mail: {professor.Email}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Esse curso ainda não tem vinculo como professor");
                                        }

                                    }
                                    Console.WriteLine();
                                    break;
                                case 6:
                                    Console.Write("Para listar os alunos, digite o código do curso: ");
                                    var codCursoAlunos = Convert.ToInt32(Console.ReadLine());
                                    curso = cursoNegocio.Selecionar(codCursoAlunos);
                                    Console.WriteLine();
                                    if (curso == null)
                                    {
                                        Console.WriteLine("Curso não encontrado");
                                    }
                                    else
                                    {
                                        var alunos = alunoNegocio.Listar().Where(r => r.CodigoCurso == codCursoAlunos);
                                        if (alunos.Count() > 0)
                                        {
                                            foreach (var item in alunos)
                                            {
                                                Console.WriteLine($"Código: {item.Codigo}");
                                                Console.WriteLine($"Nome: {item.Nome}");
                                                Console.WriteLine($"E-mail: {item.Email}");
                                                Console.WriteLine($"Celular: {item.Celular}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Esse curso não tem alunos cadastrados");
                                        }

                                    }
                                    Console.WriteLine();
                                    break;
                                case 7:
                                    Console.Write("Para alterar os dados de um curso, digite o código dele: ");
                                    var codAlterarCurso = Convert.ToInt32(Console.ReadLine());
                                    curso = cursoNegocio.Selecionar(codAlterarCurso);
                                    Console.WriteLine();
                                    if (curso == null)
                                    {
                                        Console.WriteLine("Curso não encontrado");
                                    }
                                    else
                                    {
                                        Console.Write("Digite o nome: ");
                                        curso.Nome = Console.ReadLine();
                                        Console.Write("Digite o codigo do professor, ou aperte enter para continuar: ");
                                        curso.CodigoProfessor = Convert.ToInt32(Console.ReadLine());
                                        cursoNegocio.Atualizar(curso, curso.Codigo);
                                    }
                                    Console.WriteLine();
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 4:
                        AlunoNegocio alunoNegocioWrite = new AlunoNegocio();
                        ProfessorNegocio professorNegocioWrite = new ProfessorNegocio();
                        CursoNegocio cursoNegocioWrite = new CursoNegocio();
                        StreamWriter writer = new StreamWriter(@"C:\Users\Usuario\source\repos\ProjetoFinalSolution\Arquivo.txt");
                        writer.WriteLine("Cursos");
                        writer.WriteLine("-----------------------------------------------------------------");
                        foreach (var item in cursoNegocioWrite.Listar())
                        {
                            writer.WriteLine($"Código: {item.Codigo}");
                            writer.WriteLine($"Nome: {item.Nome}");
                            if (item.CodigoProfessor != 0)
                            {
                                writer.WriteLine($"Professor: {professorNegocioWrite.Selecionar(item.CodigoProfessor).Nome}");
                            }
                            writer.WriteLine();
                        }
                        writer.WriteLine();
                        writer.WriteLine("Professores");
                        writer.WriteLine("-----------------------------------------------------------------");
                        foreach (var item in professorNegocioWrite.Listar())
                        {
                            writer.WriteLine($"Código: {item.Codigo}");
                            writer.WriteLine($"Nome: {item.Nome}");
                            writer.WriteLine($"Idade: {item.Idade}");
                            writer.WriteLine($"RG: {item.RG}");
                            writer.WriteLine($"Celular: {item.Celular}");
                            writer.WriteLine($"E-mail: {item.Email}");
                            writer.WriteLine();
                        }
                        writer.WriteLine();
                        writer.WriteLine("Alunos");
                        writer.WriteLine("-----------------------------------------------------------------");
                        foreach (var item in alunoNegocioWrite.Listar())
                        {
                            writer.WriteLine($"Código: {item.Codigo}");
                            writer.WriteLine($"Nome: {item.Nome}");
                            writer.WriteLine($"Idade: {item.Idade}");
                            writer.WriteLine($"RG: {item.RG}");
                            writer.WriteLine($"Celular: {item.Celular}");
                            writer.WriteLine($"E-mail: {item.Email}");
                            writer.WriteLine();
                        }
                        writer.Close();
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("O programa vai ser finalizado");
            Console.ReadKey();

        }
        public static void Setup()
        {
            CursoNegocio cn = new CursoNegocio();

            ProfessorNegocio pn = new ProfessorNegocio();

            AlunoNegocio an = new AlunoNegocio();
            Curso c = new Curso
            {
                Codigo = 1,
                Nome = "Curso C#"
            };
            cn.Incluir(c);
            Curso c2 = new Curso
            {
                Codigo = 2,
                Nome = "Curso Java"
            };
            cn.Incluir(c2);
            Professor p = new Professor
            {
                Codigo = 1,
                Nome = "José Aguiar",
                Idade = "50",
                RG = "25.420.401-6",
                Celular = "(21) 99567-5430",
                Email = "aguiar@gmail.com",
                CodigoCurso = 1
            };
            pn.Incluir(p);
            Professor p2 = new Professor
            {
                Codigo = 2,
                Nome = "Maria Rita",
                Idade = "55",
                RG = "29.404.069-9",
                Celular = "(51) 98236-3061",
                Email = "rita@hotmail.com",
                CodigoCurso = 2
            };
            pn.Incluir(p2);
            Aluno a = new Aluno
            {
                Codigo = 1,
                Nome = "Maria Helena Moraes",
                Idade = "18",
                RG = "27.732.520-1",
                Celular = "(92) 98149-3651",
                Email = "mari@hotmail.com",
                CodigoCurso = 1
            };
            Aluno a1 = new Aluno
            {
                Nome = "Marcela Isabelly Porto",
                Idade = "22",
                RG = "30.433.372-4",
                Celular = "(61) 99126-1470",
                Email = "isa@yahoo.com",
                CodigoCurso = 2
            };
            Aluno a2 = new Aluno
            {
                Nome = "Luís Henrique Moreira",
                Idade = "25",
                RG = "26.907.081-3",
                Celular = "(51) 98405-2343",
                Email = "henrique@gmail.com",
                CodigoCurso = 1
            };
            Aluno a3 = new Aluno
            {
                Nome = "Anderson João Barros",
                Idade = "23",
                RG = "17.746.170-6",
                Celular = "(92) 98334-1784",
                Email = "andersonjoa@hotmail.com.br",
                CodigoCurso = 1
            };
            an.Incluir(a);
            an.Incluir(a1);
            an.Incluir(a2);
            an.Incluir(a3);
        }
    }
}
