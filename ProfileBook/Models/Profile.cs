using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProfileBook.Models
{
    [Table ("Profile")]
    public class Profile: IModel
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int id { get; set; }
        [Column("first_name")]
        public string first_name { get; set; }
        [Column("last_name")]
        public string last_name { get; set; }
        [Column("user_id")]
        public int user_id { get; set; }
    }
}
