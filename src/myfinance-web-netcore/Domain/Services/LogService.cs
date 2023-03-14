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
    public class LogService
    {
        private readonly MyFinanceDbContext _dbcontext;

        public LogService(MyFinanceDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void salvarLog(char operacao)
        {
            var item = new LogModel { Operacao = operacao };

            _dbcontext.Log.Add(item);
            _dbcontext.SaveChanges();
        }
    }
}
