using ProfitCalculator.Classes.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProfitCalculator.Visual_Components;
using System.Threading;
using System.Security.Cryptography;

namespace ProfitCalculator.Classes
{
    public class Controller
    {
        private Account account;
        private MainWindow mainWindow;

        private static string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Properties.Settings.Default.AppDateFolder;
        private static string appDataFilePath = appDataFolderPath + "\\" + Properties.Settings.Default.AppDataFilePath;

        private static byte[] cryptKey  = Encoding.UTF8.GetBytes("4v0HzHNjz8zN4AxgriJQul03mx6zrlz2");
        private static byte[] cryptIV = Encoding.UTF8.GetBytes("nB=fgkB=avB2dSmB");

        public Controller(MainWindow mainWindow)
        {
            CreatePaths();

            this.mainWindow = mainWindow;
            this.mainWindow.Closed += MainWindow_Closed;
            this.mainWindow.OpenNewTransactionWindow += MainWindow_OpenNewTransactionWindow;
            this.mainWindow.OpenCategorieWindow += MainWindow_OpenCategorieWindow;
            this.mainWindow.ShowExistTransactionWindow += MainWindow_ShowExistTransactionWindow;

            LoadAccount();
        }

        private void MainWindow_ShowExistTransactionWindow(object sender, Transaction transaction)
        {
            OpenExistTransactionWindow(transaction);
        }

        private void MainWindow_OpenNewTransactionWindow(object sender)
        {
            OpenNewTransactionWindow();
        }

        private void MainWindow_OpenCategorieWindow(object sender)
        {
            OpenCategorieWindow();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            SaveAccount();
        }

        private void OpenCategorieWindow()
        {
            CategoriesWindow categoriesWindow = new CategoriesWindow()
            {
                Categories = this.account.Categories,
                Owner = mainWindow
            };

            if (categoriesWindow.ShowDialog() == true)
            {
                this.account.Categories = categoriesWindow.Categories;
            }
        }

        private void OpenNewTransactionWindow()
        {
            NewTransactionWindow newTransactionWindow = new NewTransactionWindow()
            {
                Categories = this.account.Categories,
                Owner = mainWindow
            };

            if (newTransactionWindow.ShowDialog() == true)
            {
                this.account.AddTransaction(newTransactionWindow.Transaction);
            }
        }

        private void OpenExistTransactionWindow(Transaction transaction)
        {
            NewTransactionWindow newTransactionWindow = new NewTransactionWindow(transaction, this.account.Categories)
            {
                Owner = mainWindow
            };

            newTransactionWindow.ShowDialog();
        }

        private void CreatePaths()
        {
            if (!Directory.Exists(appDataFolderPath))
            {
                Directory.CreateDirectory(appDataFolderPath);
            }
        }

        private void SaveAccount()
        {
            using (FileStream fileStream = new FileStream(appDataFilePath, FileMode.OpenOrCreate))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    fileStream.SetLength(0);
                    streamWriter.Write(EncryptString_Aes(JsonConvert.SerializeObject(this.account, Formatting.Indented), cryptKey, cryptIV));
                }
            }
        }

        private void LoadAccount()
        {
            using (FileStream fileStream = new FileStream(appDataFilePath, FileMode.OpenOrCreate))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string jsonString = streamReader.ReadToEnd();

                    if(jsonString != null && jsonString != string.Empty)
                    {
                        this.account = JsonConvert.DeserializeObject<Account>(DecryptString_Aes(jsonString, cryptKey, cryptIV));

                        if(account != null)
                            this.account.Update();
                    }
                }
            }

            if(this.account == null)
            {
                NewAccountWindow newAccountWindow = new NewAccountWindow();

                if(newAccountWindow.ShowDialog() == true)
                {
                    this.account = newAccountWindow.Account;
                    this.account.Update();
                }
            }

            if (this.account != null)
                this.mainWindow.Account = this.account;
            else
                this.mainWindow.Close();
        }

        private string EncryptString_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            string encrypted;

            byte[] bytes = Encoding.Unicode.GetBytes(plainText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(bytes, 0, bytes.Length);
                    }

                    encrypted = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }

            return encrypted;
        }

        private string DecryptString_Aes(string cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] bytes = Convert.FromBase64String(cipherText);

            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] decryptedBytes = new byte[bytes.Length];
                        csDecrypt.Read(decryptedBytes, 0, decryptedBytes.Length);
                        plaintext = Encoding.Unicode.GetString(decryptedBytes);
                    }
                }
            }

            return plaintext;
        }
    }
}
