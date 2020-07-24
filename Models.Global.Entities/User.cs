using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Global.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
