using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.UserActivityMonitor;
using System.Runtime.InteropServices;

namespace ConsoleApp
{
    public class ConsoleBase
    {
        public static void ProbarEscritura()
        {
            Tools.Texto.Instance.EscribirMensaje("¿Que edad tienes?");

            Tools.Texto.Instance.EscribirMensaje("Stui");
        }
        
        public static void EscribirLoqueEscribo()
        {
            Gma.UserActivityMonitor.HookManager.KeyDown += HookManager_KeyDown;
        }

        private static void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            Tools.Texto.Instance.EscribirMensaje(string.Format("KeyDown - {0}\n", e.KeyCode));
        }

    }
}
