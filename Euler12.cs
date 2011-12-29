using System;
using System.Collections.Generic;
using System.Linq;

namespace euler
{
    class Euler12
    {
        public static void Main ()
        {    
            foreach (int i in trianglenumbers()) {
                var n = gettreenumber (i);
                var divs = n.allDivisors;
                Console.Write (n.i.ToString ().PadLeft (7) + " ("+divs.Count().ToString().PadLeft(3)+"): ");
                foreach (treenumber div in divs) {
                    Console.Write (div.i + ",");
                }
                Console.Write ("\n");
                if (divs.Count() > 500) {
                   Console.WriteLine(">500!");
                    break;
                }
            }
        }
        
        static IEnumerable<int> trianglenumbers ()
        {
            int last = 0;
            for (int i = 1; i <= int.MaxValue; i++) {
                yield return last += i;
            }
        }

        
                
        static HashSet<treenumber> treenumbers = new HashSet<treenumber> ();

        static treenumber gettreenumber (int i)
        {
            foreach (treenumber treenumber in treenumbers)
                if (treenumber.i == i)
                    return treenumber;
            
            var newtreenumber = new treenumber (i);
            treenumbers.Add (newtreenumber);
            return newtreenumber;
        }

        class treenumber
        {
            
            public treenumber (int i)
            {
                this.i = i;
                if (i == 1) {
                    _directDivisors = new HashSet<treenumber> (){};
                    _allDivisors = new HashSet<treenumber> (){this};
                } else if (i == 2) {
                    _directDivisors = new HashSet<treenumber> (){gettreenumber (1)};
                    _allDivisors = new HashSet<treenumber> (){gettreenumber (1)};
                } else {
                    _directDivisors = null;
                    _allDivisors = null;
                }
            }
            
            public int i;
            HashSet<treenumber> _directDivisors;

            public HashSet<treenumber> directDivisors {
                get {
                    //Console.WriteLine ("Checking " + i + ".directDivisors");
                    if (_directDivisors != null)
                        return _directDivisors;
                    
                    _directDivisors = new HashSet<treenumber> ();
                    
                    var possibledivs = Enumerable.Range (1, (i + 1) / 2).ToList ();
                    while (possibledivs.Count() > 0) {
                        int n = possibledivs [possibledivs.Count () - 1];
                        if (i % n == 0) {
                            var newtreenumber = gettreenumber (n);
                            _directDivisors.Add (newtreenumber);
                            foreach (treenumber div in newtreenumber.allDivisors) {
                                possibledivs.Remove (div.i);
                            }
                        }
                        possibledivs.Remove (n);
                    }
                    
                    return _directDivisors;
                }
            }
            
            HashSet<treenumber> _allDivisors;

            public HashSet<treenumber> allDivisors {
                get {
                    //Console.WriteLine ("Checking " + i + ".allDivisors");
                    if (_allDivisors != null)
                        return _allDivisors;
                    
                    _allDivisors = new HashSet<treenumber> ();
                    foreach (treenumber div in directDivisors) {
                        _allDivisors.Add (div);
                        _allDivisors.UnionWith (div.allDivisors);
                    }
                    _allDivisors.Add (this);
                    return _allDivisors;
                }
            }

            public override string ToString ()
            {
                return i.ToString ();
            }
        }
    }
}

