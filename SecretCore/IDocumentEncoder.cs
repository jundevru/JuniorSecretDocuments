using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretCore
{
    public interface IDocumentEncoder
    {
        byte[] Encrypt(string text);
        string Decrypt(byte[] data);
    }
}
