using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UBotPlugin;

namespace PersonalPlugin
{
    class DownloadFromUrl : IUBotCommand
    {
        private List<UBotParameterDefinition> _parameters = new List<UBotParameterDefinition>();

        public DownloadFromUrl()
        {
            _parameters.Add(new UBotParameterDefinition("url", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("dest", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("filename", UBotType.String));
        }
        public string Category
        {
            get { return "Personal Commands"; }
        }

        public string CommandName
        {
            get { return "download from url"; }
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
            string url = parameters["url"];
            //string url = "http://localhost/sample/values.csv";
            string dest = parameters["dest"];
            string filename = parameters["filename"];
            //System.Windows.MessageBox.Show(url);
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(url, @dest + filename);
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("Cannot download file");
            }
        }
    }
}