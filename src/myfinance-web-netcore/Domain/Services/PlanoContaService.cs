using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Domain.Services.Interfaces;
using myfinance_web_netcore.Models;
using myfinance_web_netcore;
using myfinance_web_netcore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace myfinance_web_netcore.Domain.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _dbcontext;

        public PlanoContaService(MyFinanceDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public List<PlanoContaModel> ListarRegistros()
        {
            var result = new List<PlanoContaModel>();
            var dbSet = _dbcontext.PlanoConta;

            foreach (var item in dbSet)
            {
                var itemPlanoConta = new PlanoContaModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                };

                result.Add(itemPlanoConta);
            }

            return result;
        }

        public void Salvar(PlanoContaModel model)
        {
            var dbSet = _dbcontext.PlanoConta;

            var entidade = new PlanoConta()
            {
                Id = model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo
            };

            if (entidade.Id == null)
            {
                dbSet.Add(entidade);
            }
            else
            {
                dbSet.Attach(entidade);
                _dbcontext.Entry(entidade).State = EntityState.Modified;
            }

            _dbcontext.SaveChanges();
        }

        public PlanoContaModel RetornarRegistro(int id)
        {
            var item = _dbcontext.PlanoConta.Where(x => x.Id == id).First();
            var itemPlanoConta = new PlanoContaModel()
            {
                Id = item.Id,
                Descricao = item.Descricao,
                Tipo = item.Tipo
            };

            return itemPlanoConta;
        }

        public void Excluir(int id)
        {
            /* var entidade = new PlanoConta(){
                Id = id
            }; */

            var item = _dbcontext.PlanoConta.Where(x => x.Id == id).First();
            _dbcontext.Attach(item);
            _dbcontext.Remove(item);
            _dbcontext.SaveChanges();
        }
    }
}
