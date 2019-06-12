using System.ServiceProcess;
using BLL.LogicLayer;

namespace WindowsServiceTeclado
{
    public partial class ServiceWrirelesKeyboard : ServiceBase
    {
        public ServiceWrirelesKeyboard()
        {
            //se inicializa la captura de teclas.
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            BLL.LogicLayer.Teclado.Instance.IniciarTeclado();
        }

        protected override void OnStop()
        {

        }
    }
}
