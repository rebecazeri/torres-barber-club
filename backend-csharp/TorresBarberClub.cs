// ============================================
// PROJETO ACADÊMICO: TORRES BARBER CLUB
// Disciplina: Programação Orientada a Objetos (PIM)
// ============================================

using System;
using System.Collections.Generic;

namespace TorresBarberClub
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public Pessoa(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }

        public virtual void ExibirPerfil()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Telefone: {Telefone}");
        }
    }

    public class Cliente : Pessoa
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Agendamento> Agendamentos { get; private set; }

        public Cliente(string nome, string telefone, string email, string senha)
            : base(nome, telefone)
        {
            Email = email;
            Senha = senha;
            Agendamentos = new List<Agendamento>();
        }

        public override void ExibirPerfil()
        {
            Console.WriteLine("\n===== PERFIL DO CLIENTE =====");
            base.ExibirPerfil();
            Console.WriteLine($"Email: {Email}");
        }

        public void AdicionarAgendamento(Agendamento agendamento)
        {
            Agendamentos.Add(agendamento);
        }

        public void ExibirHistorico()
        {
            Console.WriteLine($"\n===== HISTÓRICO DE {Nome.ToUpper()} =====");
            if (Agendamentos.Count == 0)
            {
                Console.WriteLine("Nenhum agendamento realizado.");
            }
            else
            {
                foreach (var agenda in Agendamentos)
                {
                    agenda.ExibirResumo();
                }
            }
        }
    }

    public class Barbeiro : Pessoa
    {
        public string Especialidade { get; set; }
        public List<Agendamento> Agendamentos { get; private set; }

        public Barbeiro(string nome, string telefone, string especialidade)
            : base(nome, telefone)
        {
            Especialidade = especialidade;
            Agendamentos = new List<Agendamento>();
        }

        public override void ExibirPerfil()
        {
            Console.WriteLine("\n===== PERFIL DO BARBEIRO =====");
            base.ExibirPerfil();
            Console.WriteLine($"Especialidade: {Especialidade}");
        }

        public void AdicionarAgendamento(Agendamento agendamento)
        {
            Agendamentos.Add(agendamento);
        }

        public void ExibirAgenda()
        {
            Console.WriteLine($"\n===== AGENDA DE {Nome.ToUpper()} =====");
            if (Agendamentos.Count == 0)
            {
                Console.WriteLine("Nenhum agendamento na agenda.");
            }
            else
            {
                foreach (var agenda in Agendamentos)
                {
                    agenda.ExibirResumo();
                }
            }
        }
    }

    public class Servico
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int DuracaoMinutos { get; set; }

        public Servico(string nome, string descricao, decimal valor, int duracaoMinutos)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            DuracaoMinutos = duracaoMinutos;
        }

        public void ExibirServico()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Descrição: {Descricao}");
            Console.WriteLine($"Valor: R$ {Valor:F2}");
            Console.WriteLine($"Duração: {DuracaoMinutos} minutos");
        }
    }

    public class Pagamento
    {
        public string FormaPagamento { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; private set; }

        public Pagamento(string formaPagamento, decimal valor)
        {
            FormaPagamento = formaPagamento;
            Valor = valor;
            Status = "Pendente";
        }

        public void ConfirmarPagamento()
        {
            Status = "Confirmado";
            Console.WriteLine("Pagamento confirmado com sucesso!");
        }

        public void CancelarPagamento()
        {
            Status = "Cancelado";
            Console.WriteLine("Pagamento cancelado.");
        }

        public void ExibirPagamento()
        {
            Console.WriteLine($"\nForma de Pagamento: {FormaPagamento}");
            Console.WriteLine($"Valor: R$ {Valor:F2}");
            Console.WriteLine($"Status: {Status}");
        }
    }

    public class Avaliacao
    {
        public int Nota { get; set; }
        public string Comentario { get; set; }

        public Avaliacao(int nota, string comentario)
        {
            Nota = nota;
            Comentario = comentario;
        }

        public void ExibirAvaliacao()
        {
            Console.WriteLine($"\nNota: {Nota}/5");
            Console.WriteLine($"Comentário: {Comentario}");
        }
    }

    public class Agendamento
    {
        public Cliente Cliente { get; set; }
        public Barbeiro Barbeiro { get; set; }
        public Servico Servico { get; set; }
        public DateTime Data { get; set; }
        public string Horario { get; set; }
        public string Status { get; private set; }
        public Pagamento? Pagamento { get; set; }
        public Avaliacao? Avaliacao { get; set; }

        public Agendamento(Cliente cliente, Barbeiro barbeiro, Servico servico, DateTime data, string horario)
        {
            Cliente = cliente;
            Barbeiro = barbeiro;
            Servico = servico;
            Data = data;
            Horario = horario;
            Status = "Pendente";
        }

        public void Confirmar()
        {
            Status = "Confirmado";
        }

        public void Cancelar()
        {
            Status = "Cancelado";
        }

        public void Concluir()
        {
            Status = "Concluído";
        }

        public void RegistrarPagamento(Pagamento pagamento)
        {
            Pagamento = pagamento;
        }

        public void RegistrarAvaliacao(Avaliacao avaliacao)
        {
            Avaliacao = avaliacao;
        }

        public void ExibirResumo()
        {
            Console.WriteLine($"\n--- Resumo do Agendamento ---");
            Console.WriteLine($"Cliente: {Cliente.Nome}");
            Console.WriteLine($"Barbeiro: {Barbeiro.Nome}");
            Console.WriteLine($"Serviço: {Servico.Nome}");
            Console.WriteLine($"Data: {Data:dd/MM/yyyy}");
            Console.WriteLine($"Horário: {Horario}");
            Console.WriteLine($"Status: {Status}");
            if (Pagamento != null)
                Console.WriteLine($"Pagamento: {Pagamento.FormaPagamento} - R$ {Pagamento.Valor:F2}");
            if (Avaliacao != null)
                Console.WriteLine($"Avaliação: {Avaliacao.Nota}/5 - {Avaliacao.Comentario}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Cliente("Pedro Pereira", "11 99999-9999", "pedro@email.com", "123456");
            var barbeiro = new Barbeiro("Gabriel Silva", "11 98888-8888", "Corte e Barba");
            var servico = new Servico("Combo", "Corte, barba e sobrancelha", 50.00m, 60);
            var agendamento = new Agendamento(cliente, barbeiro, servico, new DateTime(2026, 7, 19), "13:30");

            cliente.AdicionarAgendamento(agendamento);
            barbeiro.AdicionarAgendamento(agendamento);

            agendamento.Confirmar();

            var pagamento = new Pagamento("PIX", 50.00m);
            pagamento.ConfirmarPagamento();
            agendamento.RegistrarPagamento(pagamento);

            agendamento.Concluir();

            var avaliacao = new Avaliacao(5, "Atendimento excelente.");
            agendamento.RegistrarAvaliacao(avaliacao);

            Console.WriteLine("=== Perfil do Cliente ===");
            cliente.ExibirPerfil();

            Console.WriteLine("\n=== Perfil do Barbeiro ===");
            barbeiro.ExibirPerfil();

            Console.WriteLine("\n=== Serviço ===");
            servico.ExibirServico();

            Console.WriteLine("\n=== Resumo do Agendamento ===");
            agendamento.ExibirResumo();

            Console.WriteLine("\n=== Histórico do Cliente ===");
            cliente.ExibirHistorico();

            Console.WriteLine("\n=== Agenda do Barbeiro ===");
            barbeiro.ExibirAgenda();
        }
    }
}