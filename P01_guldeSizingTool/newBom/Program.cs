using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace SqliteData
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"z:/bom5100.db";
            SQLiteConnection cn = new SQLiteConnection("data source =" + path);
            cn.Open();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cn;

            Console.WriteLine("--Start--");
            System.DateTime startTime = System.DateTime.Now; // 开始计时
            Console.WriteLine("start time: " + startTime.ToString());

            string bomNumber = "";

            for (int row = 1; row < 19000; row++)
            {
                // try {
                cmd.CommandText = "SELECT * FROM finalBom WHERE rowid = " + row; //get row data by rows
                SQLiteDataReader sr = cmd.ExecuteReader();
                while (sr.Read())
                {
                    string valveSize = sr.GetString(5).Trim();
                    string valveClass = sr.GetString(4).Trim();
                    string bodyMaterial = sr.GetString(10).Trim();
                    string restrictedTrim = sr.GetString(14).Trim();
                    string seatRing = sr.GetString(19).Trim();
                    string balance = sr.GetString(22).Trim();
                    string shutOff = sr.GetString(23).Trim();
                    string portSize = sr.GetString(24);
                    string trimChar = sr.GetString(25);
                    string bonnet = sr.GetString(28);
                    string packing = sr.GetString(30);
                    string act = sr.GetInt32(36) + "-" + sr.GetInt32(37) + "-" + sr.GetString(42);
                    // Console.WriteLine (row + ": " + act);

                    string item1 = "5100-";
                    string item2 = "0"; //valve size
                    string item3 = "0"; //body material
                    string item4 = "0"; // rating 
                    string item5 = "0"; //port
                    string item6 = "0"; //trim char
                    string item7 = "0"; //trim material
                    string item8 = "0"; //packing
                    string item9 = "0"; //ACT
                    string item10 = "N"; //Air and mounting 
                    string item11 = ""; //bonnet
                    // 4.8 9º30'

                    #region item2
                    if (valveClass == "150" || valveClass == "300")
                    {
                        switch (valveSize)
                        {
                            case "NPS 1":
                                item2 = "1";
                                break;
                            case "NPS 2":
                                item2 = "2";
                                break;
                            case "NPS 3":
                                item2 = "3";
                                break;
                            case "NPS 4":
                                item2 = "4";
                                break;
                            case "NPS 1 1/2":
                                item2 = "5";
                                break;
                            case "NPS 3/4":
                                item2 = "6";
                                break;
                            case "NPS 1/2":
                                item2 = "7";
                                break;
                            case "NPS 6":
                                item2 = "8";
                                break;
                            default:
                                item2 = "0";
                                break;
                        }
                    }
                    else if (valveClass == "PN10-16" || valveClass == "PN25-40")
                    {
                        switch (valveSize)
                        {
                            case "NPS 1":
                                item2 = "A";
                                break;
                            case "NPS 2":
                                item2 = "B";
                                break;
                            case "NPS 3":
                                item2 = "C";
                                break;
                            case "NPS 4":
                                item2 = "D";
                                break;
                            case "NPS 1 1/2":
                                item2 = "E";
                                break;
                            case "NPS 3/4":
                                item2 = "H";
                                break;
                            case "NPS 1/2":
                                item2 = "F";
                                break;
                            case "NPS 6":
                                item2 = "G";
                                break;
                            default:
                                item2 = "0";
                                break;
                        }
                    }
                    #endregion 

                    #region item3
                    switch (bodyMaterial)
                    {
                        case "WCC":
                            item3 = "W";
                            break;
                        case "LCC":
                            item3 = "L";
                            break;
                        case "CF8M":
                            item3 = "S";
                            break;
                        case "CF3M":
                            item3 = "T";
                            break;
                        default:
                            item3 = "0";
                            break;
                    }
                    #endregion

                    #region item4
                    switch (valveClass)
                    {
                        case "150":
                            item4 = "1";
                            break;
                        case "300":
                            item4 = "2";
                            break;
                        case "PN10-16":
                            item4 = "4";
                            break;
                        case "PN25-40":
                            item4 = "5";
                            break;
                        default:
                            item4 = "0";
                            break;
                    }
                    #endregion

                    #region item5
                    switch (item2)
                    {
                        case "7":
                        case "F":
                            {
                                switch (portSize)
                                {
                                    case "9.5":
                                        {
                                            if (restrictedTrim == "Unrestricted Trim")
                                            {
                                                item5 = "1";
                                            }
                                            else
                                            {
                                                item5 = "2";
                                            }
                                        };
                                        break;
                                    case "4.8 9º30'":
                                        item5 = "3";
                                        break;
                                    case "4.8 4º39'":
                                        item5 = "4";
                                        break;
                                    case "4.8 2º15'":
                                        item5 = "5";
                                        break;
                                    case "4.8 1º8'":
                                        item5 = "6";
                                        break;
                                    default:
                                        item5 = "0";
                                        break;
                                }

                            };
                            break;

                        case "6":
                        case "H":
                            {
                                switch (portSize)
                                {
                                    case "14":
                                        item5 = "1";
                                        break;
                                    case "9.5":
                                        {
                                            if (restrictedTrim == "Unrestricted Trim")
                                            {
                                                item5 = "2";
                                            }
                                            else
                                            {
                                                item5 = "3";
                                            }
                                        };
                                        break;
                                    case "4.8 9º30'":
                                        item5 = "4";
                                        break;
                                    case "4.8 4º39'":
                                        item5 = "5";
                                        break;
                                    case "4.8 2º15'":
                                        item5 = "6";
                                        break;
                                    case "4.8 1º8'":
                                        item5 = "7";
                                        break;
                                    default:
                                        item5 = "0";
                                        break;
                                }

                            };
                            break;

                        case "1":
                        case "A":
                            {
                                switch (portSize)
                                {
                                    case "22":
                                        item5 = "1";
                                        break;
                                    case "14":
                                        item5 = "2";
                                        break;
                                    case "9.5":
                                        {
                                            if (restrictedTrim == "Unrestricted Trim")
                                            {
                                                item5 = "3";
                                            }
                                            else
                                            {
                                                item5 = "4";
                                            }
                                        };
                                        break;
                                    case "4.8 9º30'":
                                        item5 = "5";
                                        break;
                                    case "4.8 4º39'":
                                        item5 = "6";
                                        break;
                                    case "4.8 2º15'":
                                        item5 = "7";
                                        break;
                                    case "4.8 1º8'":
                                        item5 = "8";
                                        break;
                                    default:
                                        item5 = "0";
                                        break;
                                }

                            };
                            break;

                        case "5":
                        case "E":
                            {
                                switch (portSize)
                                {
                                    case "36":
                                        item5 = "1";
                                        break;
                                    case "22":
                                        item5 = "2";
                                        break;
                                    case "14":
                                        item5 = "3";
                                        break;
                                    default:
                                        item5 = "0";
                                        break;
                                }

                            };
                            break;

                        case "2":
                        case "B":
                            {
                                switch (portSize)
                                {
                                    case "46":
                                        item5 = "1";
                                        break;
                                    case "36":
                                        item5 = "2";
                                        break;
                                    case "22":
                                        item5 = "3";
                                        break;
                                    default:
                                        item5 = "0";
                                        break;
                                }

                            };
                            break;

                        case "3":
                        case "C":
                            {
                                switch (portSize)
                                {
                                    case "70":
                                        item5 = "1";
                                        break;
                                    case "46":
                                        item5 = "2";
                                        break;
                                    case "36":
                                        item5 = "3";
                                        break;
                                    default:
                                        item5 = "0";
                                        break;
                                }

                            };
                            break;


                        case "4":
                        case "D":
                            {
                                switch (portSize)
                                {
                                    case "90":
                                        item5 = "1";
                                        break;
                                    case "70":
                                        item5 = "2";
                                        break;
                                    case "46":
                                        item5 = "3";
                                        break;
                                    default:
                                        item5 = "0";
                                        break;
                                }

                            };
                            break;


                        case "8":
                        case "G":
                            {
                                switch (portSize)
                                {
                                    case "90":
                                        item5 = "1";
                                        break;
                                    case "70":
                                        item5 = "2";
                                        break;
                                    case "46":
                                        item5 = "3";
                                        break;
                                    default:
                                        item5 = "0";
                                        break;
                                }

                            };
                            break;

                        default:
                            item5 = "0";
                            break;
                    }
                    #endregion


                    #region item6
                    if (balance == "Unbalanced" && trimChar == "Equal Percent")
                    {
                        item6 = "E";
                    }
                    else if (balance == "Unbalanced" && trimChar == "Linear")
                    {
                        item6 = "L";
                    }
                    else if (balance == "Balanced" && trimChar == "Equal Percent")
                    {
                        item6 = "D";
                    }
                    else if (balance == "Balanced" && trimChar == "Linear")
                    {
                        item6 = "X";
                    }
                    else if (trimChar == "Linear Whisper III A1")
                    {
                        item6 = "W";
                    }
                    else if (trimChar == "Linear Cavitrol III One Stage")
                    {
                        item6 = "C";
                    }
                    else
                    {
                        item6 = "0";
                    }
                    #endregion


                    #region item7
                    if (seatRing == "316 SST" && shutOff == "ANSI CL IV")
                    {
                        item7 = "1";
                    }
                    else if (seatRing == "316 SST/HF" && shutOff == "ANSI CL IV")
                    {
                        item7 = "2";
                    }
                    else if (seatRing == "CF8M/PTFE" && shutOff == "ANSI CL VI")
                    {
                        item7 = "3";
                    }
                    else if (seatRing == "316 SST" && shutOff == "ANSI CL V")
                    {
                        item7 = "4";
                    }
                    else if (seatRing == "316 SST/HF" && shutOff == "ANSI CL V")
                    {
                        item7 = "5";
                    }
                    else if (seatRing == "316L SST" && shutOff == "ANSI CL IV")
                    {
                        item7 = "6";
                    }
                    else if (seatRing == "316L SST/HF" && shutOff == "ANSI CL IV")
                    {
                        item7 = "8";
                    }
                    else if (seatRing == "316L SST" && shutOff == "ANSI CL V")
                    {
                        item7 = "9";
                    }
                    else if (seatRing == "CF3M/PTFEF" && shutOff == "ANSI CL VI")
                    {
                        item7 = "A";
                    }
                    else if (seatRing == "316L SST/HF" && shutOff == "ANSI CL V")
                    {
                        item7 = "B";
                    }
                    else if (seatRing == "316 SST" && shutOff == "ANSI CL VI")
                    {
                        item7 = "C";
                    }
                    else if (seatRing == "316L SST" && shutOff == "ANSI CL VI")
                    {
                        item7 = "D";
                    }
                    else
                    {
                        item7 = "0";
                    }
                    #endregion

                    #region item8
                    if (packing == "PTFE")
                    {
                        item8 = "P";
                    }
                    else if (packing == "Graphite ULF")
                    {
                        item8 = "U";
                    }
                    else
                    {
                        item8 = "0";
                    }
                    #endregion

                    #region item9
                    switch (act)
                    {
                        case "225-20-ATO": item9 = "A"; break;
                        case "750-20-ATO": item9 = "B"; break;
                        case "750-40-ATO": item9 = "C"; break;
                        case "225-20-ATC": item9 = "D"; break;
                        case "750-20-ATC": item9 = "E"; break;
                        case "750-40-ATC": item9 = "F"; break;
                        case "1200-60-ATO": item9 = "G"; break;
                        case "1200-60-ATC": item9 = "H"; break;
                        default: item9 = "0"; break;
                    }
                    #endregion

                    #region item10
                    item10 = "N";
                    #endregion

                    #region item11
                    switch (bonnet)
                    {
                        case "High Temp Extension": item11 = "4"; break;
                        case "Bellows": item11 = "3"; break;
                        case "Cryo Extension": item11 = "2"; break;
                        case "Plain": item11 = ""; break;
                        default: item11 = "";break;
                    }
                    #endregion

                    // Console.WriteLine(shutOff);
                    // Console.WriteLine(row + ": " + item1 + item2 + item3 + item4 + item5 + item6 + item7 + item8 + item9 + item10 + item11);

                    bomNumber+="\r\n"+row + "," + item1 + item2 + item3 + item4 + item5 + item6 + item7 + item8 + item9 + item10 + item11;
                }


                sr.Close();
            }
            // } catch {
            //     Console.WriteLine ("Error:" + row);
            // }
            cn.Close();


            System.DateTime endTime = System.DateTime.Now; // 结束计时
            Console.WriteLine("end time: " + endTime.ToString());
            System.TimeSpan ts = endTime - startTime;
            Console.WriteLine("program run time: " + ts.Milliseconds / 100 + " Seconds");

            Console.WriteLine("--End--");
            File.WriteAllText(@"z:/newBom.txt", bomNumber);

        }
    }
}
