using System;
using Xamarin.Forms;

namespace Samples
{
	public class AniButton : Button
	{
		public AniButton() : base()
		{
			Clicked += async(sender, e) =>
			{
				await this.ScaleTo(1.2, 100);
				this.ScaleTo(1, 100);
			};
		}
	}
}

