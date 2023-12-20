using Escritorio.Modelos;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Escritorio
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}
		LoginMS loginMS;
		private async void AceptarButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(CodigoTextBox.Text))
			{
				errorProvider1.SetError(CodigoTextBox, "Ingrese el código del usuario");
				CodigoTextBox.Focus();
				return;
			}
			errorProvider1.Clear();

			if (string.IsNullOrWhiteSpace(ClaveTextBox.Text))
			{
				errorProvider1.SetError(ClaveTextBox, "Ingrese la clave del usuario");
				ClaveTextBox.Focus();
				return;
			}
			errorProvider1.Clear();

			using (HttpClient httpClient = new HttpClient())
			{
				string url = "http://localhost:5124/api/Login";
				Login login = new Login(CodigoTextBox.Text, ClaveTextBox.Text);
				string jsonLogin = JsonConvert.SerializeObject(login);
				StringContent requestContent = new StringContent(jsonLogin, Encoding.Unicode, "application/json");

				HttpResponseMessage response = await httpClient.PostAsync(url, requestContent);

				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					string contect = await response.Content.ReadAsStringAsync();
					loginMS = JsonConvert.DeserializeObject<LoginMS>(contect);

					Hide();

					MenuForm menu = new MenuForm();
					menu.Show();
				}
			}
		}

		private void CancelarButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
