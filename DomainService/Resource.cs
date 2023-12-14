using Microsoft.Extensions.Localization;
using static DomainService.Resource;

namespace DomainService
{
    public class Resource : IResource
    {
        private readonly IStringLocalizer<Resource> Localizer;
        public Resource(IStringLocalizer<Resource> localizer)
        {
            Localizer = localizer;
        }
        public string GetValue(string clave)
        {
            return Localizer[clave];
        }
        public interface IResource
        {
            string GetValue(string clave);
        }
    }
}
