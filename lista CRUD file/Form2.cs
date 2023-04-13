﻿#region using
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
//using System.Linq;
using System.Net.Http;
using System.Threading; */
//using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Schema;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using System.Linq; //ha .ToArray();

namespace lista_CRUD
{
	public partial class CRUD : Form
	{
		#endregion
		//ho appena updatebutton click, fare la fun 2.
		//ref selis in switchfun non mi ispira.
		//setvisible e checkvisible
		public int fun, totlis, selis; //fun funzione //totlis totale liste //lista selezionata
		public string path;
		public CRUD()
		{
			InitializeComponent();
			ListActionVisible(true); //!
			fun = 0;
			path = GetPath();
			totlis = GetListCount(path + "\\delimitatori.txt");
		}
		//{
		private string GetPath()
		{
			string path = Path.GetFullPath(".");
			// \lista CRUD file\bin\Debug = 26 char
			//path = path.Remove(path.Length - 26);
			path = Path.GetDirectoryName(path);
			path = Path.GetDirectoryName(path);
			path = Path.GetDirectoryName(path);
			path += @"\files";
			//Directory.CreateDirectory(path);
			return path;
		}
		private int GetListCount(string filepath)
		{
			StreamReader sr = new StreamReader(filepath);
			int read = int.Parse(sr.ReadLine());
			sr.Close();
			return read;
		}
		//}
		private void CRUD_Load(object sender, EventArgs e)
		{
			DescrizioneCreate.SetToolTip(CreateButton, "Crea una nuova lista");
			//
			//if (Directory.GetFiles("path").Length != 0) // !!
			//	(TwinButton.Visible, UpdateButton.Visible, DeleteButton.Visible) = (true, true, true);
		}

		//{
		//TextAction
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
		private void ConfirmVisible(bool vis)
		{
			(ConfirmButton.Visible, CancelButton1.Visible) = (vis, vis);
		}
		//
		private void ListActionVisible(bool vis)
		{
			(MoveButton.Visible, UpdateButton.Visible, DeleteButton.Visible) = (vis, vis, vis);
			(AddButton.Visible, DuplicateButton.Visible, EditButton.Visible, RemoveButton.Visible) = (vis, vis, vis, vis);
		}
		//}
		//{
		private void CreateButton_Click(object sender, EventArgs e)
		{
			SearchVisible(false);
			TextPriceVisible(true);
			ClearVisible(true);
			ConfirmVisible(true);

			fun = 1;
			ListaProdotti.Items.Clear();
			NameList.Text = $"Stai creando la Lista{totlis + 1} :";
		}
		private void MoveButton_Click(object sender, EventArgs e)
		{
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible) = (false, false, false, false);
			(SearchBox.Visible, SearchLabel.Visible, ClearButton.Visible, ClearLabel.Visible,
				ConfirmButton.Visible, CancelButton1.Visible) = (true, true, true, true, true, true);

			//fun = 3;
		}
		private void UpdateButton_Click(object sender, EventArgs e)
		{
			SearchVisible(true);
			TextPriceVisible(false);
			ClearVisible(true); //considera se riapri il programma con già delle liste
			ConfirmVisible(true);

			fun = 2;
			ListaProdotti.Items.Clear();
			NameList.Text = "Scegli la lista da aprire digitando il numero in search :";
			for (int i = 1; i <= totlis; i++)//errore
				ListaProdotti.Items.Add($"{i}. Lista{i}");
		}
		private void DeleteButton_Click(object sender, EventArgs e)
		{
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, ClearButton.Visible,
				ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (false, false, false, false, true, true, true, true, true, true);

			//fun = 4;
		}
		private void AddButton_Click(object sender, EventArgs e)
		{
			SearchVisible(false);
			TextPriceVisible(true);

			fun = 5;
			NameList.Text = $"Stai aggiungendo alla Lista{selis} :";
		}
		private void DuplicateButton_Click(object sender, EventArgs e)
		{

		}
		private void EditButton_Click(object sender, EventArgs e)
		{

		}
		private void RemoveButton_Click(object sender, EventArgs e)
		{

		}
		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			bool control = SwitchFun(fun, TextBox.Text, PriceBox.Text, SearchBox.Text, path, ref selis, totlis);
			if (control == true)
				switch (fun)
				{
					case 1: //create
						totlis += 1;
						selis = totlis;

						//NameList.Text = $"Stai aggiungendo alla Lista{selis} :";
						//fun = 5; //add
						AddButton_Click(sender, e);

						//if (totlis == 0) ListActionVisible(false);
						//else ListActionVisible(true); //non può essere 0 se crea una lista
						// ListActionVisible(true);
						break;
					case 2: //open
						AddButton_Click(sender, e);
						//selis cambiato con ref
						//visible
						break;
				}
			//setvisible //checkvisible
			StampaForm();
		}
		private void CancelButton1_Click(object sender, EventArgs e)
		{
			ClearButton_Click(sender, e);

			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible, SearchBox.Visible, SearchLabel.Visible, ClearButton.Visible,
				ClearLabel.Visible, ConfirmButton.Visible, CancelButton1.Visible) = (false, false, false, false, false, false, false, false, false, false);

			//fun = 0;
		}
		private void ClearButton_Click(object sender, EventArgs e)
		{
			TextBox.Text = "";
			PriceBox.Text = "";
			SearchBox.Text = "";
		}
		//}

		private bool SwitchFun(int fun, string nome, string prezzo, string cerca, string path, ref int selis, int totlis)
		{
			bool control = true; // false se qualcosa è andato storto
			switch (fun)
			{
				case 1:
					control = CreaFile(nome, prezzo, path);
					//false se non ha creato
					//fun = 5;
					break;
				case 2:
					int temp = OpenFile(cerca, totlis);
					if (temp != 0) selis = temp;
					else control = false;
					break;
				case 5:
					AddLine(nome, prezzo, path, selis);
					break;
					/*
						case 2:
							//OpenFile();
							break;

						case 3:
							//twin file
							break;

						case 4:
							//delete file
							break;

						case 5:
							//AddProd();
							break;
					*/
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
			if (!double.TryParse(prezzo, out double price) || price < 0)
			{//bad input
				MessageBox.Show("numero decimale positivo", "errore nel prezzo");
				return false;
			}

			return true;
		}

		private bool CreaFile(string nome, string prezzo, string path)
		{ //fun 1
			if (!CheckNomePrezzo(nome, prezzo)) //bad input
				return false;

			string[] lines = File.ReadAllLines(path +"\\delimitatori.txt");

			StreamWriter swliste = new StreamWriter(path +"\\liste.txt", true);
			swliste.WriteLine($"1.    Nome: {nome}|    Prezzo: {prezzo}");
			swliste.WriteLine("-------------------");
			swliste.WriteLine("numero di prodotti: 1");
			swliste.WriteLine($"prezzo totale: {prezzo}"); // 15 char + somma
			swliste.WriteLine("###################");
			swliste.Close();

			StreamWriter swdel = new StreamWriter(path +"\\delimitatori.txt");
			swdel.WriteLine(int.Parse(lines[0]) + 1);
			for (int i = 1; i < lines.Length; i++)
				swdel.WriteLine(lines[i]);
			swdel.Write("5");
			swdel.Close();

			return true;
		}

		//openfile controlla se la lista cercata esiste, e modifica la variabile selis(lista selezionata), con selis si stampa la lista e va in fun 5(add)
		private int OpenFile(string cerca, int totlis)
		{
			if (!int.TryParse(cerca, out int selis) || selis < 1)
			{//bad input
				MessageBox.Show("inserisci un intero positivo", "errore nella ricerca");
				return 0; // 0 = false, se ritorna 0 non ha selezionato nessuna lista
			}
			if (selis > totlis) //il totale liste si trova nel file
			{//bad input
				MessageBox.Show("inserisci un indice che appare in lista", "errore nella ricerca");
				return 0;
			}

			return selis; //ritorna la lista selezionata
		}

		private void AddLine(string nome, string prezzo, string path, int selis)
		{//fun 5
			if (!CheckNomePrezzo(nome, prezzo)) //bad input
				return;

			string[] lines = File.ReadAllLines(path + "\\delimitatori.txt");
			//in lines[0] c'è la riga che conta quante liste ci sono
			// in lines 1 c'è la riga che dice quante linee è lunga la lista1
			//in ogni linea precedente tranne 0 si calcola la somma delle linee da trascrivere
			int numpro = int.Parse(lines[selis]) - 4; //numero righe di prodotti // 4 sono =  prodotti + somma + 2 separatori.
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
			//per il nuovo prodotto verrà trascritto fino a line+numpro, e alla riga successiva scritto il nuovo prodotto, per poi modificare le righe successive e infine trascrivere il resto del file

			lines = File.ReadAllLines(path + "\\liste.txt");

			//il fondo della lista ha la somma dei prezzi
			//conteggio char 15, 15 - 1 per la posizione, +1 = 15 il carattere successivo
			//line + numpro + 3 è dove si trova la somma
			string str = "";
			for (int c = 15; c < lines[line+numpro+2].Length; c++)
				str += lines[line+numpro+2][c];
			double sum = double.Parse(str) + double.Parse(prezzo);

			sw = new StreamWriter(path + "\\liste.txt");
			for (int i = 0; i < line+numpro; i++)
				sw.WriteLine(lines[i]);
			sw.WriteLine($"{numpro + 1}.    Nome: {nome}|    Prezzo: {prezzo}");
			sw.WriteLine("-------------------");
			sw.WriteLine($"numero di prodotti: {numpro + 1}");
			sw.WriteLine($"prezzo totale: {sum}"); // 15 char + somma
			sw.WriteLine("###################");

			for (int i = line+numpro+4; i < lines.Length; i++)
				sw.WriteLine(lines[i]);
			sw.Close();
		}

		private void StampaForm()
		{
			string[] lines = File.ReadAllLines(path + "\\delimitatori.txt"); //trovo delimitatori

			int line = 0; //numero riga dove inizia la lista
			for (int i = 1; i < selis; i++)
				line += int.Parse(lines[i]);

			int length = int.Parse(lines[selis]);

			lines = File.ReadAllLines(path + "\\liste.txt");

			ListaProdotti.Items.Clear();
			for (int i = line; i < line + length - 1; i++)
				ListaProdotti.Items.Add(lines[i]);
		}
	}
}