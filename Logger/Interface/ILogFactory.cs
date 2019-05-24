namespace Logger.Interface
{
    public interface ILogFactory
    {
        ILog Create();
        ILog Create(string folder);
    }
}
