# MaxPrimeNumberCalculator
Self-hosted SignalR application that determines the maximum prime number possible in 60 seconds.

Prerequisites:
- .NET Framework 4.6
- Port 8080 is available for hosting the self-hosted OWIN service

To run:

1. On a Windows machine, clone the repo and open the Compiled folder, or compile the solution yourself.  NOTE: Windows SmartScreen will prevent the app from running if you just download the repo as a zip from GitHub.  You must clone the repo or compile the app yourself to prevent this problem.

2. Run the MaxPrimeNumberCalculator.exe

3. Visit http://localhost:8080 in a browser and the calculations should begin

Implementation details:
The implementation has two main interfaces, ILargestPrimeFinder and IPrimeChecker.  Dependency injection is used to minimize coupling to a particular implementation.  The most effective found implementations are a prime finder which exponentially increases the interval to the next prime, and a Miller-Rabin prime checker.  This could easily be further optimized but I ran out of time.  Also, given more time, I'd explore using a factory pattern to change implementations at runtime to compare performance.
