using HelixToolkit.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace view3d
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnLoadModel_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "3D Model Files (*.fbx;*.obj;*.stl)|*.fbx;*.obj;*.stl";
            if (openFileDialog.ShowDialog() == true)
            {
                var model = new Model3DGroup();
                var loader = new ModelImporter();
                model = loader.Load(openFileDialog.FileName);
                modelVisual.Content = model;
            }
        }

        private void sliderRotationX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var rotation = new AxisAngleRotation3D(new Vector3D(1, 0, 0), sliderRotationX.Value);
            var transform = new RotateTransform3D(rotation);
            modelVisual.Transform = transform;
        }

        private void sliderRotationY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var rotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), sliderRotationY.Value);
            var transform = new RotateTransform3D(rotation);
            modelVisual.Transform = transform;
        }

        private void sliderRotationZ_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var rotation = new AxisAngleRotation3D(new Vector3D(0, 0, 1), sliderRotationZ.Value);
            var transform = new RotateTransform3D(rotation);
            modelVisual.Transform = transform;
        }

        private void sliderScale_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var scale = new ScaleTransform3D(sliderScale.Value, sliderScale.Value, sliderScale.Value);
            var transform = new Transform3DGroup();
            transform.Children.Add(scale);
            modelVisual.Transform = transform;
        }
    }
}
