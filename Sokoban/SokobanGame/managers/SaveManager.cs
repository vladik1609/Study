using System;
using System.Text;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.IO;

namespace Sokoban
{
    internal class SaveManager : ISaveManager
    {
        private readonly string pathDirectory;
        private readonly string pathFile;

        public SaveManager(string directory, string fileName)
        {
            pathDirectory = directory;
            pathFile = Path.Combine(directory, fileName);
        }

        public SaveManager(string pathFile)
        {
            this.pathFile = pathFile;
        }

        public void NewGame()
        {
            Directory.CreateDirectory(pathDirectory);
            XmlTextWriter textWriter = new XmlTextWriter(pathFile, Encoding.UTF8);
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("Sokoban");
            textWriter.WriteStartElement("Savegame");
            textWriter.WriteFullEndElement();
            textWriter.WriteEndElement();
            textWriter.Close();
        }

        public void AddWinLevel(string levelNumber, string movesCount, string pushesCount)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(pathFile);

            XmlNode head = doc.DocumentElement.ChildNodes[0];

            XmlNode element = doc.CreateElement("level");
            head.AppendChild(element);
            XmlAttribute attribute = doc.CreateAttribute("levelNumber");
            attribute.Value = levelNumber;
            element.Attributes.Append(attribute);

            XmlNode subElement1 = doc.CreateElement("moves");
            subElement1.InnerText = movesCount;
            element.AppendChild(subElement1);

            XmlNode subElement2 = doc.CreateElement("pushes");
            subElement2.InnerText = pushesCount;
            element.AppendChild(subElement2);

            doc.Save(pathFile);
        }

        public void SaveGame(string levelNumber, string movesCount, string pushesCount)
        {
            XmlDocument doc = new XmlDocument();
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
            RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

            doc.Load(pathFile);
            CryptographyXml.DecryptXml(doc, rsaKey, "Sokoban");
            doc.Save(pathFile);

            AddWinLevel(levelNumber, movesCount, pushesCount);

            doc.Load(pathFile);
            CryptographyXml.EncryptXml(doc, "Sokoban", rsaKey, "Sokoban");
            doc.Save(pathFile);

            rsaKey.Clear();
        }

        public int GetCompletedLevelsCount()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                CspParameters cspParams = new CspParameters();
                cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
                RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

                doc.Load(pathFile);
                CryptographyXml.DecryptXml(doc, rsaKey, "Sokoban");
                doc.Save(pathFile);

                XmlNode head = doc.DocumentElement.ChildNodes[0];

                int count = head.ChildNodes.Count;
                doc.Load(pathFile);
                CryptographyXml.EncryptXml(doc, "Sokoban", rsaKey, "Sokoban");
                doc.Save(pathFile);

                rsaKey.Clear();
                return count;
            }
            catch (Exception)
            {
                // Обработка исключения, если не удается получить количество
            }
            return 0;
        }
    }
}