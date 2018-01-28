using System;
using System.Text;


namespace KalendarRoutines
{
	/// <summary>
	/// Allgemeine Hilfsroutinen für Kalenderberechnungen
	/// </summary>
	public class Calendar
	{
		/// <summary>
		/// Gibt den Tag des Jahres zurück
		/// </summary>
		/// <param name="day">Tag</param>
		/// <param name="month">Monat</param>
		/// <param name="year">Jahr</param>
		/// <returns>Tag des Jahres</returns>
		public static int d_year(int day, int month, int year)
		{
			int[] dayOfMonths = new int[13];

			dayOfMonths[0] = 0;
			dayOfMonths[1] = 31;
			dayOfMonths[2] = 28;
			dayOfMonths[3] = 31;
			dayOfMonths[4] = 30;
			dayOfMonths[5] = 31;
			dayOfMonths[6] = 30;
			dayOfMonths[7] = 31;
			dayOfMonths[8] = 31;
			dayOfMonths[9] = 30;
			dayOfMonths[10] = 31;
			dayOfMonths[11] = 30;
			dayOfMonths[12] = 31;


			int J=0;
			
			if(month==1)
			{
				J=day;
				return J;
			}
			else
			{
				for(int i = 1;i< month;i++)
				{
					J=J+dayOfMonths[i];
				}
				J = J + day;
			}

			if((year % 4 == 0 && year % 100 != 0 || year % 400 == 0) && month > 2 )
			{
				J = J + 1;//Schaltjahr
			}

			return J;
		}
	
		/// <summary>
		/// Gibt dem Monat und den Tag des Ostersonntags zurück
		/// </summary>
		/// <param name="year">Gesuchtes Jahr</param>
		/// <param name="eastermonth">Monat des Ostersonntags</param>
		/// <param name="easterday">Tag des Ostersonntags</param>
		public static void easter(int year, out int eastermonth, out int easterday)
		{
			int d,m,gn,c,gc,cc,ed,e;
			gn=year%19+1;

			if(year<=1582)
			{
				ed=(5*year)/4;
				e=(11*gn-4)%30+1;
			}
			else
			{
				c=year/100+1;
				gc=(3*c)/4-12;
				cc=(c-16-(c-18)/25)/3;
				ed=(5*year)/4-gc-10;
				e=(11*gn+19+cc-gc)%30+1;
				if(((e==25)&&(gn>11)) || (e==24))
				{
					e++;
				}
			}
			d=44-e;
			if(d<21)
			{
				d=d+30;
			}
			d=d+7-(ed+d)%7;
			if(d<=31)
			{
				m=3;
			}
			else
			{	
				m=4;
				d=d-31;
			}
			eastermonth=m;
			easterday=d;
		}//end easter
		

		
		/// <summary>
		/// Berechnung des Tags und Monats des Ostersonntags
		/// Die Methode prüft im Gegensatz zu easter() erst die Jahre nach 1582 ab
		/// was wohl heute häufiger gebraucht wird.
		/// </summary>
		/// <param name="year">Jahr</param>
		/// <param name="eastermonth">Nummer des Monats, auf den der Ostersonntag fällt</param>
		/// <param name="easterday">Tag des Monats, auf den der Ostersonntag fällt</param>
		public static void easter2(int year, out int eastermonth, out int easterday)
		{
			int d,m,gn,c,gc,cc,ed,e;
			gn=year%19+1;

			if(year>1582)
			{
				c=year/100+1;
				gc=(3*c)/4-12;
				cc=(c-16-(c-18)/25)/3;
				ed=(5*year)/4-gc-10;
				e=(11*gn+19+cc-gc)%30+1;
				if(((e==25)&&(gn>11)) || (e==24))
				{
					e++;
				}
			}
			else
			{
				ed=(5*year)/4;
				e=(11*gn-4)%30+1;				
			}
			d=44-e;
			if(d<21)
			{
				d=d+30;
			}
			d=d+7-(ed+d)%7;
			if(d<=31)
			{
				m=3;
			}
			else
			{	
				m=4;
				d=d-31;
			}
			eastermonth=m;
			easterday=d;		
		}//end easter2


		/// <summary>
		/// gibt für einen Jahrestag und das Jahr den 
		/// entsprechenden Monat und Tag zurück
		/// </summary>
		/// <param name="jt">Jahrestag</param>
		/// <param name="year">Jahr</param>
		/// <param name="day">Tag</param>
		/// <param name="month">Monat</param>
		public static void DM(int jt, int year, out int day, out int month)
		{
			int l,j,k,d,m;
			l=0;
			if((year/4)*4 == year)
			{
				l=1;
			}
			k=0;
			if(jt > (59+l))
			{
				k=2-l;
			}

			j=jt+k+91;
			m=(j*100)/3055;
			d=j-(m*3055)/100;
			m=m-2;
			month=m;
			day=d;
		}
		
		/// <summary>
		/// Kalkuliert das Julianische Datum für ein übergebenes Datum
		/// Damit ist nicht der Julianische Kalender nach Julius Cäsar gemeint,
		/// sondern der Kalender nach Joseph Scaliger
		/// </summary>
		/// <param name="day">Tag als int</param>
		/// <param name="month">Monat als int</param>
		/// <param name="year">Jahr als int</param>
		/// <returns>Julianstag</returns>
		public static int Julian(int day, int month, int year)
		{
			int jd;
			int j,l;

			j=(month-14)/12;
			l=year+j+4800;
			jd=day-32075+1461*l/4+367*(month-2-12*j)/12-3*((l+100)/100)/4;
			return jd;
		}

		/// <summary>
		/// gibt für ein übergebenes Datum den Wochentag als Zahl zurück
		/// Sonntag = 0, Montag = 1
		/// </summary>
		/// <param name="day"></param>
		/// <param name="month"></param>
		/// <param name="year"></param>
		/// <returns>Wochentag als Zahl</returns>
		public static int d_week(int day, int month, int year)
		{
			int L, M;
			double weekday;	
			L = month + 10;
			M = (month-14) / 12 + year;	
			weekday = ((13 * (L-(L/13) *12)-1) / 5 + day + 77 + 5 *(M-(M/100)*100)/4 + M /400 - (M/100) * 2.7); 
			weekday = weekday % 7;
			return (int)weekday;
		}

		/// <summary>
		/// Kalkuliert das Alter in Tagen zwischen 2 Daten mit Hilfe der 
		/// Funktion<see cref="Calendar.Julian"/>
		/// Dabei wird aus den ersten drei Elemente (j1) und aus den folgenden
		/// 3 Elementen (j2) jeweils der Julianstag gebildet.
		/// Die Differenz berechnet sich dann aus j2 - j1;
		/// </summary>
		/// <param name="day_1">Tag 1</param>
		/// <param name="month_1">Monat 1</param>
		/// <param name="year_1">Jahr 1</param>
		/// <param name="day_2">Tag 2</param>
		/// <param name="month_2">Monat 2</param>
		/// <param name="year_2">Jahr 2</param>
		/// <returns>Alter in Tagen</returns>
		public static int diff_day(int day_1, int month_1, int year_1, int day_2, int month_2,int year_2)
		{
			int j_1, j_2, diff;
			j_1 = Julian(day_1, month_1, year_1);
			j_2 = Julian(day_2, month_2, year_2);

			diff = j_2 - j_1;
			return diff;
		}
	
		/// <summary>
		/// Gibt den Wochentag für ein beliebiges Datum in numerischer 
		/// Schreibweise zurück
		/// 
		/// Sonntag ist 0, Montag=1, ..., Samtag = 6
		/// </summary>
		/// <param name="t">Tag</param>
		/// <param name="m">Monat</param>
		/// <param name="j">Jahr</param>
		/// <returns></returns>
		public static int week_day( int t, int m, int j)
		{
			int c, y=0, h=0;
			if(m<=2)
			{
				m += 10;
				j -=1;
			}
			else
			{
				m -= 2;
			}

			c = j / 100;
			y = j % 100;
			h = (((26*m-2)/10)+t+y+y/4+c/4-2*c)%7;
			if(h<0)
			{
				h +=7;
			}
			return h;
		}

		public static string z2T (int zahl, int AnzahlZiffern) 
		{
			StringBuilder b = new StringBuilder();
			b.Append(zahl);
			while (b.Length < AnzahlZiffern)
				b.Insert(0,"0");
			return b.ToString();
		}

		
		

	
	}

	

}
