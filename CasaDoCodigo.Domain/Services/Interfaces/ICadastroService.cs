using CasaDoCodigo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Domain.Services.Interfaces
{
    public interface ICadastroService
    {
        Cadastro Update(int cadastroid, Cadastro cadastro);
    }
}
