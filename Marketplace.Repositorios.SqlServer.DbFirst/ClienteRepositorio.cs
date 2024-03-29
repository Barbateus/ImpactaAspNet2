﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Marketplace.Repositorios.SqlServer.DbFirst
{
    public class ClienteRepositorio
    {
        public void Inserir(Cliente cliente)
        {
            using (var contexto = new MarketplaceEntities())
            {
                contexto.Clientes.Add(cliente);
                contexto.SaveChanges();
            }
        }

        public Cliente Selecionar(int id)
        {
            using (var contexto = new MarketplaceEntities()) 
            {
                return contexto.Clientes.SingleOrDefault(c=> c.Id == id);
            }
        }

        public List<Cliente> Selecionar(int numeroPagina = 1, int quantidadeRegistro = 50)
        {
            using (var contexto = new MarketplaceEntities())
            {
                return contexto.Clientes
                    .OrderBy(c => c.Nome)
                    .Skip((numeroPagina - 1) * quantidadeRegistro)
                    .Take(quantidadeRegistro)
                    .ToList();

            }
        }

        public void Atualizar(Cliente cliente)
        {
            using (var contexto = new MarketplaceEntities())
            {
                contexto.Entry(cliente).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (var contexto = new MarketplaceEntities())
            {
                var cliente = contexto.Clientes.SingleOrDefault(c => c.Id == id);

                if (cliente == null) return;

                contexto.Clientes.Remove(cliente);
                contexto.SaveChanges();
            }
        }
    }
}
