using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ReceitaWSAPI.Data.Context;
using ReceitaWSAPI.Data.Repository;
using ReceitaWSAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReceitaWSAPI.Tests.Repository
{
    public class PedidoRepositoryTests
    {
        private async Task<ReceitaWSContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ReceitaWSContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var databaseContext = new ReceitaWSContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Pedido.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Pedido.Add(
                      new Pedido()
                      {
                          CNPJ = "33.041.260/0652-90",
                          Result = "Teste",

                      });
                    await databaseContext.SaveChangesAsync();
                }
            }

            return databaseContext;
        }

        [Fact]
        public async void PedidoRepository_GetAllPedidoAsync_ReturnsList()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var pedidoRepository = new PedidoRepository(dbContext);

            //Act
            var result = await pedidoRepository.GetAllPedidoAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Pedido>>();
        }

        [Fact]
        public async void PedidoRepository_AddAsync_ReturnsObject()
        {
            //Arrange
            var pedido = new Pedido()
            {
                CNPJ = "33.041.260/0652-90",
                Result = "Teste",
            };
            var dbContext = await GetDbContext();
            var pedidoRepository = new PedidoRepository(dbContext);

            //Act
            var result = await pedidoRepository.AddAsync(pedido);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Pedido>();
        }
    }
}
