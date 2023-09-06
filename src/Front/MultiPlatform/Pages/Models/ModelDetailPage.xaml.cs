using Client.Abstractions.DTOs.Models;
using MultiPlatform.Services.Models.Abstractions;

namespace MultiPlatform.Pages.Models;

public partial class ModelDetailPage : ContentPage
{


	private readonly IGetModelService getModelService;
	private readonly string selectedModelId;


	public ModelDetailPage(IGetModelService getModelService, string selectedModelId)
	{
		this.selectedModelId = selectedModelId;

		InitializeComponent();
		this.getModelService = getModelService;
	}


	protected override async void OnAppearing()
	{
		base.OnAppearing();

		activityIndicator.IsRunning = true;
		activityIndicator.IsVisible = true;
		itemView.IsVisible = false;

		var model = await GetData(selectedModelId);

		itemView.BindingContext = model;

		activityIndicator.IsRunning = false;
		activityIndicator.IsVisible = false;
		itemView.IsVisible = true;
	}


	private async Task<ModelDTO> GetData(string selectedModelId)
	{
		return await getModelService.GetModel(selectedModelId);
	}
}