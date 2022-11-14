using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;
bool exibirMenu = true;

List <Pessoa> hospedes = new List<Pessoa>();
Suite suite = new Suite();
Reserva reserva = new Reserva();

while (exibirMenu) {
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar hóspede");
    Console.WriteLine("2 - Cadastrar suíte");
    Console.WriteLine("3 - Criar uma reserva");
    Console.WriteLine("4 - Obter quantidade de hóspedes");
    Console.WriteLine("5 - Calcular valor da diária");
    Console.WriteLine("6 - Encerrar");

    switch (Console.ReadLine()) {
        case "1":
            Console.WriteLine("Informe o Nome do hóspede: ");
            string nomeTemp = Console.ReadLine();
            Console.WriteLine("Informe o Sobrenome do hóspede: ");
            string sobrenomeTemp= Console.ReadLine();
            Pessoa p = new Pessoa (nome: nomeTemp, sobrenome: sobrenomeTemp);
            hospedes.Add(p);
            break;

        case "2":
            Console.WriteLine("Informe o tipo da suíte: ");
            string tipoSuiteTemp = Console.ReadLine();
            Console.WriteLine("Informe a capacidade da suíte: ");
            int capacidadeTemp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o valor da diária da suíte: ");
            decimal valorDiariaTemp = Convert.ToDecimal(Console.ReadLine());
            suite.TipoSuite = tipoSuiteTemp;
            suite.Capacidade = capacidadeTemp;
            suite.ValorDiaria = valorDiariaTemp;
            break;

        case "3":
            Console.WriteLine("Informe a quantidade de dias reservados: ");
            int diasReservadosTemp = Convert.ToInt32(Console.ReadLine());
            reserva.DiasReservados = diasReservadosTemp;

            if (suite.TipoSuite is null) {
                Console.WriteLine("Nenhuma suíte foi cadastrada.");
            }
            else {
                reserva.CadastrarSuite(suite);
                if (hospedes.Count() == 0) {
                    Console.WriteLine("Não há hóspedes cadastrados.");
                }
                else {
                    reserva.CadastrarHospedes(hospedes);
                }   
            }

            break;

        case "4":
            if (reserva.DiasReservados == 0) {
                Console.WriteLine("A reserva ainda não foi criada.");
            }
            else {
                Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            }

            break;

        case "5":
            if (reserva.DiasReservados == 0) {
                Console.WriteLine("A reserva ainda não foi criada.");
            }
            else {
                Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
            }

            break;

        case "6":
            exibirMenu = false;
            break; 
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar.");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou.");