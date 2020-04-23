using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evidencia;
using static Evidencia.Record;

namespace Evidencia
{
    public class Selecting
    {
        //TODO: vybrať všetky v combobox pre SelectLocker, ak vyberiem room a po stlačení tlačidla vymazať daná vybraná položka v room sa nezobrazi v combobox zznova

        public List<Scanned> ScannedItems = new List<Scanned>();
        private List<Record> SelectRoom = new List<Record>();
        private List<Record> SelectLocker = new List<Record>();
        private List<Record> SelectShelve = new List<Record>();
        private List<Record> SelectSAP = new List<Record>();
        private List<Record> SelectINR = new List<Record>();

        public string SAPControl;
        public string INRtxtBox;
        public string SAPstring;
        public int INRcount;
        public int INRpocetNoRead;
        public string barcodeReaded;
        public int barcodeReadedCount;
        public string INRnoReadedString;
        private string INRreadedString;
        public string INRnoReadedCount;
        public string INRreadedCount;
        public int barcodeCount;
        public string RoomLockerShelve;
        private string miestnostiAll = "Všetky položky";
        private string skrineAll = "Všetky položky";
        private string polickyAll = "Všetky položky";
        public string EspString = "";
        private string INRControl;
        private int INRpocetRead;
        private string INRremoveNoRead;
        public string INRtmp;

        /// <summary>
        /// Funkcia pri zapnutí aplikácie, vloženie údajov do combo boxov, vypnutie nepoužívaných comboboxov, výbraný item č. 11 (L7) miestnosť v prvom comboboxe, funkcia overenia kontrolného módu
        /// </summary>
        /// <param name="ev"></param>
        public void InitializeSelecting(Evidencia ev)
        {
            loadDataToComboBoxes(ev);
            cmbBoxEnabled(ev);
            ev.cmbRoom.SelectedIndex = 11;
            ScannedBarcodes(ev);
            //  ev.lstBoxOcakavane.Items.AddRange(SelectRoom.Select(x => x.inr).ToArray());
        }

        /// <summary>
        /// Funkcia pre načítanie údajov do comboboxoc ohľadom miestnosti, skrine, poličky
        /// </summary>
        /// <param name="ev"></param>
        public void loadDataToComboBoxes(Evidencia ev)
        {
            try
            {

                Dictionary<string, string> miestnostiDic = new Dictionary<string, string>();
                foreach (var item in ev.localDb.zaznamyNamespace)
                {
                    miestnostiDic.Add(item.New, item.original_room);
                }
                List<string> miestnosti = ev.localDb.zaznamyNamespace.Select(x => x.New).ToList();
                miestnosti.Sort();
                ev.cmbRoom.Items.Add(miestnostiAll);
                ev.cmbRoom.Items.AddRange(miestnosti.ToArray());

                List<string> skrine = ev.localDb.zaznamyRecord.Select(x => x.place_locker).Distinct().ToList();
                skrine.Sort();
                ev.cmbLocker.Items.Add(skrineAll);
                ev.cmbLocker.Items.AddRange(skrine.ToArray());

                List<string> policky = ev.localDb.zaznamyRecord.Select(x => x.place_shelve).Distinct().ToList();
                policky.Sort();
                ev.cmbShelve.Items.Add(polickyAll);
                ev.cmbShelve.Items.AddRange(policky.ToArray());

                if (ev.cmbRoom.SelectedIndex < 1)
                {
                    ev.cmbLocker.Enabled = false;
                    ev.cmbShelve.Enabled = false;
                }
                else
                {
                    ev.cmbLocker.Enabled = true;
                    ev.cmbShelve.Enabled = true;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// Funkcia, ktorá nastane pri výbere itemu v Comboboxe pre miestnosti, vyselectuje všetky údaje, ktoré sa nachádzajú podľa výberu miestnosti comboboxu daného item
        /// </summary>
        /// <param name="ev"></param>
        public void listboxDataRoom(Evidencia ev)
        {
            try
            {
                ev.cmbLocker.Enabled = false;
                ev.cmbShelve.Enabled = false;
                string roomSap;

                if (ev.cmbRoom.Text != miestnostiAll)
                {
                    roomSap = ev.localDb.zaznamyNamespace.Find(x => x.New == ev.cmbRoom.Text).original_room;
                    SelectRoom = ev.localDb.zaznamyRecord.Where(x =>
                        (x.place_room_sap == roomSap)).ToList();
                    MakeESPstringRoom(ev);
                    ev.btnESPstringSend.Enabled = true;
                    ev.cmbLocker.Enabled = true;

                    if ((SelectRoom?.Count ?? 0) == 0)
                    {
                        ev.listBox.DataSource = null;
                        MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
                        ev.cmbLocker.Enabled = false;
                        ev.cmbShelve.Enabled = false;
                        ev.listBox.DataSource = SelectRoom;
                    }                   
                }
                else
                {
                    MakeESPstringRoom(ev);
                    SelectRoom = ev.localDb.zaznamyRecord;
                    ev.btnESPstringSend.Enabled = true;                   
                }
                ScannedBarcodes(ev);
                ev.listBox.DataSource = SelectRoom;
                ev.lblOcakavaneCounter.Text = SelectRoom.Count.ToString();
                ev.txtInr.Text = SelectRoom.Count.ToString();
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }

        }

        /// <summary>
        /// Funkcia, ktorá nastane pri výbere itemu v Comboboxe pre skrine, vyselectuje všetky údaje, ktoré sa nachádzajú podľa výberu skrine comboboxu daného item
        /// </summary>
        /// <param name="ev"></param>
        public void listboxDataLocker(Evidencia ev)
        {
            try
            {
                ev.cmbShelve.Enabled = false;

                if (ev.cmbLocker.Text != skrineAll)
                {
                    SelectLocker = SelectRoom.Where(x =>
                        (x.place_locker == ev.cmbLocker.Text)).ToList();
                    ev.cmbShelve.Enabled = true;

                    if ((SelectLocker?.Count ?? 0) == 0)
                    {
                        ev.listBox.DataSource = SelectRoom;
                        ev.listBox.DataSource = null;
                        MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
                        ev.cmbShelve.Enabled = false;
                    }
                    MakeESPstringLocker(ev);
                    ev.btnESPstringSend.Enabled = true;
                }
                else
                {
                    string roomSap = ev.localDb.zaznamyNamespace.Find(x => x.New == ev.cmbRoom.Text).original_room;
                    SelectLocker = ev.localDb.zaznamyRecord.Where(x =>
                        (x.place_room_sap == roomSap)).ToList();

                    MakeESPstringLocker(ev);
                    ev.btnESPstringSend.Enabled = true;
                }
                ScannedBarcodes(ev);
                ev.listBox.DataSource = SelectLocker;
                ev.lblOcakavaneCounter.Text = SelectLocker.Count.ToString(); 
                ev.txtInr.Text = SelectLocker.Count.ToString();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// Funkcia, ktorá nastane pri výbere itemu v Comboboxe pre poličky, vyselectuje všetky údaje, ktoré sa nachádzajú podľa výberu poličky comboboxu daného item
        /// </summary>
        /// <param name="ev"></param>
        public void listboxDataShelve(Evidencia ev)
        {
            try
            {
                if (ev.cmbShelve.Text != polickyAll)
                {
                    SelectShelve = SelectLocker.Where(x =>
                        (x.place_shelve == ev.cmbShelve.Text)).ToList();

                    if ((SelectShelve?.Count ?? 0) == 0)
                    {
                        ev.listBox.DataSource = SelectLocker;
                        ev.listBox.DataSource = null;
                        MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
                        INRnoReadedString = "";
                    }

                    MakeESPstringShelve(ev);
                    ev.btnESPstringSend.Enabled = true;
                }
                else
                {
                    SelectShelve = ev.localDb.zaznamyRecord.Where(x =>
                        (x.place_locker == ev.cmbLocker.Text)).ToList();

                    MakeESPstringShelve(ev);
                    ev.btnESPstringSend.Enabled = true;
                }
                ScannedBarcodes(ev);
                ev.listBox.DataSource = SelectShelve;
                ev.lblOcakavaneCounter.Text = SelectShelve.Count.ToString();
                ev.txtInr.Text = SelectShelve.Count.ToString();

            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// funkcia pre editáciu zapnutia a vypnutia comboboxov pre skrinu a poličku podľa výberu miestnosti
        /// </summary>
        /// <param name="ev"></param>
        public void cmbBoxEnabled(Evidencia ev)
        {
            if (ev.cmbRoom.SelectedIndex < 1)
            {
                ev.cmbLocker.Enabled = false;
                ev.cmbShelve.Enabled = false;
            }
            else
            {
                ev.cmbLocker.Enabled = true;
                ev.cmbShelve.Enabled = true;
            }
        }

        /// <summary>
        /// Funkcia pre poslanie reťazca znakov pre IoT zariadenie podľa vybraných miestnosti, skrine alebo poličky
        /// </summary>
        /// <param name="ev"></param>
        public void SendEspString(Evidencia ev)
        {          
            EspString = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRnoReadedString;
            ev.tcp.SendMsg(EspString);
        }


        /// <summary>
        /// Funkcia pre poslanie reťazca znakov, ktorý definuje nevybrané miestnosti, nastane pri stlačení tlačidla vymazať
        /// </summary>
        /// <param name="ev"></param>
        public void SendEspRemove(Evidencia ev)
        {
            RoomLockerShelve = "M-:-:-";
            INRreadedString = "( -";
            INRreadedCount = ") 0 [ 0 ]";
            INRnoReadedCount = "< 0";
            INRnoReadedString = "> -";
            EspString = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRnoReadedString;
            ev.tcp.SendMsg(EspString);
        }

        /// <summary>
        /// Funkcia pre vytváranie a ediáciu reťazca znakov pre posielanie IoT zariadeniu, reťazec znakov sa edituje pri každom prečítaní čiarového kódu
        /// </summary>
        /// <param name="ev"></param>
        public void ControlSapNumber(Evidencia ev)
        {
            try
            {
                if (ev.tcp.tcpClient.Connected)
                {
                    if (SAPstring.Contains(ev.SAP))
                    {
                        string SAPlist;
                        string INRremove;
                        INRremove = INRnoReadedString;
                        SAPlist = SAPstring;

                        SelectSAP = ev.localDb.zaznamyRecord.Where(x => x.meta_sap == ev.SAP).ToList();
                        SelectINR = SelectShelve.Where(x => x.meta_sap != ev.SAP).ToList();
                        int INRselectINRcount = SelectINR.Count();
                        List<string> INRselector = SelectSAP.Select(x => x.inr).Distinct().ToList();
                        foreach (var model in INRselector)
                        {
                            INRControl = model + "\\r";
                        }

                        //Debug.WriteLine("SelectSAP=" + SelectSAP.ToString() + "; SAP=" + ev.SAP.ToString());
                        ev.listBox.DataSource = SelectINR;

                        if (SAPlist.Contains(ev.SAP))
                        {
                            int SAPindexOf = SAPlist.IndexOf(ev.SAP);
                            int SAPlength = ev.SAP.Length;
                            int SAPStringLength = SAPlist.Length;
                            Debug.WriteLine("SAPlist IndexOff=" + SAPindexOf.ToString() + "; SAP Length=" + SAPlength.ToString() + ";  SAPStringLength=" + SAPStringLength.ToString());

                            SAPControl = SAPlist.Remove(SAPindexOf, SAPlength);
                            SAPStringLength = SAPControl.Length;
                            Debug.WriteLine("SAPList =" + SAPlist.ToString() + "SAPCONTROL LENgth =" + SAPStringLength.ToString());
                            Debug.WriteLine("SAPControl =" + SAPControl.ToString() + "SAPCONTROL LENgth =" + SAPStringLength.ToString());

                            int INRindexOf = INRremove.IndexOf(INRControl);
                            int INRlength = INRControl.Length;
                            int INRStringLength = INRremove.Length;
                            Debug.WriteLine("INRstring= " + INRremove + "INRtxtBox IndexOf=" + INRindexOf.ToString() + "; INRlength =" + INRlength.ToString() + ";  INRStringLength=" + INRStringLength.ToString());

                            INRremoveNoRead = INRremove.Remove(INRindexOf, INRlength + 1);
                            INRStringLength = INRremove.Length;
                            Debug.WriteLine("INRControl =" + INRControl.ToString() + "INRStringLength =" + INRStringLength.ToString());
                            Debug.WriteLine("INRstring= " + INRremoveNoRead + "INRtxtBox IndexOf=" + INRindexOf.ToString() + "; INRlength =" + INRlength.ToString() + ";  INRStringLength=" + INRStringLength.ToString());

                            Debug.WriteLine("SAPlistContains ev.SAP ");

                            if (SAPlist.Contains(ev.SAP))
                            {
                                SAPlistIsInList(ev);
                            }
                            else
                            {
                                SAPlistIsntInList(ev);
                            }
                        }

                        if (!SAPlist.Contains(ev.SAP))
                        {
                            SAPlistIsNotInList(ev);
                        }
                    }

                    if (!SAPstring.Contains(ev.SAP))
                    {
                        SAPstringIsNotInList(ev);
                    }
                }
                else
                {
                    ev.tcp.serverConnect(ev);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        /// <summary>
        /// Funkcia pri správnom umiestnení zariadenia
        /// </summary>
        /// <param name="ev"></param>
        public void SAPlistIsInList(Evidencia ev)
        {
            string INRremove;
            INRremove = INRnoReadedString;
            int INRindexOf = INRremove.IndexOf(INRControl);
            int INRlength = INRControl.Length;
            int INRStringLength = INRremove.Length;
            INRremoveNoRead = INRremove.Remove(INRindexOf, INRlength + 1);

            List<string> INR = SelectShelve.Select(x => x.inr).Distinct().ToList();

            RoomLockerShelve = "Mmiest.  " + ev.cmbRoom.Text + ":skr.  " + ev.cmbLocker.Text + ":pol.  " + ev.cmbShelve.Text;
            INRpocetNoRead--;
            INRnoReadedCount = "<" + INRpocetNoRead.ToString();
            INRreadedString += INRControl;
            INRpocetRead++;
            barcodeReaded += ev.SAP;
            barcodeReadedCount += ev.SAP.Count();
            barcodeCount = barcodeReadedCount / 8;
            INRreadedCount = ")" + INRpocetRead + " [" + barcodeCount + "]";
            ev.txtSender.Text = RoomLockerShelve;
            ev.txtReceiver.Text = INRpocetNoRead.ToString();
            Debug.WriteLine("EspString= " + EspString.ToString());
            // ev.listINR.DataSource = INR;
            ev.txtInr.Text = SAPControl;

            EspString = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRremoveNoRead;
            ev.TxtOut.Text = RoomLockerShelve.ToString() + INRreadedString + INRreadedCount + INRnoReadedCount.ToString() + INRnoReadedString.ToString();
            ev.tcp.SendMsg(EspString);
            Debug.WriteLine("SAPControl= " + SAPControl.ToString());
            Debug.WriteLine("INRremoveNoRead= " + INRremoveNoRead.ToString());
        }

        public void SAPlistIsntInList(Evidencia ev)
        {
            string SAPlist;
            SAPlist = SAPstring;
            Debug.WriteLine("!SAPlistContains NOT ev.SAP ");

            List<string> INR = SelectShelve.Select(x => x.inr).Distinct().ToList();

            RoomLockerShelve = "Mmiest.  " + ev.cmbRoom.Text + ":skr.  " + ev.cmbLocker.Text + ":pol.  " + ev.cmbShelve.Text;
            INRnoReadedCount = "<" + INRpocetNoRead.ToString();
            barcodeReaded += ev.SAP;
            barcodeReadedCount += ev.SAP.Count();
            barcodeCount = barcodeReadedCount / 8;
            INRreadedCount = ")" + INRpocetRead + " [" + barcodeCount + "]";
            ev.txtSender.Text = RoomLockerShelve;
            ev.txtReceiver.Text = INRpocetNoRead.ToString();
            // ev.listINR.DataSource = INR;
            //ev.txtInr.Text = SAPControl;

            EspString = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRremoveNoRead;
            ev.TxtOut.Text = RoomLockerShelve.ToString() + INRreadedString + INRreadedCount + INRnoReadedCount.ToString() + INRnoReadedString.ToString();
            Debug.WriteLine("EspString= " + EspString.ToString());
            ev.tcp.SendMsg(EspString);
            Debug.WriteLine("SAPlist= " + SAPlist.ToString());
            Debug.WriteLine("INRremoveNoRead= " + INRremoveNoRead.ToString());
        }

        public void SAPlistIsNotInList(Evidencia ev)
        {
            string SAPlist;
            SAPlist = SAPstring;
            Debug.WriteLine("!SAPlistContains NOT ev.SAP ");

            List<string> INR = SelectShelve.Select(x => x.inr).Distinct().ToList();

            RoomLockerShelve = "Mmiest.  " + ev.cmbRoom.Text + ":skr.  " + ev.cmbLocker.Text + ":pol.  " + ev.cmbShelve.Text;
            INRnoReadedCount = "<" + INRpocetNoRead.ToString();
            barcodeReaded += ev.SAP;
            barcodeReadedCount += ev.SAP.Count();
            barcodeCount = barcodeReadedCount / 8;
            INRreadedCount = ")" + INRpocetRead + " [" + barcodeCount + "]";
            ev.txtSender.Text = RoomLockerShelve;
            ev.txtReceiver.Text = INRpocetNoRead.ToString();
            // ev.listINR.DataSource = INR;
            //ev.txtInr.Text = SAPControl;

            EspString = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRremoveNoRead;
            ev.TxtOut.Text = RoomLockerShelve.ToString() + INRreadedString + INRreadedCount + INRnoReadedCount.ToString() + INRnoReadedString.ToString();
            Debug.WriteLine("EspString= " + EspString.ToString());
            ev.tcp.SendMsg(EspString);
            Debug.WriteLine("SAPlist= " + SAPlist.ToString());
            Debug.WriteLine("INRremoveNoRead= " + INRremoveNoRead.ToString());
        }

        public void SAPstringIsNotInList(Evidencia ev)
        {
            Debug.WriteLine("!SAPLIST Contains NOT ev.SAP ");
            string SAPlist;
            string INRremove;
            INRremove = INRnoReadedString;
            SAPlist = SAPstring;
            SelectSAP = ev.localDb.zaznamyRecord.Where(x => x.meta_sap == ev.SAP).ToList();
            SelectINR = SelectShelve.Where(x => x.meta_sap != ev.SAP).ToList();
            int INRselectINRcount = SelectINR.Count();
            List<string> INRselector = SelectSAP.Select(x => x.inr).Distinct().ToList();
            foreach (var model in INRselector)
            {
                INRControl = model + "\\r";
            }

            Debug.WriteLine("SelectSAP=" + SelectSAP.ToString() + "; SAP=" + ev.SAP.ToString());
            ev.listBox.DataSource = SelectINR;
            List<string> INR = SelectShelve.Select(x => x.inr).Distinct().ToList();

            RoomLockerShelve = "Mmiest.  " + ev.cmbRoom.Text + ":skr.  " + ev.cmbLocker.Text + ":pol.  " + ev.cmbShelve.Text;
            INRnoReadedCount = "<" + INRpocetNoRead.ToString();
            INRnoReadedString = "";
            INRnoReadedString = ">";
            foreach (var model in INR)
            {
                INRnoReadedString += model + "\\r";
                INRtxtBox += model;
            }
            barcodeReaded += ev.SAP;
            barcodeReadedCount += ev.SAP.Count();
            barcodeCount = barcodeReadedCount / 8;
            INRreadedCount = ")" + INRpocetRead + " [" + barcodeCount + "]";
            ev.txtSender.Text = RoomLockerShelve;
            ev.txtReceiver.Text = INRpocetNoRead.ToString();
            // ev.listINR.DataSource = INR;
            EspString = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRremoveNoRead;
            //ev.TxtOut.Text = RoomLockerShelve.ToString() + INRreadedString + INRreadedCount + INRnoReadedCount.ToString() + INRremoveNoRead.ToString();
            Debug.WriteLine("EspString= " + EspString.ToString());
            ev.tcp.SendMsg(EspString);
            //Debug.WriteLine("SAPlist= " + SAPlist.ToString());
            //Debug.WriteLine("INRremoveNoRead= " + INRremoveNoRead.ToString());
        }


        List<Record> vygenerujOckavane(List<Scanned> oskenovane, string meistnost, int skrina, int policka, Evidencia ev)
        {
            List<Record> ockavane = new List<Record>(ev.localDb.zaznamyRecord);
            ///TODO algoritmus
            ///
            return ockavane;

        }
        /// <summary>
        /// Funkcia pre vytvorenie reťazca znakov pri výbere miestnosti, skrine a poličky
        /// </summary>
        /// <param name="ev"></param>
        public void MakeESPstringShelve(Evidencia ev)
        {
            List<string> INR = SelectShelve.Select(x => x.inr).Distinct().ToList();
            List<string> SAP = SelectShelve.Select(x => x.meta_sap).Distinct().ToList();

            SAPstring = "";
            INRnoReadedString = "";
            //TODO: spraviť skladanie string pre INR, podmienka ak je väčší počet ako 200, poslať ! 
            INRpocetNoRead = INR.Count(); //počet zariadení
            INRnoReadedCount = "<" + INRpocetNoRead.ToString();
            INRreadedString = "";
            INRreadedString = "(";
            int INRpocetRead = 0;
            INRreadedCount = ")" + INRpocetRead + " [" + barcodeCount + "]"; // )0[0]
            barcodeCount = 0;

            foreach (var model in INR)
            {
                INRtxtBox += model;
                INRtmp = model;
            }
            foreach (var model in SAP)
            {
                SAPstring += model;
            }
            int INRtmpCount = SelectShelve.Count();
            if (INRtmpCount > 150) // podmienka, pokiaľ je viac ako 150 zariadení, mení sa reťazec znakov a nepošle zariadenia vo formáte INR, potreba zúžiť výber
            {
                INRnoReadedString = "! Prilis //r vela //r zariadeni";
                INRreadedString = "( Zvolte \\r skrinu";
            }
            else
            {
                INRnoReadedString = ">";
                foreach (var model in INR)
                {
                    INRnoReadedString += model + "\\r"; // načítanie všetkých INR zariadení do premennej s ošetrením nového riadku pre displej 
                    INRtxtBox += model;
                }
            }
            RoomLockerShelve = "Mmiest.  " + ev.cmbRoom.Text + ":skr.  " + ev.cmbLocker.Text + ":pol.  " + ev.cmbShelve.Text; // reťazec znakov pre miestnosť, skriňu a poličku
            ev.txtSender.Text = RoomLockerShelve.ToString();
            ev.txtReceiver.Text = INRpocetNoRead.ToString();
            // ev.listINR.DataSource = INR;
            ev.txtReceiver.Text = INRpocetNoRead.ToString();
            ev.TxtOut.Text = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRnoReadedString;
            //  ev.listINR.DataSource = INR;
            ev.txtInr.Text = ev.TxtOut.Text.Count().ToString();
        }

        public void MakeESPstringLocker(Evidencia ev)
        {
            List<string> INR = SelectLocker.Select(x => x.inr).Distinct().ToList();
            List<string> SAP = SelectLocker.Select(x => x.meta_sap).Distinct().ToList();

            SAPstring = "";
            INRnoReadedString = "";
            INRnoReadedString = ">";
            INRpocetNoRead = INR.Count();
            INRnoReadedCount = "<" + INRpocetNoRead.ToString();
            INRreadedString = "";
            INRreadedString = "(";
            int INRpocetRead = 0;
            INRreadedCount = ")" + INRpocetRead + " [" + barcodeCount + "]"; // )0[0]
            barcodeCount = 0;

            foreach (var model in INR)
            {
                INRtxtBox += model;
                INRtmp = model;
            }
            foreach (var model in SAP)
            {
                SAPstring += model;
            }
            int INRtmpCount = SelectLocker.Count();
            if (INRtmpCount > 150) // podmienka, pokiaľ je viac ako 150 zariadení, mení sa reťazec znakov a nepošle zariadenia vo formáte INR, potreba zúžiť výber
            {
                INRnoReadedString = "! Prilis //r vela //r zariadeni";
                INRreadedString = "( Zvolte \\r skrinu";
            }
            else
            {
                INRnoReadedString = ">";
                foreach (var model in INR)
                {
                    INRnoReadedString += model + "\\r"; // načítanie všetkých INR zariadení do premennej s ošetrením nového riadku pre displej 
                    INRtxtBox += model;
                }
            }

            RoomLockerShelve = "Mmiest.  " + ev.cmbRoom.Text + ":skr.  " + ev.cmbLocker.Text + ":pol.  " + ev.cmbShelve.Text; // reťazec znakov pre miestnosť, skriňu a poličku
            ev.txtSender.Text = RoomLockerShelve.ToString();
            ev.txtReceiver.Text = INRpocetNoRead.ToString();
            // ev.listINR.DataSource = INR;
            ev.txtReceiver.Text = INRpocetNoRead.ToString();
            ev.TxtOut.Text = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRnoReadedString;
            ev.txtInr.Text = ev.TxtOut.Text.Count().ToString();
        }

        public void MakeESPstringRoom(Evidencia ev)
        {
            List<string> INR = SelectRoom.Select(x => x.inr).ToList();
            List<string> SAP = SelectRoom.Select(x => x.meta_sap).ToList();

            SAPstring = "";
            INRnoReadedString = "";
            INRpocetNoRead = INR.Count();
            INRnoReadedCount = "<" + INRpocetNoRead.ToString();
            INRreadedString = "(";
            int INRpocetRead = 0;
            INRreadedCount = ")" + INRpocetRead + " [" + barcodeCount + "]"; // )0[0]
            barcodeCount = 0;

            foreach (var model in INR)
            {
                INRtxtBox += model;
                INRtmp = model;
            }
            foreach (var model in SAP)
            {
                SAPstring += model;
            }
            int INRtmpCount = SelectRoom.Count();
            if (INRtmpCount > 150) // podmienka, pokiaľ je viac ako 150 zariadení, mení sa reťazec znakov a nepošle zariadenia vo formáte INR, potreba zúžiť výber
            {
                INRnoReadedString = "! Prilis \\r vela \\r zariadeni";
                INRreadedString = "( zvolte \\r skrinu";
            }
            else
            {
                INRnoReadedString = ">";
                foreach (var model in INR) // načítanie všetkých INR zariadení do premennej s ošetrením nového riadku pre displej 
                {
                    INRnoReadedString += model + "\\r";
                    INRtxtBox += model;
                }
            }

            RoomLockerShelve = "Mmiest.  " + ev.cmbRoom.Text + ":skr.  " + ev.cmbLocker.Text + ":pol.  " + ev.cmbShelve.Text; // reťazec znakov pre miestnosť, skriňu a poličku
            ev.txtSender.Text = RoomLockerShelve.ToString();
            ev.txtReceiver.Text = INRtmpCount.ToString();
            ev.TxtOut.Text = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRnoReadedString;
            //  ev.listINR.DataSource = INR;
            ev.txtInr.Text = ev.TxtOut.Text.Count().ToString();
        }

        /// <summary>
        /// Funkcia pre vymazanie reťazca znakov
        /// </summary>
        public void FlushESPstring()
        {
            RoomLockerShelve = "";
            INRreadedString = "";
            INRreadedCount = "";
            INRnoReadedCount = "";
            INRremoveNoRead = "";
            barcodeCount = 0;
        }

        /// <summary>
        /// Funkcia hlavného kontrolného módu v aplikácií
        /// </summary>
        /// <param name="ev"></param>
        public void ScannedBarcodes(Evidencia ev)
        {
            ev.lstBoxNespravne.Items.Clear();
            ev.lstBoxSpravne.Items.Clear();
            ev.lstBoxOcakavane.Items.Clear();


            List<Record> NaskenovaneZariadenia = new List<Record>();    //zoznam naskenovanych zariadeni        
            List<Record> SpravneUmiestnenie = new List<Record>();
            List<Record> NespravneUmiestnenie = new List<Record>();
            List<Record> Ocakavane = new List<Record>(ev.localDb.zaznamyRecord);

            //List<Scanned> ScannedDeviced = new List<Scanned>();    //zoznam naskenovanych zariadeni        
            //List<Scanned> CorrectMapping = new List<Scanned>();
            //List<Scanned> UncorrectMapping = new List<Scanned>();
            //List<Scanned> WaitingDeviced = new List<Scanned>(ev.localDb.Items);


            if (ev.cmbRoom.SelectedIndex >= 0)
            {
                if (ev.cmbLocker.SelectedIndex >= 0)
                {
                    if (ev.cmbShelve.SelectedIndex >= 0)
                    {
                        //string roomSap = ev.localDb.zaznamyNamespace.Find(x => x.New == ev.cmbRoom.Text).original_room;
                        //List<Scanned> OcakavanePolicka = (List<Scanned>)Ocakavane
                        //    .FindAll(x => x.room == (string)roomSap
                        //&& x.locker == ev.cmbLocker.SelectedItem.ToString()
                        //&& x.shelve == Convert.ToInt32(ev.cmbShelve.SelectedItem));

                        SelectShelve.FindAll(x => x.place_shelve == ev.cmbShelve.Text); //ev.cmbRoom.SelectedItem 

                        foreach (var s in ScannedItems
                            .FindAll(x => x.room == ev.cmbRoom.SelectedItem.ToString()
                        && x.locker == ev.cmbLocker.SelectedItem.ToString()
                        && x.shelve == ev.cmbShelve.SelectedItem.ToString()))
                        {
                            Record item = ev.localDb.zaznamyRecord.Find(x => x.meta_sap == s.sap);
                            if (item.isShelveCorrect(s))
                            {
                                //naskenovane je medzi ocakavanymi
                                SpravneUmiestnenie.Add(item);
                                int indexF = SelectShelve.FindIndex(x => x.meta_sap == s.sap);
                                //SelectShelve.RemoveAt(SelectShelve.FindIndex(x => x.meta_sap == s.sap));
                                SelectShelve.RemoveAt(indexF);
                            }
                            else
                            {
                                NespravneUmiestnenie.Add(item);
                            }
                        }
                        ev.lstBoxOcakavane.Items.AddRange(SelectShelve.Select(x => x.inr).ToArray());
                        ev.lstBoxSpravne.Items.AddRange(SpravneUmiestnenie.Select(x => x.inr).ToArray());
                        ev.lstBoxNespravne.Items.AddRange(NespravneUmiestnenie.Select(x => x.inr).ToArray());
                        ev.txtTry.Text = "Skenované zariadenia: " + ScannedItems.Count.ToString() + Environment.NewLine
                           + "Očakávané zariadenia: " + SelectShelve.Count.ToString() + Environment.NewLine
                             + "Správne umiestnenie: " + SpravneUmiestnenie.Count.ToString() + Environment.NewLine
                             + "Nesprávna umiestnenie: " + NespravneUmiestnenie.Count.ToString();
                    }
                    else
                    {
                        //List<Scanned> OcakavaneSkrina = (List<Scanned>)Ocakavane
                        //    .FindAll(x => x.room == (string)roomSap
                        //&& x.locker == ev.cmbLocker.SelectedItem.ToString());
                        SelectLocker.FindAll(x => x.place_locker == ev.cmbLocker.Text); //ev.cmbRoom.SelectedItem   

                        foreach (var s in ScannedItems
                            .FindAll(x => x.room == ev.cmbRoom.SelectedItem.ToString()
                        && x.locker == ev.cmbLocker.SelectedItem.ToString()))
                        {
                            Record item = ev.localDb.zaznamyRecord.Find(x => x.meta_sap == s.sap);
                            if (item.isLockerCorrect(s))
                            {
                                SpravneUmiestnenie.Add(item);
                                SelectLocker.RemoveAt(SelectLocker.FindIndex(x => x.meta_sap == s.sap));
                            }
                            else
                            {
                                NespravneUmiestnenie.Add(item);
                            }
                        }
                        ev.lstBoxOcakavane.Items.AddRange(SelectLocker.Select(x => x.inr).ToArray());
                        ev.lstBoxSpravne.Items.AddRange(SpravneUmiestnenie.Select(x => x.inr).ToArray());
                        ev.lstBoxNespravne.Items.AddRange(NespravneUmiestnenie.Select(x => x.inr).ToArray());
                        ev.txtTry.Text = "Skenované zariadenia: " + ScannedItems.Count.ToString() + Environment.NewLine 
                        + "Očakávané zariadenia: " + SelectLocker.Count.ToString() + Environment.NewLine
                          + "Správne umiestnenie: " + SpravneUmiestnenie.Count.ToString() + Environment.NewLine
                          + "Nesprávna umiestnenie: " + NespravneUmiestnenie.Count.ToString();
                    }
                }
                else
                {
                    //nacitanie zoznamu, co vsetko ma byt v danej miestnosti

                    string roomSap = ev.localDb.zaznamyNamespace.Find(x => x.New == ev.cmbRoom.Text).original_room;
                    //SelectRoom.FindAll(x => x.place_room_sap == (string)roomSap); //ev.cmbRoom.SelectedItem   

                    SelectRoom = ev.localDb.zaznamyRecord.Where(x => (x.place_room_sap == roomSap)).ToList();

                    foreach (var s in ScannedItems.FindAll(x => x.room == ev.cmbRoom.SelectedItem.ToString()))
                    {
                        Record item = ev.localDb.zaznamyRecord.Find(x => x.meta_sap == s.sap);
                        if (item == null) return;

                        if (item.isRoomCorrect(s))
                        {
                            //naskenovane je medzi ocakavanymi
                            SpravneUmiestnenie.Add(item);
                            SelectRoom.RemoveAt(SelectRoom.FindIndex(x => x.meta_sap == s.sap));
                        }
                        else
                        {
                            NespravneUmiestnenie.Add(item);
                        }
                        /*
                            SelectRoom.Exists(x => (x.meta_sap == s.sap)&&(x.place_room_sap == s.room)))
                        {
                            //naskenovane je medzi ocakavanymi
                            SpravneUmiestnenie.Add(SelectRoom.Find(x => x.sap == s.sap));
                            SelectRoom.RemoveAt(SelectRoom.FindIndex(x => x.sap == s.sap));
                        }
                        else
                        {
                            NespravneUmiestnenie.Add(ev.localDb.Items.Find(x => x.sap == s.sap));
                        }
                        */
                    }
                    ev.lstBoxOcakavane.Items.AddRange(SelectRoom.Select(x => x.inr).ToArray());
                    ev.lstBoxSpravne.Items.AddRange(SpravneUmiestnenie.Select(x => x.inr).ToArray());
                    ev.lstBoxNespravne.Items.AddRange(NespravneUmiestnenie.Select(x => x.inr).ToArray());
                    ev.txtTry.Text = "Skenované zariadenia: " + ScannedItems.Count.ToString() + Environment.NewLine
                          + "Očakávané zariadenia: " + SelectRoom.Count.ToString() + Environment.NewLine
                            + "Správne umiestnenie: " + SpravneUmiestnenie.Count.ToString() + Environment.NewLine
                            + "Nesprávna umiestnenie: " + NespravneUmiestnenie.Count.ToString();

                }
            }
            // ev.listINR.DataSource = ev.localDb.Items;

        }

        public void FillScannedList(Evidencia ev)
        {
            if (ev.cmbLocker.SelectedIndex > 0)
            {
                if (ev.cmbShelve.SelectedIndex > 0)
                {
                    if (ev.SAP.Length > 0)
                    {
                        //ScannedItems.Add(ev.localDb.Items.Find(x => x.sap == ev.SAP));
                        ScannedItems.Add(new Scanned() { sap = ev.SAP, room = ev.cmbRoom.Text, locker = ev.cmbLocker.Text, shelve = (ev.cmbShelve.Text) });

                        //ScannedItems.AddRange(ev.localDb.Items.FindAll(x => ev.localDb.Items.Select(y => y.sap).Contains(x.sap)));

                        Debug.WriteLine("; SAP=" + ev.SAP.ToString());
                    }
                    ev.listINR.DataSource = ScannedItems;
                    ev.txtTry.Text = ScannedItems.Count.ToString();
                }
                else
                {
                    if (ev.SAP.Length > 0)
                    {
                        //ScannedItems.Add(ev.localDb.Items.Find(x => x.sap == ev.SAP));
                        ScannedItems.Add(new Scanned() { sap = ev.SAP, room = ev.cmbRoom.Text, locker = ev.cmbLocker.Text });

                        //ScannedItems.AddRange(ev.localDb.Items.FindAll(x => ev.localDb.Items.Select(y => y.sap).Contains(x.sap)));

                        Debug.WriteLine("; SAP=" + ev.SAP.ToString());
                    }
                    ev.listINR.DataSource = ScannedItems;
                    ev.txtTry.Text = ScannedItems.Count.ToString();
                }
            }
            else
            {
                if (ev.SAP.Length > 0)
                {
                    //ScannedItems.Add(ev.localDb.Items.Find(x => x.sap == ev.SAP));
                    ScannedItems.Add(new Scanned() { sap = ev.SAP, room = ev.cmbRoom.Text });

                    //ScannedItems.AddRange(ev.localDb.Items.FindAll(x => ev.localDb.Items.Select(y => y.sap).Contains(x.sap)));

                    Debug.WriteLine("; SAP=" + ev.SAP.ToString());
                }
                ev.listINR.DataSource = ScannedItems;
                ev.txtTry.Text = ScannedItems.Count.ToString();
            }


        }

        public void FillScan(Evidencia ev)
        {
            ScannedItems.Add(new Scanned { sap = "22001062", room = "L7", locker = "1D", shelve = "2" });
            ScannedItems.Add(new Scanned { sap = "22001283", room = "L7", locker = "1D", shelve = "6" });

            //nespravna policka
            ScannedItems.Add(new Scanned { sap = "90249403", room = "L7", locker = "1D", shelve = "6" });

            // nespravna skrina
            ScannedItems.Add(new Scanned { sap = "22001117", room = "L4", locker = "1D", shelve = "2" });

            // nespravna miestnost
            ScannedItems.Add(new Scanned { sap = "90249403", room = "L7", locker = "1H", shelve = "1" });
            ScannedItems.Add(new Scanned { sap = "22001117", room = "L7", locker = "1D", shelve = "2" });
            ScannedItems.Add(new Scanned { sap = "90249403", room = "L7", locker = "1D", shelve = "6" });
            ScannedItems.Add(new Scanned { sap = "22001200", room = "L7", locker = "1H", shelve = "1" });
            ScannedItems.Add(new Scanned { sap = "90249403", room = "L7", locker = "1D", shelve = "6" });
            ScannedItems.Add(new Scanned { sap = "28001463", room = "L7", locker = "1H", shelve = "6" });
            ScannedItems.Add(new Scanned { sap = "90049332", room = "L7", locker = "4", shelve = "2" });
            ScannedItems.Add(new Scanned { sap = "90049547", room = "L7", locker = "1D", shelve = "6" });
            ScannedItems.Add(new Scanned { sap = "90049529", room = "L7", locker = "1D", shelve = "1" });
            ScannedItems.Add(new Scanned { sap = "90049601", room = "L7", locker = "6", shelve = "6" });
            ScannedItems.Add(new Scanned { sap = "90234862", room = "L7", locker = "1H", shelve = "1" });
            ScannedItems.Add(new Scanned { sap = "90266439", room = "L7", locker = "6", shelve = "1" });
        }

        public void FlushLists()
        {
            SelectRoom.Clear();
            SelectLocker.Clear();
            SelectShelve.Clear();
        }
    }
}
