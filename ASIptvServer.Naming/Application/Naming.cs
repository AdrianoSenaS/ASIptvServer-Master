using ASMedia.Naming.Model;
using ASMedia.Naming.Interfaces;
using ASMedia.Shared.Naming;

namespace ASMedia.Naming.Application
{
    public class Naming
    {
        private readonly INamingString _name;
        public Naming(INamingString naming)
        {
            _name = naming;
        }

        public NamingResponse  GetNaming(NamingPathCreate naming)
        {
            if(naming != null)
            {
                NamingPathModel model = new NamingPathModel();
                NamingResponse response = new NamingResponse();
                model.Path = naming.Path;
                NamingModel namingModel = _name.SetNaming(model);
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
