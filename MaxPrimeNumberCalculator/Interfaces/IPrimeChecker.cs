using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxPrimeNumberCalculator.Interfaces
{
    public interface IPrimeChecker
    {
        bool IsPrime(ulong primeCandidate);
    }
}
