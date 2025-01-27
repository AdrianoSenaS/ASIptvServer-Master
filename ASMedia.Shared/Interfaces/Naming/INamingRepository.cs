using ASMedia.Shared.Model.Naming;

namespace ASMedia.Shared.Interfaces.Naming
{
    public interface INamingRepository
    {
        public NamingResponse GetNaming(NamingPathCreate name);
    }
}
