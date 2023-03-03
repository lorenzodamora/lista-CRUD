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
        public struct Prodotto
        {
            public int ind;
            public string nome;
            public float prezzo;
        }
        public Prodotto[] pro;
        public int dim;
        
        public CRUD()
		{
            InitializeComponent();
            pro = new Prodotto[100];
            dim = 0;
        }
        private void CRUD_Load(object sender, EventArgs e)
		{
           DescrizioneCreate.SetToolTip(CreateButton, "Aggiungi un prodotto alla lista");
        }

		private void CreateButton_Click(object sender, EventArgs e)
		{
            (TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, CleareButton.Visible, ClearLabel.Visible,
                ConfirmButton.Visible, CancelButton1.Visible) = (true, true, true, true, true, true, true, true);
		}

        private void ReadButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            (TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, CleareButton.Visible,
                ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (true, true, true, true, true, true, true, true, true, true);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            (TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, CleareButton.Visible,
                ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (true, true, true, true, true, true, true, true, true, true);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            pro[dim].nome = TextBox.Text;
            while (TextBox.Text == "")
            {//bad input
                MessageBox.Show("Scrivi qualcosa");
                return;
            }
            while (!float.TryParse(PriceBox.Text, out pro[dim].prezzo) || pro[dim].prezzo < 0)
            {//bad input
                MessageBox.Show("numero decimale positivo");
                return;
            }
            dim++;
            pro[dim - 1].ind = dim;
            Lista.Items.Clear();
            for (int i = 0; i < dim; i++)
            {
                Lista.Items.Add(pro[i].ind + ". Nome:" + pro[i].nome + " | prezzo:" + pro[i].prezzo.ToString());
            }
        }

        private void CancelButton1_Click(object sender, EventArgs e)
        {
            (TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, CleareButton.Visible,
                ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (false, false, false, false, false, false, false, false, false, false);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            TextBox.Text = "";
            PriceBox.Text = "";
        }
    }
}