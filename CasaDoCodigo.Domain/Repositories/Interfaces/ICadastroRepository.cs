using CasaDoCodigo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaDoCodigo.Domain.Repositories.Interfaces
{
    public interface ICadastroRepository
    {

        Cadastro Update(int cadastroId,Cadastro cadastro);
    }
}
