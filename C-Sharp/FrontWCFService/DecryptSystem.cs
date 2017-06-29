using FrontWcfService.App_Code;
using KeyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Web;
using System.Xml;

namespace FrontWcfService
{
    public class DecryptSystem
    {
        private string username;
        private string[] myFiles;
        private string[] myFilesNames;

        private List<Thread> mesThreads;

        private double numberTotalKey = 0;
        private double keyGenerated = 0;

        public DecryptSystem()
        {
            mesThreads = new List<Thread>();
        }

        public void Init(string[] str, string[] myFilesNames, string username)
        {
            myFiles = str;
            this.username = username;
            this.myFilesNames = myFilesNames;

            for (int i = 0; i < myFiles.Length; i++)
            {
                string content = myFiles[i];
                string name = myFilesNames[i];
                mesThreads.Add(new Thread(() => DecryptProcess(content,name)));
            }
            mesThreads.Add(new Thread(ManagerKeyProcess));
        }

        public void Start()
        {
            foreach (Thread th in mesThreads)
            {
                th.Start();
            }
        }

        public void Stop()
        {
            foreach(Thread th in mesThreads)
            {
                th.Abort();
            }
        }

        private void ManagerKeyProcess()
        {
            Thread.Sleep(3000);
            while (Thread.CurrentThread.IsAlive)
            {
                ModelUser userSystem = new ModelUser();
                if (numberTotalKey != 0 && keyGenerated != 0)
                {
                    double res = keyGenerated / numberTotalKey * 80;
                    
                    userSystem.updatePourcent(username, Convert.ToInt32(res));
                }

                if (!userSystem.getStat1(username))
                    Stop();

                Thread.Sleep(100);
                
            }
            
        }

        private void DecryptProcess(string filestr, string namefile)
        {
            KeyByte keygen = new KeyByte(48);
            JMSReference.WebServiceAnalysis obj = new JMSReference.WebServiceAnalysis();

            numberTotalKey += keygen.getAmountMaxKey();

            string nameFile = namefile;

            while (keygen.nextKeyExist() && Thread.CurrentThread.IsAlive)
            {
                keyGenerated++;
                string key = keygen.GetKey();
                //string decryptedFile = XORdecrypt(filestr, key);
                string decryptedFile = XORdecrypt(filestr, "fjuiop");

                string contentReadyTosend = ChaineToBinaire(decryptedFile).ToString();


                obj.rechercheDocumentDecrypte(username, contentReadyTosend, namefile, key);
            }


            
        }

        private string EncodeBinary(string str)
        {
            byte[] binaires = Encoding.ASCII.GetBytes(str);
            string strres = "";

            foreach(byte bin in binaires)
            {
                strres += Convert.ToString(bin,2);
            }

            return strres;
        }

        static StringBuilder ChaineToBinaire(string chaine)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(chaine);
            StringBuilder binary = new StringBuilder();
            foreach (byte b in bytes)
            {
                int val = b;
                for (int i = 0; i < 8; i++)
                {
                    binary.Append((val & 128) == 0 ? 0 : 1);
                    val <<= 1;
                }
                //binary.append(' ');
            }
            return binary;
        }

        public string XORdecrypt(string text, string key)
        {
            var result = new StringBuilder();
            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));
            return result.ToString();
        }
    }
}