using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeProjetos.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        // ToString
        public override string ToString() =>  $"Nome: {Nome} | Data-Inicio: {DataInicio} | Data-Fim: {DataFim}";
    }
}