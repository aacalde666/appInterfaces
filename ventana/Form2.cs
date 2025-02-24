using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventana
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        private Form1 form1;

        public Form2 (Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            Fond1.Click += Fonds_Click;
            Fond2.Click += Fonds_Click;
            Fond3.Click += Fonds_Click;
            Fond4.Click += Fonds_Click;
        }
        public void Fonds_Click(object sender, EventArgs e)
        {
            // Validar que el sender sea un PictureBox
            if (!(sender is PictureBox clickedPictureBox))
                return;

            // Inicializar la imagen seleccionada
            Image selectedImage = null;

            // Determinar qué PictureBox fue clickeado
            if (clickedPictureBox == Fond1)
            {
                selectedImage = Properties.Resources.Warcraft_Rumble;
            }
            else if (clickedPictureBox == Fond2)
            {
                selectedImage = Properties.Resources._4J538SP3ZKNO1476725822156;
            }
            else if (clickedPictureBox == Fond3)
            {
                selectedImage = Properties.Resources.Overwatch;
            }
            else if (clickedPictureBox == Fond4)
            {
                selectedImage = Properties.Resources.Diablo_IV_Vessel_of_Hatred;
            }

            if (selectedImage == null)
                return;

            form1.fondo.Controls.Clear();

            var fondoGif = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = selectedImage,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            fondoGif.Click += form1.fondo_Click;

            form1.fondo.Controls.Add(fondoGif);
            fondoGif.SendToBack();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Desuscribir eventos y liberar imágenes
            Fond1.Click -= Fonds_Click;
            Fond2.Click -= Fonds_Click;
            Fond3.Click -= Fonds_Click;
            Fond4.Click -= Fonds_Click;

            Fond1.Image?.Dispose();
            Fond2.Image?.Dispose();
            Fond3.Image?.Dispose();
            Fond4.Image?.Dispose();
            form1.CerrarForm2();
        }

    }
}
