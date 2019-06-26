using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretWord.Streams
{
    interface ISecretStream
    {
        bool Save(Models.IDocument document, SecretCore.IDocumentEncoder encoder, int key);
        Models.IDocument Load(SecretCore.IDocumentEncoder encoder, int key);
    }
}
