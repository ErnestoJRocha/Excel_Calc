using System;
using System.Collections.Generic;

namespace Db_teste.Auxiliar
{
    public partial class Nivel
    {
        public decimal Nivelid { get; set; }
        public string Shortdesc { get; set; }
        public string Desc { get; set; }
        public decimal? Vencimento { get; set; }
        public decimal? Abonos { get; set; }
        public decimal? Subsrefeicao { get; set; }
        public decimal? Despesas { get; set; }
        public decimal? Atribviatura { get; set; }
        public decimal? Despesasviatura { get; set; }
        public decimal? Despesasgasolina { get; set; }
        public decimal? Variavel { get; set; }
        public decimal? Premio { get; set; }
    }
}
