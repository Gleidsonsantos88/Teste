namespace Repository
{
    public interface ICommand<T>
    {
        bool Criar(T obj);
        bool Alterar(T obj);
        bool Excluir(int id);
    }
}
