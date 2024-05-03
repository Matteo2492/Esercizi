namespace Chattero.Repo
{
    public interface IRepo<T>
    {
        T? GetId(int id);
        T? GetCode(string code);
        List<T> GetAll();
        bool Insert(T item);
        bool Update(T item);
        bool Delete(string email);
       
    }
}
