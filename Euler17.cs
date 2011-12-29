using System;

namespace euler
{
	public class Euler17
	{
		public static void Main ()
		{
			string total = "";
			for (int i = 1; i <= 1000; i++)
				total += numbertostring (i);
			Console.WriteLine (total.Replace (" ", "").Replace ("-", "").Length);
		}

		static string numbertostring (int i)
		{
			switch (i) {
			case 0:
				return "";
			case 1:
				return "one";
			case 2:
				return "two";
			case 3:
				return "three";
			case 4:
				return "four";
			case 5:
				return "five";
			case 6:
				return "six";
			case 7:
				return "seven";
			case 8:
				return "eight";
			case 9:
				return "nine";
			case 10:
				return "ten";
			case 11:
				return "eleven";
			case 12:
				return "twelve";
			case 13:
				return "thirteen";
			case 14:
				return "fourteen";
			case 15:
				return "fifteen";
			case 16:
				return "sixteen";
			case 17:
				return "seventeen";
			case 18:
				return "eighteen";
			case 19:
				return "nineteen";
			case 20:
				return "twenty";
			case 30:
				return "thirty";
			case 40:
				return "forty";
			case 50:
				return "fifty";
			case 60:
				return "sixty";
			case 70:
				return "seventy";
			case 80:
				return "eighty";
			case 90:
				return "ninety";
			case 1000:
				return "one thousand";
			default:
				if (i < 100) {
					var tenths = (int)(Math.Floor (((double)i) / 10));
					return numbertostring (tenths * 10) + "-" + numbertostring (i - tenths * 10);
				} else if (i < 1000) {
					var hundredths = (int)(Math.Floor (((double)i) / 100));
					var rest = i - hundredths * 100;
					if (rest > 0)
						return numbertostring (hundredths) + " hundred and " + numbertostring (i - hundredths * 100);
					else
						return numbertostring (hundredths) + " hundred";
				} else
					throw new NotImplementedException ("Number is out of supported range.");
			}
			
		}
	}
}

