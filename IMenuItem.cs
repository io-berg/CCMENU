namespace Cmenu
{
    public interface IMenuItem
    {
        void Run();

        string Name { get; }
    }
}