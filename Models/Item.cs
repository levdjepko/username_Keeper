using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;


namespace username_Keeper.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
    }
}