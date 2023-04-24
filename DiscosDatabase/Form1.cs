using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace DiscosDatabase
{
    public partial class frmMostrarDiscos : Form
    {
        private List<Discos> listaDiscos;
        public frmMostrarDiscos()
        {
            InitializeComponent();
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Discos seleccionado = (Discos)dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlTapa);

        }

        private void frmMostrarDiscos_Load(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            listaDiscos = negocio.listar();

            dgvDiscos.DataSource = listaDiscos;
            dgvDiscos.Columns["UrlTapa"].Visible = false;
            cargarImagen(listaDiscos[0].UrlTapa);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbTapas.Load(imagen);
            }
            catch (Exception ex)
            {

                pbTapas.Load("https://th.bing.com/th/id/R.3f59d49f9088c8344be742f7eb4406f7?rik=QUDlwvZd9JMcKA&riu=http%3a%2f%2ficon-library.com%2fimages%2fphoto-placeholder-icon%2fphoto-placeholder-icon-17.jpg&ehk=riCMMCU3S%2fT5sthLmPPyozcjKbAku1vxzZej7CcVj6Q%3d&risl=&pid=ImgRaw&r=0");
            }
        }
    }
}
