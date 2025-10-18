using Exo.WebApi.Contexts;
using Exo.WebApi.Models;

namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;

        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }

        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

        public void Cadastrar(Projeto novoProjeto)
        {
            _context.Projetos.Add(novoProjeto);
            _context.SaveChanges();
        }

        public void Atualizar(int id, Projeto projetoAtualizado)
        {
            Projeto projeto = _context.Projetos.Find(id)!;

            if (projeto != null)
            {
                projeto.NomeDoProjeto = projetoAtualizado.NomeDoProjeto;
                projeto.Area = projetoAtualizado.Area;
                projeto.Status = projetoAtualizado.Status;

                _context.Projetos.Update(projeto);
                _context.SaveChanges();
            }
        }

        // 🔹 Excluir projeto
        public void Deletar(int id)
        {
            Projeto projeto = _context.Projetos.Find(id)!;

            if (projeto != null)
            {
                _context.Projetos.Remove(projeto);
                _context.SaveChanges();
            }
        }
    }
}