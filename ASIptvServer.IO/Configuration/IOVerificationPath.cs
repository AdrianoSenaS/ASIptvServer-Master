
namespace ASIptvServer.Configuration
{
    public class IOVerificationPath
    {
        public IOVerificationPath() { }
        public  string OS {  get; set; }
        public  string  PathRot { get; set; }
        public  string PathData { get; set; }
        public  string PathTemp {  get; set; }
        public  string PathTempData { get; set; }
       
        public IOVerificationPath(string os, 
            string pathRoot, 
            string pathData, 
            string pathTemp, 
            string pathTempData) 
        {
            this.OS = os;
            this.PathRot = pathRoot;
            this.PathData = pathData;
            this.PathTemp = pathTemp;
            this.PathTempData = pathTempData;
        }
    }
}
