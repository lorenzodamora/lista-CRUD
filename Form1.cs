using System;
/* using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading; */
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace lista_CRUD
{
	public partial class CRUD : Form
	{

		public CRUD()
		{
			InitializeComponent();
        }
        private void CRUD_Load(object sender, EventArgs e)
		{
           DescrizioneCreate.SetToolTip(CreateButton, "Aggiungi un prodotto alla lista");
        }

		private void CreateButton_Click(object sender, EventArgs e)
		{
            (TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible,
                ConfirmButton.Visible, CancelButton1.Visible) = (true, true, true, true, true, true);
		}

        private void ReadButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton1_Click(object sender, EventArgs e)
        {

        }
    }
}