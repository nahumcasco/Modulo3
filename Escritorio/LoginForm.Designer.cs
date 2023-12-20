namespace Escritorio
{
	partial class LoginForm
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CodigoTextBox = new System.Windows.Forms.TextBox();
			this.ClaveTextBox = new System.Windows.Forms.TextBox();
			this.AceptarButton = new System.Windows.Forms.Button();
			this.CancelarButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Código:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Clave:";
			// 
			// CodigoTextBox
			// 
			this.CodigoTextBox.Location = new System.Drawing.Point(67, 9);
			this.CodigoTextBox.Name = "CodigoTextBox";
			this.CodigoTextBox.Size = new System.Drawing.Size(175, 22);
			this.CodigoTextBox.TabIndex = 2;
			// 
			// ClaveTextBox
			// 
			this.ClaveTextBox.Location = new System.Drawing.Point(67, 44);
			this.ClaveTextBox.Name = "ClaveTextBox";
			this.ClaveTextBox.PasswordChar = '*';
			this.ClaveTextBox.Size = new System.Drawing.Size(175, 22);
			this.ClaveTextBox.TabIndex = 3;
			// 
			// AceptarButton
			// 
			this.AceptarButton.Location = new System.Drawing.Point(84, 82);
			this.AceptarButton.Name = "AceptarButton";
			this.AceptarButton.Size = new System.Drawing.Size(75, 23);
			this.AceptarButton.TabIndex = 4;
			this.AceptarButton.Text = "Aceptar";
			this.AceptarButton.UseVisualStyleBackColor = true;
			this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
			// 
			// CancelarButton
			// 
			this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelarButton.Location = new System.Drawing.Point(184, 82);
			this.CancelarButton.Name = "CancelarButton";
			this.CancelarButton.Size = new System.Drawing.Size(75, 23);
			this.CancelarButton.TabIndex = 5;
			this.CancelarButton.Text = "Cancelar";
			this.CancelarButton.UseVisualStyleBackColor = true;
			this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Escritorio.Properties.Resources.userLogin;
			this.pictureBox1.Location = new System.Drawing.Point(265, 10);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(102, 95);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// LoginForm
			// 
			this.AcceptButton = this.AceptarButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelarButton;
			this.ClientSize = new System.Drawing.Size(375, 126);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.CancelarButton);
			this.Controls.Add(this.AceptarButton);
			this.Controls.Add(this.ClaveTextBox);
			this.Controls.Add(this.CodigoTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "LoginForm";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox CodigoTextBox;
		private System.Windows.Forms.TextBox ClaveTextBox;
		private System.Windows.Forms.Button AceptarButton;
		private System.Windows.Forms.Button CancelarButton;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ErrorProvider errorProvider1;
	}
}

