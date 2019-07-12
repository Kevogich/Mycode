using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace GuldeSpecer_1._0
{
    /*public partial class Frm_GetBOMNO : Form*/
    public partial class  Frm_GetBOMNO : Form
    {
        Word.Application WdApp;
        Word.Document WdDoc;
        Word.Selection WdSelection;
        Word.Range WdRange, WdRangeG;
        String Findtex, Replacetex;/*wdpath, */
        Word.WdGoToItem WdGoToPage;
        Word.WdGoToDirection WdGoToNext;
        
        static int BOMlength, L, C, T, K, P, M, Q, i, j, N, Totalpage, TotalpageG;
        static String ProductName, S, Y, StrItem, StrQty, H, B,BOMText1;
        String strSize1, strSeatringmatl1, strPlugmatl1, strMaterial1, strRating1, strPortSize1, strFlowChar1, strPackingMaterial1, strActuatorSize1, strTrimStyle1, strShutOff1, strBodyOptions1, strActuatorOptions1, strActuatorType1, StrMaxCv;
        String[] myStr3 = new String[30];
        public Frm_GetBOMNO()
        {
            InitializeComponent();

        }

        public void Btn_OpenFile_Click(object sender, EventArgs e)
        {
           /*static int BOMlength, H, B, Y, L, C, T, K, P, M, Q, i, j, N, Totalpage, TotalpageG;*/
            String wdpath;
         
            /*object oMissing = System.Reflection.Missing.Value;*/
            /*Word.Application WdApp;*/
            if (folderBrowserDialog_NewBOM.ShowDialog() == DialogResult.OK)
            {
                wdpath = folderBrowserDialog_NewBOM.SelectedPath;
                OpenFileDialog_NewBOM.InitialDirectory = wdpath;
                OpenFileDialog_NewBOM.Filter = "Word文档（*.doc;.docx)|*.doc;*.docx";
                OpenFileDialog_NewBOM.FilterIndex = 2;
                OpenFileDialog_NewBOM.RestoreDirectory = true;
               /* WdApp = new Word.Application();*/
                if (OpenFileDialog_NewBOM.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    WdApp = new Microsoft.Office.Interop.Word.Application();
                    WdDoc = WdApp.Documents.Open(OpenFileDialog_NewBOM.FileName);
                    WdApp.Visible = true;
                    WdRange = WdDoc.Range();
                    T = WdRange.Tables.Count;
                    /*Totalpage = WdRange.Information[Word.WdInformation.wdNumberOfPagesInDocument]();*/
                    /*Totalpage = WdDoc.ComputeStatistics(Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages, ref oMissing);*/
                    Totalpage = WdRange.Information[Word.WdInformation.wdNumberOfPagesInDocument];
                    N = Totalpage;
                    M = 1;
                    Find_();
                }
            }
        }
        public void Find_()
        {
            String strSize, strSeatringmat, strPlugmatl, strMaterial, strRating, strPortSize, strFlowChar, strPackingMaterial, strActuatorSize, strTrimStyle, strShutOff, strBodyOptions, strActuatorOptions, strActuatorType, StrTags;
            /* String  ProductName, Findtex, S, Y, StrItem, StrQty,H,B;*/

            int W = 1, k = 1, U = 3;
            bool R, F, N;
            String[] myStr1 = { "Size And Type", "Design Temp", "Design Press", "End Connect/In/Out", "End Connect/In/Out", "Seat Ring Matl", "VALVE PLUG", "Balance", "Shutoff Class",
        "Port Size", "Characteristic", "Stem Material", "Stem Size", "Bonnet Style", "Packing", "Bolt, Bonnet", "Type/Size", "Travel", "To Actuator", "Fails Valve", "Handwheel", "Max Rated Cv", "Item", "Qty", "Tags"};
            String[] myStr2 = new String[30]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", };
            String[] myStr3 = new String[30] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", };
            int TotalpageG, a, i, L, C;
            Word.Document GDoc;
         /*Word.Document WdDoc8*/;
            Word.Range GDocRange, WdRangeG;
            Word.Application WdApp = new Microsoft.Office.Interop.Word.Application();
            //Word.Document GDoc = new Word.Document();
            Word.Selection wdSelect;
            /*WdApp = new Microsoft.Office.Interop.Word.Application();*/
            GDoc = WdDoc;
            GDocRange = GDoc.Range();
            TotalpageG = GDocRange.Information[Word.WdInformation.wdNumberOfPagesInDocument];
            for (a = 1; a < TotalpageG; a++)
            {
                for (i = 0; i <= 24; i++)
                {
                    Findtex = myStr1[i];
                    if (i < 22)
                    {
                        if (a == TotalpageG)
                        {
                            WdRangeG = GDocRange.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, a);
                        }
                        else
                        {
                            WdRangeG = GDoc.Range(GDoc.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, a).Start,
                         GDoc.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, a + 1).Start);
                        }
                        WdRangeG.Select();
                        wdSelect = WdApp.Selection;
                        WdRangeG.Find.ClearFormatting();
                        WdRangeG.Find.MatchWholeWord = true;
                        WdRangeG.Find.MatchCase = false;
                        WdRangeG.Find.Format = true;
                        WdRangeG.Find.Forward = false;
                        F = WdRangeG.Find.Execute(Findtex);
                        if (F == true)
                        {
                            L = WdRangeG.Information[Word.WdInformation.wdEndOfRangeRowNumber];
                            C = WdRangeG.Information[Word.WdInformation.wdEndOfRangeColumnNumber];
                            if (i == 4 || i == 6)
                            {
                                S = WdRangeG.Tables[1].Cell(L + 1, C + 1).Range.Text;
                            }
                            else
                            {
                                S = WdRangeG.Tables[1].Cell(L, C + 1).Range.Text;
                            }
                            myStr2[i] = S.Replace("\r\a", "").Trim();/* Chr(13)在C# 对应“\r”(enter key)， Chr"\n"(huan hang), myStr2(i) = Trim(Replace(S, Chr(13) & ChrW(&H7), ""))*/
                            strSize = myStr2[0].Replace("5100", "").Trim();
                            //strRating = myStr2[3].Substring(0, 5);
                            if(myStr2[3]==!) strRating = myStr2[3].Substring(5);

                            //strRating = myStr2[3].Substring(5);
                            strMaterial = myStr2[4].Substring(3);
                            strSeatringmat = myStr2[5];
                            strPlugmatl = myStr2[6]; strTrimStyle = myStr2[7]; strShutOff = myStr2[8]; strPortSize = myStr2[9]; strFlowChar = myStr2[10];
                            strBodyOptions = myStr2[13]; strPackingMaterial = myStr2[14];
                            strActuatorSize = myStr2[16].Substring(0, 3) + "," + myStr2[17].Substring(0, 2) + "," + myStr2[19].Substring(0, 5);
                            StrMaxCv = myStr2[21];
                        }
                    }
                    else
                    {
                        if (a == TotalpageG)
                        {
                            WdRangeG = GDocRange.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, a);
                        }
                        else
                        {
                            WdRangeG = GDoc.Range(GDoc.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, a).Start,
                         GDoc.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, a + 1).Start);
                        }
                        WdRangeG.Select();
                        wdSelect = WdApp.Selection;
                        WdRangeG.Find.ClearFormatting();
                        WdRangeG.Find.MatchWholeWord = true;
                        WdRangeG.Find.MatchCase = false;
                        WdRangeG.Find.Format = true;
                        WdRangeG.Find.Forward = false;
                        F = WdRangeG.Find.Execute(Findtex);
                        if (F == true)
                        {
                            L = WdRangeG.Information[Word.WdInformation.wdEndOfRangeRowNumber];
                            C = WdRangeG.Information[Word.WdInformation.wdEndOfRangeColumnNumber];
                            S = WdRangeG.Tables[1].Cell(L, C).Range.Text;
                        }
                        myStr2[i] = S.Replace("\n\a", "").Trim();
                        /*Replace("\n", "").Trim();/* Chr(13)在C# 对应“\r”， Chr"\n", myStr2(i) = Trim(Replace(S, Chr(13) & ChrW(&H7), ""))*/
                        StrItem = myStr2[22].Replace("Item", "");
                        StrQty = myStr2[23].Replace("Qty:", "");
                        StrTags = myStr2[24].Replace("Tags:", "");
                        H = StrItem;
                        B = StrQty;
                        Y = StrTags;

                    }
                        }
            }
        }
        public void BOMText()
        {
           /* String BOMText1,H,Y,B;*/
            int intRow1=1;
            switch (strSize1)
            {
                case "NPS 1": myStr3[0] = "1"; break;
                case "NPS 2": myStr3[0] = "2"; break;
                case "NPS 3": myStr3[0] = "3"; break;
                case "NPS 4": myStr3[0] = "4"; break;
                case "NPS 1 1/2": myStr3[0] = "5"; break;
                case "NPS 3/4": myStr3[0] = "6"; break;
                case "NPS 1/2": myStr3[0] = "7"; break;
                case "DN 25": myStr3[0] = "A"; break;
                case "DN 40": myStr3[0] = "E"; break;
                case "DN 50": myStr3[0] = "B"; break;
                case "DN 80": myStr3[0] = "C"; break;
                case "DN 100": myStr3[0] = "D"; break;
                case "DN 20": myStr3[0] = "F"; break;
                case "DN 15": myStr3[0] = "H"; break;
                case "DN 150": myStr3[0] = "G"; break;
            }
            switch (strMaterial1)
            {
                case "WCC": myStr3[1] = "W"; break;
                case "CF8": myStr3[1] = "S"; break;
                case "CF3": myStr3[1] = "T"; break;
                case "LCC": myStr3[1] = "L"; break;
            }
            switch (strRating1)
            {
                case "CL150": myStr3[2] = "1"; break;
                case "CL300": myStr3[2] = "2"; break;
                case "PN16": myStr3[2] = "4"; break;
                case "PN 25": myStr3[2] = "5"; break;
            }
            switch (strSize1)
            {
                case "NPS 1/2":
                case "DN 15":
                    {
                        switch (strPortSize1)
                        {
                            case "9.5 mm":
                                {
                                    if (StrMaxCv == "3.338")
                                        myStr3[3] = "1";
                                    else
                                        myStr3[3] = "2";
                                }; break;
                            case "4.8 mm":
                                {
                                    if (StrMaxCv == "0.785")
                                        myStr3[3] = "3";
                                    if (StrMaxCv == "0.294")
                                        myStr3[3] = "4";
                                    if (StrMaxCv == "0.139")
                                        myStr3[3] = "5";
                                    if (StrMaxCv == "0.0389")
                                        myStr3[3] = "6";
                                }; break;
                        }
                    }; break;
                case "NPS 3/4":
                case "DN 20":
                    {
                        switch (strPortSize1)
                        {
                            case "14 mm":
                                myStr3[3] = "1"; break;
                            case "9.5 mm":
                                {
                                    if (StrMaxCv == "3.338")
                                        myStr3[3] = "2";
                                    else
                                        myStr3[3] = "3";
                                }; break;
                            case "4.8 mm":
                                {
                                    if (StrMaxCv == "0.785")
                                        myStr3[3] = "4";
                                    if (StrMaxCv == "0.294")
                                        myStr3[3] = "5";
                                    if (StrMaxCv == "0.139")
                                        myStr3[3] = "6";
                                    if (StrMaxCv == "0.0.0389")
                                        myStr3[3] = "7";
                                }; break;
                        };
                    }; break;
                case "NPS 1":
                case "DN 25":
                    {
                        switch (strPortSize1)
                        {
                            case "22 mm": myStr3[3] = "1"; break;
                            case "14 mm": myStr3[3] = "2"; break;
                            case "9.5 mm":
                                {
                                    if (StrMaxCv == "3.338")
                                        myStr3[3] = "3";
                                    else
                                        myStr3[3] = "4";
                                }; break;
                            case "4.8 mm":
                                {
                                    if (StrMaxCv == "0.785")
                                        myStr3[3] = "5";
                                    if (StrMaxCv == "0.294")
                                        myStr3[3] = "6";
                                    if (StrMaxCv == "0.139")
                                        myStr3[3] = "7";
                                    if (StrMaxCv == "0.0.0389")
                                        myStr3[3] = "8";
                                }; ; break;
                        }
                    }; break;

                case "NPS 1-1/2":
                case "DN 40":
                    {
                        switch (strPortSize1)
                        {
                            case "36 mm": myStr3[3] = "1"; break;
                            case "22 mm": myStr3[3] = "2"; break;
                            case "14 mm": myStr3[3] = "3"; break;
                        }
                    }; break;
                case "NPS 2":
                case "DN 50":
                    {
                        switch (strPortSize1)
                        {
                            case "46 mm": myStr3[3] = "1"; break;
                            case "36 mm": myStr3[3] = "2"; break;
                            case "22 mm": myStr3[3] = "3"; break;
                        }
                    }; break;
                case "NPS 3":
                case "DN 80":
                    {
                        switch (strPortSize1)
                        {
                            case "70 mm": myStr3[3] = "1"; break;
                            case "46 mm": myStr3[3] = "2"; break;
                            case "36 mm": myStr3[3] = "3"; break;
                        }
                    }; break;
                case "NPS 4":
                case "DN 100":
                    {
                        switch (strPortSize1)
                        {
                            case "90 mm": myStr3[3] = "1"; break;
                            case "70 mm": myStr3[3] = "2"; break;
                            case "46 mm": myStr3[3] = "3"; break;
                        }
                    }; break;
                case "NPS 6":
                case "DN 150":
                    {
                        switch (strPortSize1)
                        {
                            case "136 mm": myStr3[3] = "1"; break;
                            case "90 mm": myStr3[3] = "2"; break;
                            case "70 mm": myStr3[3] = "3"; break;
                        }
                    }; break;
            }
            switch (strTrimStyle1)
            {
                case "Unbalanced":
                    {
                        if (strFlowChar1 == "Linear")
                            myStr3[4] = "L";
                        else
                            myStr3[4] = "E";
                    }; break;
                case "Balanced":
                    {
                        if (strFlowChar1 == "Linear")
                            myStr3[4] = "X";
                        else
                            myStr3[4] = "D";
                    }; break;
            }
            switch (strSeatringmatl1)
            {
                case "CF8M SST":
                case "316 SST":
                    {
                        if (strShutOff1 == "ANSI CL IV")
                            myStr3[5] = "1";
                        else
                            myStr3[5] = "4";
                    }; break;
                case "CF8M SST/CoCr-A Seat":
                case "316 SST/CoCr-A Seat":
                case "CF8M SST/CoCr-A Seat/Guide":
                    {
                        if (strShutOff1 == "ANSI CL IV")
                            myStr3[5] = "2";
                        else
                            myStr3[5] = "5";
                    }; break;
                case "CF3M SST":
                case "316L SST":
                    {
                        if (strShutOff1 == "ANSI CL IV")
                            myStr3[5] = "6";
                        else
                            myStr3[5] = "9";
                    }; break;
                case "CF3M SST/CoCr-A Seat":
                case "316L SST/CoCr-A Seat":
                case "CF3M SST/CoCr-A Seat/Guide":
                    {
                        if (strShutOff1 == "ANSI CL IV")
                            myStr3[5] = "8";
                        else
                            myStr3[5] = "B";
                    }; break;
            }
            switch (strPackingMaterial1)
            {
                case "PTFE": myStr3[6] = "P"; break;
                case "Live Loaded PTFE": myStr3[6] = "P"; break;
                case "Graphite ULF": myStr3[6] = "U"; break;
            }

            switch (strActuatorSize1)
            {
                case "225,20,(ATO)": myStr3[7] = "A"; break;
                case "225,20,(ATC)": myStr3[7] = "D"; break;
                case "750,20,(ATO)": myStr3[7] = "B"; break;
                case "750,20,(ATC)": myStr3[7] = "E"; break;
                case "750,40,(ATO)": myStr3[7] = "C"; break;
                case "750,40,(ATC)": myStr3[7] = "F"; break;
            }
            myStr3[8] = "N";
            switch (strBodyOptions1)
            {
                case "Standard": myStr3[9] = ""; break;
                case "Extension": myStr3[7] = "4"; break;/*区分新延长和GX延长结构，低温延长用GX结构*/
                case "Bellows": myStr3[7] = "3"; break;
            }
            if (myStr3[9] == "" && myStr3[8] == "N")
                BOMText1 = "5100-" + myStr3[0] + myStr3[1] + myStr3[2] + myStr3[3] + myStr3[4] + myStr3[5] + myStr3[6] + myStr3[7];
            dataGridView1.Rows.Add();
            dataGridView1.Rows[intRow1].Cells[0].Value = H;/*item*/
            dataGridView1.Rows[intRow1].Cells[1].Value = Y;/*Tags*/
            dataGridView1.Rows[intRow1].Cells[2].Value = BOMText1;/*BOM Number*/
            dataGridView1.Rows[intRow1].Cells[3].Value = B;
            intRow1 = intRow1++;
        }
    }
    }
  
    
