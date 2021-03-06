﻿using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace SqliteData {
    class Program {
        static void Main (string[] args) {
            string path = @"z:/bom5100.db";
            SQLiteConnection cn = new SQLiteConnection ("data source =" + path);
            cn.Open ();

            SQLiteCommand cmd = new SQLiteCommand ();
            cmd.Connection = cn;

            Console.WriteLine ("--Start--");
            string newBom="";

            for (int row = 1; row < 63009; row++) {
                // try {
                    cmd.CommandText = "SELECT * FROM Bom WHERE rowid = " + row; //get row data by rows
                    SQLiteDataReader sr = cmd.ExecuteReader ();
                    while (sr.Read ()) {
                        // Console.WriteLine ($" {sr.GetString(1)}"); //shown row 1 column 1 and column 2 data, please be aware that the data type must be string, if the data type in database is int, then use GetInt32() instead.

                        string bomNumber = sr.GetString (1).Trim();
                        if (bomNumber.Length < 10) {
                            bomNumber = bomNumber + "000000";                            
                        }
                        string Number1 = bomNumber.Substring (0, 1);
                        string Number2 = bomNumber.Substring (1, 1);
                        string Number3 = bomNumber.Substring (2, 1);
                        string Number4 = bomNumber.Substring (3, 1);
                        string Number5 = bomNumber.Substring (4, 1);
                        string Number6 = bomNumber.Substring (5, 1);
                        string Number7 = bomNumber.Substring (6, 1);
                        string Number8 = bomNumber.Substring (7, 1);
                        string Number9 = bomNumber.Substring (8, 1);
                        string Number10 = bomNumber.Substring (9, 1);
           

                        // Console.WriteLine(firstNumber);
                        // Console.WriteLine(bomNumber + "," + Number1 + "," + Number2 + "," + Number3 + "," + Number4 + "," + Number5 + "," + Number6 + "," + Number7 + "," + Number8 + "," + Number9 + "," + Number10 + "," + Number11);

                        string valveSize = "NA";
                        string valveBodyMaterial = "NA";
                        string valveRating = "NA";
                        string valvePort = "NA";
                        double maxCv = 0;
                        string balanced = "NA";
                        string flowChar = "NA";
                        string seatRingMaterial = "NA";
                        string shutOff = "NA";
                        string packing = "NA";
                        string actuatorType = "NA";
                        string actuatorSize = "NA";
                        string actuatorATO = "NA";
                        string air = "NA";
                        string mounting = "NA";
                        string bonnet = "NA";

                        switch (Number1) {
                            case "1":
                                valveSize = "NPS 1";
                                break;
                            case "2":
                                valveSize = "NPS 2";
                                break;
                            case "3":
                                valveSize = "NPS 3";
                                break;
                            case "4":
                                valveSize = "NPS 4";
                                break;
                            case "5":
                                valveSize = "NPS 1 1/2";
                                break;
                            case "6":
                                valveSize = "NPS 3/4";
                                break;
                            case "7":
                                valveSize = "NPS 1/2";
                                break;
                            case "A":
                                valveSize = "DN 25";
                                break;
                            case "E":
                                valveSize = "DN 40";
                                break;
                            case "B":
                                valveSize = "DN 50";
                                break;
                            case "C":
                                valveSize = "DN 80";
                                break;
                            case "D":
                                valveSize = "DN 100";
                                break;
                            case "F":
                                valveSize = "DN 20";
                                break;
                            case "H":
                                valveSize = "DN 15";
                                break;
                            case "G":
                                valveSize = "DN 150";
                                break;
                            default:
                                valveSize = "NA";
                                break;
                        }

                        switch (Number2) {
                            case "W":
                                valveBodyMaterial = "WCC";
                                break;
                            case "S":
                                valveBodyMaterial = "CF8";
                                break;
                            case "T":
                                valveBodyMaterial = "CF3";
                                break;
                            case "L":
                                valveBodyMaterial = "LCC";
                                break;
                            default:
                                valveBodyMaterial = "NA";
                                maxCv = 0;
                                break;
                        }

                        switch (Number3) {
                            case "1":
                                valveRating = "ANSL CL 150";
                                break;
                            case "2":
                                valveRating = "ANSL CL 300";
                                break;
                            case "4":
                                valveRating = "PN 16";
                                break;
                            case "5":
                                valveRating = "PN 25";
                                break;
                            default:
                                valveRating = "NA";
                                maxCv = 0;
                                break;
                        }

                        switch (valveSize) {
                            case "NPS 1/2":
                            case "DN 15":
                                {
                                    switch (Number4) {
                                        case "1":
                                            valvePort = "9.5";
                                            maxCv = 3.338;
                                            break;
                                        case "2":
                                            valvePort = "9.5";
                                            maxCv = 0;
                                            break;
                                        case "3":
                                            valvePort = "4.8(4)";
                                            maxCv = 0.785;
                                            break;
                                        case "4":
                                            valvePort = "4.8(3)";
                                            maxCv = 0.294;
                                            break;
                                        case "5":
                                            valvePort = "4.8(2)";
                                            maxCv = 0.139;
                                            break;
                                        case "6":
                                            valvePort = "4.8(1)";
                                            maxCv = 0.0389;
                                            break;
                                        default:
                                            valvePort = "NA";
                                            maxCv = 0;
                                            break;
                                    }
                                }
                                break;

                            case "NPS 3/4":
                            case "DN 20":
                                {
                                    switch (Number4) {
                                        case "1":
                                            valvePort = "14";
                                            maxCv = 0;
                                            break;
                                        case "2":
                                            valvePort = "9.5";
                                            maxCv = 3.338;
                                            break;
                                        case "3":
                                            valvePort = "9.5";
                                            maxCv = 0;
                                            break;
                                        case "4":
                                            valvePort = "4.8(4)";
                                            maxCv = 0.785;
                                            break;
                                        case "5":
                                            valvePort = "4.8(3)";
                                            maxCv = 0.294;
                                            break;
                                        case "6":
                                            valvePort = "4.8(2)";
                                            maxCv = 0.139;
                                            break;
                                        case "7":
                                            valvePort = "4.8(1)";
                                            maxCv = 0.0389;
                                            break;
                                        default:
                                            valvePort = "NA";
                                            maxCv = 0;
                                            break;

                                    }
                                }
                                break;

                            case "NPS 1":
                            case "DN 25":
                                {
                                    switch (Number4) {
                                        case "1":
                                            valvePort = "22";
                                            maxCv = 0;
                                            break;
                                        case "2":
                                            valvePort = "14";
                                            maxCv = 0;
                                            break;
                                        case "3":
                                            valvePort = "9.5";
                                            maxCv = 3.338;
                                            break;
                                        case "4":
                                            valvePort = "9.5";
                                            maxCv = 0;
                                            break;
                                        case "5":
                                            valvePort = "4.8(4)";
                                            maxCv = 0.785;
                                            break;
                                        case "6":
                                            valvePort = "4.8(3)";
                                            maxCv = 0.294;
                                            break;
                                        case "7":
                                            valvePort = "4.8(2)";
                                            maxCv = 0.139;
                                            break;
                                        case "8":
                                            valvePort = "4.8(1)";
                                            maxCv = 0.0389;
                                            break;
                                        default:
                                            valvePort = "NA";
                                            maxCv = 0;
                                            break;

                                    }
                                }
                                break;
                            case "NPS 1-1/2":
                            case "DN 40":
                                {
                                    switch (Number4) {
                                        case "1":
                                            valvePort = "36";
                                            maxCv = 0;
                                            break;
                                        case "2":
                                            valvePort = "22";
                                            maxCv = 0;
                                            break;
                                        case "3":
                                            valvePort = "14";
                                            maxCv = 0;
                                            break;
                                        default:
                                            valvePort = "NA";
                                            maxCv = 0;
                                            break;
                                    }
                                };
                                break;
                            case "NPS 2":
                            case "DN 50":
                                {
                                    switch (Number4) {
                                        case "1":
                                            valvePort = "46";
                                            maxCv = 0;
                                            break;
                                        case "2":
                                            valvePort = "36";
                                            maxCv = 0;
                                            break;
                                        case "3":
                                            valvePort = "22";
                                            maxCv = 0;
                                            break;
                                        default:
                                            valvePort = "NA";
                                            maxCv = 0;
                                            break;
                                    }
                                };
                                break;
                            case "NPS 3":
                            case "DN 80":
                                {
                                    switch (Number4) {
                                        case "1":
                                            valvePort = "70";
                                            maxCv = 0;
                                            break;
                                        case "2":
                                            valvePort = "46";
                                            maxCv = 0;
                                            break;
                                        case "3":
                                            valvePort = "36";
                                            maxCv = 0;
                                            break;
                                        default:
                                            valvePort = "NA";
                                            maxCv = 0;
                                            break;
                                    }
                                };
                                break;
                            case "NPS 4":
                            case "DN 100":
                                {
                                    switch (Number4) {
                                        case "1":
                                            valvePort = "90";
                                            maxCv = 0;
                                            break;
                                        case "2":
                                            valvePort = "70";
                                            maxCv = 0;
                                            break;
                                        case "3":
                                            valvePort = "46";
                                            maxCv = 0;
                                            break;
                                        default:
                                            valvePort = "NA";
                                            maxCv = 0;
                                            break;
                                    }
                                };
                                break;
                            case "NPS 6":
                            case "DN 150":
                                {
                                    switch (Number4) {
                                        case "1":
                                            valvePort = "136";
                                            maxCv = 0;
                                            break;
                                        case "2":
                                            valvePort = "90";
                                            maxCv = 0;
                                            break;
                                        case "3":
                                            valvePort = "70";
                                            maxCv = 0;
                                            break;
                                        default:
                                            valvePort = "NA";
                                            maxCv = 0;
                                            break;
                                    }
                                };
                                break;
                            default:
                                valvePort = "NA";
                                maxCv = 0;
                                break;
                        }

                        switch (Number5) {
                            case "L":
                                balanced = "Unbalanced";
                                flowChar = "Linear";
                                break;
                            case "E":
                                balanced = "Unbalanced";
                                flowChar = "EqualPcentage";
                                break;
                            case "X":
                                balanced = "Balanced";
                                flowChar = "Linear";
                                break;
                            case "D":
                                balanced = "Balanced";
                                flowChar = "EqualPcentage";
                                break;
                            default:
                                balanced = "NA";
                                flowChar = "NA";
                                break;
                        }

                        switch (Number6) {
                            case "1":
                                seatRingMaterial = "316 SST";
                                shutOff = "ANSI CL IV";
                                break;
                            case "2":
                                seatRingMaterial = "316 SST/CoCr-A";
                                shutOff = "ANSI CL IV";
                                break;
                            case "3":
                                seatRingMaterial = "316 SST/PTFE";
                                shutOff = "ANSI CL VI";
                                break;
                            case "4":
                                seatRingMaterial = "316 SST";
                                shutOff = "ANSI CL V";
                                break;
                            case "5":
                                seatRingMaterial = "316 SST/CoCr-A";
                                shutOff = "ANSI CL V";
                                break;
                            case "6":
                                seatRingMaterial = "316L SST";
                                shutOff = "ANSI CL IV";
                                break;
                            case "7":
                                seatRingMaterial = "316L SST";
                                shutOff = "ANSI CL VI";
                                break;
                            case "8":
                                seatRingMaterial = "316L SST/CoCr-A";
                                shutOff = "ANSI CL IV";
                                break;
                            case "9":
                                seatRingMaterial = "316L SST";
                                shutOff = "ANSI CL V";
                                break;
                            case "X":
                                seatRingMaterial = "304L SST";
                                shutOff = "ANSI CL IV";
                                break;
                            case "A":
                                seatRingMaterial = "CF3M SST/PTFE";
                                shutOff = "ANSI CL VI";
                                break;
                            case "B":
                                seatRingMaterial = "316L SST";
                                shutOff = "ANSI CL V";
                                break;
                            case "C":
                                seatRingMaterial = "316 SST";
                                shutOff = "ANSI CL VI";
                                break;
                            case "D":
                                seatRingMaterial = "316L SST";
                                shutOff = "ANSI CL VI";
                                break;
                            case "E":
                                seatRingMaterial = "304L SST";
                                shutOff = "ANSI CL IV";
                                break;
                            case "F":
                                seatRingMaterial = "304L SST";
                                shutOff = "ANSI CL IV";
                                break;
                            case "J":
                                seatRingMaterial = "304L SST/CoCr-A";
                                shutOff = "ANSI CL V";
                                break;
                            default:
                                seatRingMaterial = "NA";
                                break;
                        }

                        switch (Number7) {
                            case "P":
                                packing = "PTFE";
                                break;
                            case "U":
                                packing = "Graphite ULF";
                                break;
                            default:
                                packing = "NA";
                                break;
                        }

                        switch (Number8) {
                            case "A":
                                actuatorType = "225";
                                actuatorType = "20";
                                actuatorATO = "ATO";
                                break;
                            case "D":
                                actuatorType = "225";
                                actuatorType = "20";
                                actuatorATO = "ATC";
                                break;
                            case "B":
                                actuatorType = "750";
                                actuatorType = "20";
                                actuatorATO = "ATO";
                                break;
                            case "E":
                                actuatorType = "750";
                                actuatorType = "20";
                                actuatorATO = "ATC";
                                break;
                            case "C":
                                actuatorType = "750";
                                actuatorType = "40";
                                actuatorATO = "ATO";
                                break;
                            case "F":
                                actuatorType = "750";
                                actuatorType = "40";
                                actuatorATO = "ATC";
                                break;
                            default:
                                actuatorType = "NA";
                                actuatorType = "NA";
                                actuatorATO = "NA";
                                break;
                        }

                        switch (Number9) {
                            case "L":
                                air = "2-3 Barg (29-43 Psig)";
                                mounting = "NA";
                                break;
                            case "M":
                                air = "3-4 Barg (43-58 Psig)";
                                mounting = "NA";
                                break;
                            case "H":
                                air = "4-6 Barg (58-85 Psig)";
                                mounting = "Side Mounted";
                                break;
                            case "T":
                                air = "4-6 Barg (58-85 Psig)";
                                mounting = "Top Mounted";
                                break;
                            case "N":
                                air = "4-6 Barg (58-85 Psig)";
                                mounting = "NA";
                                break;
                            default:
                                air = "4-6 Barg (58-85 Psig)";
                                mounting = "NA";
                                break;
                        }

                        switch (Number10) {
                            case "1":
                                bonnet = "High Temp Extenstion";
                                break;
                            case "2":
                                bonnet = "Low Temp Extenstion";
                                break;
                            case "3":
                                bonnet = "Bellows";
                                break;
                            case "4":
                                bonnet = "New High Temp";
                                break;
                            default:
                                bonnet = "Plain";
                                break;
                        }
                        // Console.WriteLine (row);
                        newBom += " \r\n " +row + "," + bomNumber+"," + valveSize + "," + valveBodyMaterial + "," + valveRating + "," + valvePort + "," + maxCv + "," + balanced + "," + flowChar + "," + seatRingMaterial + "," + shutOff + "," + packing + "," + actuatorType + "," + actuatorSize + "," + actuatorATO + "," + air + "," + mounting + "," + bonnet;
                    }
                    sr.Close ();
                // } catch {
                //     Console.WriteLine ("Error:" + row);
                // }
            }
            cn.Close ();
            Console.WriteLine ("--End--");
            File.WriteAllText (@"z:/newBom.txt", newBom);

        }
    }
}