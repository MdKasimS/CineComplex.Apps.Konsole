namespace Konsole.Classes.Base
{
    public abstract class AViewBase<T> : ABaseSingleton<T> where T : AViewBase<T>, new()
    {
        // Protected constructor to prevent direct instantiation.
        protected AViewBase() { }

    }
}
