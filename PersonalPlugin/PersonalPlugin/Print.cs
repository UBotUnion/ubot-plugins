using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UBotPlugin;

namespace Print
{
    class Print : IUBotCommand
    {
        private List<UBotParameterDefinition> _parameters = new List<UBotParameterDefinition>();

        public Print()
        {
            _parameters.Add(new UBotParameterDefinition("source", UBotType.String));
        }
        public string Category
        {
            get { return "Personal Commands"; }
        }

        public string CommandName
        {
            get { return "print"; }
        }

        public bool IsContainer
        {
            get { return false; }
        }

        public IEnumerable<UBotParameterDefinition> ParameterDefinitions
        {
            get { return _parameters; }
        }

        public UBotVersion UBotVersion
        {
            get { return UBotVersion.Standard; }
        }

        public void Execute(IUBotStudio ubotStudio, Dictionary<string, string> parameters)
        {
            string source = parameters["source"];
            try
            {
                //string name = parameters["Name"];
                //System.Windows.MessageBox.Show("Hello " + name);
                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = @source;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                p.WaitForInputIdle();
                System.Threading.Thread.Sleep(3000);
                if (false == p.CloseMainWindow())
                    p.Kill();
                
            }
            catch (Exception e)
            {
                //System.Windows.MessageBox.Show("Cannot print file");
            }
        }
    }
}