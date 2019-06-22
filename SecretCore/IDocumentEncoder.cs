using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretCore
{
    public interface IDocumentEncoder
    {
        string Name { get; }
        byte[] Encrypt(byte[] data, int key);
        byte[] Decrypt(byte[] data, int key);
    }
}
