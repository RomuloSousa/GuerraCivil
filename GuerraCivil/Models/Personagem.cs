using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuerraCivil.Models
{
    public class Personagem
    {        
        public int Id { get; set; }

        public int IdPersonagem { get; set; }

        public string Nome { get; set; }

        public int QuantQuadrinhos { get; set; }

    }
}
