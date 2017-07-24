using EntityModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using WebDemo.Model;

namespace WebDemo.Module
{
    public static class clsEntity
    {
        #region Database
        public static zModel db;
        static Dictionary<string, xNgonNgu> dicWord;
        #endregion

        #region GetValueObject
        public static object GetObjectByName(this object oSource, string pName)
        {
            if (oSource == null) return string.Empty;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe;
        }

        public static string GetStringByName(this object oSource, string pName)
        {
            if (oSource == null) return string.Empty;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? oRe.ToString() : string.Empty;
        }

        public static int GetInt32ByName(this object oSource, string pName)
        {
            if (oSource == null) return 0;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? Convert.ToInt32(oRe) : 0;
        }

        public static decimal GetDecimalByName(this object oSource, string pName)
        {
            if (oSource == null) return 0;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? Convert.ToDecimal(oRe) : 0;
        }

        public static string GetPrimaryKeyName<T>(this DbContext context) where T : class
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            var key = entityType.GetKeys();
            return key.FirstOrDefault().Properties.ToList()[0].Name;
        }

        public static void CopyValue(this object oSource, object oDestination)
        {
            if (oSource == null) return;

            foreach (PropertyInfo pInfo in oSource.GetType().GetProperties())
            {
                var oRe = oSource.GetType().GetProperty(pInfo.Name).GetValue(oSource, null);

                if (pInfo.PropertyType == typeof(Int32))
                    oDestination.GetType().GetProperty(pInfo.Name).SetValue(oDestination, oRe);
                if (pInfo.PropertyType == typeof(Decimal))
                    oDestination.GetType().GetProperty(pInfo.Name).SetValue(oDestination, oRe);
                if (pInfo.PropertyType == typeof(String))
                    oDestination.GetType().GetProperty(pInfo.Name).SetValue(oDestination, oRe == null ? string.Empty : oRe.ToString());
                if (pInfo.PropertyType == typeof(DateTime))
                    oDestination.GetType().GetProperty(pInfo.Name).SetValue(oDestination, oRe);

            }
        }

        public static Dictionary<string, object> GetValue(this object oSource)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (oSource == null) return dic;

            foreach (PropertyInfo pInfo in oSource.GetType().GetProperties())
            {
                var oRe = pInfo.GetValue(oSource, null);
                if (pInfo.PropertyType == typeof(Int32))
                    dic.Add(pInfo.Name.ToLower(), Convert.ToInt32(oRe));
                if (pInfo.PropertyType == typeof(Decimal))
                    dic.Add(pInfo.Name.ToLower(), Convert.ToDecimal(oRe));
                if (pInfo.PropertyType == typeof(String))
                    dic.Add(pInfo.Name.ToLower(), oRe == null ? string.Empty : oRe.ToString());
                if (pInfo.PropertyType == typeof(DateTime))
                    dic.Add(pInfo.Name.ToLower(), Convert.ToDateTime(oRe));
            }

            return dic;
        }
        #endregion

        #region Mã hóa dữ liệu
        public static string key = "0123456789ABCDEFGH";

        public static string Encrypt(this string plainText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                    }
                    plainText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return plainText;
        }

        public static string Decrypt(this string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion

        #region Ngôn ngữ
        private static void AddNewWord()
        {
            if (dicWord == null)
            {
                dicWord = new Dictionary<string, xNgonNgu>();
                dicWord.Add("keyid", new xNgonNgu() { EN = "KeyID", VN = "Khóa chính" });
                dicWord.Add("code", new xNgonNgu() { EN = "Code", VN = "Mã" });
                dicWord.Add("name", new xNgonNgu() { EN = "Name", VN = "Tên" });
                dicWord.Add("isenable", new xNgonNgu() { EN = "Is Enable", VN = "Kích hoạt" });
            }
        }

        public static string Translate(this string clsName, string fieldName, string en = "", string vn = "")
        {
            AddNewWord();
            try
            {
                xNgonNgu item = db.xNgonNgu.FirstOrDefault(x => x.ClassName.Equals(clsName) && x.FieldName.ToLower().Equals(fieldName.ToLower()));
                item = item ?? new xNgonNgu()
                {
                    ClassName = clsName,
                    FieldName = fieldName.ToLower(),
                    EN = dicWord[fieldName.ToLower()].EN,
                    VN = dicWord[fieldName.ToLower()].VN,
                };

                item.EN = string.IsNullOrEmpty(en) ? item.EN : en;
                item.VN = string.IsNullOrEmpty(vn) ? item.VN : vn;

                if (item.KeyID == 0)
                    db.Add(item);

                db.SaveChanges();

                return item.VN;
            }
            catch { return string.Empty; }

        }

        public static string Translate(this object obj, string fieldName, string en = "", string vn = "")
        {
            AddNewWord();
            try
            {
                xNgonNgu item = db.xNgonNgu.FirstOrDefault(x => x.ClassName.Equals(obj.GetType().Name) && x.FieldName.ToLower().Equals(fieldName.ToLower()));
                item = item ?? new xNgonNgu()
                {
                    ClassName = obj.GetType().Name,
                    FieldName = fieldName.ToLower(),
                    EN = dicWord.Any(x => x.Key.ToLower().Equals(fieldName.ToLower())) ? dicWord[fieldName.ToLower()].EN : fieldName,
                    VN = dicWord.Any(x => x.Key.ToLower().Equals(fieldName.ToLower())) ? dicWord[fieldName.ToLower()].VN : fieldName
                };

                item.EN = string.IsNullOrEmpty(en) ? item.EN : en;
                item.VN = string.IsNullOrEmpty(vn) ? item.VN : vn;

                if (item.KeyID == 0)
                    db.Add(item);

                db.SaveChanges();

                return item.VN;
            }
            catch { return string.Empty; }

        }
        #endregion
    }


}
