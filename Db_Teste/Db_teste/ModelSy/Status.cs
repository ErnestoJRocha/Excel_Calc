using System;
using System.Collections.Generic;

namespace Db_teste.Model
{
    public partial class Status
    {
        public int Id { get; set; }
        public string MaritalStatus { get; set; }
        public int IrsTable { get; set; }
        public int Extra { get; set; }
    }
}
