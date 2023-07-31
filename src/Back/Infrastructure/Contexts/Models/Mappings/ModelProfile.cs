using AutoMapper;
using Client.Abstractions.DTOs.Models;
using Infrastructure.Contexts.Models.Services.DTOs;

namespace Infrastructure.Contexts.Models.Mappings
{
	public class ModelProfile : Profile
	{


		public ModelProfile()
		{
			CreateMap<OpenAiModelDTO, ModelDTO>();
		}
	}
}
