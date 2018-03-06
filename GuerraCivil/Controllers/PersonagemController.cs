
using Marvel.Api;
using Marvel.Api.Filters;
using Marvel.Api.Model.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GuerraCivil.Models;
using GuerraCivil.ViewModel;

namespace GuerraCivil.Controllers
{
    public class PersonagemController : Controller
    {
        private readonly string publicKey = "5a753c4c13a390e0035a1c8a7defb43e";
        private readonly string privateKey = "19e94e14e6a180b8f806a4e1487b8ecd4e40dc9b";

        private List<int> codigos;


        public ActionResult Atualizar()
        {
            var client = new MarvelRestClient(publicKey, privateKey);

            List<Personagem> personagens = BaixarPersonagens(client);

            using (var ctx = new Contexto())
            {
                if (ctx.Personagens.Count() > 0)
                {
                    ctx.Personagens.RemoveRange(ctx.Personagens.ToList());
                    ctx.SaveChanges();
                }                

                ctx.Personagens.AddRange(personagens);
                ctx.SaveChanges();
            }

            return View(personagens);
        }

        private static List<Personagem> BaixarPersonagens(MarvelRestClient client)
        {
            int offset = 0;
            int limit = 100;
            int total = int.MaxValue;
            var personagens = new List<Personagem>();

            while (offset < total)
            {
                var filtro = new CharacterRequestFilter()
                {
                    Limit = limit,
                    Offset = offset
                };

                var response = client.FindCharacters(filtro);

                total = Convert.ToInt32(response.Data.Total);
                offset += limit;

                foreach (var character in response.Data.Results)
                {
                    var personagem = new Personagem()
                    {
                        IdPersonagem = character.Id,
                        Nome = character.Name,
                        QuantQuadrinhos = character.Comics.Items.Count
                    };

                    personagens.Add(personagem);
                }
            }

            return personagens;
        }

        // GET: Personagens
        public ActionResult Index()
        {
            var time1 = new List<Personagem>();
            var time2 = new List<Personagem>();            

            Personagem personagem;                        

            using (var ctx = new Contexto())
            {
                int IdInicial = ctx.Personagens
                    .OrderBy(p => p.Id)
                    .FirstOrDefault().Id;

                int IdFinal = ctx.Personagens
                    .OrderByDescending(p => p.Id)
                    .FirstOrDefault().Id;

                codigos = new List<int>();

                for (int i = 1; i < 11; i++)
                {
                    personagem = BuscaAleatorio(ctx, IdInicial, IdFinal);
                    time1.Add(personagem);
                }

                for (int i = 1; i < 11; i++)
                {
                    personagem = BuscaAleatorio(ctx, IdInicial, IdFinal);
                    time2.Add(personagem);
                }
            }

            var viewModel = new IndexViewModel();
            viewModel.Time1 = time1;
            viewModel.Time2 = time2;

            viewModel.QtdTime1 = 20;
            viewModel.QtdTime2 = 20;

            return View(viewModel);
        }

        private Personagem BuscaAleatorio(Contexto ctx, int IdInicial, int IdFinal)
        {
            Random rnd = new Random();            

            var r = rnd.Next(IdInicial, IdFinal);            
            while (codigos.Exists(i => i == r))
            {
                r = rnd.Next(IdInicial, IdFinal);
            }                    
            codigos.Add(r);

            return ctx.Personagens.FirstOrDefault(p => p.Id == r);
        }
    }
}