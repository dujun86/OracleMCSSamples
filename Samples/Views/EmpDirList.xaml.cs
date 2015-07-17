using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using Samples;
using Samples.Models;
using Oracle.Cloud.Mobile.Analytics;

namespace Samples.Views
{
	public partial class EmpDirList : ContentPage
	{
		private EmpDirListVm _viewModel;

		public EmpDirList ()
		{
			InitializeComponent ();

			_viewModel = new EmpDirListVm ();
			this.BindingContext = _viewModel;

			//Pull to refresh
			itemListview.IsPullToRefreshEnabled = true;

			//Refresh data from Oracle MCS
			itemListview.Refreshing += async (sender, e) => {
				await _viewModel.AllEmployees();
				itemListview.ItemsSource = _viewModel.EmployeeList;
				itemListview.EndRefresh();
			};

			//Refresh List
			itemListview.BeginRefresh ();


			//Item clicked
			itemListview.ItemSelected += async (sender, e) =>  {

				if (e.SelectedItem == null) return;

				var selectedData = (Employee)e.SelectedItem;

				//Retrieve geo data
				//selectedData.GeoLocation = await App.EmpDirClient.GetGeolocation(selectedData.City);

				var nextPage = new EmpDirDetail(selectedData);

				await Navigation.PushAsync(nextPage);

				((ListView)sender).SelectedItem = null;
			};
		}

	
		public void OnMore (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public void OnDelete (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
		}
	}
}

