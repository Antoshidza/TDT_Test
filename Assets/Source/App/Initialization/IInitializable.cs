namespace Source.App.Initialization
{
    public interface IInitializable 
        // : IAsyncInitializable
    {
        public void Initialize();

        // UniTask IAsyncInitializable.Initialize()
        // {
        //     Initialize();
        //     return UniTask.CompletedTask;
        // }
    }

    // public interface IAsyncInitializable
    // {
    //     public UniTask Initialize();
    // }
}