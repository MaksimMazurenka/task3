using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class HMACGenerator
    {
        private int pc;
        private static Random rnd = new Random();
        private static int size;
        private byte[] key;
        private string HMAC;

        public HMACGenerator(int s)
        {
            size = s;
        }
        private void pcTurnGenerator()
        {
            pc = rnd.Next(0, size);
        }
        public void keyGenerator()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[32];
            rng.GetBytes(buff);
            key = buff;
        }
        public int getPcTurn()
        {
            pcTurnGenerator();
            return pc;
        }
        public int getPc()
        {
            return pc;
        }
        public string getStringKey()
        {
            string kluch = BitConverter.ToString(key).Replace("-", string.Empty).ToLower();
            return kluch;
        }
        public byte[] getKey()
        {
            return key;
        }
        public string getHMAC()
        {
            return HMAC;
        }

        public string HMACHASH(string str, byte[] bkey)
        {
            using (var hmac = new HMACSHA256(bkey))
            {
                byte[] bstr = Encoding.Default.GetBytes(str);
                var bhash = hmac.ComputeHash(bstr);
                HMAC = BitConverter.ToString(bhash).Replace("-", string.Empty).ToLower();
                return HMAC;
            }
        }
    }
}
