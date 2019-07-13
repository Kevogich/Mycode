using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml;

namespace Rebuild5100Bom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------ Start -----");
            epplusCore eC = new epplusCore();
            eC.filePath = @"Z:\MyCode\P01_guldeSizingTool\5100Bom.xlsx";
            eC.workSheet = "Sheet1";

            for (int row = 1; row < 10; row++)
            {
                string bomNumber = eC.cv(row, 2); // 获取第二列的每一行的值，也就是B1, B2....
                if (bomNumber.Length < 10)
                {
                    bomNumber = bomNumber + "00000";
                }
                string Number1 = bomNumber.Substring(0, 1);
                string Number2 = bomNumber.Substring(1, 1);
                string Number3 = bomNumber.Substring(2, 1);
                string Number4 = bomNumber.Substring(3, 1);
                string Number5 = bomNumber.Substring(4, 1);
                string Number6 = bomNumber.Substring(5, 1);
                string Number7 = bomNumber.Substring(6, 1);
                string Number8 = bomNumber.Substring(7, 1);
                string Number9 = bomNumber.Substring(8, 1);
                string Number10 = bomNumber.Substring(9, 1);
                string Number11 = bomNumber.Substring(10, 1);

                // Console.WriteLine(firstNumber);
                Console.WriteLine(bomNumber + ":" + Number1 + ":" + Number2 + ":" + Number3 + ":" + Number4 + ":" + Number5 + ":" + Number6 + ":" + Number7 + ":" + Number8 + ":" + Number9 + ":" + Number10 + ":" + Number11);

                string valveSize;
                string valveBodySize;
                string valveRating;
                string valvePort;
                double maxCv;

                switch (Number1)
                {
                    case "1": valveSize = "NPS 1"; break;
                    case "2": valveSize = "NPS 2"; break;
                    case "3": valveSize = "NPS 3"; break;
                    case "4": valveSize = "NPS 4"; break;
                    case "5": valveSize = "NPS 1 1/2"; break;
                    case "6": valveSize = "NPS 3/4"; break;
                    case "7": valveSize = "NPS 1/2"; break;
                    case "A": valveSize = "DN 25"; break;
                    case "E": valveSize = "DN 40"; break;
                    case "B": valveSize = "DN 50"; break;
                    case "C": valveSize = "DN 80"; break;
                    case "D": valveSize = "DN 100"; break;
                    case "F": valveSize = "DN 20"; break;
                    case "H": valveSize = "DN 15"; break;
                    case "G": valveSize = "DN 150"; break;
                    default: valveSize = "NA"; break;
                }

                switch (Number2)
                {
                    case "W": valveBodySize = "WCC"; break;
                    case "S": valveBodySize = "CF8"; break;
                    case "T": valveBodySize = "CF3"; break;
                    case "L": valveBodySize = "LCC"; break;
                    default: valveBodySize = "NA"; break;
                }

                switch (Number3)
                {
                    case "1": valveRating = "ANSL CL 150"; break;
                    case "2": valveRating = "ANSL CL 300"; break;
                    case "4": valveRating = "PN 16"; break;
                    case "5": valveRating = "PN 25"; break;
                    default: valveRating = "NA"; break;
                }

                switch (valveSize)
                {
                    case "NPS 1/2":
                    case "DN 15":
                        {
                            switch (Number4)
                            {
                                case "1": valvePort = "9.5"; maxCv = 3.338; break;
                                case "2": valvePort = "9.5"; maxCv = 0; break;
                                case "3": valvePort = "4.8"; maxCv = 0.785; break;
                                case "4": valvePort = "4.8"; maxCv = 0.294; break;
                                case "5": valvePort = "4.8"; maxCv = 0.139; break;
                                case "6": valvePort = "4.8"; maxCv = 0.0389; break;
                                default: valvePort = "NA"; break;
                            }
                        }
                        break;

                    case "NPS 3/4":
                    case "DN 20":
                        {
                            switch (Number4)
                            {
                                case "1": valvePort = "14"; maxCv = 0; break;
                                case "2": valvePort = "9.5"; maxCv = 3.338; break;
                                case "3": valvePort = "9.5"; maxCv = 0; break;
                                case "4": valvePort = "4.8"; maxCv = 0.785; break;
                                case "5": valvePort = "4.8"; maxCv = 0.294; break;
                                case "6": valvePort = "4.8"; maxCv = 0.139; break;
                                case "7": valvePort = "4.8"; maxCv = 0.0389; break;
                                default: valvePort = "NA"; break;

                            }
                        }
                        break;
                }
            }
        }
    }

    class epplusCore
    {
        internal string filePath;
        internal string workSheet;

        ///<summary>
        ///get cell value 

        ///sample:
        // epplusCore eC = new epplusCore ();
        // eC.filePath = @"z:/test.xlsx";
        // eC.workSheet = "Sheet1";
        // int row = 0;
        // int col = 0;
        // string cellValue = eC.cv (row, col);

        // for (row = 1; row < 4; row++) {
        //     string output = eC.cv (row, 1) + eC.cv (row, 2); //merge column 1 and 2
        //     Console.WriteLine (output);
        // }
        ///</summary>
        internal string cv(int row, int col)
        { //get cell value and convert it to string 
            try
            {
                FileInfo existingFile = new FileInfo(filePath); //get target file infomation
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[workSheet]; //locate the worksheet
                    string cellValue = worksheet.Cells[row, col].Value.ToString(); //Cval means 'Cell Value'
                    return cellValue;
                }

            }
            catch
            {
                return null;
            }
        }

        ///<summary>
        ///create new worksheet in current workbook
        ///<summary>
        internal void createNewWorkSheet(string newWorkSheetName)
        {
            try
            {
                FileInfo existingFile = new FileInfo(filePath); //get target file infomation
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[workSheet]; //locate the worksheet
                    package.Workbook.Worksheets.Add(newWorkSheetName);
                    package.Save();
                }
            }
            catch
            {
                Console.WriteLine("Process Failed to add Sheet: " + newWorkSheetName);
            }
        }

        ///<summary>
        ///delete worksheet in current workbook
        ///<summary>
        internal void deleteWorkSheet(string deleteWorkSheetName)
        {
            try
            {
                FileInfo existingFile = new FileInfo(filePath); //get target file infomation
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    package.Workbook.Worksheets.Delete(deleteWorkSheetName);
                    package.Save();
                }
            }
            catch
            {
                Console.WriteLine("Process Failed to delete Sheet: " + deleteWorkSheetName);
            }
        }

        ///<summary>
        ///create new worksheet in current workbook, the worksheet is copied from another worksheet
        ///Notice: if Sheet2 is already existed, the process will fail
        ///example:
        // epplusCore eC = new epplusCore ();
        // eC.filePath = @"z:/test.xlsx";  
        // copyWorkSheet("Sheet1", "Sheet2");
        ///<summary>
        internal void copyWorkSheet(string existingWorkSheetName, string newWorkSheetName)
        {
            try
            {
                FileInfo existingFile = new FileInfo(filePath); //get target file infomation
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[workSheet]; //locate the worksheet
                    package.Workbook.Worksheets.Copy(existingWorkSheetName, newWorkSheetName);
                    package.Save();
                }
            }
            catch
            {
                Console.WriteLine("Process Failed to copy " + existingWorkSheetName + " to " + newWorkSheetName);

            }
        }

    }
}
