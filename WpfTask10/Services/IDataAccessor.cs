namespace WpfTask10.Services
{
    public interface IDataAccessor<T>
    {
        void Save(T data);
        T Load();
    }
}
