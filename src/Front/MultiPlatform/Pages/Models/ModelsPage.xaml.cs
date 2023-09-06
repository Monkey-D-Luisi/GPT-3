using Client.Abstractions.DTOs.Models;
using MultiPlatform.Services.Models.Abstractions;

namespace MultiPlatform.Pages.Models;

public partial class ModelsPage : ContentPage
{


	private readonly IListModelsService listModelsService;
	private readonly IGetModelService getModelService;


	public ModelsPage(IListModelsService listModelsService, IGetModelService getModelService)
	{
		InitializeComponent();
		this.listModelsService = listModelsService;
		this.getModelService = getModelService;
	}


	protected override async void OnAppearing()
	{
		base.OnAppearing();

		activityIndicator.IsRunning = true;
		activityIndicator.IsVisible = true;
		listView.IsVisible = false;

		var models = await GetData();

		listView.ItemsSource = models;

		activityIndicator.IsRunning = false;
		activityIndicator.IsVisible = false;
		listView.IsVisible = true;
	}


	private async Task<IEnumerable<ModelDTO>> GetData()
	{
		return await listModelsService.ListModels();
	}


	private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
        if (e.SelectedItem is ModelDTO selectedModel)
        {
            await Navigation.PushAsync(new ModelDetailPage(getModelService, selectedModel.Id));
        }
    }
}