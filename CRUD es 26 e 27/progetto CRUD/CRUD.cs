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

namespace progetto_CRUD
{
	public struct StructLine
	{
		public int ind;
		public string text;
		public int amount;
		public float price;
	}
	public struct StructFile
	{
		public StructLine[] csvLines;
		public int totline; //totline totale linee
		public int totpro; //totpro totale prodotti
		public float sumprice; //somma prezzi
	}
	public partial class CRUD : Form
	{
		//tooltip
		//structline logicremove
		//menu a comparsa
		//elementi cliccabili in listview
		//aggiustare tab index
		//funzioni esterne
		//cronologia //pensavo a due stack (ctrl z  ctrl y) //???togliere logicremove.csv e mettere history.csv???

		//non c'è mai seline 0; quando è 0 diventa totline + 1; tranne add e select funziona tutto a select line

		public StructFile csvFile = new StructFile();
		public int fun, seline; //fun funzione //seline linea selezionata
		public string path;
		public CRUD()
		{
			InitializeComponent();
			path = GetPath();
			csvFile.totline = GetLineCount(path + "\\lista.csv") - 2;
			seline = csvFile.totline + 1;
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

		private int GetStructLength(int tot)
		{
			if (tot < 100) return 100;
			return tot/100 * 100 + 100;
		}
		private void CheckStruct(ref StructFile csvFile)
		{
			int newSize = GetStructLength(csvFile.totline);
			if (newSize != csvFile.csvLines.Length)
				StructLineResize(ref csvFile.csvLines, newSize);
		}
		private void StructLineResize(ref StructLine[] array, int newSize)
		{
			if (array.Length != newSize)
			{
				StructLine[] array2 = new StructLine[newSize];
				if (array.Length < newSize) //se newsize è più grande, copia fino ad array.length e il resto rimane default
					for (int i = 0; i < array.Length; i++)
						array2[i] = array[i];
				else //se newsize è più piccolo copia fino a newsize
					for (int i = 0; i < newSize; i++)
						array2[i] = array[i];
				array = array2;
			}
		}
		private StructLine UpdateStruct(int ind, string text, int amount, float price)
		{
			StructLine line = new StructLine()
			{
				ind = ind,
				text = text,
				amount = amount,
				price = price
			};
			return line;
		}
		private string StructLineToString(StructLine line)
		{
			return string.Join(";", line.ind, line.text, line.amount, line.price);
		}
		private string[] StructFileToStrings(StructFile csvFile)
		{
			string[] lines = new string[csvFile.totline+2];
			for (int i = 0; i < csvFile.totline; i++)
				lines[i] = StructLineToString(csvFile.csvLines[i]);
			lines[csvFile.totline] = csvFile.totpro.ToString();
			lines[csvFile.totline+1] = csvFile.sumprice.ToString();

			return lines;
		}
		private string StructFileToString(StructFile csvFile)
		{
			string allLines = "";
			for (int i = 0; i < csvFile.totline; i++)
				allLines += StructLineToString(csvFile.csvLines[i]) + "\n";
			allLines += csvFile.totpro + "\n";

			return allLines + csvFile.sumprice + "\n"; ;
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
			string[] lines;
			if (line[line.Length-1] == '\n')
				// .SubString() perché altrimenti per ultimo rimarrebbe una stringa vuota
				lines = line.Substring(0, line.Length-1).Split('\n');
			else
				lines = line.Split('\n');
			for (int i = 0; i < lines.Length; i++)
				lines[i] = lines[i].TrimEnd('\r');
			return lines;
		}
		private void FileWriteAllText(string path, string allLines, FileMode mode)
		{
			Byte[] info = new UTF8Encoding(true).GetBytes(allLines);
			FileStream fs = new FileStream(path, mode, FileAccess.Write, FileShare.None);
			fs.Write(info, 0, info.Length);
			fs.Close();
		}
		/* funzioni non utilizzate
		private void FileWriteAllText(string path, string allLines)
		{
			FileWriteAllText(path, allLines, FileMode.Create);
		}
		private void FileWriteAllLines(string path, string[] lines)
		{
			FileWriteAllLines(path, lines, FileMode.Create);
		}
		private void FileWriteAllLines(string path, string[] lines, FileMode mode)
		{
			FileWriteAllText(path, string.Join("\n", lines), mode);
		}*/

		private void CRUD_Shown(object sender, EventArgs e)
		{
			csvFile.csvLines = new StructLine[GetStructLength(csvFile.totline)];
			string[] lines = FileReadAllLines(path + "\\lista.csv");
			string[] splits;
			for (int i = 0; i < csvFile.totline; i++)
			{
				splits = lines[i].Split(';');
				csvFile.csvLines[i] = UpdateStruct(int.Parse(splits[0]), splits[1], int.Parse(splits[2]), float.Parse(splits[3]));
			}
			csvFile.totpro = int.Parse(lines[lines.Length-2]);
			csvFile.sumprice = float.Parse(lines[lines.Length-1]);

			SetVisible();
			StampaForm(lines);

			//aggiungere
			DescrizioneAdd.SetToolTip(AddButton, "Aggiungi nuova linea");
			DescrizioneHistoryR.SetToolTip(HistoryButton, "Guarda la lista delle linee rimosse");
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

			vis[0] = csvFile.totline != 0;
			vis[1] = seline != csvFile.totline + 1;
			vis[2] = csvFile.totline > 1 && vis[1];
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
			seline = csvFile.totline + 1;
			SetVisible();
			NameList.Text = $"Stai aggiungendo la linea {seline}, o la linea scelta in search:";
		}
		private void EditButton_Click(object sender, EventArgs e)
		{
			fun = 3;
			SetVisible();
			NameList.Text = $"Stai modificando il testo della linea {seline}:";

			//get set text boxes
			string[] splits = StructLineToString(csvFile.csvLines[seline-1]).Split(';');
			SearchBox.Text = splits[0];
			TextBox.Text = splits[1];
			AmountBox.Text = splits[2];
			PriceBox.Text = splits[3];
		}
		private void SelectButton_Click(object sender, EventArgs e)
		{
			IndexCheckBox.Checked = true;
			fun = 21;
			seline = csvFile.totline + 1;
			SetVisible();
			NameList.Text = "Scegli la linea da modificare digitando il numero in search :";
		}
		private void IndexCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (IndexCheckBox.Checked) { fun = 21; StampaForm(StructFileToStrings(csvFile)); NameList.Text = "Scegli la linea da modificare digitando il numero in search :"; }
			else if (!IndexCheckBox.Checked) fun = 2;
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
		private void RemoveButton_Click(object sender, EventArgs e)
		{
			fun = 8;
			SetVisible();
			NameList.Text = $"Stai rimuovendo dei prodotti dalla linea {seline}:";
		}

		private void CancelButton1_Click(object sender, EventArgs e)
		{
			fun = 0;
			seline = csvFile.totline + 1;
			SetVisible();
			AddButton.Visible = true;
			StampaForm(StructFileToStrings(csvFile));
			NameList.Text = "Non è stata selezionata nessuna linea";
		}
		private void ClearButton_Click(object sender, EventArgs e)
		{
			TextBox.Text = "";
			AmountBox.Text = "";
			PriceBox.Text = "";
			SearchBox.Text = "";
		}
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
				NameList.Text = "riclicca il pulsante H per ripristinare la cancellazione più recente";
				StampaForm(FileReadAllLines(path + "\\logicRemove.csv"));

				return;
			} //else
			string[] lines = FileReadAllLines(path + "\\logicRemove.csv");
			string[] splits = lines[0].Split(';');
			AddButton.Visible = true;
			AddButton_Click(sender, e);
			AddLine(ref csvFile, splits[1], splits[2], splits[3], splits[0], path);
			seline = int.Parse(splits[0]);
			fun = 0;
			NameList.Text = $"Stai modificando la linea {seline}";
			SetVisible();
			StampaForm(StructFileToStrings(csvFile));

			if (lines.Length != 1)
			{
				lines[0] = "";
				for (int i = 1; i<lines.Length; i++)
					lines[0] += lines[i] + "\n";
				FileWriteAllText(path + "\\logicRemove.csv", lines[0], FileMode.Truncate);

				return;
			} //else
			File.Create(path + "\\logicRemove.csv").Close(); //svuota
			HistoryButton.Visible = false;
		}

		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			bool control = true;
			if (fun != 2 || fun != 8) control = SwitchFun(fun, ref csvFile, TextBox.Text, AmountBox.Text, PriceBox.Text, SearchBox.Text, seline, path);
			if (control) //if SwitchFun è meno ridondante ma brutto
			{
				switch (fun)
				{
					case 1: //addline
						seline += 1;
						NameList.Text = $"Stai aggiungendo la linea {seline}, o la linea scelta in search :";
						break;
					case 21: //select index
					case 5: //move line
					case 6: //switch line
						seline = int.Parse(SearchBox.Text);
						break;
					case 4: //delete line
						if (seline == csvFile.totline+1) seline--;
						if (seline == 0) seline++;
						NameList.Text = $"Conferma per cancellare la linea {seline}:";
						HistoryButton.Visible = true;
						break;
					case 7: //twin line
						seline += 1;
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
				switch (fun)
				{
					case 1: //addline
					case 4: //delete line
					case 7: //twin line
							//case 8
						CheckStruct(ref csvFile);
						break;
				}
			}
			if (fun == 2)
			{
				NameList.Text = $"Tutte le linee trovate in ricerca(spunta index e scegli la linea da modificare):";
				StampaForm(SelectLineResearch(csvFile, SearchBox.Text));
				return;
			} //else
			if (fun == 8)
			{
				short check = RemoveAmount(ref csvFile, AmountBox.Text, seline, path);
				if (check != -1) //-1 = errore in input
					if (check == 0)
					{//quando da 8remove passa a 4delete, ma era remove
						if (seline == csvFile.totline+1) seline--;
						if (seline == 0) seline++;
						NameList.Text = $"Stai rimuovendo dei prodotti dalla linea {seline}:";
						CheckStruct(ref csvFile);
						HistoryButton.Visible = true;
					}
					else //remove amount
						NameList.Text = $"Stai modificando la linea {seline}";
			}
			if (csvFile.totline == 0 && (fun == 4 || fun == 8)) //&& fun 4 //serve quando sbagli in add con 0 linee
			{
				CancelButton1_Click(sender, e); //NameList.Text e fun 0
				return;
			} //else
			SetVisible();
			StampaForm(StructFileToStrings(csvFile));
		}
		private bool SwitchFun(int fun, ref StructFile csvFile, string nome, string qua, string prezzo, string cerca, int seline, string path)
		{
			bool control = true; // false se qualcosa è andato storto
			switch (fun)
			{
				case 1:
					control = AddLine(ref csvFile, nome, qua, prezzo, cerca, path); //mettere return AddLine ?
					break;
				case 21:
					control = SelectLineIndex(cerca, csvFile.totline);
					break;
				case 3:
					control = EditLine(ref csvFile, nome, qua, prezzo, seline, path);
					break;
				case 4:
					DeleteLine(ref csvFile, seline, path);
					break;
				case 5:
					control = MoveLine(ref csvFile, cerca, seline, path);
					break;
				case 6:
					control = SwitchLine(ref csvFile, cerca, seline, path);
					break;
				case 7:
					TwinLine(ref csvFile, seline, path);
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

		private bool AddLine(ref StructFile csvFile, string nome, string qua, string prezzo, string cerca, string path)
		{//fun 1
			if (qua=="") qua = "1";
			if (!CheckNomePrezzoQua(nome, qua, prezzo)) //errore in input
				return false;
			int seline = IntCheckCercaLine(cerca, csvFile.totline);
			if (seline == 0) //0 = false
				return false;
			seline--; //da indice linea a indice generico (linea 1 è indice 0)

			//aggiorna la struct File
			csvFile.totpro += int.Parse(qua); //aggiungo i prodotti
			csvFile.sumprice += float.Parse(prezzo);
			for (int i = csvFile.totline; i > seline; i--)
			{
				csvFile.csvLines[i] = csvFile.csvLines[i-1];
				csvFile.csvLines[i].ind = i+1;
			}
			csvFile.csvLines[seline] = UpdateStruct(seline+1, nome, int.Parse(qua), float.Parse(prezzo));
			csvFile.totline++;

			//stampa struct su file
			FileWriteAllText(path + "\\lista.csv", StructFileToString(csvFile), FileMode.Open);

			return true;
		}
		private bool SelectLineIndex(string cerca, int totline)
		{//fun 21
			return BoolCheckCercaLine(cerca, totline); //ret false = il cerca non è valido //ret true = string cerca  ha  int seline
		}
		private string[] SelectLineResearch(StructFile csvFile, string cerca)
		{//fun 2
			string[] lines = new string[csvFile.totline];
			int k = 0;
			for (int i = 0; i< csvFile.totline; i++)
				if (csvFile.csvLines[i].text.ToLower().Contains(cerca.ToLower())) //cerca solo in text
					lines[k++]= StructLineToString(csvFile.csvLines[i]);

			if (k == 0)
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
		private bool EditLine(ref StructFile csvFile, string nome, string qua, string prezzo, int seline, string path)
		{//fun 3
			if (!EditCheckNomePrezzoQua(nome, qua, prezzo)) //errore in input
				return false;
			seline--;

			if (nome != "")
				csvFile.csvLines[seline].text = nome;

			if (qua != "")
			{
				//al totpro attuale toglie il vecchio valore e ci aggiunge quello modificato
				//csvFile.totpro -= csvFile.csvLines[seline].amount + int.Parse(qua); //a quanto pare -= toglie il risultato a destra
				csvFile.totpro = csvFile.totpro - csvFile.csvLines[seline].amount + int.Parse(qua);
				csvFile.csvLines[seline].amount = int.Parse(qua);
			}
			if (prezzo != "")
			{
				//alla somma attuale toglie il vecchio valore e si aggiunge quello modificato
				csvFile.sumprice = csvFile.sumprice - csvFile.csvLines[seline].price + float.Parse(prezzo);
				csvFile.csvLines[seline].price = float.Parse(prezzo);
			}

			//stampa struct su file
			FileWriteAllText(path + "\\lista.csv", StructFileToString(csvFile), FileMode.Truncate);  //file mode truncate per evitare errori

			return true;
		}
		private void DeleteLine(ref StructFile csvFile, int seline, string path)
		{//fun 4
			seline--;

			//aggiorna la struct File
			csvFile.totpro -= csvFile.csvLines[seline].amount; //tolgo una linea di prodotti
			csvFile.sumprice = csvFile.sumprice - csvFile.csvLines[seline].price;
			string logic = StructLineToString(csvFile.csvLines[seline]) + "\n";//linea da aggiungere alla cancellazione logica
			for (int i = seline; i < csvFile.totline - 1; i++)
			{
				csvFile.csvLines[i] = csvFile.csvLines[i+1];
				csvFile.csvLines[i].ind = i+1;
			}
			csvFile.totline--;
			csvFile.csvLines[csvFile.totline] = UpdateStruct(0, null, 0, 0); //per scrupolo

			//stampa struct su file
			FileWriteAllText(path + "\\lista.csv", StructFileToString(csvFile), FileMode.Truncate); //truncate perché il numero di byte è meno rispetto a prima

			string[] lines = FileReadAllLines(path + "\\logicRemove.csv");
			for (int i = 0; i  < lines.Length; i++)
				logic += lines[i] + "\n";

			FileWriteAllText(path + "\\logicRemove.csv", logic, FileMode.Open); //open perché il numero di byte è più rispetto a prima
		}
		private void StructMoveLine(StructLine[] csvLines, int seline, int moveline)
		{
			StructLine line = csvLines[moveline]; //salva la linea scelta
			csvLines[moveline] = csvLines[seline]; //sulla la linea scelta mette la linea selezionata
			if (seline < moveline) //se la linea selezionata si trova prima della linea scelta
			{
				for (int i = seline; i < moveline-1; i++) //dalla linea selezionata alla linea scelta - 1 
					csvLines[i] = csvLines[i+1]; //la linea selezionata diventa la linea successiva
				csvLines[moveline-1] = line; //la linea scelta - 1 diventa la linea scelta
			}
			else //se la linea selezionata si trova dopo la linea scelta
			{
				for (int i = seline; i > moveline+1; i--) //dalla linea selezionata alla linea scelta + 1 (quindi a ritroso)
					csvLines[i] = csvLines[i-1]; //la linea selezionata diventa la linea precedente
				csvLines[moveline+1] = line; //la linea scelta + 1 diventa la linea scelta
			}
		}
		private bool MoveLine(ref StructFile csvFile, string cerca, int seline, string path)
		{//fun 5
			if (!BoolCheckCercaLine(cerca, csvFile.totline))
				return false;

			int moveline = int.Parse(cerca);
			if (seline == moveline) return false;

			seline--; moveline--; //da ind linea a ind informatico
			StructMoveLine(csvFile.csvLines, seline, moveline);

			for (int i = 0; i < csvFile.totline; i++)
				csvFile.csvLines[i].ind = i+1;

			FileWriteAllText(path + "\\lista.csv", StructFileToString(csvFile), FileMode.Open); //il numero di byte è lo stesso identico, truncate non serve

			return true;
		}
		private bool SwitchLine(ref StructFile csvFile, string cerca, int seline, string path)
		{//fun 6
			if (!BoolCheckCercaLine(cerca, csvFile.totline))
				return false;

			int moveline = int.Parse(cerca);
			if (seline == moveline) return false;

			seline--; moveline--;
			(csvFile.csvLines[seline].ind, csvFile.csvLines[moveline].ind) = (csvFile.csvLines[moveline].ind, csvFile.csvLines[seline].ind); //metto a posto gli index
			(csvFile.csvLines[seline], csvFile.csvLines[moveline]) = (csvFile.csvLines[moveline], csvFile.csvLines[seline]); //switch-o le linee

			FileWriteAllText(path + "\\lista.csv", StructFileToString(csvFile), FileMode.Open); //il numero di byte è lo stesso identico, truncate non serve

			return true;
		}
		private void TwinLine(ref StructFile csvFile, int seline, string path)
		{//fun 7
			seline--;

			csvFile.totpro += csvFile.csvLines[seline].amount; //aggiungo i prodotti duplicati
			csvFile.sumprice += csvFile.csvLines[seline].price;
			for (int i = csvFile.totline; i > seline; i--)
			{
				csvFile.csvLines[i] = csvFile.csvLines[i-1];
				csvFile.csvLines[i].ind = i+1;
			}
			csvFile.totline++;

			//stampa struct su file
			FileWriteAllText(path + "\\lista.csv", StructFileToString(csvFile), FileMode.Open);
		}
		private short RemoveAmount(ref StructFile csvFile, string qua, int seline, string path)
		{//fun 8
			if (qua == "") qua = "1";
			seline--;

			if (!CheckAmount(qua, csvFile.csvLines[seline].amount)) //errore in input
				return -1;

			if (csvFile.csvLines[seline].amount != int.Parse(qua))
			{
				csvFile.csvLines[seline].amount -= int.Parse(qua);
				csvFile.totpro -= int.Parse(qua); //tolgo i prodotti

				FileWriteAllText(path + "\\lista.csv", StructFileToString(csvFile), FileMode.Truncate); //truncate per il numero di byte

				return 1;
			}
			else
			{
				DeleteLine(ref csvFile, seline+1, path);
				return 0;
			}
		}
	}
}