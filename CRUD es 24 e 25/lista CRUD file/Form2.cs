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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace lista_CRUD
{
    public partial class CRUD : Form
    {
        #endregion
        //cancellazione logica
        //file accesso diretto
        //menu a comparsa
        //elementi cliccabili in listview
        //funzioni esterne
        //edit logico?? //cronologia?? //pensavo a due stack (ctrl z  ctrl y)

        public int fun, totlis, selis; //fun funzione //totlis totale liste //lista selezionata
        public string path;
        public CRUD()
        {
            InitializeComponent();
            path = GetPath();
            totlis = GetListCount(path + "\\delimitatori.txt");
            fun = 0;
            SetVisible();
            File.Create(path + "\\logic remove.txt").Close(); //svuota
        }

        private void Shortcut(object sender, KeyEventArgs e)
        {
            if (e.Control &&  e.Shift &&e.KeyCode == Keys.C)
            {//shortcut Ctrl+Shift+C
                CreateButton_Click(sender, e);
            }
            if (e.Control &&  e.Shift &&e.KeyCode == Keys.A && fun !=0)
            {//shortcut Ctrl+Shift+A
                AddButton_Click(sender, e);
            }
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
            DescrizioneHistoryR.SetToolTip(HistoryRButton, "Guarda la lista delle linee rimosse");
            //Close();
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
        private void SetVisible()
        {
            //bool 0 update, 1 move, 0 delete, 2 add, 2 edit, 2 dupl, 2 remove, 3 search, 4 textprice, 5 clear, 5 confirm
            bool[] vis = new bool[5];
            vis[0] = totlis != 0;
            vis[1] = !(totlis < 2 || selis == 0);
            vis[2] = selis != 0;
            //vis[3] search = update2 o move3 o delete4 o edit6 o twin7 o remove8
            //vis[4] textprice = create1 o add5 o edit6
            vis[3] = !(fun == 1 || fun == 5 || fun == 0);
            vis[4] = (fun == 1 || fun == 5 || fun == 6);
            //vis[5] = vis[4] || vis[3];

            //bool 0 update, 1 move, 0 delete, 2 add, 2 edit, 2 dupl, 2 remove, 3 search, 4 textprice, 5 clear, 5 confirm
            UpdateButton.Visible = vis[0];
            MoveButton.Visible = vis[1];
            DeleteButton.Visible = vis[0];
            AddButton.Visible = vis[2];
            EditButton.Visible = vis[2];
            TwinButton.Visible = vis[2];
            RemoveButton.Visible = vis[2];
            SearchVisible(vis[3]);
            TextPriceVisible(vis[4]);
            ClearConfirmVisible(vis[4] || vis[3]);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("test"); //avvia con debug >> apri output >> debug >> appare lì
            fun = 1;
            SetVisible();
            ListaProdotti.Items.Clear();
            NameList.Text = $"Stai creando la Lista{totlis + 1} :";
        }
        private void MoveButton_Click(object sender, EventArgs e)
        {
            //muove la lista aperta al posto di un altra
            fun = 3;
            SetVisible();
            ListaProdotti.Items.Clear();
            NameList.Text = $"Scegli la lista da scambiare digitando il numero in search(verrà scambiata con la lista{selis}) :";
            for (int i = 1; i <= totlis; i++)
                ListaProdotti.Items.Add($"{i}. Lista{i}");
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            selis = 0;
            fun = 2;
            SetVisible();
            ListaProdotti.Items.Clear();
            NameList.Text = "Scegli la lista da aprire digitando il numero in search :";
            for (int i = 1; i <= totlis; i++)
                ListaProdotti.Items.Add($"{i}. Lista{i}");
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            selis = 0;
            fun = 4;
            SetVisible();
            ListaProdotti.Items.Clear();
            NameList.Text = "Scegli la lista da cancellare digitando il numero in search :";
            for (int i = 1; i <= totlis; i++)
                ListaProdotti.Items.Add($"{i}. Lista{i}");
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            fun = 5;
            SetVisible();
            NameList.Text = $"Stai aggiungendo alla Lista{selis} :";
        }
        private void TwinButton_Click(object sender, EventArgs e)
        {
            fun = 7;
            SetVisible();
            NameList.Text = $"Stai duplicando una linea nella Lista{selis} (verrà aggiunta accanto alla linea duplicata):";
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            fun = 6;
            SetVisible();
            NameList.Text = $"Stai modificando una linea nella Lista{selis} :";
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            fun = 8;
            SetVisible();
            NameList.Text = $"Stai eliminando una linea nella Lista{selis} :";
        }
        private void CancelButton1_Click(object sender, EventArgs e)
        {
            ClearButton_Click(sender, e);
            fun = 0;
            selis = 0;
            SetVisible();
            ListaProdotti.Items.Clear();
            NameList.Text = "Non è aperta nessuna lista";
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            TextBox.Text = "";
            PriceBox.Text = "";
            SearchBox.Text = "";
        }
        private void HistoryRButton_Click(object sender, EventArgs e)
        {
            fun = 0;
            selis = 0;
            SetVisible();
            ListaProdotti.Items.Clear();
            NameList.Text = "Queste sono le linee rimosse";

            string[] lines = File.ReadAllLines(path + "\\logic remove.txt");
            int i = 0;
            while (i < lines.Length)
                ListaProdotti.Items.Add(lines[i++]);
        }
        //}
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            bool control = SwitchFun(fun, TextBox.Text, PriceBox.Text, SearchBox.Text, path, selis, totlis);
            if (control == true)
                switch (fun)
                {
                    case 1: //create file
                        totlis += 1;
                        selis = totlis;

                        //NameList.Text = $"Stai aggiungendo alla Lista{selis} :";
                        //fun = 5; //add
                        AddButton_Click(sender, e);
                        break;
                    case 2: //open
                        selis = int.Parse(SearchBox.Text);//controlli già fatti con switchfun
                        AddButton_Click(sender, e);
                        break;
                    case 3: //move
                        selis = int.Parse(SearchBox.Text); //rimane sulla lista spostata, "la rincorre"
                        AddButton_Click(sender, e);
                        break;
                    case 4: //delete file
                        ListaProdotti.Items.Clear();
                        NameList.Text = "Non è aperta nessuna lista";
                        fun = 0;
                        totlis -= 1;
                        SetVisible();
                        break;
                    //case 5: //add line //non serve nulla
                    case 6: //edit
                        AddButton_Click(sender, e);
                        break;

                    case 7: //twin
                        TwinButton_Click(sender, e);
                        break;

                    case 8: //remove
                        HistoryRButton.Visible = true;
                        RemoveButton_Click(sender, e);
                        break;
                }
            if (selis != 0)
                StampaForm();
        }

        private bool SwitchFun(int fun, string nome, string prezzo, string cerca, string path, int selis, int totlis)
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
                    //int temp = OpenFile(cerca, totlis, path);
                    //if (temp != 0) selis = temp;
                    //else control = false;
                    control = CheckCercaFile(cerca, totlis);// se ritorna false non ha selezionato nessuna lista
                    break;
                case 3:
                    control = MoveFile(cerca, totlis, selis, path);
                    break;
                case 4:
                    control = DeleteFile(cerca, totlis, path);
                    break;
                case 5:
                    AddLine(nome, prezzo, path, selis);
                    break;
                case 6:
                    EditLine(nome, prezzo, cerca, selis, path);
                    break;
                case 7:
                    TwinLine(cerca, selis, path);
                    break;
                case 8:
                    RemoveLine(cerca, selis, path);
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

        private bool CheckCercaFile(string cerca, int totlis)
        {
            if (!int.TryParse(cerca, out int selis) || selis < 1)
            {//bad input
                MessageBox.Show("inserisci un intero positivo", "errore nella ricerca");
                return false;
            }
            if (selis > totlis) //il totale liste si trova nel file
            {//bad input
                MessageBox.Show("inserisci un indice che appare in lista", "errore nella ricerca");
                return false;
            }
            return true;
        }

        private bool CheckCercaLine(string cerca, int totline)
        {
            if (!int.TryParse(cerca, out int seline) || seline < 1) //seleziona riga select + line
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
        private bool CreaFile(string nome, string prezzo, string path)
        { //fun 1
            if (!CheckNomePrezzo(nome, prezzo)) //bad input
                return false;


            StreamWriter swliste = new StreamWriter(path +"\\liste.txt", true);
            swliste.WriteLine($"1.    Nome: {nome}     Prezzo: {prezzo}");
            swliste.WriteLine("-------------------");
            swliste.WriteLine("numero di prodotti: 1");
            swliste.WriteLine($"prezzo totale: {prezzo}"); // 15 char + somma
            swliste.WriteLine("###################");
            swliste.Close();

            string[] lines = File.ReadAllLines(path +"\\delimitatori.txt");
            StreamWriter swdel = new StreamWriter(path +"\\delimitatori.txt");

            swdel.WriteLine(int.Parse(lines[0]) + 1); //aggiungo una nuova lista
            for (int i = 1; i < lines.Length; i++)
                swdel.WriteLine(lines[i]);
            swdel.Write("5"); //conteggio righe lista
            swdel.Close();

            return true;
        }

        //openfile controlla se la lista cercata esiste, e modifica la variabile selis(lista selezionata), con selis si stampa la lista e va in fun 5(add)
        //private int OpenFile(string cerca, int totlis, string path)
        //{//fun 2
        //	if (CheckCercaFile(cerca, totlis)) return int.Parse(cerca);//ritorna la lista selezionata
        //	else return 0; // 0 = false, se ritorna 0 non ha selezionato nessuna lista
        //}

        private bool MoveFile(string cerca, int totlis, int selis, string path)
        {//fun 3
            if (!CheckCercaFile(cerca, totlis)) //bad input
                return false;
            int movelis = int.Parse(cerca); //dove spostare la selis
            if (movelis == selis) return true;
            string[] lines = File.ReadAllLines(path + "\\delimitatori.txt");
            int nlines1 = int.Parse(lines[selis]); //numero righe da scambiare, lista1
            int nlines2 = int.Parse(lines[movelis]); //numero righe da scambiare, lista2

            int start1 = 0; //numero riga dove inizia la lista1
            int start2 = 0; //numero riga dove inizia la lista2
            for (int i = 1; i < selis; i++)
                start1 += int.Parse(lines[i]); //fa la somma di tutti i delimitatori (tranne il primo in lines[0])
            for (int i = 1; i < movelis; i++)
                start2 += int.Parse(lines[i]);

            //scambio le liste
            StreamWriter sw = new StreamWriter(path + "\\delimitatori.txt");
            (lines[selis], lines[movelis]) = (lines[movelis], lines[selis]); //tupla, assegna i valori, evita l'uso di variabili temp
            sw.Write(totlis); //prima riga senza \n iniziale
            for (int i = 1; i < lines.Length; i++)
                sw.Write("\n"+lines[i]); //nessuna riga vuota alla fine del file
            sw.Close();

            lines = File.ReadAllLines(path + "\\liste.txt");
            string[] lines1 = new string[lines.Length];

            //swap

            if (start1 > start2) //if start2 is before to start1, swap variable
                (start1, start2, nlines1, nlines2) = (start2, start1, nlines2, nlines1);

            int ind = 0;
            while (ind < start1) //pos from 0 to 0 //here is where i write positions and values based on the values in the initial comment
                lines1[ind] = lines[ind++]; //print 0

            //how much for print group 2?
            //start from start1, print nelem2 time
            while (ind < start1 + nlines2) //pos from 1 to 2
            {
                lines1[ind] = lines[ind + start2 - start1]; //print 8 9
                                                            //now pos to i, i = start1; start 2 is start for print group 2
                ind++;
            }
            //how much for print from end of group 2 and start of group 1?

            //start 2 + nelem2 is where is stop to print group 1, -nelem1 is where is start to print
            while (ind < start2 + nlines2 - nlines1) //pos from 3 to 5
            {
                lines1[ind]=lines[ind + nlines1 - nlines2]; //print 5 6 7
                                                            //now pos to i, i = start1+nelem2; start1 + nelem 1 is where start the value to print, -nelem2 for the space is already used
                ind++;
            }

            //start2 + nelem2 is end of print all variation
            while (ind <  start2 + nlines2) //pos from 6 to 9 
            {
                lines1[ind]= lines[ind + start1 - start2 - nlines2 + nlines1];//print 1 2 3 4 
                                                                              //now pos to i, print from start1, in the start of while i = -(-start2-nelem2 + nelem1)
                ind++;
            }

            while (ind< lines.Length)
                lines1[ind] = lines[ind++]; //print the rest

            sw = new StreamWriter(path + "\\liste.txt");
            for (int i = 0; i < lines1.Length; i++)
                sw.WriteLine(lines1[i]);
            sw.Close();

            return true;
        }
        private bool DeleteFile(string cerca, int totlis, string path)
        {//fun 4
            if (!CheckCercaFile(cerca, totlis)) //bad input
                return false;
            int selis = int.Parse(cerca);
            string[] lines = File.ReadAllLines(path + "\\delimitatori.txt");
            // in lines 1 c'è la riga che dice quante linee è lunga la lista1
            //in ogni linea precedente tranne 0 si calcola la somma delle linee da trascrivere
            int linesdel = int.Parse(lines[selis]); //numero righe lista
            int line = 0; //numero riga dove inizia la lista
            for (int i = 1; i < selis; i++)
                line += int.Parse(lines[i]); //fa la somma di tutti i delimitatori (tranne il primo in lines[0])

            //rimuovo la lista eliminata
            StreamWriter sw = new StreamWriter(path + "\\delimitatori.txt");
            //in lines 0 c'è anche la lunghezza -1 del file, e lines 0 = totlis
            for (int i = selis; i < totlis; i++) //l'ultima riga non viene fatta in ogni caso
                lines[i] = lines[i+1];
            lines[totlis]=""; //ultima riga è inutile in ogni caso;

            sw.Write(totlis-1); //prima riga senza \n iniziale
            for (int i = 1; i < lines.Length; i++)
                sw.Write("\n"+lines[i]); //nessuna riga vuota alla fine del file
            sw.Close();

            lines = File.ReadAllLines(path + "\\liste.txt");

            //trascrive tutto fino alla lista da eliminare, poi la salta e trascrive il resto
            sw = new StreamWriter(path + "\\liste.txt");
            for (int i = 0; i < line; i++)
                sw.WriteLine(lines[i]);
            for (int i = line+linesdel; i < lines.Length; i++)
                sw.WriteLine(lines[i]);
            sw.Close();

            return true;
        }

        private void AddLine(string nome, string prezzo, string path, int selis)
        {//fun 5
            if (!CheckNomePrezzo(nome, prezzo)) //bad input
                return;

            string[] lines = File.ReadAllLines(path + "\\delimitatori.txt");
            //in lines[0] c'è la riga che conta quante liste ci sono
            // in lines 1 c'è la riga che dice quante linee è lunga la lista1
            //in ogni linea precedente tranne 0 si calcola la somma delle linee da trascrivere
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
            //per il nuovo prodotto verrà trascritto fino a line+numpro, e alla riga successiva scritto il nuovo prodotto, per poi modificare le righe successive e infine trascrivere il resto del file

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
            sw.WriteLine($"prezzo totale: {sum}"); // 15 char + somma
            sw.WriteLine("###################");

            for (int i = line+npro+4; i < lines.Length; i++)
                sw.WriteLine(lines[i]);
            sw.Close();
        }
        private void TwinLine(string cerca, int selis, string path)
        {// fun 7
            string[] lines = File.ReadAllLines(path + "\\delimitatori.txt");
            int npro = int.Parse(lines[selis]) - 4; //numero righe di prodotti // -4 =  tot prodotti + somma + 2 separatori

            if (!CheckCercaLine(cerca, npro)) //bad input
                return;

            int line = 0; //numero riga dove inizia la lista
            for (int i = 1; i < selis; i++)
                line += int.Parse(lines[i]);

            //aggiungo un prodotto
            StreamWriter sw = new StreamWriter(path + "\\delimitatori.txt");
            lines[selis] = (int.Parse(lines[selis])+1).ToString(); ; //aggiungo già una riga al conteggio righe della lista

            sw.Write(lines[0]); //prima riga senza \n iniziale
            for (int i = 1; i < lines.Length; i++)
                sw.Write("\n"+lines[i]); //nessuna riga vuota alla fine del file
            sw.Close();
            lines = File.ReadAllLines(path + "\\liste.txt");

            string strSum = "";
            for (int c = 15; c < lines[line+npro+2].Length; c++)
                strSum += lines[line+npro+2][c];

            int seline = int.Parse(cerca);

            string strSeline = "";
            for (int c = lines[line+ seline - 1].Length - 1; true; c--)
            {
                strSeline = lines[line+ seline - 1][c] + strSeline;
                if (!float.TryParse(strSeline, out _))
                { //bad input
                    strSeline = strSeline.Substring(2); // ": "
                    break;
                }
            }

            float sum = float.Parse(strSum) + float.Parse(strSeline);

            sw = new StreamWriter(path + "\\liste.txt");
            int ind = 0;
            while (ind < line + seline - 1)
                sw.WriteLine(lines[ind++]);

            sw.WriteLine(lines[ind]); //scrivo la linea selezionata senza ind++

            while (ind < line + npro)
            { //a tutti l'identificativo + 1, parte cambiando quello appena stampato per ristamparlo
                seline++;
                lines[ind] = seline + lines[ind].Substring((seline-1).ToString().Length); // se è "10." allora scrive dall index 2, parte da '.'
                sw.WriteLine(lines[ind++]);
            }
            //sw.WriteLine("-------------------");
            sw.WriteLine(lines[ind++]);
            sw.WriteLine($"numero di prodotti: {seline}");
            sw.WriteLine($"prezzo totale: {sum}"); // 15 char + somma
            ind += 2; //salta somma e npro
                      //sw.WriteLine("###################");
            while (ind < lines.Length) //scrive tutto il resto
                sw.WriteLine(lines[ind++]);
            sw.Close();
        }
        private void EditLine(string nome, string prezzo, string cerca, int selis, string path)
        {//fun 6
            string[] lines = File.ReadAllLines(path + "\\delimitatori.txt");
            int npro = int.Parse(lines[selis]) - 4; //numero righe di prodotti // -4 =  tot prodotti + somma + 2 separatori.

            if (!CheckCercaLine(cerca, npro)) //bad input
                return;
            if (!CheckNomePrezzo(nome, prezzo)) //bad input
                return;

            int line = 0; //numero riga dove inizia la lista
            for (int i = 1; i < selis; i++)
                line += int.Parse(lines[i]);

            lines = File.ReadAllLines(path + "\\liste.txt");

            string strSum = "";
            for (int c = 15; c < lines[line+npro+2].Length; c++)
                strSum += lines[line+npro+2][c];

            string strSeline = "";
            for (int c = lines[line+ int.Parse(cerca) - 1].Length - 1; true; c--)
            {
                strSeline = lines[line+ int.Parse(cerca) - 1][c] + strSeline;
                if (!float.TryParse(strSeline, out _))
                { //bad input
                    strSeline = strSeline.Substring(2); // ": "
                    break;
                }
            }

            float sum = float.Parse(strSum) - float.Parse(strSeline) + float.Parse(prezzo);

            StreamWriter sw = new StreamWriter(path + "\\liste.txt");
            //for (int i = 0; i < line+npro; i++)
            for (int i = 0; i < line+ int.Parse(cerca) - 1; i++)
                sw.WriteLine(lines[i]);
            //sw.WriteLine($"{npro + 1}.    Nome: {nome}|    Prezzo: {prezzo}");
            sw.WriteLine($"{cerca}.    Nome: {nome}|    Prezzo: {prezzo}");
            //sw.WriteLine("-------------------");
            //sw.WriteLine($"numero di prodotti: {npro + 1}");
            for (int i = line + int.Parse(cerca); i < line+npro+2; i++)
                sw.WriteLine(lines[i]);
            sw.WriteLine($"prezzo totale: {sum}"); // 15 char + somma

            //sw.WriteLine("###################");

            for (int i = line+npro+4; i < lines.Length; i++)
                sw.WriteLine(lines[i]);
            sw.Close();
        }
        private void RemoveLine(string cerca, int selis, string path)
        {//fun 8
            string[] lines = File.ReadAllLines(path + "\\delimitatori.txt");
            int npro = int.Parse(lines[selis]) - 4; //numero righe di prodotti // -4 =  tot prodotti + somma + 2 separatori

            if (!CheckCercaLine(cerca, npro)) //bad input
                return;

            int line = 0; //numero riga dove inizia la lista
            for (int i = 1; i < selis; i++)
                line += int.Parse(lines[i]);

            //rimuovo un prodotto
            StreamWriter sw = new StreamWriter(path + "\\delimitatori.txt");
            lines[selis] = (int.Parse(lines[selis])-1).ToString(); ; //aggiungo già una riga al conteggio righe della lista

            //if npro == 1 cancella lista ?? nahh
            sw.Write(lines[0]); //prima riga senza \n iniziale
            for (int i = 1; i < lines.Length; i++)
                sw.Write("\n"+lines[i]); //nessuna riga vuota alla fine del file
            sw.Close();
            lines = File.ReadAllLines(path + "\\liste.txt");

            string strSum = "";
            for (int c = 15; c < lines[line+npro+2].Length; c++)
                strSum += lines[line+npro+2][c];

            int seline = int.Parse(cerca) - 1; //tutti i calcoli hanno - 1

            string strSeline = "";
            for (int c = lines[line+ seline].Length - 1; true; c--)
            {
                strSeline = lines[line+ seline][c] + strSeline;
                if (!float.TryParse(strSeline, out _))
                { //bad input
                    strSeline = strSeline.Substring(2); // ": "
                    break;
                }
            }

            float sum = float.Parse(strSum) - float.Parse(strSeline);

            sw = new StreamWriter(path + "\\liste.txt");
            int ind = 0;
            while (ind < line + seline)
                sw.WriteLine(lines[ind++]);

            //ind++; //salto la linea selezionata
            StreamWriter swr = new StreamWriter(path + "\\logic remove.txt", true);
            swr.WriteLine($"lista{selis}: {lines[ind++]}");
            swr.Close();

            while (ind < line + npro)
            { //a tutti l'identificativo - 1
                seline++;
                lines[ind] = seline + lines[ind].Substring((seline+1).ToString().Length); // se è "10." allora scrive dall index 2, parte da '.'
                sw.WriteLine(lines[ind++]);
            }
            //sw.WriteLine("-------------------");
            sw.WriteLine(lines[ind++]);
            sw.WriteLine($"numero di prodotti: {seline}");
            sw.WriteLine($"prezzo totale: {sum}"); // 15 char + somma
            ind += 2; //salta somma e npro

            //sw.WriteLine("###################");

            while (ind < lines.Length) //scrive tutto il resto
                sw.WriteLine(lines[ind++]);
            sw.Close();
        }

        private void StampaForm()
        {
            string[] lines = File.ReadAllLines(path + "\\delimitatori.txt"); //trovo delimitatori

            int line = 0; //numero riga dove inizia la lista
            for (int i = 1; i < selis; i++)
                line += int.Parse(lines[i]);

            int length = int.Parse(lines[selis]) - 1;

            lines = File.ReadAllLines(path + "\\liste.txt");

            ListaProdotti.Items.Clear();
            for (int i = line; i < line + length; i++)
                ListaProdotti.Items.Add(lines[i]);
        }
    }
}