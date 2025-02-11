namespace Sieve;

public interface ISieve
{
    long NthPrime(long n);
}

public class SieveImplementation : ISieve
{
    /// Validates prime number against list of known primes
    ///
    private bool isPrime(long n, ref List<long> pList)
    {
        double highestRoot = Math.Sqrt(n);
        for (int d = 0; d < pList.Count; d++)
        {
            if (n % pList[d] == 0)
            {
                return false;
            }
            if (pList[d] > highestRoot)
            { return true; }
        }
        return true;
    }
    
    ///
    /// Implementation of NthPrime(long n)
    /// Determines the n-th prime of a number
    ///
    /// Note: All tests pass with the following caveats
    /// 1 - where n < 10,000, the approx run-time is ~2s
    /// 2 - where n = 100,000, the run-time is ~1m
    /// 3 - where n = 1,000,000, the run-time is ~30m
    /// 4 - where n = 10,000,000, the run-time is ~160m
    /// The run-times are consistent with iteration through n integers.
    /// 
    /// 11th Hour Update:
    /// Added a test to helper method to exclude x > Sqrt(n) in the list of primes.
    /// This cut the run-time to ~2m for the 10M-th prime.
    /// <param>n</param> The index of the prime number to return. In this case, it is always the last.
    /// 
    public long NthPrime(long n)
    {
        List<long> primeList = new List<long>();
        //primeList.Add(2); //default
        for (long i = 2; primeList.Count - 1 < n; i++)
        {
            if (isPrime(i, ref primeList))
            {
                primeList.Add(i);
            }
            //otherwise ignore the number, it's not prime anyway
            //effectively we're testing all primes and sub-primes
            //against the list of already known primes
        }
        return primeList.Last(); //we're always only creating out to the n-th prime, no further.
        //throw new NotImplementedException("unimplemented");
    }
}