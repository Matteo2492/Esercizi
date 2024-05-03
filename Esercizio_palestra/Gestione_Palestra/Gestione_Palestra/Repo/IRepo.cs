namespace Gestione_Palestra.Repo
{
    public interface IRepo<T>
    {
        List<T> All();
        T? Id(int id);
        T? Nominativo(string nom);

        bool Insert(T t);
    }
}
