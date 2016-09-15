using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestPicswapper2.Models
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string mail { get; set; }
        public string haslo { get; set; }
        
    }
}