using Controller;
using System;
using System.Windows.Forms;

namespace View
{
    public partial class ViewForm : Form
    {
        private ControllerInterface controlIF;
        private Model.ModelControl model;

        public ViewForm()
        {
            InitializeComponent();

            model = new Model.ModelControl();
            controlIF = new ControllerInterface(model);

            model.ImgUpdated += Model_CategoryUpdated; 
        }

        private void Model_CategoryUpdated(object sender, Model.ImgUpdatedEventArgs e)
        {
            // MessageBox.Show(this,e.category);
            using (pictureBox.Image){}
            pictureBox.Image = e.Bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controlIF.JudgeColor(comboBox1.SelectedItem.ToString());
        }
    }
}
