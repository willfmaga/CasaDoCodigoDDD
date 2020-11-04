using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Repositories.Interfaces;
using CasaDoCodigo.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Domain.Services
{
    public class CadastroService : ICadastroService
    {
        private readonly ICadastroRepository cadastroRepository;

        public CadastroService(ICadastroRepository cadastroRepository)
        {
            this.cadastroRepository = cadastroRepository;
        }

        public Cadastro Update(int cadastroid, Cadastro cadastro)
        {
            return cadastroRepository.Update(cadastroid, cadastro);
        }
    }
}
