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
//using System.Linq;
using System.Net.Http;
using System.Threading; */
//using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using System.Linq; //ha .ToArray();

namespace lista_CRUD
{
	public partial class CRUD : Form
	{
		//public struct Prodotto
		//{
		//	public int ind;
		//	public string nome;
		//	public float prezzo;
		//}
		//public Prodotto[] pro;
		public int dim, fun, sel; //dim lunghezza lista, fun funzione, sel search lista
		public float sum; //sum somma prezzi
		public string path, filepath; //percorso \liste e \liste\lista1.txt
		public StreamWriter swl; //stream writer list
		public string[] lines; //tutto il file trascritto

		public CRUD()
		{
			InitializeComponent();
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
			if(Directory.GetFiles(path).Length != 0)
				(TwinButton.Visible, UpdateButton.Visible, DeleteButton.Visible) = ( true, true , true);
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
		private void TwinButton_Click(object sender, EventArgs e)
		{ //fun 3
			//float sum = 0;
			//Lista.Items.Clear();
			//for (int i = 0; i < dim; i++)
			//{
			//	Lista.Items.Add($"{pro[i].ind}.    Nome: {pro[i].nome}|    Prezzo: {pro[i].prezzo}");
			//	sum += pro[i].prezzo;
			//}
			//Lista.Items.Add($"-------------------");
			//Lista.Items.Add($"numero di prodotti: {dim}");
			//Lista.Items.Add($"prezzo totale: {sum}");
		}

		//modifica un file, perciò va a compilare la struct prodotti coi nuovi dati
		private void UpdateButton_Click(object sender, EventArgs e)
		{
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, CleareButton.Visible,
				ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (true, true, true, true, true, true, true, true, true, true);

			fun = 2;

            ListaProdotti.Items.Clear();
            NameList.Text = "Scegli la lista da aprire digitando il numero in search:";
            for (int i = 1; i <= Directory.GetFiles(path).Length; i++)
                ListaProdotti.Items.Add($"{i}. Lista{i}");
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
					break;

				case 2:
					OpenFile();
					break;

				case 3:
					//
					break;

				case 5:
					AddProd();
					break;
			}

			//if (dim == 0 && fun == 3)
			//{
			//	(UpdateButton.Visible, DeleteButton.Visible) = (false, false);
			//	CancelButton1_Click(sender, e);
			//}
			if (lines != null)
				Stampa();
			else
				UpdateButton_Click(sender, e);
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
		//fun 1
		private void CreateFile()
		{
			//Directory.CreateDirectory(path);
			sel = Directory.GetFiles(path).Length + 1;
            filepath = $"{path}\\lista{sel}.txt";
			//crea \lista1.txt
			swl = new StreamWriter(filepath, false);
			//swl stream writer lista


			if (TextBox.Text == "")
			{//bad input
				MessageBox.Show("Scrivi qualcosa", "errore nel nome del prodotto");
				return;
			}
			if (!float.TryParse(PriceBox.Text, out float prezzo) || prezzo < 0)
			{//bad input
				MessageBox.Show("numero decimale positivo", "errore nel prezzo");
				return;
			}
			dim = 1;
			swl.WriteLine($"{dim}.    Nome: {TextBox.Text}|    Prezzo: {PriceBox.Text}");
			swl.WriteLine($"-------------------");
			swl.WriteLine($"numero di prodotti: {dim}");
			sum = float.Parse(PriceBox.Text);
			swl.WriteLine($"prezzo totale: {sum}"); // 15 char + prezzo
			
			swl.Close();
			//OpenFile();
			lines = File.ReadAllLines(filepath);
			fun = 5;

			//UpdateButton_Click()
		}

		//azzera e aggiorna la struct e poi apre in modifica
		//fun 2
		private void OpenFile()
		{
			if (!int.TryParse(SearchBox.Text, out sel) || sel < 1)
			{//bad input
				MessageBox.Show("inserisci un intero positivo", "errore nella ricerca");
				return;
			}
			if (sel > Directory.GetFiles(path).Length)
			{//bad input
				MessageBox.Show("inserisci un indice che appare in lista", "errore nella ricerca");
				return;
			}
			filepath = $"{path}\\lista{sel}.txt";
			lines = File.ReadAllLines(filepath);
			dim = lines.Length - 3;

			//il fondo del file ha la somma dei prezzi
			//conteggio char 15, 15 - 1 per la posizione, +1 = 15 il carattere successivo
			string str = "";
			for (int c = 15; c < lines[lines.Length - 1].Length; c++)
				str += lines[lines.Length - 1][c];
			sum = float.Parse(str);

            /* reset e nuovi dati struct
			//pro[] = new Prodotto[100]
			//for (int i = 0; i < lines.Length - 3; i++)
			//{
			//	int chp; //char position
			//
			//	string str = ""; //stringa d'appoggio
			//	for (chp = 0; chp < (i + 1).ToString().Length; chp++)
			//		str += lines[i][chp];
			//	pro[dim].ind = int.Parse(str);
			//
			//	chp += 11;//.    Nome: //11 char
			//
			//	str = "";
			//	while (lines[i][chp] != '|')
			//	{
			//		str += lines[i][chp];
			//		chp++;
			//	}
			//	pro[dim].nome = str;
			//
			//	str = "";
			//	// |    Prezzo: // 13 char - 1 perchè '|' già fatto
			//	for (chp += 12; chp < lines[i].Length; chp++)
			//		str += lines[i][chp];
			//	pro[dim].prezzo = float.Parse(str);

			//	dim++;
			//}
			//le ultime 3 righe non servono alla struct
			*/

            fun = 5;
		}

		//finito? // aggiungere controllo: non si può scrivere '|'
		//fun 5
		private void AddProd()
		{
			if (TextBox.Text == "")
			{//bad input
				MessageBox.Show("Scrivi qualcosa", "errore nel nome del prodotto");
				return;
			}
			if (!float.TryParse(PriceBox.Text, out float prezzo) || prezzo < 0)
			{//bad input
				MessageBox.Show("numero decimale positivo", "errore nel prezzo");
				return;
			}

			dim++;
			swl = new StreamWriter(filepath);
			for (int i = 0; i < lines.Length - 3; i++) //mi posiziono all'inizio del separatore
				swl.WriteLine(lines[i]); //purtroppo riscrivo tutto

			sum += float.Parse(PriceBox.Text);
			swl.WriteLine($"{dim}.    Nome: {TextBox.Text}|    Prezzo: {PriceBox.Text}");
			swl.WriteLine($"-------------------");
			swl.WriteLine($"numero di prodotti: {dim}");
			swl.WriteLine($"prezzo totale: {sum}");

			swl.Close();
			lines = File.ReadAllLines(filepath);

			(UpdateButton.Visible, DeleteButton.Visible) = (true, true);
		}

		//finito?
		//fun 6
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
			if (!float.TryParse(PriceBox.Text, out float prezzo) || prezzo < 0)
			{//bad input
				MessageBox.Show("numero decimale positivo", "errore nel prezzo");
				return;
			}
			//pro[sea].nome = TextBox.Text;

		}

		//finito?
		//fun 8
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
				//pro[i] = pro[i + 1];
				//pro[i].ind--;
			}
			dim--;
		}

		//stampa dal file alla listview
		private void Stampa()
		{
            NameList.Text = $"Stai modificando la Lista{sel} :";
            ListaProdotti.Items.Clear();
			for (int i = 0; i < lines.Length; i++)
				ListaProdotti.Items.Add(lines[i]);
		}
	}
}