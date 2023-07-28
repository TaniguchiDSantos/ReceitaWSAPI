using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReceitaWSAPI.Data.Context;
using ReceitaWSAPI.Domain.Entities;
using ReceitaWSAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ReceitaWSAPI.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRespository
    {
        public PedidoRepository(ReceitaWSContext context) : base(context)
        {
        }

        public async Task<List<Pedido>> GetAllPedidoAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task CNPJSerachAsync(string cnpj)
        {
            string url = "https://www.receitaws.com.br/v1/cnpj/" + cnpj;
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
           

            Pedido pedido = new Pedido();
            pedido.CNPJ = FormatCNPJ(cnpj);
            //pedido.Result = System.Text.Json.JsonSerializer.Serialize(json);
            pedido.Result = json;

            AddAsync(pedido);
        }

        public static string FormatCNPJ(string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        public override async Task<Pedido> AddAsync(Pedido obj)
        {
            Pedido pedido = null;
            var strategy = Db.Database.CreateExecutionStrategy();
            await strategy.Execute(async () =>
            {
                using (var transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        DbSet.AddRange(obj);
                        Db.SaveChanges();
                        transaction.Commit();
                        pedido = obj;
                    }
                    catch (Exception except)
                    {
                        transaction.Rollback();
                        throw except;
                    }
                }
            });
            return pedido;
        }
    }
}
