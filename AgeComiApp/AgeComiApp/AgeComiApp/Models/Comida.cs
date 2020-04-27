using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AgeComiApp.Models
{
    [Table("Comida")]
    public class Comida
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public String Nombre { get; set; }
        public String Nombre_Imagen { get; set; }

        public int ID_Horario { get; set; }

    }
}
