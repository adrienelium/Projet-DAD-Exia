using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FrontWcfService
{
    [ServiceContract]
    public interface IResultService
    {

        [OperationContract]
        void SendResult(string docname, string content, string taux, string key, string username);

    }
}
