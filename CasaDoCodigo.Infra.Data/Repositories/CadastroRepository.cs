using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasaDoCodigo.Infra.Data.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Cadastro Update(int cadastroId, Cadastro cadastro)
        {
            var cadastroDB = dbSet.Where(c => c.Id == cadastroId).SingleOrDefault();

            if (cadastroDB == null) throw new ArgumentException("Cadastro não encontrado");

            cadastroDB.Update(cadastro);
            contexto.SaveChanges();
            return cadastroDB;

        }
    }
}
