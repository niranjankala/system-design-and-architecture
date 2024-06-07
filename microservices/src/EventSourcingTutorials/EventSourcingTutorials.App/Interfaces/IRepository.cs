namespace EventSourcingTutorials.App.Interfaces
{
    interface IRepository<T>
    {
        bool Add(T obj);
        bool Update(T obj);
        List<T> Query(int it);
        List<T> Query(string name);

    }
}
