using System;
using System.Net.NetworkInformation;
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
		public int fun;
		public CRUD()
		{
			InitializeComponent();
			pro = new Prodotto[100];
			dim = 0;
			fun = 0; // 1 Add ; 2 Edit ; 3 Delete
		}
		private void CRUD_Load(object sender, EventArgs e)
		{
			DescrizioneCreate.SetToolTip(CreateButton, "Aggiungi un prodotto alla lista");
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			(SearchBox.Visible, SearchLabel.Visible) = (false, false);
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, CleareButton.Visible, ClearLabel.Visible,
				ConfirmButton.Visible, CancelButton1.Visible) = (true, true, true, true, true, true, true, true);

            fun = 1;
		}

		private void ReadButton_Click(object sender, EventArgs e)
		{
			float sum = 0;
			Lista.Items.Clear();
			for (int i = 0; i < dim; i++)
			{
				Lista.Items.Add($"{pro[i].ind}.    Nome: {pro[i].nome}     Prezzo: {pro[i].prezzo}");
				sum += pro[i].prezzo;
			}
			Lista.Items.Add($"-------------------");
			Lista.Items.Add($"numero di prodotti: {dim}");
			Lista.Items.Add($"prezzo totale: {sum}");
			// File
		}

		private void UpdateButton_Click(object sender, EventArgs e)
		{
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, CleareButton.Visible,
				ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (true, true, true, true, true, true, true, true, true, true);

			fun = 2;
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, CleareButton.Visible,
				ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (false, false, false, false, true, true, true, true, true, true);

			fun = 3;
		}

		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			switch (fun)
			{
				case 1:
					AddProd();
					break;

				case 2:
					EditProd();
					break;

				case 3:
					DelProd();
					break;
			}

			if (dim == 0 && fun == 3)
			{
				(UpdateButton.Visible, DeleteButton.Visible) = (false, false);
				CancelButton1_Click(sender, e);
			}
			ReadButton_Click(sender, e);
		}

		private void CancelButton1_Click(object sender, EventArgs e)
		{
			ClearButton_Click(sender, e);
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, CleareButton.Visible,
				ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (false, false, false, false, false, false, false, false, false, false);
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			TextBox.Text = "";
			PriceBox.Text = "";
			SearchBox.Text = "";
		}

		private void AddProd()
		{
			pro[dim].nome = TextBox.Text;
            if (TextBox.Text == "")
			{//bad input
				MessageBox.Show("Scrivi qualcosa", "errore nel nome del prodotto");
				return;
			}
            if (!float.TryParse(PriceBox.Text, out pro[dim].prezzo) || pro[dim].prezzo < 0)
			{//bad input
				MessageBox.Show("numero decimale positivo", "errore nel prezzo");
				return;
			}
			dim++;
			pro[dim - 1].ind = dim;

			(UpdateButton.Visible, DeleteButton.Visible )= (true,true);
		}
		private void EditProd()
		{
			int sea;
            if (!int.TryParse(SearchBox.Text, out sea) || sea < 1)
			{//bad input
				MessageBox.Show("inserisci un intero positivo", "errore nella ricerca");
				return;
			}
            if (sea > dim)
			{//bad input
				MessageBox.Show("inserisci un indice che appare in lista", "errore nella ricerca");
				return;
			}
			sea--;
            if (TextBox.Text == "" || PriceBox.Text == "")
			{//bad input
				MessageBox.Show("Scrivi qualcosa", "errore");
				return;
			}
			if (!float.TryParse(PriceBox.Text, out pro[sea].prezzo) || pro[sea].prezzo < 0)
			{//bad input
				MessageBox.Show("numero decimale positivo", "errore nel prezzo");
				return;
			}
			pro[sea].nome = TextBox.Text;

	}


		private void DelProd()
		{
			int sea;
			if (!int.TryParse(SearchBox.Text, out sea) || sea < 1)
			{//bad input
				MessageBox.Show("inserisci un intero positivo", "errore nella ricerca");
				return;
			}
			if (sea > dim)
			{//bad input
				MessageBox.Show("inserisci un indice che appare in lista", "errore nella ricerca");
				return;
			}
			for (int i = sea - 1; i < dim; i++)
			{
				pro[i] = pro[i + 1];
				pro[i].ind--;
			}
			dim--;
		}
	}
}