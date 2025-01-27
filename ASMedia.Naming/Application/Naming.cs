using ASMedia.Naming.Model;
using ASMedia.Naming.Services;
using ASMedia.Shared.Model.Naming;
using ASMedia.Shared.Interfaces.Naming;

namespace ASMedia.Naming.Application
{
    public class Naming : INaming
    {
        public NamingResponse GetNaming(NamingPathCreate naming)
        {
            if(naming != null)
            {
                NamingPathModel model = new NamingPathModel();
                NamingResponse response = new NamingResponse();
                model.Path = naming.Path;
                NamingModel namingModel = NamingString.SetNaming(model);
                response.Name = namingModel.Name;
                response.Lang = namingModel.Lang;
                response.Year = namingModel.Year;
                response.IsSerie = namingModel.IsSerie;
                return response;
            }
            else
            {
                return new NamingResponse
                {
                    Name = "Não encontrado"
                };
            }
        }
    }
}
