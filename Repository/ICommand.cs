namespace Repository
{
    public interface ICommand<T>
    {
        void Criar(T obj);
        void Alterar(T obj);
        void Excluir(T obj);
    }
}
