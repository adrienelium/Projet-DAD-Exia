using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FrontWcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IDecryptageService
    {

        [OperationContract]
        LogInfo Login(LogInfo loginInfo);

        [OperationContract]
        bool LaunchDecryptProcess(string[] str, string[] filesNames, string username, string token);

        [OperationContract]
        State GetState(string username, string token);

        [OperationContract]
        void Reset(string username, string token);

        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class LogInfo
    {

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string token { get; set; }
    }

    public class State
    {

        [DataMember]
        public string comment { get; set; }

        [DataMember]
        public int amount { get; set; }
        

    }
}
