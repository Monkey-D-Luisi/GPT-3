using MultiPlatform.Pages.Models;
using MultiPlatform.Services.Models.Abstractions;

namespace MultiPlatform.Pages
{
	public partial class MainPage : ContentPage
	{


		public MainPage()
		{
			InitializeComponent();
		}


		private void OnViewModelsClicked(object sender, EventArgs e)
		{
			var listModelsService = MultiPlatform.Services.ServiceProvider.GetService<IListModelsService>();
			var getModelService = MultiPlatform.Services.ServiceProvider.GetService<IGetModelService>();

			Navigation.PushAsync(new ModelsPage(listModelsService, getModelService));
		}
	}
}