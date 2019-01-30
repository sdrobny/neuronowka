using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Neuronowka
{
    //Generator liczb naprawdę losowych dla wykorzystania przez siec
    //ktora wykorzystuje dużą ilość liczb losowych przy inicjalizacji
    public class CryptoRandom
    {
        public double RandValue { get; set; }

        public CryptoRandom()
        {
            using (RNGCryptoServiceProvider cp = new RNGCryptoServiceProvider())
            {
                Random r = new Random(cp.GetHashCode());
                this.RandValue = r.NextDouble();
            }
        }
    }
}
