using ExoApi.Contexts;
using ExoApi.Interfaces;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class ProjetoRepository : IProjetoRepository

    {
        private readonly ExoApiContext _context;
        public ProjetoRepository(ExoApiContext context)
        {
            _context = context;
        }

        public List<Projeto> Listar()
        {
            
            return _context.Projetos.ToList();
        }
        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }

        public void Cadastrar(Projeto projeto)
        {
            _context.Projetos.Add(projeto);

            _context.SaveChanges();
        }

        public void Atualizar(int id, Projeto projeto)
        {
            Projeto projetoBuscado = _context.Projetos.Find(id);

            if (projetoBuscado != null)
            {
                projetoBuscado.Id = projeto.Id;
                projetoBuscado.Titulo = projeto.Titulo;
                projetoBuscado.Status = projeto.Status;
                projetoBuscado.Tecnologias = projeto.Tecnologias;
                projetoBuscado.Requisitos = projeto.Requisitos;
                projetoBuscado.Area = projeto.Area;

            }

            _context.Projetos.Update(projetoBuscado);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Projeto projeto = _context.Projetos.Find(id);

            _context.Projetos.Remove(projeto);

            _context.SaveChanges();
        }
    }
}
