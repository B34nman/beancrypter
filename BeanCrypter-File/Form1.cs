using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BeanCrypter_File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool encrypted = false, decrypted = false, fileSelected = false;
        string contents;
        private const string SecurityKey = "andersoncooper360_231dsf29fajlasnvs[21301d";

        private void file_select_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text (*.txt)|*.txt";
                ofd.Title = "Select text file to encrypt";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    file_path.Text = ofd.FileName;
                    contents = File.ReadAllText(@file_path.Text);
                    fileSelected = true;
                }
            }
        } 
        

        //encrypt
        private void encrypt_Click(object sender, EventArgs e)
        {
            if (!encrypted && fileSelected)
            {
                string encrypted_contents = EncryptPlainTextToCipherText(contents);
                File.WriteAllText(@file_path.Text, encrypted_contents);
                System.Windows.Forms.MessageBox.Show("File has been encrypted");
            }
            else if (!fileSelected)
                System.Windows.Forms.MessageBox.Show("Please select a file");
            else
                System.Windows.Forms.MessageBox.Show("File is already encrypted");
            encrypted = true;
            decrypted = false;
        }
       
        //decrypt
        private void decrypt_Click(object sender, EventArgs e)
        {
            if (!decrypted && fileSelected)
            {
                contents = File.ReadAllText(@file_path.Text);
                string decrypted_contents = DecryptCipherTextToPlainText(contents);
                File.WriteAllText(@file_path.Text, decrypted_contents);
                System.Windows.Forms.MessageBox.Show("File has been decrypted");
            }
            else if (!fileSelected)
                System.Windows.Forms.MessageBox.Show("Please select a file");
            else
                System.Windows.Forms.MessageBox.Show("File is already decrypted");
            decrypted = true;
            encrypted = false;
        }



        //This method is used to convert the plain text to Encrypted/Un-Readable Text format.
        public static string EncryptPlainTextToCipherText(string PlainText)
        {
            // Getting the bytes of Input String.
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);

            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            //De-allocatinng the memory after doing the Job.
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;
            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;


            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        //This method is used to convert the Encrypted/Un-Readable Text back to readable  format.
        public static string DecryptCipherTextToPlainText(string CipherText)
        {
            byte[] toEncryptArray = Convert.FromBase64String(CipherText);
            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;
            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            objTripleDESCryptoService.Clear();

            //Convert and return the decrypted data/byte into string format.
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

    }
}
