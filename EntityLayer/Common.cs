using Microsoft.Win32;
using System;
using System.Configuration;
using System.IO;
using System.Net;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Data;

namespace EntityLayer
{

    public static class Common
    {
        //static Database defaultDB = null;


        //defaultDB = EnterpriseLibraryContainer.Current.GetInstance<Database>();

        public enum Voucher
        {
            BankPayment = 1,
            BankReceive = 2,
            CashPayment = 3,
            CashReceive
        }

        public enum ButtonSelect
        {
            LocalSales,
            LocalPurchase,
            CaseSales,
            CasePurchase,
            Stock,
            SalesReturn,
            PurchaseReturn,
            SalesDiscount,
            PurchaseDiscount
        }

        public static string UserName = string.Empty;
        public static string Password = string.Empty;
        public static string ServerName { get; set; }

        public enum User
        {
            POS = 1,
            FullAccess = 2
        }
        public static DateTime NewDDate()
        {
            TimeZoneInfo UAETimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time"); DateTime utc = DateTime.Now;
            DateTime UAE = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utc, "Arabian Standard Time");
            return UAE;
        }

        public static decimal getDecimal(object obj)
        {
            return validateDecimal(obj) ? Convert.ToDecimal(obj) : 0;
        }
        public static decimal getDecimal(object obj, int roundAt)
        {
            return validateDecimal(obj) ? Math.Round(Convert.ToDecimal(obj), roundAt) : 0;
        }

        public static bool validateDecimal(object obj)
        {
            try
            {
                decimal dt = Convert.ToDecimal(obj);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static void SendSMS()
        {
            WebClient client = new WebClient();
            string to, message;
            to = "971507498936";
            message = "Selvin";
            string baseURL = "http://api.clickatell.com/http/sendmsg?user=selvin&password=OYeNLVUHTNIHbD&api_id=3528011&to='" + to + "'&text='" + message + "'";
            client.OpenRead(baseURL);
        }

        public static bool IsDecimalLimitedtoTwoDigits(string inputvalue)
        {
            Regex isnumber = new Regex(@"^[\d]{1,6}([.]{1}[\d]{1,2})?$");
            return isnumber.IsMatch(inputvalue);
        }

        public static void Server()
        {
            string path;
            path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filename = "Connection" + ".dll";// +DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            string filepath = directory + "\\" + filename;

            if (filepath != null)
            {
                if (File.Exists(filepath))
                {
                    File.WriteAllText(filepath, String.Empty);
                    StreamWriter writer = null;

                    writer = new StreamWriter(filepath, true);
                    if (writer != null)
                    {
                        writer.WriteLine();
                        writer.Close();
                    }
                }
                else
                {
                    StreamWriter writer = File.CreateText(filepath);
                    if (writer != null)
                    {
                        writer.WriteLine();
                        writer.Close();
                    }
                }
            }
        }

        public static void GetServer(string InitialCatalog)
        {
            try
            {
                string LogPath = ConfigurationManager.AppSettings["LogPath"].ToString(); //Application.StartupPath + "\\";
                //string driveLetter = Path.GetPathRoot(Environment.SystemDirectory);
                //string loPath = LogPath + LogPath;
                string filename = "ConnectionString" + ".dll";
                string filepath = LogPath + filename;

                StreamReader writer1 = null;
                writer1 = new StreamReader(filepath, true);
                string connectionString = writer1.ReadToEnd();
                string ComputerName = connectionString.Split(new string[] { "=", ";" },
                           StringSplitOptions.RemoveEmptyEntries)[1];
                string UserId = connectionString.Split(new string[] { "user id=", ";" },
                           StringSplitOptions.RemoveEmptyEntries)[1];
                string Password = connectionString.Split(new string[] { "password=", ";" },
                           StringSplitOptions.RemoveEmptyEntries)[2];

                string LogPath1 = ConfigurationManager.AppSettings["LogPath"].ToString();// Application.StartupPath + "\\";
                //string loPath1 = LogPath1 + LogPath1;
                string filename1 = "Authentication" + ".dll";
                string filepath1 = LogPath1 + filename1;

                if (filepath1 != null)
                {
                    if (File.Exists(filepath1))
                    {
                        File.WriteAllText(filepath1, String.Empty);
                        StreamWriter writer = null;

                        writer = new StreamWriter(filepath1, true);
                        if (writer != null)
                        {
                            writer.WriteLine("Data Source=" + ComputerName + ";Initial Catalog=" + InitialCatalog + ";user id=" + UserId + ";password=" + Password + ";Integrated Security=false;Connect Timeout=120;User Instance=false");
                            writer.Close();
                        }
                    }
                    else
                    {
                        StreamWriter writer = File.CreateText(filepath1);
                        if (writer != null)
                        {
                            writer.WriteLine("Data Source=" + ComputerName + ";Initial Catalog=" + InitialCatalog + ";user id=" + UserId + ";password=" + Password + ";Integrated Security=false;Connect Timeout=120;User Instance=false");
                            writer.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /* public static void DecimalValidation(object sender, KeyPressEventArgs e, bool isNegativeFiled)
         {
             try
             {
             //    TextBox txt = (TextBox)sender;
             //    if (!char.IsNumber(e.KeyChar))
             //    {
             //        e.Handled = true;
             //    }
             //    if (e.KeyChar == 8)
             //    {
             //        e.Handled = false;
             //    }
             //    if (e.KeyChar == 46)
             //    {
             //        if (txt.Text.Contains(".") && txt.SelectionStart != 0)
             //        {
             //            e.Handled = true;
             //        }
             //        else
             //        {
             //            if (txt.Text == "" || txt.SelectionStart == 0)
             //            {
             //                txt.Clear();
             //                txt.Text = "0.";
             //                txt.SelectionStart = txt.Text.Length;
             //            }
             //            else
             //            {
             //                txt.Text = txt.Text + ".";
             //                txt.SelectionStart = txt.Text.Length;
             //            }
             //        }
             //    }
             //    else if (e.KeyChar == 45 && (isNegativeFiled))
             //    {
             //        if (txt.Text.Contains("-") && txt.SelectionStart != 0)
             //        {
             //            e.Handled = true;
             //        }
             //        else
             //        {
             //            txt.Clear();
             //            txt.Text = "-";
             //            txt.SelectionStart = txt.Text.Length;
             //        }
             //    }
             //}
             //catch (Exception ex)
             //{
             //    MessageBox.Show("TAX: " + ex.Message, "ICT", MessageBoxButtons.OK, MessageBoxIcon.Information);
             //}
         }*/

        public static bool CheckWhetherOfficeInstalled()
        {
            // Checking whether excel is installed on system
            RegistryKey TargetKey = default(RegistryKey);
            TargetKey = Registry.ClassesRoot.OpenSubKey("excel.application");
            if (TargetKey == null)
            {
               
                return false;

            }
            else
            {
                return true;
            }
        }


    }
}
