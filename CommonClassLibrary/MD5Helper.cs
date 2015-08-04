using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace CommonClassLibrary
{
    class MD5Helper
    {
        //创建密钥
        public static string GenerateKey()
        {
            return "tjnu2015Novtt";
        }

        ///MD5加密
        public static string MD5Encrypt(string pToEncrypt,string sKey)
        {
             DESCryptoServiceProvider des = new DESCryptoServiceProvider();
             byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
             des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
             des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
             MemoryStream ms = new MemoryStream();
             CryptoStream cs = new CryptoStream(ms,des.CreateEncryptor(),CryptoStreamMode.Write);
             cs.Write(inputByteArray,0,inputByteArray.Length);
             cs.FlushFinalBlock();
             StringBuilder ret = new StringBuilder();
             foreach(byte b in ms.ToArray())
             {
                ret.AppendFormat("{0:X2}",b);
             }
             ret.ToString();
             return ret.ToString();
        }

        ///MD5解密
        public static string MD5Decrypt(string pToDecrypt, string sKey)
        {
             DESCryptoServiceProvider des = new DESCryptoServiceProvider();
             byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
             for(int x = 0;x < pToDecrypt.Length / 2;x++)
             {
                  int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2,2),16));
                  inputByteArray[x] = (byte)i;
             }

             des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
             des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
             MemoryStream ms = new MemoryStream();
             CryptoStream cs = new CryptoStream(ms,des.CreateDecryptor(),CryptoStreamMode.Write);
             cs.Write(inputByteArray,0,inputByteArray.Length);
             cs.FlushFinalBlock();
             StringBuilder ret = new StringBuilder();  
             return System.Text.Encoding.Default.GetString(ms.ToArray());
        }

    }
}