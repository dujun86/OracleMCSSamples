using System;
using System.Text.RegularExpressions;


namespace Samples.Models
{
	public class Employee
	{
		public Employee ()
		{
		}

		public string FullName { get { return Doc.FullName; } }
		public string Email {get { return Doc.Email; } }
		public string Phone { get { return Doc.Phone; } }
		public string Twitter { get { return Doc.Twitter; } }
		public string City { get { return Doc.City; } }
		public string Title { get { return Doc.Title; } }

		public GeoLocation GeoLocation { get; set; }
		public Document Doc { get; set; }

		public struct Document {
			public string FullName;
			public string Email;
			public string Phone;
			public string Twitter;
			public string City;
			public string Title;
		}

		public string Initials {
			get { 
				Regex initials = new Regex (@"(\b[a-zA-Z])[a-zA-Z]* ?");
				string init = initials.Replace (FullName, "$1");
				return init;
			}
		}

//		public Employee (string name, string email, string phone, string city, string twitter, string title)
//		{
//			FullName = name;
//			Email = email;
//			Phone = phone;
//			Twitter = twitter;
//			Title = title;
//			City = city;
//		}
	}
}

