using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Global.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Force { get; set; }
        public int Endurance { get; set; }
        public int Intelligence { get; set; }
        public int Charisme { get; set; }
        public int UserId { get; set; }
    }
}
