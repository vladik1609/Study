using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Xml;

namespace Sokoban
{
    internal class CryptographyXml
    {
        public static void EncryptXml(XmlDocument doc, string elementToEncrypt, RSA alg, string keyName)
        {
            XmlElement elementToEncryptElement = doc.GetElementsByTagName(elementToEncrypt)[0] as XmlElement;

            RijndaelManaged sessionKey = new RijndaelManaged
            {
                KeySize = 256
            };

            EncryptedXml xml = new EncryptedXml();

            EncryptedKey encryptedKey = new EncryptedKey
            {
                CipherData = new CipherData(EncryptedXml.EncryptKey(sessionKey.Key, alg, false)),
                EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url)
            };

            KeyInfoName keyInfoName = new KeyInfoName
            {
                Value = keyName
            };
            encryptedKey.KeyInfo.AddClause(keyInfoName);
            xml.AddKeyNameMapping(keyName, alg);

            byte[] encryptedElement = xml.EncryptData(elementToEncryptElement, sessionKey, false);

            EncryptedData encryptedData = new EncryptedData
            {
                CipherData = new CipherData(encryptedElement),
                Type = EncryptedXml.XmlEncElementUrl,
                EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url)
            };
            encryptedData.KeyInfo.AddClause(new KeyInfoEncryptedKey(encryptedKey));

            EncryptedXml.ReplaceElement(elementToEncryptElement, encryptedData, false);

            sessionKey.Clear();
        }

        public static void DecryptXml(XmlDocument doc, RSA alg, string keyName)
        {
            EncryptedXml xml = new EncryptedXml(doc);
            xml.AddKeyNameMapping(keyName, alg);
            xml.DecryptDocument();
        }
    }
}