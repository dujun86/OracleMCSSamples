using System;
using Samples.Models;
using Oracle.Cloud.Mobile.Analytics;

namespace Samples.ViewModels
{
	public class EmpDirDetailVm : ViewModelBase
	{
		public EmpDirDetailVm (Employee employee)
		{
			EmployeeData = employee;

			WriteEventToMCS ();
		}

		private Employee _employeeData;

		public Employee EmployeeData { 
			get { return _employeeData; } 
			set {
				_employeeData = value;
				NotifyPropertyChanged ();
			}
		}

		/// <summary>
		/// Writes the event to Oracle MCS
		/// </summary>
		public async void WriteEventToMCS()
		{
			var analytics = App.Backend.GetService<Analytics>();

			// Record name of person clicked on
			analytics.LogEvent(EmployeeData.FullName);
			await analytics.FlushAsync();
		}
	}
}

