using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva () {
            DiasReservados = 0;
        }

        public Reserva (int diasReservados) {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes (List<Pessoa> hospedes) {
            if (Suite.Capacidade > hospedes.Count()) {
                Hospedes = hospedes;
                Console.WriteLine("Hospedado(s) com sucesso!");
            }
            else {
                Console.WriteLine("O número de hóspedes é maior do que a capacidade da suíte.");
                Hospedes = null;
            }
        }

        public void CadastrarSuite (Suite suite) {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes () {
            if (Hospedes == null) {
                //Console.WriteLine("Não há hóspedes cadastrados.");
                return 0;
            }
            else {
                return Hospedes.Count();
            }
        }

        public decimal CalcularValorDiaria () {
            decimal valor = 0M;

            if (Hospedes != null) {
                valor = DiasReservados * Suite.ValorDiaria;

                if (DiasReservados >= 10) {
                    valor = valor * 0.90M;
                }
                return valor;
            }

            else {
                return 0;
            }
        }
    }
}