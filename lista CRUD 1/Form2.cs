using System;
using System.Net.NetworkInformation;
//lo ha aggiunto il codice

/* using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading; */
//using System.Threading.Tasks;
using System.IO;
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
		public string path;
		public StreamWriter swl;

		public CRUD()
		{
			InitializeComponent();
			pro = new Prodotto[100];
			dim = 0;
			fun = 0; // 1 Create ; 2 Update ; 3 Twin ; 4 Delete ; 5 Add ; 6 Edit ; 7 Duplicate ; 8 Remove

			path = Path.GetFullPath(".");
			for (int i = 2; i > 0; i--) //il 2 dipende dalla gestione della cartella della soluzione
			{ //in breve: torna indietro di una cartella per ciclo
				path = Path.GetDirectoryName(path);
			}
			path += @"\liste";

		}
		private void CRUD_Load(object sender, EventArgs e)
		{
			DescrizioneCreate.SetToolTip(CreateButton, "Crea una nuova lista");
			//
		}

		//da finire
		private void CreateButton_Click(object sender, EventArgs e)
		{
			(SearchBox.Visible, SearchLabel.Visible) = (false, false);
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, CleareButton.Visible, ClearLabel.Visible,
				ConfirmButton.Visible, CancelButton1.Visible) = (true, true, true, true, true, true, true, true);

			fun = 1; //CreateFile()
		}

		//da spostare, questo dovrebbe essere TwinButton
		private void ReadButton_Click(object sender, EventArgs e)
		{ //fun 3
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
		}

		//modifica un file, perciò va a compilare la struct prodotti coi nuovi dati
		//rinominare
		private void UpdateButton_Click(object sender, EventArgs e)
		{
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, CleareButton.Visible,
				ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (true, true, true, true, true, true, true, true, true, true);

			fun = 2;
		}

		//guardare?
		private void DeleteButton_Click(object sender, EventArgs e)
		{
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, CleareButton.Visible,
				ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (false, false, false, false, true, true, true, true, true, true);

			fun = 3;
		}

		//rifare
		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			switch (fun)
			{
				case 1:
					CreateFile();
					//AddProd();
					break;

				case 2:
					//EditProd();
					break;

				case 3:
					//DelProd();
					break;
			}

			if (dim == 0 && fun == 3)
			{
				(UpdateButton.Visible, DeleteButton.Visible) = (false, false);
				CancelButton1_Click(sender, e);
			}
			ReadButton_Click(sender, e);
		}

		//finito? nop. attenzione swl
		private void CancelButton1_Click(object sender, EventArgs e)
		{
			ClearButton_Click(sender, e);
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, CleareButton.Visible,
				ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (false, false, false, false, false, false, false, false, false, false);
		}

		//finito?
		private void ClearButton_Click(object sender, EventArgs e)
		{
			TextBox.Text = "";
			PriceBox.Text = "";
			SearchBox.Text = "";
		}

		//finito?
		private void CreateFile()
		{
			//if (!File.Exists(path)) //+ $"\\lista{{}}.txt"
			Directory.CreateDirectory(path);
			// Directory.GetFileSystemEntries(path).Lenght;
			//swl stream writer lista
			swl = new StreamWriter($"{path}\\lista{Directory.GetFileSystemEntries(path).Length + 1}.txt",false); //crea \lista1.txt
			//swl stream writer lista
			//copiato StreamWriter sw = new StreamWriter(path + "\\Test.txt", false);
			//di base append è false
			//se streamwriter è false sovrascrive la prima riga, se true aggiunge alla fine del file

			AddProd();
			swl.WriteLine($"{dim}.    Nome: {TextBox.Text}     Prezzo: {PriceBox.Text}");//la riga è lunga 24 + Length
            swl.WriteLine($"-------------------");
            swl.WriteLine($"numero di prodotti: {dim}");
            swl.WriteLine($"prezzo totale: {PriceBox.Text}");

            swl.Close();
		}

		//finito?
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

		//finito?
		private void EditProd()
		{
			if (!int.TryParse(SearchBox.Text, out int sea) || sea < 1)
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

		//finito?
		private void DelProd()
		{
			
			if (!int.TryParse(SearchBox.Text, out int sea) || sea < 1)
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