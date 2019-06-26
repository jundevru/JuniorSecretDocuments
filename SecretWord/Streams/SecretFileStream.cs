using System;
using System.IO;
using SecretCore;
using SecretWord.Models;
using System.Text;

namespace SecretWord.Streams
{
    class SecretFileStream : ISecretStream
    {
        private string fileName;
        public IDocument Load(IDocumentEncoder encoder, int key)
        {
            Models.Document doc = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, (int)fs.Length);
                byte[] decodedData = encoder.Decrypt(data, key);
                doc = new Document(Encoding.Unicode.GetString(decodedData));
                fs.Close();
            }
            return doc;
        }

        public bool Save(IDocument document, IDocumentEncoder encoder, int key)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                byte[] data = Encoding.Unicode.GetBytes(document.Text);
                fs.Write(data, 0, data.Length);
                fs.Close();
            }
            return true;
        }

        public SecretFileStream(string fileName)
        {
            this.fileName = fileName;
        }
    }
}
