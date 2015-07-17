using System;
using Samples.Models;

namespace Samples.ViewModels
{
	public class EmpDirDetailVm : ViewModelBase
	{
		public EmpDirDetailVm (Employee employee)
		{
			EmployeeData = employee;
		}

		private Employee _employeeData;

		public Employee EmployeeData { 
			get { return _employeeData; } 
			set {
				_employeeData = value;
				NotifyPropertyChanged ();
			}
		}
	}
}

