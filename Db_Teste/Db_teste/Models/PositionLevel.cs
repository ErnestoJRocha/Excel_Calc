using System;
using System.Collections.Generic;

namespace Db_teste.Models
{
    public partial class PositionLevel
    {
        public decimal NivelId { get; set; }
        public int? AreaId { get; set; }
        public string PositionName { get; set; }
        public string LevelName { get; set; }
    }
}
