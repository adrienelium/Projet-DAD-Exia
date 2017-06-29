using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.SqlServer;
using FrontWcfService;
using FrontWcfService.App_Code;

namespace FrontWcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ResultService : IResultService
    {
        /// <summary>
        /// Informe le FrontService que le résultat a été trouvé.
        /// </summary>
        /// <param name="docname">Nom du document</param>
        /// <param name="content">Contenu du fichier décodé</param>
        /// <param name="taux">Taux de confiance</param>
        /// <param name="key">Clé de déchiffrement</param>
        /// <param name="username">Username de la tache</param>
        public void SendResult(string docname, string content, string taux, string key, string username)
        {
            ModelUser userSystem = new ModelUser();

            userSystem.updateStat2True(username);
            userSystem.updateResultByUsername(docname, content, taux, key, username);
        }
    }
}
