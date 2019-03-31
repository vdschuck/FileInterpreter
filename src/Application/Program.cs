
using Application.Interpreter;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileObserver = new FileObserver();

            fileObserver.HandlerEvents();           
        }   
    }
}

