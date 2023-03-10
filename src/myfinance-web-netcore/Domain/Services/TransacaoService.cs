using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Domain.Services.Interfaces;
using myfinance_web_netcore.Models;
using myfinance_web_netcore;
using myfinance_web_netcore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Domain.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _dbcontext;
        private readonly IPlanoContaService _planoContaService;
        private readonly LogService _logService;

        public TransacaoService(MyFinanceDbContext dbContext, IPlanoContaService planoContaService)
        {
            _dbcontext = dbContext;
            _planoContaService = planoContaService;
            _logService = new LogService(_dbcontext);
        }

        public List<TransacaoModel> ListarRegistros()
        {
            var result = new List<TransacaoModel>();
            var dbSet = _dbcontext.Transacao.Include(x => x.PlanoConta);

            foreach (var item in dbSet)
            {
                var itemTransacao = new TransacaoModel()
                {
                    Id = item.Id,
                    Data = item.Data,
                    Valor = item.Valor,
                    Historico = item.Historico,
                    ItemPlanoConta = new PlanoContaModel()
                    {
                        Id = item.PlanoConta.Id,
                        Descricao = item.PlanoConta.Descricao,
                        Tipo = item.PlanoConta.Tipo
                    },
                    PlanoContaId = item.PlanoContaId,
                };

                result.Add(itemTransacao);
            }

            return result;
        }

        public TransacaoModel RetornarRegistro(int id)
        {
            var item = _dbcontext.Transacao.Where(x => x.Id == id).First();

            var itemPlanoConta = new TransacaoModel()
            {
                Id = item.Id,
                Data = item.Data,
                Valor = item.Valor,
                Historico = item.Historico,
                PlanoContaId = item.PlanoContaId,
            };

            return itemPlanoConta;
        }

        public void Salvar(TransacaoModel model)
        {
            var dbSet = _dbcontext.Transacao;

            using var transaction = _dbcontext.Database.BeginTransaction();

            var entidade = new Transacao()
            {
                Id = model.Id,
                Valor = model.Valor,
                Data = model.Data,
                Historico = model.Historico,
                PlanoContaId = model.PlanoContaId,
            };

            if (entidade.Id == null)
            {
                dbSet.Add(entidade);
                _logService.salvarLog('I');
            }
            else
            {
                dbSet.Attach(entidade);
                _dbcontext.Entry(entidade).State = EntityState.Modified;
                _logService.salvarLog('A');
            }

            _dbcontext.SaveChanges();
            transaction.Commit();
        }

        public void Excluir(int id)
        {
            using var transaction = _dbcontext.Database.BeginTransaction();
            var item = _dbcontext.Transacao.Where(x => x.Id == id).First();
            _dbcontext.Attach(item);
            _dbcontext.Remove(item);
            _logService.salvarLog('E');
            _dbcontext.SaveChanges();
            transaction.Commit();
        }
    }
}
