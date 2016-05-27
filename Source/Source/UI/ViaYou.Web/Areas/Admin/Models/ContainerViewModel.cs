using ViaYou.Domain.Enums;
using ViaYou.Domain.Travels;
using ViaYou.Infraestructure.Mapping;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class ContainerViewModel : IMapFrom<Container>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public Measure Measure { get; set; }
    }
}