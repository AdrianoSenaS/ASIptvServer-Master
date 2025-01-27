using ASMedia.Shared.Model.Naming;

namespace ASMedia.Shared.Interfaces.Naming
{
    public interface INaming
    {
        public NamingResponse GetNaming(NamingPathCreate naming);
    }
}
