namespace Konsole.Classes.Exceptions
{
    public class InavlidDuarationException
    {

        public InavlidDuarationException()
        {
            Console.WriteLine("The mentioned movie duration is invalid. Please ensure to enter a valid duration.");
        }

        //This exception has to be thrown in the subsequent methods that add a new movie details, if the movie duartion is less then or equal to Zero.
    }
}