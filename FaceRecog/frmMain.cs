using System;
using System.CodeDom;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using FaceRecog.Libraries;
using Timer = System.Windows.Forms.Timer;
using FaceRecog;
using FaceRecog.Utils;

namespace FaceRecog
{
    public partial class frmMain : Form
    {
        public VideoCapture capture { get; set; }
        public EigenFaceRecognizer FaceRecognition;
        public FisherFaceRecognizer fisherFaceRecognizer;
        public CascadeClassifier FaceDetection { get; set; }
        public CascadeClassifier FaceProperty { get; set; }
        public Mat frameMat { get; set; }

        public List<Image<Bgr, byte>> Faces;
        public List<Mat> matList;

        private List<Image<Gray, byte>> _imgsList;
        private Image<Bgr, byte> _inputEmGuImage;    //EmguCV type color image
        private int[] _arrayNumber;
        private Boolean trainedImage { get; set; } = false;
        public List<int> personIds { get; set; }
        public int processImageWidth { get; set; } = 100;
        public int processImageHeight { get; set; } = 100;
        public int timerCounter { get; set; } = 0;
        public int timeLimit { get; set; } = 30;
        public int ScanCounter { get; set; } = 0;
        public const string YlmPath = UtilConstant.haarAlgorithm;
        public Timer timer { get; set; }
        public bool facesSquares { get; set; } = false;
        private Boolean regUser { get; set; } = false;
        private Image<Gray, byte> gray = null;
        private Image<Gray, byte> result, TrainedFace = null;
        int _facesCount = 0;
        int _facesPanelY = 0;
        int _facesPanelX = 0;

        internal bool grabstart = false;
        Thread tvthread;

        public frmMain()
        {
            InitializeComponent();
         //  FaceRecognition = new EigenFaceRecognizer(80, double.PositiveInfinity);
           fisherFaceRecognizer = new FisherFaceRecognizer(80, double.PositiveInfinity);
           FaceDetection = new CascadeClassifier(UtilConstant.haarCudaDefault); 
          
           Faces = new List<Image<Bgr, byte>>();
           matList = new List<Mat>();
           personIds = new List<int>();

            if (File.Exists(YlmPath))
            {
               // FaceRecognition.Read(YlmPath);
                fisherFaceRecognizer.Read(YlmPath);
            }

            tvthread = new Thread(InitCamera) { Priority = ThreadPriority.AboveNormal };
            tvthread.Start();

        }



        private void InitCamera()
        {
           
               capture = new VideoCapture(0);
              
               capture.SetCaptureProperty(CapProp.Fps, 55);
               facesSquares = !facesSquares;
               capture.ImageGrabbed += CaptureOnImageGrabbed;
               capture.Start();
        }

        //*****************************************
        private void CaptureWebCamera()
        {
            if (capture != null)
            {
                stop_capture();
                capture = new VideoCapture(0);
                capture.SetCaptureProperty(CapProp.Fps, 55);
                facesSquares = !facesSquares;
                splashManager.ClosingDelay = 50;
                splashManager.CloseWaitForm();
                capture.ImageGrabbed += CaptureOnImageGrabbed;
                capture.Start();

            }
        }


        private void CaptureHdCamera()
        {
           if(capture!=null)
           {
               stop_capture();
               capture = new VideoCapture(1);
               capture.SetCaptureProperty(CapProp.Fps, 55);
               facesSquares = !facesSquares;
               splashManager.ClosingDelay = 50;
               splashManager.CloseWaitForm();
                capture.ImageGrabbed += CaptureOnImageGrabbed;
               capture.Start();
               
           }
        }

        private void CaptureIpCamera()
        {
            if(capture!=null)
            {
               
                stop_capture();
                capture = new VideoCapture(UtilConstant.haarRemoteCamera);
                capture.SetCaptureProperty(CapProp.Fps, 55);
                facesSquares = !facesSquares;
                splashManager.ClosingDelay = 50;
                splashManager.CloseWaitForm();
                capture.ImageGrabbed += CaptureOnImageGrabbed;
                capture.Start();
            }
             
        }


        private void CaptureOnImageGrabbed(object sender, EventArgs eventArgs)
        {
               GC.AddMemoryPressure(128);
               frameMat = new Mat();
            //var rectangleFaces = new List<Rectangle>();
            //long detectionTime;
            if (capture != null)
            {
               
                capture.Retrieve(frameMat);
                var currentFrame = frameMat.ToImage<Bgr, byte>();
                var grayFrame = currentFrame.Convert<Gray, byte>();
                if (facesSquares)
                {
                    var facesDetected = FaceDetection.DetectMultiScale(grayFrame, 1.2,
                                                    10,
                                                    new Size(100, 100),
                                                    Size.Empty);
                    foreach (var faceRectangle in facesDetected)
                    {
                        if (facesDetected.Length == 0) continue;
                        var processImage = grayFrame.Copy(faceRectangle).Resize(processImageWidth, processImageHeight, Inter.Cubic);
                        processImage._EqualizeHist();
                        currentFrame.Draw(faceRectangle, new Bgr(Color.Red), 2);
                        // var recognicerFace = FaceRecognition.Predict(processImage);
                        try
                        {
                            var recognicerFace = fisherFaceRecognizer.Predict(processImage);
                            var personId = recognicerFace.Label.ToString();
                            if (!string.IsNullOrEmpty(personId))
                            {
                                try
                                {
                                    currentFrame.Draw(@"ID: " + personId, new Point(faceRectangle.Location.X + 10, faceRectangle.Location.Y - 10), FontFace.HersheyComplex, 1, new Bgr(Color.Cyan));
                                    processImg.Image = Image.FromFile("trainingset/" + personId + UtilConstant.haarImageExtension);

                                    Invoke(new Action(() =>
                                    {
                                        txtID.Text = personId;
                                        outputBox.AppendText($"Detected ID: {personId} {Environment.NewLine}");
                                        outputBox.ScrollToCaret();
                                        AddFacesPanel(processImage, personId, 1);
                                    }));
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }


                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(@"FisherRecognizer Model not train yet please load before begin scanning",
                                @"FisherRecognizer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        
                    }
                }

                imgBox.Image = currentFrame.ToBitmap();

                GC.RemoveMemoryPressure(128);
                GC.Collect();
            }
               

        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            if (txtID.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {
                outputBox.Text = text;
                txtID.Text = text;
            }
        }



        internal void stop_capture()
        {
            Thread.Sleep(100);
            grabstart = false;
            try
            {
                while (tvthread.IsAlive) tvthread.Abort();
            }
            catch { }

            Thread.Sleep(100);
            try
            {
                capture.Dispose();
            }
            catch { }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // InitCamera();
            // TestCudaFASTDetector();
            /*
            int targetWidth = 1366;
            int targetHeight = 768;
            int originalWidth = 1960;
            int originalHeight = 1078;
            float scaleWidth = (float)targetWidth / originalWidth;
            float scaleHeight = (float)targetHeight / originalHeight;

            Scale(new SizeF(scaleWidth, scaleHeight));
            Size = new Size(targetWidth, targetHeight);
            Location = new Point((Screen.PrimaryScreen.Bounds.Width - targetWidth) / 2,
                (Screen.PrimaryScreen.Bounds.Height - targetHeight) / 2);
            */
        }

     /*   public void TestCudaFASTDetector()
        {
            if (!CudaInvoke.HasCuda)
                MessageBox.Show(@"No cuda found!");
            using (var img = new Image<Bgr, byte>(@"D:\yearbook.jpg"))
            using (var cudaImage = new CudaImage<Bgr, byte>(img))
            using (var grayCudaImage = cudaImage.Convert<Gray, byte>())
            using (var featureDetector = new CudaFastFeatureDetector(10, true, FastFeatureDetector.DetectorType.Type9_16, 1000))
            using (var kpts = new VectorOfKeyPoint())
            using (var keyPointsMat = new GpuMat())
            {
                featureDetector.DetectAsync(grayCudaImage, keyPointsMat);
                featureDetector.Convert(keyPointsMat, kpts);
                //featureDetector.DetectKeyPointsRaw(grayCudaImage, null, keyPointsMat);

                //featureDetector.DownloadKeypoints(keyPointsMat, kpts);

                foreach (var kpt in kpts.ToArray())
                {
                    img.Draw(new CircleF(kpt.Point, 3.0f), new Bgr(0, 255, 0), 1);
                }

               // imgBox.Image = img;
                ImageViewer.Show(img);
            }  
        } */



        private void ActivateCamera(object sender, EventArgs e){
            if (capture == null || capture.Ptr == IntPtr.Zero) return;
                capture.Retrieve(frameMat, 1);
            //imgBox.Image = frameMat;
            var image = frameMat.ToImage<Bgr, Byte>();
            long detectionTime;
            var faces = new List<Rectangle>();
            startCam(image, UtilConstant.haarCudaDefault, faces);
            foreach (var face in faces) CvInvoke.Rectangle(image, face, new Bgr(Color.Firebrick).MCvScalar, 2);
            //display the image 
            using (var iaImage = image.GetInputArray())
            {
                imgBox.Image = image.Bitmap;
            }

           
        }




     
        private void ReleaseData()
        {
            capture?.Dispose();

        }

        

        

        private void frmFaces_Click(object sender, EventArgs e)
        {
           
           
        }

        private void bntRecognize_Click(object sender, EventArgs e)
        {
            var frm = new frmTrain();
            if (capture!=null)
            {
                capture.ImageGrabbed -= ActivateCamera;
                capture.Stop();
            }
            frm.Show();
           
            facesSquares = false;
            regUser = true;
           





        }

        private void ClearCamera()
        {
            outputBox.Clear();
            processImg.Image = null;
            ClearPanel();
            if (capture != null)
            {
               // capture.ImageGrabbed -= CaptureOnImageGrabbed;
                capture.Stop();
                imgBox.Image = null;
                facesSquares = false;
                frameMat.Dispose();
            }
           
        }



      

        

        private void Load_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(
                        @"WARNING: this will delete the existing data! Are you sure you would like contineu?",
                        @"REWRITE DATA",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                if (File.Exists(YlmPath))
                {
                    File.Delete(YlmPath);
                    LoadData();
                    trainedImage = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void SplitDataset(List<Mat> mats, int[] ids, out List<Mat> trainMats, out List<int> trainIds, out List<Mat> valMats, out List<int> valIds)
        {
            trainMats = new List<Mat>();
            trainIds = new List<int>();
            valMats = new List<Mat>();
            valIds = new List<int>();

            // Perform 80-20 split
            int splitIndex = (int)(mats.Count * 0.8);

            trainMats = mats.Take(splitIndex).ToList();
            trainIds = ids.Take(splitIndex).ToList();
            valMats = mats.Skip(splitIndex).ToList();
            valIds = ids.Skip(splitIndex).ToList();
        }
        private void EvaluateModel(List<Mat> valMats, List<int> valIds)
        {
            int total = valMats.Count;
            int correct = 0;

            Dictionary<int, int> truePositives = new Dictionary<int, int>();
            Dictionary<int, int> falsePositives = new Dictionary<int, int>();
            Dictionary<int, int> falseNegatives = new Dictionary<int, int>();

            // Initialize metrics for each unique label
            foreach (int label in valIds.Distinct())
            {
                truePositives[label] = 0;
                falsePositives[label] = 0;
                falseNegatives[label] = 0;
            }

            // Evaluate predictions
            for (int i = 0; i < total; i++)
            {
                Mat img = valMats[i];
                int trueLabel = valIds[i];
                int predictedLabel = fisherFaceRecognizer.Predict(img).Label;

                if (predictedLabel == trueLabel)
                {
                    correct++;
                    truePositives[trueLabel]++;
                }
                else
                {
                    if (!falsePositives.ContainsKey(predictedLabel))
                        falsePositives[predictedLabel] = 0;
                    if (!falseNegatives.ContainsKey(trueLabel))
                        falseNegatives[trueLabel] = 0;

                    falsePositives[predictedLabel]++;
                    falseNegatives[trueLabel]++;
                }
            }

            // Calculate overall accuracy
            double accuracy = (double)correct / total * 100;
            string message = $"Validation Accuracy: {accuracy:F2}%\n\n";

            // Calculate precision, recall, and F1 score for each label
            foreach (int label in truePositives.Keys)
            {
                int tp = truePositives[label];
                int fp = falsePositives.ContainsKey(label) ? falsePositives[label] : 0;
                int fn = falseNegatives.ContainsKey(label) ? falseNegatives[label] : 0;

                double precision = tp + fp > 0 ? (double)tp / (tp + fp) : 0;
                double recall = tp + fn > 0 ? (double)tp / (tp + fn) : 0;
                double f1Score = precision + recall > 0 ? 2 * (precision * recall) / (precision + recall) : 0;

                message += $"Label: {label}\n";
                message += $"  - Precision: {precision:P2}\n";
                message += $"  - Recall: {recall:P2}\n";
                message += $"  - F1 Score: {f1Score:P2}\n\n";
            }

            // Show results in a MessageBox
            MessageBox.Show(message, "Model Evaluation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private async Task LoadData()
        {
            outputBox.Clear();

            var i = 0;
            var itemData = Directory.EnumerateFiles("trainingset/", "*.bmp");
            var enumerable = itemData as IList<string> ?? itemData.ToList();
            var total = enumerable.Count();
            _arrayNumber = new int[total];
            var listMat = new List<Mat>();
            
            foreach (var file in enumerable)
            {
                var inputImg = Image.FromFile(file);
                _inputEmGuImage = new Image<Bgr, byte>(new Bitmap(inputImg));
                var imgGray = _inputEmGuImage.Convert<Gray, byte>();
                listMat.Add(imgGray.Mat);
                var number = file.Split('/')[1].ToString().Split('_')[0];
                if (number != "")
                {
                    _arrayNumber[i] = int.Parse(number);
                }
                i++;
                processImg.Image = _inputEmGuImage.ToBitmap();
                outputBox.AppendText($"Person Id: {number} {Environment.NewLine}");
                if (total == i)
                {
                    splashManager.ShowWaitForm();
                    SplitDataset(listMat, _arrayNumber, out var trainMats, out var trainIds, out var valMats, out var valIds);

                    fisherFaceRecognizer.Train(listMat.ToArray(), _arrayNumber);
                    fisherFaceRecognizer.Write(YlmPath);
                   // FaceRecognition.Train(listMat.ToArray(), _arrayNumber);
                   // FaceRecognition.Write(YlmPath);
                    splashManager.CloseWaitForm();

                    EvaluateModel(valMats, valIds);

                    MessageBox.Show(@"Total of " + _arrayNumber.Length + @" successfully loaded");
                    bntHdCamera.Enabled = true;
                    bntIpCamera.Enabled = true;
                }
                await Task.Delay(1);
            }
        }

        private void startCam(IInputArray imageArray, string faceFileName, List<Rectangle> faces)
        {
           // Stopwatch watch;
            using (var iaImage = imageArray.GetInputArray())
            {
                
                using (var face = new CascadeClassifier(faceFileName))
                {
                  //  watch = Stopwatch.StartNew();
                    using (var ugray = new UMat())
                    {
                        CvInvoke.CvtColor(imageArray, ugray, ColorConversion.Bgr2Gray);

                        CvInvoke.EqualizeHist(ugray, ugray);

                        var facesDetected = face.DetectMultiScale(ugray, 1.1, 10, new Size(20, 20));

                        faces.AddRange(facesDetected);

                    }
                }
            }
           // detectionTime = watch.ElapsedMilliseconds;
        }

        private void ClearPanel()
        {
            panelControl.Controls.Clear();
            _facesCount = 0;
            _facesPanelY = 0;
            _facesPanelX = 0;
        }

        private void AddFacesPanel(Image<Gray, byte> imFound, string namePerson, int matchValue)
        {
            var pictureBox = new PictureBox
            {
                Location = new Point(_facesPanelX, _facesPanelY),
                Height = 100,
                Width = 100,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = imFound.ToBitmap()
            };
            var personLabel = new Label
            {
                Text = namePerson,
                Location = new Point(_facesPanelX, _facesPanelY + 100),
                Height = 15
            };

            panelControl.Controls.Add(pictureBox);
            panelControl.Controls.Add(personLabel);

            _facesCount++;
            if (_facesCount == 2)
            {
                _facesPanelX = 0;
                _facesPanelY += 120;
                _facesCount = 0;
            }
            else _facesPanelX += 120;

            if (panelControl.Controls.Count > 10)
            {
                ClearPanel();
            }
        }

        private void bntHdCamera_Click(object sender, EventArgs e)
        {
            splashManager.ShowWaitForm();
            bntHdCamera.Enabled = false;
            bntWebCamera.Enabled = true;
            bntIpCamera.Enabled = true;
            ClearCamera();
            CaptureHdCamera();
        }

        private void bntWebCamera_Click(object sender, EventArgs e)
        {
            splashManager.ShowWaitForm();
            bntHdCamera.Enabled = true;
            bntWebCamera.Enabled = false;
            bntIpCamera.Enabled = true;
            ClearCamera();
            CaptureWebCamera();
        }

        private void bntIpCamera_Click(object sender, EventArgs e)
        {
            splashManager.ShowWaitForm();
            bntHdCamera.Enabled = true;
            bntWebCamera.Enabled = true;
            bntIpCamera.Enabled = false;
            ClearCamera();
            CaptureIpCamera();
        }
        private void bntLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(
                        @"WARNING: this will delete the existing data! Are you sure you would like continue?",
                        @"REWRITE DATA",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                bntHdCamera.Enabled = false;
                bntIpCamera.Enabled = false;
                if (File.Exists(YlmPath))
                {
                    File.Delete(YlmPath);
                    LoadData();
                    trainedImage = true;
                }
                else
                {
                    LoadData();
                    trainedImage = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void bntDelete_Click(object sender, EventArgs e)
        {

        }

        private void bntRegister_Click(object sender, EventArgs e)
        {
            var frm = new frmTrain();
            if (capture != null)
            {
                ClearCamera();
                capture.ImageGrabbed -= ActivateCamera;
                capture.Stop();
            }
            frm.Show();

            facesSquares = false;
            regUser = true;
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            outputBox.Clear();
            processImg.Image = null;
            ClearPanel();
        }

        private void cmbDelete_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
