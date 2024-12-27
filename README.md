# A Scalable Multi-Device Face Recognition Attendance System with Offline Functionality

This project is a Windows Forms application that uses **EmguCV** (OpenCV wrapper for .NET) for face detection and recognition. It implements FisherFace recognition and uses a webcam, HD camera, or IP camera for real-time facial recognition.

## Features

- Real-time face detection using Haar Cascade Classifier.
- Face recognition using FisherFaceRecognizer from EmguCV.
- Ability to switch between different cameras (Webcam, HD Camera, IP Camera).
- Loading and training facial recognition models with custom datasets.
- Displaying detected faces and recognized individuals in a panel.
- Option to save trained models and load them for recognition.

## Requirements

- **Emgu.CV** (for computer vision functionalities).
- **Emgu.CV.UI** (for OpenCV user interface elements).
- **.NET Framework** (Windows Forms support).

### EmguCV Installation

To use this project, you need to install EmguCV libraries. You can install them via **NuGet Package Manager** in Visual Studio.

## How to Use

1. **Start Camera**: Choose between Webcam, HD Camera, or IP Camera to start capturing images for face detection and recognition.
   - Use the **Webcam** button for basic webcam usage.
   - Use the **HD Camera** or **IP Camera** for higher quality or remote cameras.
   
2. **Face Detection**: The application uses a Haar Cascade Classifier to detect faces in real-time from the video feed. Detected faces are outlined in red rectangles.

3. **Face Recognition**: Once faces are detected, the system attempts to recognize them using the FisherFaceRecognizer model. If recognized, it will display the person's ID and associated information on the interface.

4. **Load & Train Data**: You can load a dataset of images to train the FisherFaceRecognizer model for face recognition. The dataset should be placed in the following location:
   ```plaintext
   FaceRecog\FaceRecog\bin\Debug\trainingset
   ```
   Images in the dataset should be named in the format `PersonID_ImageNumber.bmp`.

5. **Saving Trained Model**: After training, the system saves the trained model to the path specified by `YlmPath` (constant in the project). The model can be loaded for future use.

### File Structure

- `frmMain.cs`: The main form handling the camera feed, face detection, and recognition.
- `frmTrain.cs`: A form used to train new facial data.
- `FaceRecog\FaceRecog\bin\Debug\trainingset`: Folder containing face images used to train the recognizer. Images should be in `.bmp` format.
- `Utils/`: Utility classes and constants used throughout the project.

## Usage Example

1. Launch the application by starting `FaceRecog.sln` in Visual Studio.
2. Choose a camera by clicking the **Webcam**, **HD Camera**, or **IP Camera** button.
3. Once a face is detected, it will display a red box around the face.
4. If the face is recognized, the ID and relevant details will be displayed.

## Dependencies

- **Emgu.CV**: A cross-platform .NET wrapper to the OpenCV library.
- **System.Windows.Forms**: For building the graphical user interface (GUI).
- **OpenCV**: Used for image processing and computer vision tasks.
- **.NET Framework**: The base framework for building and running the Windows application.

## Known Issues

- If the trained model is not loaded, face recognition may fail.
- Ensure that the camera is properly configured and connected to the system.
