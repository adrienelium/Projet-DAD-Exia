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
    public class FrontService : IDecryptageService
    {
        private DecryptSystem systemDecry;

        /// <summary>
        /// Renvoi le resultat d'un traitement J2EE sous forme d'un objet Result
        /// </summary>
        /// <param name="username"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Result GetResult(string username, string token)
        {
            Result res = new Result();

            if (AuthToken(username, token))
            {
                ModelUser userSystem = new ModelUser();
                res = userSystem.getResult(username);
            }

            return res;
        }

        /// <summary>
        /// Renvoi l'état de la demande en cours sous la forme d'un objet State.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public State GetState(string username, string token)
        {
            State state = new State();

            if (AuthToken(username,token))
            {
                ModelUser userSystem = new ModelUser();

                switch (userSystem.getProgressUser(username))
                {
                    case 0:
                        state.amount = 0;
                        state.comment = "Ready to bruteforce";
                        break;
                    case 10:
                        int amount = 10;

                        int res = userSystem.getPourcent(username);

                        amount += res; 

                        state.amount = amount;
                        state.comment = amount + "% progress";
                        break;
                    case 100:
                        state.amount = 100;
                        state.comment = "100% Finished";
                        break;
                    default:

                        break;

                }

                state.resultExist = userSystem.isResultExist(username);

                
                return state;
            }
            else
            {
                state.amount = 0; 
                state.comment = "Invalid token";
                return state;
            }

        }

        /// <summary>
        /// Lance le processus de décryptage des fichiers
        /// </summary>
        /// <param name="str">Tableau de fichiers sous forme de string</param>
        /// <param name="filesNames">Tableau de nom de fichier sous forme de string</param>
        /// <param name="username"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool LaunchDecryptProcess(string[] str, string[] filesNames, string username, string token)
        {
            if (AuthToken(username, token))
            {
                ModelUser userSystem = new ModelUser();
                userSystem.updateStat1True(username);
                userSystem.resetResultByUsername(username);

                systemDecry = new DecryptSystem();
                systemDecry.Init(str, filesNames, username);
                systemDecry.Start();

                

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Réalise une authentification en fonction de l'objet LogInfo envoyé
        /// </summary>
        /// <param name="loginInfo">Objet LogInfo contenant les crédentials</param>
        /// <returns></returns>
        public LogInfo Login(LogInfo loginInfo)
        {
            ModelUser userSystem = new ModelUser();

            if (userSystem.isUserExist(loginInfo.username, loginInfo.password))
            {
                string token = TokenGen.TokenGenerator.GetInstance.BuildSecureToken(30);
                int idUser = userSystem.getIdUser(loginInfo.username);

                userSystem.updateUserToken(idUser, token);

                loginInfo.token = token;

                return loginInfo;
            }
            else
            {
                loginInfo.token = "";
                return loginInfo;
            }

        }

        /// <summary>
        /// Annule un traitement Bruteforce
        /// </summary>
        /// <param name="username"></param>
        /// <param name="token"></param>
        public void Reset(string username, string token)
        {
            ModelUser userSystem = new ModelUser();
            if (AuthToken(username, token))
            {
                userSystem.updateResetStatAndPourcent(username);
            }
        }

        private bool AuthToken(string username ,string token)
        {
            ModelUser userSystem = new ModelUser();
            if (userSystem.isTokenExist(username, token))
            {
                return true;
            }   
            else
            {
                return false;
            }
                
        }
    }
}
