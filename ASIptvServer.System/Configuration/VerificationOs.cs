﻿using System.Runtime.InteropServices;
using ASIptvServer.System.IO;
namespace ASIptvServer.System.Configuration
{
    public interface IVerification
    {
        IOVerificationPath Verification();
    }
    public class VerificationOs : IVerification
    {
        public IOVerificationPath Verification()
        {
            IOVerificationPath iOVerificationPaths = new IOVerificationPath();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                iOVerificationPaths.OS = "Windows";
                iOVerificationPaths.PathRot = IOpathWindows.PathRoot;
                iOVerificationPaths.PathData = IOpathWindows.PathData;
                iOVerificationPaths.PathTemp = IOpathWindows.PathTemp;
                iOVerificationPaths.PathTempData = IOpathWindows.PathTempData;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                iOVerificationPaths.OS = "Linux";
                iOVerificationPaths.PathRot = IOpathLinux.PathRoot;
                iOVerificationPaths.PathData = IOpathLinux.PathData;
                iOVerificationPaths.PathTemp = IOpathLinux.PathTemp;
                iOVerificationPaths.PathTempData = IOpathLinux.PathTempData;
            }
            return iOVerificationPaths;
        }
    }
}
