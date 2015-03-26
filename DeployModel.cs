using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDeploy
{

    [Serializable]
    public class DeployModel
    {
        public List<Server> Servers { get; set; }
        public List<Corp> Corps { get; set; }
    }

    public class Server
    {
        public const string ServerPath = "/ReportServer/ReportService2010.asmx";

        public string ServerName { get; set; }

        private string _serverUrl;

        public string ServerUrl
        {
            get { return _serverUrl; }
            set { _serverUrl = "http://" + value + ServerPath; }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Corp
    {
        public string CorpId { get; set; }
        public string CorpName { get; set; }
        public string ServerName { get; set; }
        public string DefaultPath { get; set; }
    }
}
