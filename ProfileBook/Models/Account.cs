﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProfileBook.Models
{
    [Table("Account")]
    public class Account: IModel
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int id { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("password")]
        public string Password { get; set; }
        
    }
}
