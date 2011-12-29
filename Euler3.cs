using System;
using System.Collections.Generic;
using System.Linq;

namespace euler
{
	class Euler3
	{
		static void Main ()
		{
			Console.WriteLine (largestprimedivisor (600851475143));
		}
		
		static IEnumerable<ulong> primes (ulong highest)
		{
			var numbers = new Dictionary<ulong, bool> ();
			for (ulong i = 1; i <= highest; i++)
				numbers.Add (i, true);
			for (ulong i = 2; i <= highest; i++) {
				if (numbers [i] == true) {
					for (ulong j = 2; j <= Math.Sqrt(i+1); j++) {
						if (i % j == 0) {
							numbers [i] = false;
						}
					}
					for (ulong k = 2*i; k<=highest; k+=i) {
						numbers [k] = false;
					}
					if (numbers [i] == true) {
						yield return i;
					}
				}
				
			}
		}

		static IEnumerable<ulong> primestopdown (ulong highest)
		{
			for (ulong i = highest; i > 1; i--) {
				bool broken = false;
				for (ulong j = 2; j <= Math.Sqrt (i); j++) {
					if (i % j == 0) {
						broken = true;
						break;
					}
				}
				if (broken == true)
					continue;
				else
					yield return i;
			}
			yield break;
		}

		static ulong largestprimedivisor (ulong n)
		{
			var b = primestopdown ((ulong)Math.Sqrt (n));
			foreach (ulong i in b)
				if (n % i == 0)
					return i;
			return 0;
		}
	}
}
