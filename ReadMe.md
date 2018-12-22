# PrimeGen #

An exploration in all things prime numbers.

```
Usage: PrimeGen (action) [options]
  -h / --help    Show full help
  --debug        Show debug messages (implies -v)
  -v             Show extra information

 gen             Generates a sequence of prime numbers and outputs one per line
  -t (type)      Type of generator to use (leave empty to list the types)
  -s (number)    Starting number for the generator (default 2)
  -e (number)    Ending number for the generator (default 100)
  -f (file)      Optional text file to store primes

 bits            Generate array of bits with primes as 1s and composites as 0s
  -t (type)      Type of generator to use (leave empty to list the types)
  -s (number)    Starting number for the generator (default 2)
  -e (number)    Ending number for the generator (default 100) or use -l
  -l (size)      Target size of file. can specify K/M/G/T/E suffixes or use -e
  -f (file)      File to store the bits

 bitsimg         Generate an image using the prime number bit array process
  -t (type)      Type of generator to use (leave empty to list the types)
  -s (number)    Starting number for the generator (default 2)
  -d (w) (h)     Dimensions of the image (width and height)
  -c (number)    Bits per color between 1 and 48 (default 1)
  -p (file)      Color palette file to use for coloring
  -f (file)      File to store image
```

## notes ##
https://github.com/phillipm/ecpp-aks-primality-proving

= alternate way pascal trial division - TODO
https://www.futilitycloset.com/2015/12/29/pascals-primes/

(a+b)^p ≡ a^p+b^p (modp) for all primes p

