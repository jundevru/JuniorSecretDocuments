using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecretCore;

namespace XorEncoder
{
    public class Encoder : IDocumentEncoder
    {
        public string Name => "XOR Encoder";
        public byte[] Decrypt(byte[] data, int key)
        {
            return CodingDecoding(data, GetKeys(key));
        }

        public byte[] Encrypt(byte[] data, int key)
        {
            return CodingDecoding(data, GetKeys(key));
        }

        private byte[] CodingDecoding(byte[] arrray, byte[] keys)
        {
            var res = new byte[arrray.Length];
            int keyIndex = -1;
            for (int k = 0; k < arrray.Length; k++)
            {
                keyIndex++;
                if (keyIndex >= keys.Length)
                    keyIndex = 0;
                res[k] = (byte)(arrray[k] ^ keys[keyIndex]);
            }
            return res;
        }
        private byte[] GetKeys(int key)
        {
            if (key < 0)
                key = -key;
            if (key <= 255)
                return new byte[1] { (byte)key };
            List<byte> res = new List<byte>();
            while (key > 255)
            {
                key = key / 2;
                res.Add((byte)(key % 255));
            }
            return res.ToArray();
        }
    }
}
