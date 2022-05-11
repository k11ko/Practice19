using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice19
{
	public static class Date
	{
		public static int НомерПункта;
		public static int IndexRow;
	}
	public static class DateUser
	{
		public static int ID;
		public static string Login = "false";
		public static string Right;
		public static string FirstName;
		public static string SecondName;
	}
	public static class DateQuery
	{
		public static IQueryable<Accounting> SQL;
	}
}
