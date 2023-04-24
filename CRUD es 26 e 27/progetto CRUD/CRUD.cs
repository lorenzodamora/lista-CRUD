#region using
using System;
using System.Diagnostics.Eventing.Reader;
//using System.Net.NetworkInformation;
//lo ha aggiunto il codice

/* using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Linq; //ha .ToArray();
using System.Net.Http;
using System.Threading; */
//using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Schema;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace progetto_CRUD
{
	public partial class CRUD : Form
	{
        #endregion
        //fare sia csv che txt
        //togliere multi liste
        //moltiplica linea
        //cancellazione logica
        //file accesso diretto
        //search sia indice che string
        //menu a comparsa
        //elementi cliccabili in listview
        //funzioni esterne
        //edit logico?? //cronologia?? //pensavo a due stack (ctrl z  ctrl y)

        public int fun, totpro, totline, seline; //fun funzione //totlis totale liste //lista selezionata
		public string path;
		public CRUD()
		{
			InitializeComponent();
			path = GetPath();
			totpro = GetProCount(path + "\\contatori.txt");
			fun = 0; // 1 add, 2 select, 3 edit, 4 move, 5 delete, 6 switch, 7 twin, 8 remove 
			SetVisible();
			File.Create(path + "\\logic remove.txt").Close(); //crea
		}
		//{
		private string GetPath()
		{
			string path = Path.GetFullPath(".");
			path = Path.GetDirectoryName(path);
			path = Path.GetDirectoryName(path);
			path = Path.GetDirectoryName(path);
			path += @"\files";
			//Directory.CreateDirectory(path);
			return path;
		}
		//see
		private int GetProCount(string filepath)
		{
			StreamReader sr = new StreamReader(filepath);
			int read = int.Parse(sr.ReadLine());
			sr.Close();
			return read;
		}
		//}
		private void CRUD_Load(object sender, EventArgs e)
		{
			//aggiungere
			DescrizioneAdd.SetToolTip(AddButton, "Aggiungi nuova linea");
			DescrizioneHistoryR.SetToolTip(HistoryRButton, "Guarda la lista delle linee rimosse");
		}
		//add
		private void Shortcut(object sender, KeyEventArgs e)
		{			
			if (e.Control &&  e.Shift &&e.KeyCode == Keys.A)
			//shortcut Ctrl+Shift+A
				AddButton_Click(sender, e);
			
		}
		private void ChiudiFormButton_Click(object sender, EventArgs e)
		{
			File.Delete(path + "\\logic remove.txt");
			Close();
		}
		//{
		private void SearchVisible(bool vis)
		{
			(SearchBox.Visible, SearchLabel.Visible) = (vis, vis);
		}
		private void TextPriceVisible(bool vis)
		{
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible) = (vis, vis, vis, vis);
		}
		private void ClearConfirmVisible(bool vis)
		{
			(ClearButton.Visible, ClearLabel.Visible) = (vis, vis);
			(ConfirmButton.Visible, CancelButton1.Visible) = (vis, vis);
		}
		//}
		//modificare
		private void SetVisible()
		{
			//bool 0 update, 1 move, 0 delete, 2 add, 2 edit, 2 dupl, 2 remove, 3 search, 4 textprice, 5 clear, 5 confirm
			bool[] vis = new bool[5];
			//*vis[0] = totlis != 0;
			//*vis[1] = !(totlis < 2 || selis == 0);
			//*vis[2] = selis != 0;
			//vis[3] search = update2 o move3 o delete4 o edit6 o twin7 o remove8
			//vis[4] textprice = create1 o add5 o edit6
			//*vis[3] = !(fun == 1 || fun == 5 || fun == 0);
			//*vis[4] = (fun == 1 || fun == 5 || fun == 6);

			//bool 0 update, 1 move, 0 delete, 2 add, 2 edit, 2 dupl, 2 remove, 3 search, 4 textprice, 5 clear, 5 confirm
			//*UpdateButton.Visible = vis[0];
			//*MoveButton.Visible = vis[1];
			//*DeleteButton.Visible = vis[0];
			AddButton.Visible = vis[2];
			EditButton.Visible = vis[2];
			TwinButton.Visible = vis[2];
			RemoveButton.Visible = vis[2];
			SearchVisible(vis[3]);
			TextPriceVisible(vis[4]);
			ClearConfirmVisible(vis[4] || vis[3]);
		}
		//move line, sposta
		private void MoveButton_Click(object sender, EventArgs e)
		{
			fun = 3;
			SetVisible();
			ListaProdotti.Items.Clear();
			NameList.Text = $"Scegli la linea da spostare digitando il numero in search :";
			//stampa
		}
		//switch line scambiare

		//select line
		private void UpdateButton_Click(object sender, EventArgs e)
		{
			fun = 2;
			SetVisible();
			ListaProdotti.Items.Clear();
			NameList.Text = "Scegli la linea da modificare digitando il numero in search :";
			//stampa
		}
		//delete line
		private void DeleteButton_Click(object sender, EventArgs e)
		{
			fun = 4;
			SetVisible();
			ListaProdotti.Items.Clear();
			NameList.Text = "Scegli la linea da cancellare digitando il numero in search :";
			//stampa
		}
		//edit //fun 1
		private void AddButton_Click(object sender, EventArgs e)
		{
			fun = 1;
			SetVisible();
			//!! totpro
			NameList.Text = $"Stai aggiungendo alla linea {totline}. :";
		}
		//edit // fun ??
		private void TwinButton_Click(object sender, EventArgs e)
		{
			fun = 7;
			SetVisible();
			NameList.Text = $"Stai duplicando una linea (verrà aggiunta accanto alla linea duplicata):";
		}
		//edit fun ??
		private void EditButton_Click(object sender, EventArgs e)
		{
			fun = 6;
			SetVisible();
			NameList.Text = $"Stai modificando una linea:";
		}
		//remove 1 pro
		private void RemoveButton_Click(object sender, EventArgs e)
		{
			fun = 8;
			SetVisible();
			//!! seline
			NameList.Text = $"Stai rimuovendo un prodotto alla linea {seline} :";
		}
		private void CancelButton1_Click(object sender, EventArgs e)
		{
			ClearButton_Click(sender, e);
			fun = 0;
			SetVisible();
			ListaProdotti.Items.Clear();
			NameList.Text = "Non è selezionata nessuna linea";
		}
		private void ClearButton_Click(object sender, EventArgs e)
		{
			TextBox.Text = "";
			PriceBox.Text = "";
			SearchBox.Text = "";
		}
		//edit // cronologia
		private void HistoryRButton_Click(object sender, EventArgs e)
		{
			fun = 0;
			SetVisible();
			ListaProdotti.Items.Clear();
			NameList.Text = "Queste sono le linee rimosse";

			string[] lines = File.ReadAllLines(path + "\\logic remove.txt");
			int i = 0;
			while (i < lines.Length)
				ListaProdotti.Items.Add(lines[i++]);
		}
		//}
		//edit
		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			bool control = SwitchFun(fun, TextBox.Text, PriceBox.Text, SearchBox.Text, path);
			if (control == true)
				switch (fun)
				{
					case 1: //add line
						AddButton_Click(sender, e);
						break;
					case 2: //select line
						AddButton_Click(sender, e);
						break;
					case 3: //move linne
						AddButton_Click(sender, e);
						break;
					case 4: //delete line
						NameList.Text = "Non è aperta nessuna linea";
						fun = 0;
						SetVisible();
						break;
					case 6: //edit line
						AddButton_Click(sender, e);
						break;

					case 7: //twin pro
						TwinButton_Click(sender, e);
						break;

					case 8: //remove pro
						HistoryRButton.Visible = true;
						RemoveButton_Click(sender, e);
						break;
				}
			//if (selis != 0)
				StampaForm();
		}
		//edit
		private bool SwitchFun(int fun, string nome, string prezzo, string cerca, string path)
		{
			bool control = true; // false se qualcosa è andato storto
			switch (fun)
			{
				case 1:
					break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					break;
				case 5:
					break;
				case 6:
					break;
				case 7:
					break;
				case 8:
					break;
			}
			return control;
		}

		private bool CheckNomePrezzo(string nome, string prezzo)
		{
			if (nome == "")
			{//bad input
				MessageBox.Show("Scrivi qualcosa", "errore nel nome del prodotto");
				return false;
			}
			if (!float.TryParse(prezzo, out float price) || price < 0)
			{//bad input
				MessageBox.Show("numero decimale positivo", "errore nel prezzo");
				return false;
			}

			return true;
		}
		private bool CheckCercaLine(string cerca, int totline)
		{
			if (!int.TryParse(cerca, out int seline) || seline < 1) //seline = seleziona riga, select line
			{//bad input
				MessageBox.Show("inserisci un intero positivo", "errore nella ricerca");
				return false;
			}
			if (seline > totline)
			{//bad input
				MessageBox.Show("inserisci un indice che appare in lista", "errore nella ricerca");
				return false;
			}
			return true;
		}
		//delete line
		
		//see
		private void AddLine(string nome, string prezzo, string path, int selis)
		{//fun 5
			if (!CheckNomePrezzo(nome, prezzo)) //bad input
				return;

			string[] lines = File.ReadAllLines(path + "\\delimitatori.txt");
			int npro = int.Parse(lines[selis]) - 4; //numero righe di prodotti // 4 sono =  tot prodotti + somma + 2 separatori.
			int line = 0; //numero riga dove inizia la lista
			for (int i = 1; i < selis; i++)
				line += int.Parse(lines[i]); //fa la somma di tutti i delimitatori (tranne il primo in lines[0])

			//aggiungo un prodotto
			StreamWriter sw = new StreamWriter(path + "\\delimitatori.txt");
			lines[selis] = (int.Parse(lines[selis])+1).ToString(); ; //aggiungo già una riga al conteggio righe della lista

			sw.Write(lines[0]); //prima riga senza \n iniziale
			for (int i = 1; i < lines.Length; i++)
				sw.Write("\n"+lines[i]); //nessuna riga vuota alla fine del file
			sw.Close();

			lines = File.ReadAllLines(path + "\\liste.txt");

			//il fondo della lista ha la somma dei prezzi
			//conteggio char 15, 15 - 1 per la posizione, +1 = 15 il carattere successivo
			//line + numpro + 3 è dove si trova la somma
			string str = "";
			for (int c = 15; c < lines[line+npro+2].Length; c++)
				str += lines[line+npro+2][c];
			float sum = float.Parse(str) + float.Parse(prezzo);

			sw = new StreamWriter(path + "\\liste.txt");
			for (int i = 0; i < line+npro; i++)
				sw.WriteLine(lines[i]);
			sw.WriteLine($"{npro + 1}.    Nome: {nome}     Prezzo: {prezzo}");
			sw.WriteLine("-------------------");
			sw.WriteLine($"numero di prodotti: {npro + 1}");
			sw.WriteLine($"prezzo totale: {sum}");
			sw.WriteLine("###################");

			for (int i = line+npro+4; i < lines.Length; i++)
				sw.WriteLine(lines[i]);
			sw.Close();
		}
		
		private void StampaForm()
		{
			
		}
	}
}