using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgeComiApp.Models
{
    [Table("Menu")]
    class Menu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ID_Desayuno { get; set; }
        public int ID_Comida { get; set; }
        public int ID_Cena { get; set; }


    }
}
