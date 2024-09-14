using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace FaceRecog
{
   public static class RecognitionLibs{

       public static void Detect(IInputArray imageArray, string faceFileName,  List<Rectangle> faces,  out long detectionTime)
       {
           using (var iaImage = imageArray.GetInputArray())
           {

#if !(__IOS__ || NETFX_CORE)
               Stopwatch watch;
               if (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda)
               {
                   
                   using (var face = new CudaCascadeClassifier(faceFileName))
                   {
                       face.ScaleFactor = 1.1;
                       face.MinNeighbors = 10;
                       face.MinObjectSize = Size.Empty;
                      
                       watch = Stopwatch.StartNew();
                       using (var gpuImage = new CudaImage<Bgr, byte>(imageArray))
                       using (var gpuGray = gpuImage.Convert<Gray, byte>())
                       using (var region = new GpuMat())
                       {
                          /* face.DetectMultiScale(gpuGray, region);
                           var faceRegion = face.Convert(region);
                           faces.AddRange(faceRegion);
                           foreach (var f in faceRegion)
                           {
                               using (var faceImg = gpuGray.GetSubRect(f))
                               {
                                   //For some reason a clone is required.
                                  
                              
                               }
                           } */
                       }
                      // watch.Stop();
                   }
               }
               else
#endif
               {
                   //Read the HaarCascade objects
                   using (var face = new CascadeClassifier(faceFileName))
                   {
                       watch = Stopwatch.StartNew();
                       using (var ugray = new UMat())
                       {
                           CvInvoke.CvtColor(imageArray, ugray, ColorConversion.Bgr2Gray);

                           //normalizes brightness and increases contrast of the imageArray
                           CvInvoke.EqualizeHist(ugray, ugray);

                           //Detect the faces  from the gray scale imageArray and store the locations as rectangle
                           //The first dimensional is the channel
                           //The second dimension is the index of the rectangle in the specific channel                     
                           var facesDetected = face.DetectMultiScale(ugray, 1.1, 10, new Size(20, 20));
                           faces.AddRange(facesDetected);
                          // foreach (var f in facesDetected)
                           //{
                               //Get the region of interest on the faces
                              // using (UMat faceRegion = new UMat(ugray, f))
                              // {

                               //}
                           //}
                       }
                    }
                    /* using (var eye = new CascadeClassifier(eyeFileName))
                     {
                         watch = Stopwatch.StartNew();

                         using (var ugray = new UMat())
                         {
                             CvInvoke.CvtColor(imageArray, ugray, ColorConversion.Bgr2Gray);

                             //normalizes brightness and increases contrast of the imageArray
                             CvInvoke.EqualizeHist(ugray, ugray);

                             //Detect the faces  from the gray scale imageArray and store the locations as rectangle
                             //The first dimensional is the channel
                             //The second dimension is the index of the rectangle in the specific channel                     
                             var facesDetected = face.DetectMultiScale(
                                 ugray,
                                 1.1,
                                 10,
                                 new Size(20, 20));

                             faces.AddRange(facesDetected);

                             foreach (var f in facesDetected)
                             {
                                 //Get the region of interest on the faces
                                 using (UMat faceRegion = new UMat(ugray, f))
                                 {

                                 }
                             }
                         }

                     } */
                    watch.Stop();
                }
               detectionTime = watch.ElapsedMilliseconds;
           }
       }


    }
}
