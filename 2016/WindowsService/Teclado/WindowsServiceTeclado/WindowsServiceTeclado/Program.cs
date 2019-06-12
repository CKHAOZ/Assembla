using System.ServiceProcess;

namespace WindowsServiceTeclado
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            ServicesToRun = new ServiceBase[]
            {
                new ServiceWrirelesKeyboard()
            };
            
            ServiceBase.Run(ServicesToRun);
        }
    }
}
