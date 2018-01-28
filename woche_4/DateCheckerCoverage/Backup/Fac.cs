using System;

namespace KalendarRoutines
{
	/// <summary>
	/// Zusammenfassung f�r Fac.
	/// </summary>
	public class Fac
	{
		/// <summary>
		/// Errechnet die Fakult�t einer Zahl
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static int factorial(int x) 
		{
			int result;// = -1;
			if(x >= 0) 
			{
				result = 1;
				for(int i=2; i <= x; i++) 
				{
					result = result * i;
				}
			} 
			else 
			{
				result = -1;
			}
			return result;
		}
	}
}
