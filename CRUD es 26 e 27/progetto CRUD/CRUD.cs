#region using
using System;
/* using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.ComponentModel;
using System.Data;
using System.Linq; //ha .ToArray();
using System.Net.Http;
using System.Threading; */
//using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text;
using System.Diagnostics;

namespace progetto_CRUD
{
	#endregion
	public struct StructLines
	{
		public int ind;
		public string text;
		public int amount;
		public float price;
	}
	public partial class CRUD : Form
	{
		//listview tabelle e struct (togliere lista.txt)
		//rifare accesso diretto
		//tooltip
		//menu a comparsa
		//elementi cliccabili in listview
		//funzioni esterne
		//cronologia //pensavo a due stack (ctrl z  ctrl y) //togliere logicremove.csv e mettere history.csv

		//non c'è mai seline 0; quando è 0 diventa totline + 1; tranne add e select funziona tutto a select line

		public int len, totpro; //len lunghezza usata struct[], totpro totale prodotti
		public float sumprice; //somma prezzi
		public StructLines[] csvLines;
		public int fun, totline, seline; //fun funzione //totline totale linee //seline linea selezionata
		public string path;
		public CRUD()
		{
			InitializeComponent();
			path = GetPath();
			totline = GetLineCount(path + "\\lista.csv") - 2;
			seline = totline + 1;
			fun = 0; // 1 add, 2 select, 3 edit, 4 delete, 5 move, 6 switch, 7 twin, 8 remove, (a parte) 9 history

			//SetVisible(); crud load
			//StampaForm();
			File.Create(path + "\\logicRemove.csv").Close(); //crea o svuota
		}
		private string GetPath()
		{
			string path = Path.GetFullPath("..\\..\\..\\files");
			//Directory.CreateDirectory(path);
			return path;
		}
		private int GetLineCount(string path)
		{
			int lineCount = 0;
			FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
			for (int ch = fs.ReadByte(); ch!=-1; ch = fs.ReadByte())
				if ((char)ch == '\n') lineCount++;
			fs.Close();
			return lineCount;
		}
		private string[] FileReadAllLines(string path)
		{
			byte[] b = new byte[1024];
			UTF8Encoding temp = new UTF8Encoding(true);
			string line = "";
			FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
			for (int l; (l = fs.Read(b, 0, b.Length)) > 0;)
				line += temp.GetString(b, 0, l);
			fs.Close();

			if (line == "") return new string[0];
			// .SubString() perché altrimenti per ultimo rimarrebbe una stringa vuota
			string[] lines = line.Substring(0, line.Length-1).Split('\n');
			for (int i = 0; i < lines.Length; i++)
				lines[i] = lines[i].TrimEnd('\r');
			return lines;
		}
		private void FileWriteAllLines(string path, string[] lines)
		{
			FileWriteAllLines(path, lines, FileMode.Create);
		}
		private void FileWriteAllLines(string path, string[] lines, FileMode mode)
		{
			string allLines = string.Join("\n", lines);
			Byte[] info = new UTF8Encoding(true).GetBytes(allLines);
			FileStream fs = new FileStream(path, mode, FileAccess.Write, FileShare.None);
			fs.Write(info, 0, info.Length);
			fs.Close();
		}
		private void CRUD_Shown(object sender, EventArgs e)
		{
			SetVisible();
			StampaForm();

			//aggiungere
			DescrizioneAdd.SetToolTip(AddButton, "Aggiungi nuova linea");
			DescrizioneHistoryR.SetToolTip(HistoryButton, "Guarda la lista delle linee rimosse");

		}
		private void Shortcut(object sender, KeyEventArgs e)
		{
			if (e.Control && e.Shift && e.KeyCode == Keys.A && AddButton.Visible)
				//shortcut Ctrl+Shift+A
				AddButton_Click(sender, e);
			if (e.Control && e.Shift && e.KeyCode == Keys.S && SelectButton.Visible)
				//shortcut Ctrl+Shift+S
				SelectButton_Click(sender, e);
			if (e.Control && e.Shift && e.KeyCode == Keys.E && EditButton.Visible)
				//shortcut Ctrl+Shift+E
				EditButton_Click(sender, e);
			if (e.Control && e.Shift && e.KeyCode == Keys.D && DeleteButton.Visible)
				//shortcut Ctrl+Shift+D
				DeleteButton_Click(sender, e);
			if (e.Control && e.Shift && e.KeyCode == Keys.M && MoveButton.Visible)
				//shortcut Ctrl+Shift+M
				MoveButton_Click(sender, e);
			if (e.Control && e.Shift && e.KeyCode == Keys.T && TwinButton.Visible)
				//shortcut Ctrl+Shift+T
				TwinButton_Click(sender, e);
			if (e.Control && e.Shift && e.KeyCode == Keys.W && SwitchButton.Visible)
				//shortcut Ctrl+Shift+W
				SwitchButton_Click(sender, e);
			if (e.Control && e.Shift && e.KeyCode == Keys.R && RemoveButton.Visible)
				//shortcut Ctrl+Shift+R
				RemoveButton_Click(sender, e);
			if (e.Control && e.Shift && e.KeyCode == Keys.H && HistoryButton.Visible)
				//shortcut Ctrl+Shift+H
				HistoryButton_Click(sender, e);
			if (e.Control && e.Shift && e.KeyCode == Keys.I && IndexCheckBox.Visible)
				//shortcut Ctrl+Shift+I
				IndexCheckBox.Checked = !IndexCheckBox.Checked;
			if (e.Control && e.Shift && e.KeyCode == Keys.C && ClearButton.Visible)
				//shortcut Ctrl+Shift+C
				ClearButton_Click(sender, e);
			if (e.Control && e.Shift && e.KeyCode == Keys.Enter && ConfirmButton.Visible)
				//shortcut Ctrl+Shift+Enter
				ConfirmButton_Click(sender, e);
			if (e.Control && e.Shift && (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) && CancelButton1.Visible)
				//shortcut Ctrl+Shift+ Canc o Back
				CancelButton1_Click(sender, e);

			if (e.Control && e.Alt && e.KeyCode == Keys.S && SearchBox.Visible)
				//shortcut Ctrl+Alt+ S
				SearchBox.Focus();
			if (e.Control && e.Alt && e.KeyCode == Keys.T && TextBox.Visible)
				//shortcut Ctrl+Alt+ T
				TextBox.Focus();
			if (e.Control && e.Alt && e.KeyCode == Keys.P && PriceBox.Visible)
				//shortcut Ctrl+Alt+ P
				PriceBox.Focus();
			if (e.Control && e.Alt && e.KeyCode == Keys.A && AmountBox.Visible)
				//shortcut Ctrl+Alt+ A
				AmountBox.Focus();
		}
		private void StampaForm()
		{
			StampaForm(FileReadAllLines(path + "\\lista.csv"));
		}
		private void StampaForm(string[] lines)
		{
			Lista.Clear();

			ColumnHeader index, name, amount, price;
			index = new ColumnHeader()
			{
				Text = "index",
				TextAlign = HorizontalAlignment.Center,
				Width = 44
			};
			name = new ColumnHeader()
			{
				Text = "name",
				TextAlign = HorizontalAlignment.Center,
				Width = 46
			};
			amount = new ColumnHeader()
			{
				Text = "amount",
				TextAlign = HorizontalAlignment.Center,
				Width = 56
			};
			price = new ColumnHeader()

			{
				Text = "price",
				TextAlign = HorizontalAlignment.Center,
				Width = 42
			};

			Lista.Columns.Add(index);
			Lista.Columns.Add(name);
			Lista.Columns.Add(amount);
			Lista.Columns.Add(price);

			ListViewItem line;
			for (int i = 0; i < lines.Length; i++)
			{
				string[] split = lines[i].Split(';');
				if (split.Length == 1)
				{
					line = new ListViewItem(); //main item
					Lista.Items.Add("");
					line.SubItems.Add("totale prodotti:"); //sub item
					line.SubItems.Add(lines[lines.Length-2]); //sub item
					Lista.Items.Add(line);
					line = new ListViewItem(); //main item
					line.SubItems.Add("somma totale:"); //sub item
					line.SubItems.Add(""); //sub item
					line.SubItems.Add(lines[lines.Length-1]); //sub item
					Lista.Items.Add(line);
					break;
				}
				else
				{
					line = new ListViewItem(split[0]); //main item
					for (int j = 1; j < split.Length; j++)
						line.SubItems.Add(split[j]); //sub item
					Lista.Items.Add(line);
				}
			}

			index.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			if (index.Width<44) index.Width=44;
			name.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			if (name.Width<46) name.Width=46;
			amount.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			if (amount.Width<56) amount.Width=56;
			price.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			if (price.Width<42) price.Width=42;
		}
		private void ChiudiFormButton_Click(object sender, EventArgs e)
		{
			File.Create(path + "\\logicRemove.csv").Close(); //svuota
			Close();
		}
		private void ClosingForm(object sender, FormClosingEventArgs e)
		{//???
			File.Create(path + "\\logicRemove.csv").Close(); //svuota
		}
		private void SearchVisible(bool vis)
		{
			(SearchBox.Visible, SearchLabel.Visible) = (vis, vis);
		}
		private void TextPriceVisible(bool vis)
		{
			(TextBox.Visible, TextLabel.Visible, PriceBox.Visible, PriceLabel.Visible) = (vis, vis, vis, vis);
		}
		private void AmountVisible(bool vis)
		{
			AmountBox.Visible = vis;
			AmountLabel.Visible = vis;
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

			//search, textprice, amount, clear, confirm, cancel.
			//search = 1 add o 2 select o 5 move o 6 switch
			//textprice = 1 add o 3 edit
			//amount = 1 add o 3 edit o 8 remove
			//numero di prodotti box
			//clear(search || textprice)
			// confirm = tranne 0
			//cancel = tranne 0 e tranne seline non è 0
			//bool //search 3, textprice 4, amount 4 || fun 8, clear 3 || 4 || fun 8, confirm 5, cancel 5 || 1

			bool[] vis = new bool[6];

			vis[0] = totline != 0;
			vis[1] = seline != totline + 1;
			vis[2] = totline > 1 && vis[1];
			vis[3] = fun == 1 || fun == 2 || fun == 21 || fun == 5 || fun == 6;
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
			AmountVisible(fun == 8 || vis[4]);
			ClearVisible(vis[3] || vis[4] || fun == 8);
			ConfirmButton.Visible = vis[5];
			CancelButton1.Visible = vis[5] || vis[1];

			//box ricerca index o testo
			IndexCheckBox.Visible = fun == 2 || fun == 21;
		}
		private void AddButton_Click(object sender, EventArgs e)
		{
			fun = 1;
			seline = totline + 1;
			SetVisible();
			NameList.Text = $"Stai aggiungendo la linea {seline}, o la linea scelta in search:";
		}
		private void EditButton_Click(object sender, EventArgs e)
		{
			fun = 3;
			SetVisible();
			NameList.Text = $"Stai modificando il testo della linea {seline}:";
		}
		private void SelectButton_Click(object sender, EventArgs e)
		{
			IndexCheckBox.Checked = true;
			fun = 21;
			seline = totline + 1;
			SetVisible();
			NameList.Text = "Scegli la linea da modificare digitando il numero in search :";
		}
		private void IndexCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (IndexCheckBox.Checked) { fun = 21; StampaForm(); NameList.Text = "Scegli la linea da modificare digitando il numero in search :"; }
			if (!IndexCheckBox.Checked) fun = 2;
		}
		private void DeleteButton_Click(object sender, EventArgs e)
		{
			fun = 4;
			SetVisible();
			NameList.Text = $"Conferma per cancellare la linea {seline}:";
		}
		private void MoveButton_Click(object sender, EventArgs e)
		{
			fun = 5;
			SetVisible();
			NameList.Text = $"Stai spostando la linea {seline}:";
		}
		private void SwitchButton_Click(object sender, EventArgs e)
		{
			fun = 6;
			SetVisible();
			NameList.Text = $"Stai scambiando la linea {seline}:";
		}
		private void TwinButton_Click(object sender, EventArgs e)
		{
			fun = 7;
			SetVisible();
			NameList.Text = $"Conferma per duplicare la linea {seline}:";
			//verrà aggiunta accanto alla linea duplicata
		}
		//remove tot amount
		private void RemoveButton_Click(object sender, EventArgs e)
		{
			fun = 8;
			SetVisible();
			NameList.Text = $"Stai rimuovendo dei prodotti dalla linea {seline}:";
		}

		private void CancelButton1_Click(object sender, EventArgs e)
		{
			fun = 0;
			seline = totline + 1;
			SetVisible();
			AddButton.Visible = true;
			StampaForm();
			NameList.Text = "Non è stata selezionata nessuna linea";
		}
		private void ClearButton_Click(object sender, EventArgs e)
		{
			TextBox.Text = "";
			AmountBox.Text = "";
			PriceBox.Text = "";
			SearchBox.Text = "";
		}
		// cronologia
		private void HistoryButton_Click(object sender, EventArgs e)
		{//fun 9
			if (fun != 9)
			{
				fun = 9;
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
				AmountVisible(false);
				ClearVisible(false);
				ConfirmButton.Visible = false;

				CancelButton1.Visible = true;
				Lista.Items.Clear();
				NameList.Text = "Queste sono le linee rimosse";
				ListViewItem line = new ListViewItem(); //main item
				line.SubItems.Add("riclicca il pulsante H per ripristinare la cancellazione più recente");
				Lista.Items.Add(line);
				StampaForm(FileReadAllLines(path + "\\logicRemove.csv"));
			}
			else
			{
				string[] lines = FileReadAllLines(path + "\\logicRemove.csv");
				string[] splits = lines[0].Split(';');
				AddButton.Visible = true;
				AddButton_Click(sender, e);
				AddLine(splits[1], splits[2], splits[3], splits[0], totline, path);
				totline += 1;
				seline = int.Parse(splits[0]);
				fun = 0;
				NameList.Text = $"Stai modificando la linea {seline}";
				SetVisible();
				StampaForm();

				if (lines.Length != 1)
				{
					//StreamWriter sw = new StreamWriter(path + "\\logicRemove.csv");
					lines[0] = "";
					for (int i = 1; i<lines.Length; i++)
						lines[0] += lines[i] + "\n";
					Byte[] info = new UTF8Encoding(true).GetBytes(lines[0]);
					FileStream fs = new FileStream(path + "\\logicRemove.csv", FileMode.Truncate, FileAccess.Write, FileShare.None);
					fs.Write(info, 0, info.Length);
					fs.Close();
				}
				else
				{
					File.Create(path + "\\logicRemove.csv").Close(); //svuota
					HistoryButton.Visible = false;
				}
			}
		}

		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			bool control = true;
			if (fun != 2) control = SwitchFun(ref fun, TextBox.Text, AmountBox.Text, PriceBox.Text, SearchBox.Text, totline, seline, path);
			if (control) //if SwitchFun è meno ridondante ma brutto
			{
				switch (fun)
				{
					case 1: //addline
						totline += 1;
						seline += 1;
						NameList.Text = $"Stai aggiungendo la linea {seline}, o la linea scelta in search :";
						break;
					case 21: //select index
					case 5: //move line
					case 6: //switch line
						seline = int.Parse(SearchBox.Text);
						break;
					case 4: //delete line
						if (seline == totline) seline--;
						if (seline == 0) seline++;
						totline--;
						NameList.Text = $"Conferma per cancellare la linea {seline}:";
						HistoryButton.Visible = true;
						break;
					case 7: //twin line
						totline += 1;
						seline += 1;
						break;
					case 8: //remove amount
						NameList.Text = $"Stai modificando la linea {seline}";
						break;
					case 84: //quando da 8remove passa a 4delete, ma era remove
						if (seline == totline) seline--;
						if (seline == 0) seline++;
						totline--;
						NameList.Text = $"Stai rimuovendo dei prodotti dalla linea {seline}:";
						fun = 8;
						HistoryButton.Visible = true;
						break;
				}
				switch (fun)
				{
					case 21: //select index
					case 3: //edit line
					case 5: //move line
					case 6: //switch line
					case 7: //twin line
						NameList.Text = $"Stai modificando la linea {seline}";
						fun = 0;
						break;
				}
			}
			if (totline == 0 && (fun == 4 || fun == 8)) //&& fun 4 //serve quando sbagli in add con 0 linee
				CancelButton1_Click(sender, e); //NameList.Text e fun 0

			if (fun == 2)
			{
				NameList.Text = $"Tutte le linee trovate in ricerca(spunta index e scegli la linea da modificare):";
				StampaForm(SelectLineResearch(SearchBox.Text, path));
			}
			else
			{
				SetVisible();
				StampaForm();
			}
		}
		private bool SwitchFun(ref int fun, string nome, string qua, string prezzo, string cerca, int totline, int seline, string path)
		{
			bool control = true; // false se qualcosa è andato storto
			switch (fun)
			{
				case 1:
					control = AddLine(nome, qua, prezzo, cerca, totline, path); //mettere return AddLine ?
					break;
				case 21:
					control = SelectLineIndex(cerca, totline);
					break;
				case 3:
					control = EditLine(nome, qua, prezzo, seline, path);
					break;
				case 4:
					DeleteLine(seline, path);
					break;
				case 5:
					control = MoveLine(cerca, totline, seline, path);
					break;
				case 6:
					control = SwitchLine(cerca, totline, seline, path);
					break;
				case 7:
					TwinLine(seline, path);
					break;
				case 8:
					int amount = RemoveAmount(qua, seline, path);
					control = amount != -1; //-1 = errore in input
					if (amount == 0) fun = 84;
					break;
			}
			return control;
		}

		private bool CheckNomePrezzoQua(string nome, string qua, string prezzo)
		{
			if (nome == "")
			{//bad input
				MessageBox.Show("Scrivi qualcosa", "errore nel nome del prodotto");
				return false;
			}
			if (nome.Contains(";"))
			{//bad input
				MessageBox.Show("Non puoi usare il carattere ' ; '", "errore nel nome del prodotto");
				return false;
			}
			if (!int.TryParse(qua, out int amount) || amount < 0)
			{//bad input
				MessageBox.Show("numero intero positivo", "errore nella quantità");
				return false;
			}
			if (!float.TryParse(prezzo, out float price) || price < 0)
			{//bad input
				MessageBox.Show("numero decimale positivo", "errore nel prezzo");
				return false;
			}

			return true;
		}
		private bool EditCheckNomePrezzoQua(string nome, string qua, string prezzo)
		{
			//se nome o prezzo o qua sono vuoti è ok, non tutti vuoti
			//quando 1 o 2 sono vuoti si prende quello vecchio
			if (nome == "" && prezzo == "" && qua == "")
			{//bad input
				MessageBox.Show("Scrivi qualcosa", "errore nel nome del prodotto");
				return false;
			}
			if (nome.Contains(";"))
			{//bad input
				MessageBox.Show("Non puoi usare il carattere ' ; '", "errore nel nome del prodotto");
				return false;
			}
			if (qua != "")
				if (!int.TryParse(qua, out int amount) || amount < 0)
				{//bad input
					MessageBox.Show("numero intero positivo", "errore nella quantità");
					return false;
				}
			if (prezzo != "")
				if (!float.TryParse(prezzo, out float price) || price < 0)
				{//bad input
					MessageBox.Show("numero decimale positivo", "errore nel prezzo");
					return false;
				}

			return true;
		}
		private bool CheckAmount(string qua, int amount)
		{
			if (!int.TryParse(qua, out int quan) || quan < 0)
			{//bad input
				MessageBox.Show("numero intero positivo", "errore nella quantità");
				return false;
			}
			if (quan > amount)
			{//bad input
				MessageBox.Show("inserisci una quantità minore di quella selezionata", "errore nella quantità");
				return false;
			}
			return true;
		}
		private int IntCheckCercaLine(string cerca, int totline)
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
		private bool BoolCheckCercaLine(string cerca, int totline)
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
			return true; //ret false = il cerca non è valido
		}
		private bool AddLine(string nome, string qua, string prezzo, string cerca, int totline, string path)
		{//fun 1
			if (qua=="") qua = "1";
			if (!CheckNomePrezzoQua(nome, qua, prezzo)) //errore in input
				return false;
			int seline = IntCheckCercaLine(cerca, totline);
			if (seline == 0) //0 = false
				return false;
			seline--;

			string[] lines = FileReadAllLines(path + "\\lista.csv");
			string totpro = (int.Parse(lines[lines.Length - 2]) + int.Parse(qua)).ToString(); //aggiungo i prodotti
			float sum = float.Parse(lines[lines.Length - 1]) + float.Parse(prezzo);

			string allLines = "";
			for (int i = 0; i < seline; i++)
				allLines += lines[i] + "\n";
			allLines += string.Join(";", seline+1, nome, qua, prezzo) + "\n";
			for (int i = seline; i < lines.Length - 2; i++)// -1 prezzo totale, -1 n prodotti
				allLines += i+2 + ";" + lines[i].Split(";".ToCharArray(), 2)[1] + "\n"; //scrive il nuovo indice, e poi trascrive il resto
			allLines += totpro + "\n" + sum + "\n";
			Byte[] info = new UTF8Encoding(true).GetBytes(allLines);
			FileStream fs = new FileStream(path + "\\lista.csv", FileMode.Open, FileAccess.Write, FileShare.None);
			fs.Write(info, 0, info.Length);
			fs.Close();

			/*
			StreamWriter sw = new StreamWriter(path + "\\lista.csv");
			for (int i = 0; i < seline; i++)
				sw.WriteLine(lines[i]);
			sw.WriteLine(string.Join(";", seline+1, nome, qua, prezzo)); //la nuova linea
			for (int i = seline; i < lines.Length - 2; i++)// -1 prezzo totale, -1 n prodotti
				sw.WriteLine(i+2 + ";" + lines[i].Split(";".ToCharArray(), 2)[1]); //scrive il nuovo indice, e poi trascrive il resto
			sw.WriteLine(totpro);
			sw.WriteLine(sum);
			sw.Close();
			*/

			/*lines = FileReadAllLines(path + "\\lista.txt");

			allLines = "";
			for (int i = 0; i < seline; i++)
				allLines += lines[i] + "\n";
			allLines += $"{seline+1}.    Nome: {nome}     Quantità: {qua}     Prezzo: {prezzo}\n";
			for (int i = seline; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				allLines += i+2 + "." + lines[i].Split(".".ToCharArray(), 2)[1] + "\n"; //scrive il nuovo indice, e poi trascrive il resto
			allLines += $"-------------------\nnumero di prodotti: {totpro}\nprezzo totale: {sum}\n";
			info = new UTF8Encoding(true).GetBytes(allLines);
			fs = new FileStream(path + "\\lista.txt", FileMode.Open, FileAccess.Write, FileShare.None);
			fs.Write(info, 0, info.Length);
			fs.Close();*/

			/*
			var sw = new StreamWriter(path + "\\lista.txt");
			for (int i = 0; i < seline; i++)
				sw.WriteLine(lines[i]);
			sw.WriteLine($"{seline+1}.    Nome: {nome}     Quantità: {qua}     Prezzo: {prezzo}");
			for (int i = seline; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				sw.WriteLine(i+2 + "." + lines[i].Split(".".ToCharArray(), 2)[1]); //scrive il nuovo indice, e poi trascrive il resto
			sw.WriteLine("-------------------");
			sw.WriteLine($"numero di prodotti: {totpro}");
			sw.WriteLine($"prezzo totale: {sum}");
			sw.Close();
			*/
			return true;
		}
		private bool SelectLineIndex(string cerca, int totline)
		{//fun 21
			return BoolCheckCercaLine(cerca, totline); //ret false = il cerca non è valido //ret true = string cerca  ha  int seline
		}
		private string[] SelectLineResearch(string cerca, string path)
		{//fun 2
			string[] lines = FileReadAllLines(path + "\\lista.csv");
			string[] splits = new string[0];
			int k = 0;
			for (int i = 0; i< lines.Length-2; i++)
				if (lines[i].Split(";".ToCharArray(), 3)[1].ToLower().Contains(cerca.ToLower())) //cerca solo in text
				{
					splits = lines[i].Split(';');
					lines[k++]=$"{splits[0]}.    Nome: {splits[1]}     Quantità: {splits[2]}     Prezzo: {splits[3]}";
				}
			if (splits.Length == 0)
			{
				ErrorInSelect();
				return new string[0];
			}
			else
			{
				Array.Resize(ref lines, k);
				return lines;
			}
		}
		private void ErrorInSelect()
		{
			MessageBox.Show("la parola cercata non esiste", "errore nella ricerca");
		}
		private bool EditLine(string nome, string qua, string prezzo, int seline, string path)
		{//fun 3
			if (!EditCheckNomePrezzoQua(nome, qua, prezzo)) //errore in input
				return false;

			seline--;
			string[] lines = FileReadAllLines(path + "\\lista.csv");
			if (nome == "")
				nome = lines[seline].Split(";".ToCharArray(), 3)[1];
			int totpro;
			if (qua == "")
			{
				qua = lines[seline].Split(";".ToCharArray(), 4)[2];
				totpro = int.Parse(lines[lines.Length - 2]);
			}
			else
				//al totpro attuale toglie il vecchio valore e ci aggiunge quello modificato
				totpro = int.Parse(lines[lines.Length-2]) - int.Parse(lines[seline].Split(";".ToCharArray(), 4)[2]) + int.Parse(qua);
			float sum;
			if (prezzo == "")
			{
				prezzo = lines[seline].Split(";".ToCharArray(), 4)[3];
				sum = float.Parse(lines[lines.Length - 1]);
			}
			else
				//alla somma attuale toglie il vecchio valore e si aggiunge quello modificato
				sum = float.Parse(lines[lines.Length - 1]) - float.Parse(lines[seline].Split(";".ToCharArray(), 4)[3]) + float.Parse(prezzo);

			string allLines = "";
			for (int i = 0; i < seline; i++)
				allLines += lines[i] + "\n";
			allLines += string.Join(";", seline+1, nome, qua, prezzo) + "\n";
			for (int i = seline+1; i < lines.Length - 2; i++)//seline + 1 per saltare la vecchia linea // length -1 prezzo totale, -1 n prodotti
				allLines += lines[i] + "\n"; //trascrive il resto
			allLines += totpro + "\n" + sum + "\n";
			//allLines += totpro + '\n' + sum + '\n'; //essendo totpro e sum degli interi, i char '\n' rappresentano il 10
			Byte[] info = new UTF8Encoding(true).GetBytes(allLines);
			FileStream fs = new FileStream(path + "\\lista.csv", FileMode.Truncate, FileAccess.Write, FileShare.None); //file mode truncate per evitare errori
			fs.Write(info, 0, info.Length);
			fs.Close();

			/*
			StreamWriter sw = new StreamWriter(path + "\\lista.csv");
			for (int i = 0; i < seline; i++)
				sw.WriteLine(lines[i]);
			//aggiungo la linea modificata
			sw.WriteLine(string.Join(";", seline+1, nome, qua, prezzo));
			for (int i = seline+1; i < lines.Length - 2; i++)//seline + 1 per saltare la vecchia linea // length -1 prezzo totale, -1 n prodotti
				sw.WriteLine(lines[i]); //trascrive il resto
			sw.WriteLine(totpro);
			sw.WriteLine(sum);
			sw.Close();
			*/

			/*lines = FileReadAllLines(path + "\\lista.txt");

			allLines = "";
			for (int i = 0; i < seline; i++)
				allLines += lines[i] + "\n";
			allLines += $"{seline+1}.    Nome: {nome}     Quantità: {qua}     Prezzo: {prezzo}\n";
			for (int i = seline+1; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				allLines += lines[i] + "\n"; //trascrive il resto
			allLines += $"-------------------\nnumero di prodotti: {totpro}\nprezzo totale: {sum}\n";
			info = new UTF8Encoding(true).GetBytes(allLines);
			fs = new FileStream(path + "\\lista.txt", FileMode.Truncate, FileAccess.Write, FileShare.None);
			fs.Write(info, 0, info.Length);
			fs.Close();*/

			/*
			sw = new StreamWriter(path + "\\lista.txt");

			for (int i = 0; i < seline; i++)
				sw.WriteLine(lines[i]);
			sw.WriteLine($"{seline+1}.    Nome: {nome}     Quantità: {qua}     Prezzo: {prezzo}");
			for (int i = seline + 1; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				sw.WriteLine(lines[i]); //trascrive il resto
			sw.WriteLine("-------------------");
			sw.WriteLine($"numero di prodotti: {totpro}");
			sw.WriteLine($"prezzo totale: {sum}");
			sw.Close();
			*/
			return true;
		}
		private void DeleteLine(int seline, string path)
		{//fun 4
			seline--;
			string[] lines = FileReadAllLines(path + "\\lista.csv");
			int totpro = int.Parse(lines[lines.Length-2]) - int.Parse(lines[seline].Split(";".ToCharArray(), 4)[2]); //tolgo una linea di prodotti
			float sum = float.Parse(lines[lines.Length - 1]) - float.Parse(lines[seline].Split(";".ToCharArray(), 4)[3]);
			string logic = lines[seline] + "\n";//linea da aggiungere alla cancellazione logica

			string allLines = "";
			for (int i = 0; i < seline; i++)
				allLines += lines[i] + "\n";
			for (int i = seline + 1; i < lines.Length - 2; i++)//seline + 1 per saltare // length -1 prezzo totale, -1 n prodotti
				allLines += i + ";" + lines[i].Split(";".ToCharArray(), 2)[1] + "\n"; //i+1 indice attuale // i = il nuovo indice, e poi trascrive il resto
			allLines += totpro + "\n" + sum + "\n";
			Byte[] info = new UTF8Encoding(true).GetBytes(allLines);
			FileStream fs = new FileStream(path + "\\lista.csv", FileMode.Truncate, FileAccess.Write, FileShare.None); //truncate perché il numero di byte è meno rispetto a prima
			fs.Write(info, 0, info.Length);
			fs.Close();

			/*
			StreamWriter sw = new StreamWriter(path + "\\lista.csv");
			for (int i = 0; i < seline; i++)
				sw.WriteLine(lines[i]);
			string logic = lines[seline];//linea da aggiungere alla cancellazione logica
			for (int i = seline + 1; i < lines.Length - 2; i++)//seline + 1 per saltare // length -1 prezzo totale, -1 n prodotti
				sw.WriteLine(i + ";" + lines[i].Split(";".ToCharArray(), 2)[1]); //i+1 indice attuale // i = il nuovo indice, e poi trascrive il resto
			sw.WriteLine(totpro);
			sw.WriteLine(sum);
			sw.Close();
			*/

			lines = FileReadAllLines(path + "\\logicRemove.csv");
			for (int i = 0; i  < lines.Length; i++)
				logic += lines[i] + "\n";
			info = new UTF8Encoding(true).GetBytes(logic);//aggiungo l'elemento appena rimosso alla cancellazione logica, poi trascrivo il resto
			fs = new FileStream(path + "\\logicRemove.csv", FileMode.Truncate, FileAccess.Write, FileShare.None); //
			fs.Write(info, 0, info.Length);
			fs.Close();

			/*
			sw = new StreamWriter(path + "\\logicRemove.csv");
			sw.WriteLine(logic); //aggiungo l'elemento appena rimosso alla cancellazione logica
			for (int i = 0; i  < lines.Length; i++)
				sw.WriteLine(lines[i]);
			sw.Close();
			*/

			/*lines = FileReadAllLines(path + "\\lista.txt");

			allLines = "";
			for (int i = 0; i < seline; i++)
				allLines += lines[i] + "\n";
			for (int i = seline+1; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				allLines += i + "." + lines[i].Split(".".ToCharArray(), 2)[1] + "\n"; //i+1 indice attuale // i = il nuovo indice, e poi trascrive il resto
			allLines += $"-------------------\nnumero di prodotti: {totpro}\nprezzo totale: {sum}\n";
			info = new UTF8Encoding(true).GetBytes(allLines);
			fs = new FileStream(path + "\\lista.txt", FileMode.Truncate, FileAccess.Write, FileShare.None); //truncate perché il numero di byte è meno rispetto a prima
			fs.Write(info, 0, info.Length);
			fs.Close();*/

			/*
			sw = new StreamWriter(path + "\\lista.txt");

			for (int i = 0; i < seline; i++)
				sw.WriteLine(lines[i]);
			for (int i = seline+1; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				sw.WriteLine(i + "." + lines[i].Split(".".ToCharArray(), 2)[1]); //scrive il nuovo indice, e poi trascrive il resto
			sw.WriteLine("-------------------");
			sw.WriteLine($"numero di prodotti: {totpro}");
			sw.WriteLine($"prezzo totale: {sum}");
			sw.Close();
			*/
		}
		private void StringMoveLine(string[] lines, int seline, int moveline)
		{
			string line = lines[moveline];
			lines[moveline] = lines[seline];
			if (seline < moveline)
			{
				for (int i = seline; i < moveline-1; i++)
					lines[i] = lines[i+1];
				lines[moveline-1] = line;
			}
			else
			{
				for (int i = seline; i > moveline+1; i--)
					lines[i]=lines[i-1];
				lines[moveline+1] = line;
			}
		}
		private bool MoveLine(string cerca, int totline, int seline, string path)
		{//fun 5
			if (!BoolCheckCercaLine(cerca, totline))
				return false;

			int moveline = int.Parse(cerca);
			if (seline == moveline) return false;

			seline--; moveline--;
			string[] lines = FileReadAllLines(path + "\\lista.csv");
			StringMoveLine(lines, seline, moveline);

			string allLines = "";
			for (int i = 0; i < lines.Length - 2; i++) // length -1 prezzo totale, -1 n prodotti
				allLines += i+1 + ";" + lines[i].Split(";".ToCharArray(), 2)[1] + "\n"; //scrive il nuovo indice, e poi trascrive il resto
			allLines += lines[lines.Length-2] + "\n" + lines[lines.Length-1] + "\n"; //totpro e sum
			Byte[] info = new UTF8Encoding(true).GetBytes(allLines);
			FileStream fs = new FileStream(path + "\\lista.csv", FileMode.Open, FileAccess.Write, FileShare.None); //il numero di byte è lo stesso identico, truncate non serve
			fs.Write(info, 0, info.Length);
			fs.Close();

			/*
			StreamWriter sw = new StreamWriter(path + "\\lista.csv");
			for (int i = 0; i < lines.Length - 2; i++) // length -1 prezzo totale, -1 n prodotti
				sw.WriteLine(i+1 + ";" + lines[i].Split(";".ToCharArray(), 2)[1]);
			sw.WriteLine(lines[lines.Length-2]); //totpro
			sw.WriteLine(lines[lines.Length-1]); //sum
			sw.Close();
			*/

			/*lines = FileReadAllLines(path + "\\lista.txt");
			StringMoveLine(lines, seline, moveline);

			allLines = "";
			for (int i = 0; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				allLines += i+1 + "." + lines[i].Split(".".ToCharArray(), 2)[1] + "\n"; //scrive il nuovo indice, e poi trascrive il resto
			allLines += lines[lines.Length-3] + "\n" +lines[lines.Length-2] + "\n" + lines[lines.Length-1] + "\n"; //separatore totpro e sum
			info = new UTF8Encoding(true).GetBytes(allLines);
			fs = new FileStream(path + "\\lista.txt", FileMode.Open, FileAccess.Write, FileShare.None);
			fs.Write(info, 0, info.Length);
			fs.Close();*/

			/*
			sw = new StreamWriter(path + "\\lista.txt");
			for (int i = 0; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				sw.WriteLine(i+1 + "." + lines[i].Split(".".ToCharArray(), 2)[1]); //scrive il nuovo indice, e poi trascrive il resto
			sw.WriteLine(lines[lines.Length-3]); //------
			sw.WriteLine(lines[lines.Length-2]); //totpro
			sw.WriteLine(lines[lines.Length-1]); //sum
			sw.Close();
			*/
			return true;
		}
		private bool SwitchLine(string cerca, int totline, int seline, string path)
		{//fun 6
			if (!BoolCheckCercaLine(cerca, totline))
				return false;

			int moveline = int.Parse(cerca);
			if (seline == moveline) return false;

			seline--; moveline--;
			string[] lines = FileReadAllLines(path + "\\lista.csv");
			(lines[seline], lines[moveline]) =
				(seline+1 + ";" + lines[moveline].Split(";".ToCharArray(), 2)[1], moveline+1 + ";" + lines[seline].Split(";".ToCharArray(), 2)[1]);

			FileWriteAllLines(path + "\\lista.csv", lines);

			/*
			StreamWriter sw = new StreamWriter(path + "\\lista.csv");
			for (int i = 0; i < lines.Length; i++)
				sw.WriteLine(lines[i]);
			sw.Close();
			*/

			/*lines = FileReadAllLines(path + "\\lista.txt");
			(lines[seline], lines[moveline]) =
				(seline+1 + "." + lines[moveline].Split(".".ToCharArray(), 2)[1], moveline+1 + "." + lines[seline].Split(".".ToCharArray(), 2)[1]);

			FileWriteAllLines(path + "\\lista.txt", lines);*/

			/*
			sw = new StreamWriter(path + "\\lista.txt");
			for (int i = 0; i < lines.Length; i++)
				sw.WriteLine(lines[i]);
			sw.Close();
			*/
			return true;
		}
		private void TwinLine(int seline, string path)
		{//fun 7
			seline--;
			string[] lines = FileReadAllLines(path + "\\lista.csv");
			int totpro = int.Parse(lines[lines.Length-2]) + int.Parse(lines[seline].Split(";".ToCharArray(), 4)[2]); //aggiungo i prodotti duplicati
			float sum = float.Parse(lines[lines.Length - 1]) + float.Parse(lines[seline].Split(";".ToCharArray(), 4)[3]);

			string allLines = "";
			for (int i = 0; i < seline; i++)
				allLines += lines[i] + "\n";
			allLines += lines[seline] + "\n"; //la nuova linea
			for (int i = seline; i < lines.Length - 2; i++)// -1 prezzo totale, -1 n prodotti
				allLines += i+2 + ";" + lines[i].Split(";".ToCharArray(), 2)[1] + "\n"; //scrive il nuovo indice, e poi trascrive il resto
			allLines += totpro + "\n" + sum + "\n";
			Byte[] info = new UTF8Encoding(true).GetBytes(allLines);
			FileStream fs = new FileStream(path + "\\lista.csv", FileMode.Open, FileAccess.Write, FileShare.None);
			fs.Write(info, 0, info.Length);
			fs.Close();

			/*
			StreamWriter sw = new StreamWriter(path + "\\lista.csv");
			for (int i = 0; i < seline; i++)
				sw.WriteLine(lines[i]);
			sw.WriteLine(lines[seline]); //la nuova linea
			for (int i = seline; i < lines.Length - 2; i++)// -1 prezzo totale, -1 n prodotti
				sw.WriteLine(i+2 + ";" + lines[i].Split(";".ToCharArray(), 2)[1]); //scrive il nuovo indice, e poi trascrive il resto
			sw.WriteLine(totpro);
			sw.WriteLine(sum);
			sw.Close();
			*/

			/*lines = File.ReadAllLines(path + "\\lista.txt");

			allLines = "";
			for (int i = 0; i < seline; i++)
				allLines += lines[i] + "\n";
			allLines += lines[seline] + "\n"; //la nuova linea
			for (int i = seline; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				allLines += i+2 + "." + lines[i].Split(".".ToCharArray(), 2)[1] + "\n"; //scrive il nuovo indice, e poi trascrive il resto
			allLines += $"-------------------\nnumero di prodotti: {totpro}\nprezzo totale: {sum}\n";
			info = new UTF8Encoding(true).GetBytes(allLines);
			fs = new FileStream(path + "\\lista.txt", FileMode.Open, FileAccess.Write, FileShare.None);
			fs.Write(info, 0, info.Length);
			fs.Close();*/

			/*
			sw = new StreamWriter(path + "\\lista.txt");

			for (int i = 0; i < seline; i++)
				sw.WriteLine(lines[i]);
			sw.WriteLine(lines[seline]); //la nuova linea
			for (int i = seline; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				sw.WriteLine(i+2 + "." + lines[i].Split(".".ToCharArray(), 2)[1]); //scrive il nuovo indice, e poi trascrive il resto
			sw.WriteLine("-------------------");
			sw.WriteLine($"numero di prodotti: {totpro}");
			sw.WriteLine($"prezzo totale: {sum}");
			sw.Close();
			*/
		}
		private int RemoveAmount(string qua, int seline, string path)
		{//fun 8
			seline--;
			if (qua == "") qua = "1";
			string[] lines = FileReadAllLines(path + "\\lista.csv");
			int amount = int.Parse(lines[seline].Split(";".ToCharArray(), 4)[2]);
			if (!CheckAmount(qua, amount)) //errore in input
				return -1;

			amount -= int.Parse(qua);
			int totpro = int.Parse(lines[lines.Length - 2]) - int.Parse(qua); //tolgo i prodotti

			string allLines = "";
			for (int i = 0; i < seline; i++)
				allLines += lines[i] + "\n";
			string[] split = lines[seline].Split(";".ToCharArray(), 4);
			split[2] = amount.ToString();
			allLines += string.Join(";", split) + "\n"; //riscrive la linea col nuovo amount
			for (int i = seline+1; i < lines.Length - 2; i++)//seline + 1 per saltare la vecchia linea // length -1 prezzo totale, -1 n prodotti
				allLines += lines[i] + "\n"; //trascrive il resto
			allLines += totpro + "\n" + lines[lines.Length-1] + "\n"; // totpro e sum
			Byte[] info = new UTF8Encoding(true).GetBytes(allLines);
			FileStream fs = new FileStream(path + "\\lista.csv", FileMode.Truncate, FileAccess.Write, FileShare.None); //truncate per il numero di byte
			fs.Write(info, 0, info.Length);
			fs.Close();

			/*
			StreamWriter sw = new StreamWriter(path + "\\lista.csv");
			for (int i = 0; i < seline; i++)
				sw.WriteLine(lines[i]);
			string[] split = lines[seline].Split(";".ToCharArray(), 4);
			split[2] = amount.ToString();
			sw.WriteLine(string.Join(";", split));
			for (int i = seline+1; i < lines.Length - 2; i++)//seline + 1 per saltare la vecchia linea // length -1 prezzo totale, -1 n prodotti
				sw.WriteLine(lines[i]); //trascrive il resto
			sw.WriteLine(totpro);
			sw.WriteLine(lines[lines.Length-1]); // sum
			sw.Close();
			*/

			/*lines = FileReadAllLines(path + "\\lista.txt");

			allLines = "";
			for (int i = 0; i < seline; i++)
				allLines += lines[i] + "\n";
			allLines += $"{split[0]}.    Nome: {split[1]}     Quantità: {split[2]}     Prezzo: {split[3]}\n"; //riscrive la linea col nuovo amount
			for (int i = seline + 1; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				allLines += lines[i] + "\n"; //trascrive il resto
			allLines += $"-------------------\nnumero di prodotti: {totpro}\n{lines[lines.Length-1]}\n"; //sum
			info = new UTF8Encoding(true).GetBytes(allLines);
			fs = new FileStream(path + "\\lista.txt", FileMode.Truncate, FileAccess.Write, FileShare.None); //truncate per il numero di byte sconosciuto
			fs.Write(info, 0, info.Length);
			fs.Close();*/

			/*
			sw = new StreamWriter(path + "\\lista.txt");

			for (int i = 0; i < seline; i++)
				sw.WriteLine(lines[i]);
			sw.WriteLine($"{split[0]}.    Nome: {split[1]}     Quantità: {split[2]}     Prezzo: {split[3]}");
			for (int i = seline + 1; i < lines.Length - 3; i++) // -1 prezzo totale, -1 n prodotti e -1 separatore
				sw.WriteLine(lines[i]); //trascrive il resto
			sw.WriteLine("-------------------");
			sw.WriteLine($"numero di prodotti: {totpro}");
			sw.WriteLine(lines[lines.Length-1]); // sum
			sw.Close();
			*/

			if (amount == 0)
			{
				DeleteLine(seline+1, path);

				//a logicRemove aggiungo la quantità rimossa per arrivare a 0
				lines = FileReadAllLines(path + "\\logicRemove.csv");
				split = lines[0].Split(";".ToCharArray());
				split[2] = qua;

				allLines = string.Join(";", split) + "\n";
				for (int i = 1; i < lines.Length; i++)
					allLines += lines[i] + "\n";
				info = new UTF8Encoding(true).GetBytes(allLines);
				fs = new FileStream(path + "\\logicRemove.csv", FileMode.Truncate, FileAccess.Write, FileShare.None); //truncate per il numero di byte sconosciuto
				fs.Write(info, 0, info.Length);
				fs.Close();

				/*
				sw = new StreamWriter(path + "\\logicRemove.csv");
				sw.WriteLine(string.Join(";", split));
				for (int i = 1; i  < lines.Length; i++)
					sw.WriteLine(lines[i]);
				sw.Close();
				*/
			}
			return amount;
		}
	}
}