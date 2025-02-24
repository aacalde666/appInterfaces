using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventana.UsersControl;

namespace ventana
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Form2 nuevoFormulario;
        private mainFrom mainFrom;
        private SQL sql;
        private ventanaAdminForm adminForm;
        string user;
        BibliotecaControl b;
        CestaControl cs;
        MainCatalogo cuf;

        public Form1(mainFrom mainFrom, String user, SQL sql)
        {
            InitializeComponent();
            this.user = user;
            this.mainFrom = mainFrom;
            this.sql = sql;
            btnPerfil.Text = user;
            btnAdmin.Hide();
            if (sql.VerSiESUserOAdmin(user).Equals("admin"))
            {
                btnAdmin.Show();
            }
            else if (sql.VerSiESUserOAdmin(user).Equals("owner"))
            {
                btnAdmin.Text = "Owner";
                btnAdmin.Show();
            }
            b = new BibliotecaControl(sql, user);
            cs = new CestaControl(sql, user);
            cuf = new MainCatalogo(sql, user);
            adminForm = new ventanaAdminForm(this, user, btnAdmin.Text, cuf);
        }
        private void imagenesInvisible()
        {
            IMGVand.Visible = false;
            IMGOver1.Visible = false;
            IMGOver2.Visible = false;
            IMGOver3.Visible = false;
            IMGDivIV1.Visible = false;
            IMGDivIV2.Visible = false;
            IMGDivIV3.Visible = false;
        }
        private void btnTienda_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.shop.battle.net/es-es") { UseShellExecute = true });
        }

        private void btnComunidad_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.forums.blizzard.com/es/blizzard/c/feedback-discussion/5/l/latest") { UseShellExecute = true });
        }

        private void btnSoporte_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.battle.net/support") { UseShellExecute = true });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel.Dock = DockStyle.Fill;
            fondo.Dock = DockStyle.Fill;
            btnPerfil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSoporte.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnComunidad.Anchor = AnchorStyles.Top;
            btnTienda.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            listPerfil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            listBattle.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            PLotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelLotes.Anchor = AnchorStyles.Top;
            panelTituloLotes.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            GrupoLotes.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            IMGVand.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            IMGOver1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            IMGOver2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
            IMGOver3.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            IMGDivIV1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            IMGDivIV2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
            IMGDivIV3.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelCatalogo.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listPerfil.Visible = false;
            PLotes.Visible = false;
            PVD.Visible = false;
            PUL.Visible = false;
            POfer.Visible = false;
            panelCatalogo.Visible = false;
            panelCesta.Visible = false;
            imagenesInvisible();
        }

        private void List_Click(object sender, EventArgs e)
        {
            if (listPerfil.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listPerfil.SelectedItems[0];
                string url = selectedItem.Tag as string;
                if (url.Equals("Close"))
                {
                    mainFrom.Show();
                    this.Dispose();
                }
                else if (url.Equals("Cesta"))
                {
                    cs.Dock = DockStyle.Fill;  // Ajusta el control al tamaño del panel
                    this.panelCesta.Controls.Add(cs);
                    cs.actualizarCesta();
                    panelCesta.Visible = true;
                }
                else if (url.Equals("Biblioteca"))
                {
                    this.panelCatalogo.Controls.Clear();
                    b.Dock = DockStyle.Fill;
                    this.panelCatalogo.Controls.Add(b);
                    b.actualizarBiblioteca();
                    panelCatalogo.Visible = true;
                }
                else
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al abrir la URL: {ex.Message}");
                    }
                }
            }
        }

        private void btnPerfil_Off(object sender, EventArgs e)
        {
            listPerfil.Visible = false;
        }

        public void fondo_Click(object sender, EventArgs e)
        {
            listPerfil.Visible = false;
            PLotes.Visible = false;
            PVD.Visible = false;
            PUL.Visible = false;
            POfer.Visible = false;
            panelCatalogo.Visible = false;
            panelCesta.Visible = false;
        }

        private void btnPerfil_Click_1(object sender, EventArgs e)
        {
            listPerfil.Visible = true;
        }

        private void PLotes_Click(object sender, EventArgs e)
        {
            listPerfil.Visible = false;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            listPerfil.Visible = false;
        }

        private void ListBatle_Click(object sender, EventArgs e)
        {
            if (listBattle.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listBattle.SelectedItems[0];
                if (selectedItem.Tag.Equals("Lotes"))
                {
                    imagenesInvisible();
                    PLotes.Visible = true;
                    PVD.Visible = false;
                    PUL.Visible = false;
                    POfer.Visible = false;
                    panelCatalogo.Visible = false;
                    panelCesta.Visible = false;
                }
                else if (selectedItem.Tag.Equals("VidDest"))
                {
                    imagenesInvisible();
                    PLotes.Visible = false;
                    PVD.Visible = true;
                    PUL.Visible = false;
                    POfer.Visible = false;
                    panelCatalogo.Visible = false;
                    panelCesta.Visible = false;
                }
                else if (selectedItem.Tag.Equals("UltLand"))
                {
                    imagenesInvisible();
                    PLotes.Visible = false;
                    PVD.Visible = false;
                    PUL.Visible = true;
                    POfer.Visible = false;
                    panelCatalogo.Visible = false;
                    panelCesta.Visible = false;
                }
                else if (selectedItem.Tag.Equals("Ofert"))
                {
                    imagenesInvisible();
                    PLotes.Visible = false;
                    PVD.Visible = false;
                    PUL.Visible = false;
                    POfer.Visible = true;
                    panelCatalogo.Visible = false;
                    panelCesta.Visible = false;

                }
                else if (selectedItem.Tag.Equals("Cat"))
                {
                    imagenesInvisible();
                    PLotes.Visible = false;
                    PVD.Visible = false;
                    PUL.Visible = false;
                    POfer.Visible = false;
                    panelCesta.Visible = false;
                    this.panelCatalogo.Controls.Clear();
                    if (cuf == null || cuf.IsDisposed)
                    {
                       cuf = new MainCatalogo(sql, user);
                    }
                    if (!sql.VerSiESUserOAdmin(user).Equals("user"))
                    {
                        if (string.IsNullOrEmpty(clave))
                        {
                            clave = InputBoxForm.Show("CLAVE", "Introduce tu clave: ");
                        }
                        if (sql.VerClave(user, clave))
                        {
                            cuf.Dock = DockStyle.Fill;  // Ajusta el control al tamaño del panel
                            this.panelCatalogo.Controls.Add(cuf);
                        }
                        else
                        {
                            MessageBox.Show("Clave incorrecta");
                        }
                    }
                    else
                    {
                        cuf.Dock = DockStyle.Fill;
                        this.panelCatalogo.Controls.Add(cuf);
                    }
                    panelCatalogo.Visible = true;
                }
                else if (selectedItem.Tag.Equals("Avt"))
                {
                    imagenesInvisible();
                    PLotes.Visible = false;
                    PVD.Visible = false;
                    PUL.Visible = false;
                    POfer.Visible = false;
                    panelCatalogo.Visible = false;
                    panelCesta.Visible = false;
                }
                else if (selectedItem.Tag.Equals("Fond"))
                {
                    imagenesInvisible();
                    PLotes.Visible = false;
                    PVD.Visible = false;
                    PUL.Visible = false;
                    POfer.Visible = false;
                    panelCatalogo.Visible = false;
                    panelCesta.Visible = false;
                    nuevoFormulario = new Form2(this);
                    nuevoFormulario.FormClosing += Form2_FormClosing;
                    nuevoFormulario.Show();
                }
                else if (selectedItem.Tag.Equals("Prem"))
                {
                    imagenesInvisible();
                    PLotes.Visible = false;
                    PVD.Visible = false;
                    PUL.Visible = false;
                    POfer.Visible = false;
                    panelCatalogo.Visible = false;
                    panelCesta.Visible = false;
                }
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Llamar a Dispose para liberar recursos de Form2
            nuevoFormulario.Dispose();
            nuevoFormulario = null;
        }
        public void CerrarForm2()
        {
            if (nuevoFormulario != null)
            {
                nuevoFormulario.Close(); // Cierra el formulario
                nuevoFormulario.Dispose(); // Libera los recursos
                nuevoFormulario = null; // Limpia la referencia
            }
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://battle.net") { UseShellExecute = true });
        }

        private void GrupoLotes_Click(object sender, EventArgs e)
        {
            listPerfil.Visible = false;
            IMGVand.Visible = false;
        }

        private void CoDV_Click(object sender, EventArgs e)
        {
            IMGVand.Visible = true;
            IMGOver1.Visible = false;
            IMGOver2.Visible = false;
            IMGOver3.Visible = false;
            IMGDivIV1.Visible = false;
            IMGDivIV2.Visible = false;
            IMGDivIV3.Visible = false;
        }
        private void IMGVand_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.shop.battle.net/es-mx/product/call-of-duty-vanguard-code-gift-of-honor") { UseShellExecute = true });
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.shop.battle.net/es-mx/product/call-of-duty-vanguard-code-gift-of-honor") { UseShellExecute = true });
        }

        private void IMGOver1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.shop.battle.net/es-mx/product/overwatch-ultimate-bundle") { UseShellExecute = true });
        }

        private void IMGOver2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.shop.battle.net/es-mx/product/overwatch-invasion-bundle") { UseShellExecute = true });
        }

        private void IMGOver3_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.shop.battle.net/es-mx/product/overwatch-ana-mythic-weapon-skin-bundle") { UseShellExecute = true });
        }

        private void Overw_Click(object sender, EventArgs e)
        {
            IMGOver1.Visible = true;
            IMGOver2.Visible = true;
            IMGOver3.Visible = true;
            IMGVand.Visible = false;
            IMGDivIV1.Visible = false;
            IMGDivIV2.Visible = false;
            IMGDivIV3.Visible = false;
        }

        private void IMGDivIV1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.shop.battle.net/es-mx/family/diablo-iv/items/1446839/eye-of-zakarum") { UseShellExecute = true });
        }

        private void IMGDivIV2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.shop.battle.net/es-mx/family/diablo-iv/items/1839107/the-scarlet-bard") { UseShellExecute = true });
        }

        private void IMGDivIV3_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.shop.battle.net/es-mx/family/diablo-iv/items/1595019/jade-scorpion") { UseShellExecute = true });
        }

        private void DivIV_Click(object sender, EventArgs e)
        {
            IMGOver1.Visible = false;
            IMGOver2.Visible = false;
            IMGOver3.Visible = false;
            IMGVand.Visible = false;
            IMGDivIV1.Visible = true;
            IMGDivIV2.Visible = true;
            IMGDivIV3.Visible = true;
        }

        private void VIDDivIV_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=7RdDpqCmjb4&ab_channel=Diablo") { UseShellExecute = true });
        }

        private void VIDOver_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=qRc1nPG7qXA&ab_channel=OverwatchES") { UseShellExecute = true });
        }

        private void VIDWoW_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=jSJr3dXZfcg&ab_channel=WorldofWarcraft") { UseShellExecute = true });
        }

        private void VIDHearthstone_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=lMhpHgqIQdQ&ab_channel=Hearthstone") { UseShellExecute = true });
        }

        private void IMGWoWUL_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://thewarwithin.blizzard.com/es-es/") { UseShellExecute = true });
        }

        private void GIFDivIV_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.shop.battle.net/es-es/product/world-of-warcraft-free-trial?p=76095") { UseShellExecute = true });
        }

        private void GIFWR_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://eu.shop.battle.net/es-es/product/warcraft-rumble") { UseShellExecute = true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private string clave = "";  // Variable para almacenar la clave

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (adminForm == null || adminForm.IsDisposed)
            {
                // Si el formulario ya fue desechado o no existe, lo creamos de nuevo
                adminForm = new ventanaAdminForm(this, user, btnAdmin.Text, cuf);
            }
            if (string.IsNullOrEmpty(clave))
            {
                clave = InputBoxForm.Show("CLAVE", "Introduce tu clave: ");
            }

            // Verificamos la clave antes de mostrar el formulario
            if (sql.VerClave(user, clave))
            {
                adminForm.Show();
                adminForm.BringToFront();
            }
            else
            {
                MessageBox.Show("Clave incorrecta");
            }
        }


    }
}
