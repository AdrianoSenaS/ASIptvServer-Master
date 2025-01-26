using ASMedia.Naming.Model;
using ASMedia.Naming.Interfaces;

namespace ASMedia.Naming.Application
{
    public class Naming
    {
        private readonly INamingString _name;
        public Naming(INamingString naming)
        {
            _name = naming;
        }

        public NamingModel GetNaming(NamingPathModel naming)
        {
            if(naming != null)
            {
                return _name.SetNaming(naming);
            }
            else
            {
                return new NamingModel
                {
                    Name = "Não encontrado"
                };
            }
        }
    }
}
