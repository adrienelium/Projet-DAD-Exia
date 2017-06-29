using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUC_Client.FrontWCFService;

namespace CUC_Client
{
    public class Service
    {
        private static Service instance;

        private DecryptageServiceClient service;

        private Service()
        {
            service = new DecryptageServiceClient();
        }

        public static Service GetInstance()
        {
            if (instance == null)
            {
                instance = new Service();
            }
            return instance;
        }

        public string login(string userName, string passWord)
        {
            LogInfo info = service.Login(new LogInfo { username = userName, password = passWord });

            if (info.token != "")
                return info.token;
            else
                return "";
        }

    }
}
