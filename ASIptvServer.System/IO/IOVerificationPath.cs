namespace ASIptvServer.System.IO
{
    public class IOVerificationPath
    {
        public IOVerificationPath() { }
        public string OS { get; set; }
        public string PathRot { get; set; }
        public string PathData { get; set; }
        public string PathTemp { get; set; }
        public string PathTempData { get; set; }

        public IOVerificationPath(string os,
            string pathRoot,
            string pathData,
            string pathTemp,
            string pathTempData)
        {
            OS = os;
            PathRot = pathRoot;
            PathData = pathData;
            PathTemp = pathTemp;
            PathTempData = pathTempData;
        }
    }
}
