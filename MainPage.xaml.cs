using goniometer.model;
using goniometer.view;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Capture;


namespace goniometer
{
    public sealed partial class MainPage : Page
    {
        DrawOnCanvas drawOnCanvas;
        MediaCapture takePhotoManager;
        private static bool isDemonstrate = false;

        public MainPage()
        {
            this.InitializeComponent();
            initializeCamera();
            drawOnCanvas = new DrawOnCanvas(MyCanvas);
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void initializeCamera()
        {
            takePhotoManager = new MediaCapture();
            await takePhotoManager.InitializeAsync();
            cameraPreview.Source = takePhotoManager;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MyCanvas.Children.Clear();
            Point point = e.GetCurrentPoint(MyCanvas).Position;
            drawOnCanvas.touching(point);
            textAngle.Text = AngleCounter.calculateAngle(point, MyCanvas) + "'";
        }

        private async void Camera_Click(object sender, RoutedEventArgs e)
        {
            if (!isDemonstrate)
                await takePhotoManager.StartPreviewAsync();
            else
                await takePhotoManager.StopPreviewAsync();
            isDemonstrate = !isDemonstrate;
        }
    }
}
