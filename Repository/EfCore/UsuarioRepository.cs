using Model;
using Repository.Utils;
using System.Linq;

namespace Repository.EfCore
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ProdapDbContext _prodapDbContext;
        public UsuarioRepository(ProdapDbContext prodapDbContext)
        {
            _prodapDbContext = prodapDbContext;
        }
        public Usuario BuscarUsuarioPorNomeSenha(string nome, string senha)
        {
            senha = CriptografiaMD5.RetorneMD5(senha);
            return _prodapDbContext.Usuarios
                                   .Where(x => x.Senha == senha && x.Nome == nome)?
                                   .Select(s => new Usuario
                                   {
                                       Id = s.Id,
                                       Nome = s.Nome
                                   }).FirstOrDefault();

        }

        public bool Criar(Usuario usuario)
        {
            usuario.Senha = CriptografiaMD5.RetorneMD5(usuario.Senha);
            _prodapDbContext.Usuarios.Add(usuario);
            _prodapDbContext.SaveChanges();
            return true;
        }

        
    }
}
