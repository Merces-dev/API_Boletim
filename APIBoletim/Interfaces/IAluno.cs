using APIBoletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Interfaces
{
    interface IAluno
    {
        Aluno Cadastrar(Aluno a);
        List<Aluno> LerTodos();
        Aluno BuscarPorId(int Id);
        Aluno Alterar(int id, Aluno a);
        void Excluir(int id);

    }
}
