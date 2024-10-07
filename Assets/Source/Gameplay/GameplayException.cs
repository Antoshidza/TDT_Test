using System;

namespace Source.Gameplay
{
    public class GameplayException : Exception
    {
        public GameplayException(string msg) : base(msg)
        {
        }
    }
}