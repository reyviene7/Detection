using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecog.Libraries
{
  public static class UtilConstant
  {
     public const string haarFileFace = @"D:\Utils\haarcascades\haarcascade_frontalface_default.xml";
     public const string haarExtended = @"D:\Utils\haarcascades\haarcascade_profileface.xml";
     public const string haarFileEye = @"D:\Utils\haarcascades\haarcascade_eye.xml";
     public const string haarAlgorithm = @"D:\Utils\Sources\algorithm\trainingData.yml";
     public const string haarImageExtension = @"_1.bmp";
     public const string haarRemoteCamera = @"http://192.168.0.127/asp/video.cgi?profile=3&resolution=1080p&random=0.3507861196682971";
     public const string haarRemoteSecure = @"rtsp://10.10.56.243:554/av0_0";
      public const int haarDefaultCamera = 0;
      public const string haarCudaDefault = @"D:\Utils\haarcascades_cuda\haarcascade_frontalface_default.xml";
  }
}
