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
        private FaceRecognizer _faceRecognition;
        private Timer timer;
        private Mat _frameMat;
        private CascadeClassifier FaceDetection;
        private MCvScalar color;
        private List<Mat> matList;
        private List<int> personIds;
        private int timerCounter = 0;
        private int timeLimit = 20;
        private int ScanCounter = 0;

        public frmTrain()
        {
            InitializeComponent();

            // Use EigenFaceRecognizer for single person training
            _faceRecognition = new EigenFaceRecognizer();
            FaceDetection = new CascadeClassifier(UtilConstant.haarCudaDefault);

            _frameMat = new Mat();
            matList = new List<Mat>();
            personIds = new List<int>();

            InitializedCamera();
        }

        private void frmTrain_Load(object sender, EventArgs e)
        {
            int targetWidth = 1366;
            int targetHeight = 768;
            int originalWidth = 1944;
            int originalHeight = 986;
            float scaleWidth = (float)targetWidth / originalWidth;
            float scaleHeight = (float)targetHeight / originalHeight;

            Scale(new SizeF(scaleWidth, scaleHeight));
            Size = new Size(targetWidth, targetHeight);
            Location = new Point((Screen.PrimaryScreen.Bounds.Width - targetWidth) / 2,
                (Screen.PrimaryScreen.Bounds.Height - targetHeight) / 2);
        }

        private void InitializedCamera()
        {
            _capture = new VideoCapture(0);  // 0 refers to the default webcam
            _capture.SetCaptureProperty(CapProp.Fps, 30);
            _capture.ImageGrabbed += ActivateCamera;
            _capture.Start();
        }

        private Rectangle[] rectangles;

        private void ActivateCamera(object sender, EventArgs e)
        {
            _capture.Retrieve(_frameMat);
            var currentFrame = _frameMat.ToImage<Bgr, byte>().Resize(1080, 720, Inter.Cubic);
            var faceDetect = new CascadeClassifier(UtilConstant.haarFileFace);
            var facesDetected = faceDetect.DetectMultiScale(currentFrame, 1.2, 10, new Size(100, 100), Size.Empty);

            foreach (var faceRectangle in facesDetected)
            {
                currentFrame.Draw(faceRectangle, new Bgr(Color.Red), 2);
            }

            imgBox.Image = currentFrame.ToBitmap();
        }

        private void bntStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                txtID.Enabled = false;
                timer = new Timer { Interval = 500 };
                timer.Tick += Timer_Tick;
                timer.Start();
                bntTrain.Enabled = false;
            }
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
                    var faces = FaceDetection.DetectMultiScale(imageFrame, 1.2, 10, new Size(100, 100), Size.Empty);

                    if (faces.Any())
                    {
                        var processImage = imageFrame.Copy(faces[0])
                            .Resize(100, 100, Inter.Cubic);

                        // Add the face and person ID to their respective lists
                        matList.Add(processImage.Mat);
                        personIds.Add(Convert.ToInt32(txtID.Text));

                        ScanCounter++;
                        outputBox.AppendText($"{personIds.Count} scans taken... matList size: {matList.Count} {Environment.NewLine}");
                        outputBox.ScrollToCaret();

                        //Create an array of save images to database
                        //Create Profile Table - List names of images, id, name, course, college, age

                        // record nlng datetime each mo sulod ang student


                        //Create Time-in Table and Time-out
                        processImg.Image = processImage.ToBitmap();
                        processImage.Save($"trainingset/{txtID.Text}_{timerCounter}.bmp");
                    }
                }
            }
            else
            {
                if (matList.Count > 0)
                {
                    // Train the recognizer with the collected faces and person IDs
                    _faceRecognition.Train(matList.ToArray(), personIds.ToArray());
                    _faceRecognition.Write(UtilConstant.haarAlgorithm);  // Save the trained model

                    outputBox.AppendText($"Training completed! Number of training samples: {matList.Count}{Environment.NewLine}");
                    MessageBox.Show($"Training for ID {txtID.Text} successfully completed!");

                    ResetTraining();
                }
                else
                {
                    MessageBox.Show("No faces detected for training. Please try again.");
                    ResetTraining();
                }
            }
        }

        private void ResetTraining()
        {
            timer.Stop();
            timerCounter = 0;
            ScanCounter = 0;
            bntTrain.Enabled = true;
            txtID.Enabled = true;
            txtID.Clear();
            matList.Clear();
            personIds.Clear();
        }

        private void bntTrain_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                txtID.Enabled = false;
                timer = new Timer { Interval = 500 };
                timer.Tick += Timer_Tick;
                timer.Start();
                bntTrain.Enabled = false;
            }
        }
    }

}
