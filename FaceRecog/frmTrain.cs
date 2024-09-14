using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using FaceRecog.Libraries;

namespace FaceRecog
{
    public partial class frmTrain : Form
    {

        private CascadeClassifier _classifier;
        private VideoCapture _capture;
        private FisherFaceRecognizer _faceRecognition;
        private Timer timer;
        private Mat _frameMat;
        private CascadeClassifier FaceDetection;
        private MCvScalar color;
        public frmTrain()
        {
            InitializeComponent();
            _faceRecognition = new FisherFaceRecognizer(80, double.PositiveInfinity);
            FaceDetection = new CascadeClassifier(UtilConstant.haarCudaDefault);
         
            _frameMat = new Mat();
            matList = new List<Mat>();
            personIds = new List<int>();


            InitializedCamera();
        }

        private void frmTrain_Load(object sender, EventArgs e)
        {

        }

        private void InitializedCamera()
        {
            _capture = new VideoCapture(UtilConstant.haarRemoteCamera);
            _capture.SetCaptureProperty(CapProp.Fps, 55);
            _capture.ImageGrabbed += ActivateCamera;
            _capture.Start();
        }

        private Rectangle[] rectangles;

        private void ActivateCamera(object sender, EventArgs e)
        {
            _capture.Retrieve(_frameMat);
            var currentFrame = _frameMat.ToImage<Bgr, byte>().Resize(1080, 720, Emgu.CV.CvEnum.Inter.Cubic);
            var faceDetect = new CascadeClassifier(UtilConstant.haarFileFace);
            var facesDetected = faceDetect.DetectMultiScale(currentFrame, 1.2,
                10,
                new Size(100, 100),
                Size.Empty);
            foreach (var faceRectangle in facesDetected)
            {
                currentFrame.Draw(faceRectangle, new Bgr(Color.Red), 2);
            }


                imgBox.Image = currentFrame.ToBitmap();
        }

        private void bntStart_Click(object sender, EventArgs e)
        {
            if (txtID.Text != string.Empty)
            {
                txtID.Enabled = !txtID.Enabled;
                timer = new Timer { Interval = 500 };
                timer.Tick += Timer_Tick;
                timer.Start();
                bntTrain.Enabled = !bntTrain.Enabled;
            }
        }

        private int timerCounter;
        public int timeLimit { get; set; } = 20;
        private int processImageWidth =100, processImageHeight = 100;
        public int ScanCounter { get; set; } = 0;
        public List<int> personIds { get; set; }
        public List<Mat> matList;
        public const string YlmPath = UtilConstant.haarAlgorithm;

        private void frmTrain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

       

        private void Timer_Tick(object sender, EventArgs e)
        {
            _capture.Retrieve(_frameMat);
            var imageFrame = _frameMat.ToImage<Gray, byte>();
            if (timerCounter < timeLimit)
            {
                timerCounter++;
                if (imageFrame != null)
                {
                    var faces = FaceDetection.DetectMultiScale(imageFrame, 1.2,
                        10,
                        new Size(100, 100),
                        Size.Empty);  
                    if (faces.Any())
                    {
                        var processImage = imageFrame.Copy(faces[0])
                            .Resize(100, 100, Inter.Cubic);
                        matList.Add(processImage.Mat);
                        personIds.Add(Convert.ToInt32(txtID.Text));
                        ScanCounter++;
                        outputBox.AppendText($"{personIds.Count} Successfully scan taken... matList {matList.Count} {Environment.NewLine}");
                        outputBox.ScrollToCaret();
                        processImg.Image = processImage.ToBitmap();
                        processImage.Save("trainingset/" + txtID.Text + @"_" + timerCounter + ".bmp");
                    }

                }

            }
            else
            {

                _faceRecognition.Train(matList.ToArray(), personIds.ToArray());
                _faceRecognition.Write(YlmPath);
                timer.Stop();
                // facesSquares = false;
                timerCounter = 0;
                ScanCounter = 0;
                bntTrain.Enabled = !bntTrain.Enabled;
                txtID.Enabled = !txtID.Enabled;
                outputBox.AppendText($"Training mat! {matList.Count}  {Environment.NewLine}");
                MessageBox.Show(@"Trained " + txtID.Text.ToString() + @" successfully completed!");
              //  txtName.Clear();
                txtID.Clear();
            }
        }

      

        private void bntTrain_Click(object sender, EventArgs e)
        {
            if (txtID.Text != string.Empty)
            {
                txtID.Enabled = !txtID.Enabled;
                timer = new Timer { Interval = 500 };
                timer.Tick += Timer_Tick;
                timer.Start();
                bntTrain.Enabled = !bntTrain.Enabled;
            }
        }

        private void bntHdCamera_Click(object sender, EventArgs e)
        {

        }

        private void bntWebCamera_Click(object sender, EventArgs e)
        {

        }

        private void bntIpCamera_Click(object sender, EventArgs e)
        {

        }
    }
}
