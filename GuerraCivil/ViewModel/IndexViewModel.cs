using GuerraCivil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuerraCivil.ViewModel
{
    public class IndexViewModel
    {
        public List<Personagem> Time1 { get; set; }
        public List<Personagem> Time2 { get; set; }

        public int QtdTime1 { get; set; }
        public int QtdTime2 { get; set; }
    }
}