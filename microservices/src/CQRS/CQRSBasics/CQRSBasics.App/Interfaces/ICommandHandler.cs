namespace CQRSBasics.App.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
