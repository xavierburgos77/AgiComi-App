using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgeComiApp.Models
{
    [Table("Horario")]
    public class Horario
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Nombre { get; set; }
        public TimeSpan Hora { get; set; }

    }
}
