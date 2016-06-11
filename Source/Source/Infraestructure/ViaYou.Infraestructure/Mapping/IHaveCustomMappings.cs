using AutoMapper;

namespace ViaYou.Infraestructure.Mapping
{
	public interface IHaveCustomMappings
	{
		void CreateMappings(IConfiguration configuration);
	}
}