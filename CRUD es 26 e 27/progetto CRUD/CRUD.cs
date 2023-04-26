#region using
using System;
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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace progetto_CRUD
{
	public partial class CRUD : Form
	{
		#endregion
		//togliere multi liste //fare sia csv che txt
		//togliere gli autocomplete
		//moltiplica linea
		//cancellazione logica
		//file accesso diretto
		//search sia indice che string
		//menu a comparsa
		//elementi cliccabili in listview
		//funzioni esterne
		//edit logico?? //cronologia?? //pensavo a due stack (ctrl z  ctrl y)

		//non c'è mai seline 0; quando è 0 diventa il totline + 1; fa solo add o select altro; funziona tutto a select

		public int fun, totline, seline; //fun funzione //totlis totale liste //lista selezionata
		public string path;
		public CRUD()
		{
			InitializeComponent();
			path = GetPath();
			//totpro = GetProCount(path + "\\contatori.txt");
			totline = GetLineCount(path + "\\contatori.txt");
			seline = totline + 1;
			fun = 0; // 1 add, 2 select, 3 edit, 4 delete, 5 move, 6 switch, 7 twin, 8 remove, (a parte) history
			SetVisible();
			StampaForm();
			File.Create(path + "\\logic remove.txt").Close(); //crea
		}
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
		private int GetProCount(string filepath)
		{
			//StreamReader sr = File.OpenText(filepath);
			StreamReader sr = new StreamReader(filepath);
			int read = int.Parse(sr.ReadLine());
			sr.Close();
			return read;
		}
		private int GetLineCount(string filepath)
		{
			int lineCount = -1; //non conto la prima linea
			//StreamReader sr = new (filepath);
			StreamReader sr = new StreamReader(filepath);
			while (sr.ReadLine() != null)
				lineCount++;
			sr.Close();
			return lineCount;
		}
		private void CRUD_Load(object sender, EventArgs e)
		{
			//aggiungere
			DescrizioneAdd.SetToolTip(AddButton, "Aggiungi nuova linea");
			DescrizioneHistoryR.SetToolTip(HistoryButton, "Guarda la lista delle linee rimosse");
		}
		//add
		private void Shortcut(object sender, KeyEventArgs e)
		{
			//funziona con history?
			if (e.Control &&  e.Shift &&e.KeyCode == Keys.A)
				//shortcut Ctrl+Shift+A
				AddButton_Click(sender, e);
			//confirm shortcut
			//cancel shortcut
			//
		}
		private void StampaForm()
		{
			string[] lines = File.ReadAllLines(path + "\\lista.txt");
			ListaProdotti.Items.Clear();
			for (int i = 0; i < lines.Length; i++)
				ListaProdotti.Items.Add(lines[i]);
		}
		private void ChiudiFormButton_Click(object sender, EventArgs e)
		{
			File.Delete(path + "\\logic remove.txt");
			Close();
		}
		private void SearchVisible(bool vis)
		{
			(SearchBox.Visible, SearchLabel.Visible) = (vis, vis);
		}
		private void TextPriceVisible(bool vis)
		{
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible) = (vis, vis, vis, vis);
		}
		private void ClearVisible(bool vis)
		{
			(ClearButton.Visible, ClearLabel.Visible) = (vis, vis);
		}
		private void SetVisible()
		{
			//fun // 0 nulla, 1 add sempre attivo, 2 select esiste 1 linea (totline)
			//3 edit 4 delete 7 twin 8 remove + è attivo select ( seline non è 0)
			//5 move 6 switch + è attivo select + esistono 2 linee
			//9 history = cancel to exit, la sua visibilità è gestita da solo (si attiva al primo remove)
			//bool //add \, select 0, edit delete twin remove 1, move switch 2

			//search, textprice, clear, confirm, cancel.
			//search = 1 add o 2 select o 5 move o 6 switch
			//textprice = 1 add o 3 edit
			//numero di prodotti box
			//clear(search || textprice)
			// confirm cancel = tranne 0
			//bool //search 3, textprice 4, clear 3 || 4, confirm cancel 5 

			bool[] vis = new bool[6];

			vis[0] = totline != 0;
			vis[1] = seline != totline + 1;
			vis[2] = totline > 1 && vis[1];
			vis[3] = fun == 1 || fun == 2 || fun == 5 || fun == 6;
			vis[4] = fun == 1 || fun == 3;
			vis[5] = fun != 0;

			SelectButton.Visible = vis[0];
			EditButton.Visible = vis[1];
			DeleteButton.Visible = vis[1];
			MoveButton.Visible = vis[2];
			SwitchButton.Visible = vis[2];
			TwinButton.Visible = vis[1];
			RemoveButton.Visible = vis[1];
			SearchVisible(vis[3]);
			TextPriceVisible(vis[4]);
			ClearVisible(vis[4] || vis[3]);
			ConfirmButton.Visible = vis[5];
			CancelButton1.Visible = vis[5];
		}
		private void AddButton_Click(object sender, EventArgs e)
		{
			fun = 1;
			seline = totline + 1;
			SetVisible();
			NameList.Text = $"Stai aggiungendo la linea {seline} :";
		}
		//edit fun ??
		private void EditButton_Click(object sender, EventArgs e)
		{
			fun = 6;
			SetVisible();
			NameList.Text = $"Stai modificando una linea:";
		}
		//select line
		private void SelectButton_Click(object sender, EventArgs e)
		{
			fun = 2;
			SetVisible();
			NameList.Text = "Scegli la linea da modificare digitando il numero in search :";
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
		private void SwitchButton_Click(object sender, EventArgs e)
		{

		}
		//edit // fun ??
		private void TwinButton_Click(object sender, EventArgs e)
		{
			fun = 7;
			SetVisible();
			NameList.Text = $"Stai duplicando una linea (verrà aggiunta accanto alla linea duplicata):";
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
			fun = 0;
			seline = totline + 1;
			SetVisible();
			StampaForm();
			NameList.Text = "Non è selezionata nessuna linea";
		}
		private void ClearButton_Click(object sender, EventArgs e)
		{
			TextBox.Text = "";
			PriceBox.Text = "";
			SearchBox.Text = "";
		}
		// cronologia
		private void HistoryButton_Click(object sender, EventArgs e)
		{//fun 9
			AddButton.Visible = false;
			SelectButton.Visible = false;
			EditButton.Visible = false;
			DeleteButton.Visible = false;
			MoveButton.Visible = false;
			SwitchButton.Visible = false;
			TwinButton.Visible = false;
			RemoveButton.Visible = false;
			SearchVisible(false);
			TextPriceVisible(false);
			ClearVisible(false);
			ConfirmButton.Visible = false;
			CancelButton1.Visible = true;
			ListaProdotti.Items.Clear();
			NameList.Text = "Queste sono le linee rimosse";

			string[] lines = File.ReadAllLines(path + "\\logic remove.txt");
			int i = 0;
			while (i < lines.Length)
				ListaProdotti.Items.Add(lines[i++]);
		}
		//edit
		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			bool control = SwitchFun(fun, TextBox.Text, PriceBox.Text, SearchBox.Text, totline, seline, path);
			if (control == true)
				switch (fun)
				{
					case 1: //addline
						totline += 1;
						seline += 1;
						SetVisible();
						NameList.Text = $"Stai aggiungendo la linea {seline}, o la linea scelta in search :";
						break;
					case 2:
						break;
				}
			StampaForm();
		}
		//edit
		private bool SwitchFun(int fun, string nome, string prezzo, string cerca, int totline, int seline, string path)
		{
			bool control = true; // false se qualcosa è andato storto
			switch (fun)
			{
				case 1:
					AddLine(nome, prezzo, cerca, totline, path);
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
		private int CheckCercaLine(string cerca, int totline)
		{
			if (cerca == "")
				return totline + 1;
			if (!int.TryParse(cerca, out int seline) || seline < 1) //seline = seleziona riga, select line
			{//bad input
				MessageBox.Show("inserisci un intero positivo", "errore nella ricerca");
				return 0;
			}
			if (seline > totline + 1)
			{//bad input
				MessageBox.Show("inserisci un indice che appare in lista", "errore nella ricerca");
				return 0;
			}
			return seline;
		}

		private void AddLine(string nome, string prezzo, string cerca, int totline, string path)
		{
			if (!CheckNomePrezzo(nome, prezzo)) //errore in input
				return;
			int seline = CheckCercaLine(cerca, totline);
			if (seline == 0) //0 = false
				return;

			string[] lines = File.ReadAllLines(path + "\\contatori.txt");
			lines[0] = (int.Parse(lines[0]) + 1).ToString(); //aggiungo un prodotto
			string totpro = lines[0];

			StreamWriter sw = new StreamWriter(path + "\\contatori.txt");
			for (int i = 0; i < seline; i++) //stampo fino alla linea scelta
				sw.WriteLine(lines[i]);
			sw.WriteLine("1"); //aggiungo la linea di prodotti
			for (int i = seline; i < lines.Length; i++) //stampo il resto
				sw.WriteLine(lines[i]);
			sw.Close();

			lines = File.ReadAllLines(path + "\\lista.csv");

			float sum = float.Parse(lines[lines.Length - 1]) + float.Parse(prezzo);

			sw = new StreamWriter(path + "\\lista.csv");
			for (int i = 0; i < seline - 1; i++)
				sw.WriteLine(lines[i]);
			sw.WriteLine(string.Join(";", seline, nome, prezzo)); //la nuova linea
			for (int i = seline-1; i < lines.Length - 2; i++)// -1 prezzo totale, -1 n prodotti
				sw.WriteLine(i+2 + ";" + lines[i].Split(";".ToCharArray(), 2)[1]); //scrive il nuovo indice, e poi trascrive il resto
			sw.WriteLine(totpro);
			sw.WriteLine(sum);
			sw.Close();

			lines = File.ReadAllLines(path + "\\lista.txt");
			sw = new StreamWriter(path + "\\lista.txt");

			for (int i = 0; i < seline -1; i++)
				sw.WriteLine(lines[i]);
			sw.WriteLine($"{seline}.    Nome: {nome}     Prezzo: {prezzo}");
			for (int i = seline -1; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				sw.WriteLine(i+2 + "." + lines[i].Split(".".ToCharArray(), 2)[1]); //scrive il nuovo indice, e poi trascrive il resto
			sw.WriteLine("-------------------");
			sw.WriteLine($"numero di prodotti: {totpro}");
			sw.WriteLine($"prezzo totale: {sum}");
			sw.Close();
		}
	}
}