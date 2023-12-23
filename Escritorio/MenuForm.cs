using System;
using System.Windows.Forms;

namespace Escritorio
{
	public partial class MenuForm : Form
	{
		public MenuForm()
		{
			InitializeComponent();
		}

		private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EmpresaForm form = new EmpresaForm();
			form.Show();
		}

		private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UsuariosForm form = new UsuariosForm();
			form.MdiParent = this;
			form.Show();
		}
	}
}
