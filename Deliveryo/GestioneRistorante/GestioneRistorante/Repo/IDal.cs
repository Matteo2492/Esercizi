namespace GestioneRistorante.Repo
{
    public interface IDal<T>
    {
        IEnumerable<T> GetAll();
        T? GetID(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(string code);
        T? GetCode(string code);    
    }
}
