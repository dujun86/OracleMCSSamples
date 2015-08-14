using System;
using System.Text;
using System.Json;
using Newtonsoft.Json;
using Samples.Models;
using Samples.ViewModels;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace Samples
{
	public class EmpDirListVm : ViewModelBase
	{
		public EmpDirListVm ()
		{
		}

		private Employee[] _employeeList;

		public Employee[] EmployeeList { 
			get { return _employeeList; } 
			set {
				_employeeList = value;
				NotifyPropertyChanged ();
			}
		}

		public async Task AllEmployees()
		{
			using (var client = App.Backend.CreateHttpClient ()) {

				//
				// RETRIEVE CONTACTS FROM ORACLE MCS
				//

				var response = await client.GetAsync (App.Backend.CustomCodeUri + "/SteveAPI/addresses");
				response.EnsureSuccessStatusCode ();

				var json = await response.Content.ReadAsStringAsync ();
				JObject jsonobj = JObject.Parse (json);

				// CONVERT JSON TO EMPLOYEE OBJECT
				Employee[] emp = new Employee[(int)jsonobj["total_rows"]];
				emp = JsonConvert.DeserializeObject<Employee[]> (jsonobj ["rows"].ToString ());
				EmployeeList = emp;

			}
		}
	}
}

