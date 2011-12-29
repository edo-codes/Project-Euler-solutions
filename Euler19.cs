using System;
using System.Collections.Generic;
using System.Linq;

namespace euler
{
	class Euler19
	{
		public static void Main ()
		{
			Console.WriteLine (days ().Where (i=>i.dayOfMonth==1&&i.dayOfWeek==weekday.sunday&&i.year>=1901).Count ());
		}

		static IEnumerable<Day> days ()
		{
			Day previousday = new Day ()
			{
				dayOfMonth = 1,
				dayOfWeek = weekday.monday,
				month = month.january,
				year = 1900
			};
			yield return previousday;
			while (!(previousday.year==2000 && previousday.month==month.december&&previousday.dayOfMonth==31)) {
				var next = new Day ();
				if (previousday.dayOfWeek == weekday.saturday) {
					next.dayOfWeek = weekday.sunday;
				} else {
					next.dayOfWeek = previousday.dayOfWeek + 1;
				}
				if (previousday.dayOfMonth == daysPerMonth (previousday.month, previousday.year)) {
					next.dayOfMonth = 1;
					if (previousday.month == month.december) {
						next.month = month.january;
						next.year = previousday.year + 1;
					} else {
						next.month = previousday.month + 1;
						next.year = previousday.year;
					}
				} else {
					next.dayOfMonth = previousday.dayOfMonth + 1;
					next.month = previousday.month;
					next.year = previousday.year;
				}
				yield return next;
				previousday = next;
			}
			yield break;
		}

		static int daysPerMonth (month Month, int Year)
		{
			switch (Month) {
			case month.january:
			case month.march:
			case month.may:
			case month.july:
			case month.august:
			case month.october:
			case month.december:
				return 31;
				
			case month.april:
			case month.june:
			case month.september:
			case month.november:
				return 30;
				
			case month.february:
				if (Year % 4 == 0) {
					if (Year % 100 == 0) {
						if (Year % 400 == 0)
							return 29;
						return 28;
					}
					return 29;
				} else
					return 28;
			default:
				throw new Exception ("The program could not continue because the universe has imploded. Please try again later.");
			}	
		}

		enum weekday
		{
			sunday,
			monday,
			tuesday,
			wednesday,
			thursday,
			friday,
			saturday
		}

		enum month
		{
			january,
			february,
			march,
			april,
			may,
			june,
			july,
			august,
			september,
			october,
			november,
			december
		}

		class Day
		{
			public weekday dayOfWeek;
			public int dayOfMonth;
			public month month;
			public int year;

			public override string ToString ()
			{
				return dayOfWeek + ", " + dayOfMonth + " " + month + " " + year;
			}
		}
	}
}
