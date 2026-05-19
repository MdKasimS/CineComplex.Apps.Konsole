namespace Konsole.Classes.Exceptions
{
    public class InvalidLanguageException
    {
        public InvalidLanguageException()
        {
            Console.WriteLine("The mentioned language is invalid. Please ensure to enter a valid language.");

            //This excpetion has to be thrown in the subsequent methods that add a new movie details.
        }

    }
}