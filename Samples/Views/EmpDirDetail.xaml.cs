﻿using System;
using System.Collections.Generic;
using Samples;
using Samples.Models;
using Samples.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Samples.Views
{
	public partial class EmpDirDetail : ContentPage
	{
		private EmpDirDetailVm _viewModel;

		public EmpDirDetail (Employee data)
		{

			InitializeComponent ();

			_viewModel = new EmpDirDetailVm (data);

			//Bind data to form
			this.BindingContext = _viewModel;


			//Some entries don't have twitter entries...hide icon in that case
			if (data.Twitter == null || data.Twitter.Length == 0)
				twittericon.IsVisible = false;


			//Center map on city
//			MyMap.MoveToRegion(
//				MapSpan.FromCenterAndRadius(
//					new Position(data.GeoLocation.Lattitude,data.GeoLocation.Longitude), Distance.FromMiles(5)));
		}
			
	}
}

