using System.Collections.Generic;

namespace Source.App.Initialization
{
    public static class Extensions
    {
        public static void Initialize(this IEnumerable<IInitializable> initializables)
        {
            foreach (var initializable in initializables)
                initializable.Initialize();
        }
    }
}