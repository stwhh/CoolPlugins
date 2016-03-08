// Copyright (c) 孙涛. All rights reserved.
// 创 建 人：孙涛
// 创建日期：2016-3-8 20:00
// 用    途：加密类

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;

namespace CoolPlugins.Public.Tools
{
    /// <summary>超全加密=,=集大成版(但是各种加密方式依旧没有全,不过基本实现已经提供了)</summary>
    public class EncryptHelper
    {
        #region MD5(Message Digest Algorithm Version.5)

        /// <summary>MD5加密</summary>
        /// <param name="beforeStr">需要加密的字符串</param>
        /// <remarks>此种加密之后的字符串是三十二位的(字母加数据)字符串</remarks>
        /// <remarks>Example: password是admin 加密变成后21232f297a57a5a743894a0e4a801fc3</remarks>
        /// <returns></returns>
        public static string Md5Encrypt(string beforeStr)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.UTF8.GetBytes(beforeStr));
            StringBuilder sb = new StringBuilder(32);
            foreach (byte item in t)
            {
                sb.Append(item.ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        /// <summary>MD5加密,可指定加密字符编码</summary>
        /// <param name="encypStr">需加密的字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public static string Md5Encrypt(string encypStr, Encoding encoding)
        {
            var m5 = new MD5CryptoServiceProvider();
            var inputBye = encoding.GetBytes(encypStr);
            var outputBye = m5.ComputeHash(inputBye);
            var retStr = Convert.ToBase64String(outputBye);
            return (retStr);
        }

        ///<summary>生成MD5摘要</summary>
        /// <param name="original">数据源(可以通过Endoding.*.GetBytes(string)进行获取)</param>
        /// <returns>摘要</returns>
        public static byte[] Md5Make(byte[] original)
        {
            var hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyhash = hashmd5.ComputeHash(original);
            hashmd5 = null;
            return keyhash;
        }

        /// <summary>Hash算法加密(HashCode)</summary>
        /// <param name="password"></param>
        /// <remarks>这种加密是  字母加-加字符</remarks>
        /// <remarks>Example: password是admin 加密变成后19-A2-85-41-44-B6-3A-8F-76-17-A6-F2-25-01-9B-12</remarks>
        /// <returns></returns>
        public static string HashEncrypt(string password)
        {
            Byte[] hashedBytes = null;
            try
            {
                Byte[] clearBytes = new UnicodeEncoding().GetBytes(password);
                hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return BitConverter.ToString(hashedBytes); //MD5加密
        }

        #endregion

        #region BASE64(8bit字节代码编码)

        private static readonly string Base64Code = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

        /// <summary>Base64加密</summary>
        /// <param name="text">要加密的字符串</param>
        /// <param name="encoding">编码方式,如果不确定可以试试Default</param>
        /// <returns></returns>
        public static string Base64Encode(string text, Encoding encoding)
        {
            //如果字符串为空，则返回
            if (string.IsNullOrEmpty(text)) return "";
            try
            {
                byte empty = 0;
                ArrayList byteMessage = new ArrayList(encoding.GetBytes(text));
                int messageLen = byteMessage.Count;
                int page = messageLen / 3;
                int use = 0;
                if ((use = messageLen % 3) > 0)
                {
                    for (int i = 0; i < 3 - use; i++)
                        byteMessage.Add(empty);
                    page++;
                }
                var outmessage = new StringBuilder(page * 4);
                for (int i = 0; i < page; i++)
                {
                    byte[] instr = new byte[3];
                    instr[0] = (byte)byteMessage[i * 3];
                    instr[1] = (byte)byteMessage[i * 3 + 1];
                    instr[2] = (byte)byteMessage[i * 3 + 2];
                    int[] outstr = new int[4];
                    outstr[0] = instr[0] >> 2;
                    outstr[1] = ((instr[0] & 0x03) << 4) ^ (instr[1] >> 4);
                    outstr[2] = !instr[1].Equals(empty) ? ((instr[1] & 0x0f) << 2) ^ (instr[2] >> 6) : 64;
                    if (!instr[2].Equals(empty))
                        outstr[3] = (instr[2] & 0x3f);
                    else
                        outstr[3] = 64;
                    outmessage.Append(Base64Code[outstr[0]]);
                    outmessage.Append(Base64Code[outstr[1]]);
                    outmessage.Append(Base64Code[outstr[2]]);
                    outmessage.Append(Base64Code[outstr[3]]);
                }
                return outmessage.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Base64解密</summary>
        /// <param name="text">要解密的字符串</param>
        /// <param name="encoding">编码方式,如果不确定可以试试Default</param>
        public static string Base64Decode(string text, Encoding encoding)
        {
            //如果字符串为空，则返回
            if (string.IsNullOrEmpty(text)) return "";
            //将空格替换为加号
            text = text.Replace(" ", "+");
            try
            {
                if ((text.Length % 4) != 0) return "包含不正确的BASE64编码";
                if (!Regex.IsMatch(text, "^[A-Z0-9/+=]*$", RegexOptions.IgnoreCase)) return "包含不正确的BASE64编码";
                int page = text.Length / 4;
                ArrayList outMessage = new ArrayList(page * 3);
                char[] message = text.ToCharArray();
                for (int i = 0; i < page; i++)
                {
                    byte[] instr = new byte[4];
                    instr[0] = (byte)Base64Code.IndexOf(message[i * 4]);
                    instr[1] = (byte)Base64Code.IndexOf(message[i * 4 + 1]);
                    instr[2] = (byte)Base64Code.IndexOf(message[i * 4 + 2]);
                    instr[3] = (byte)Base64Code.IndexOf(message[i * 4 + 3]);
                    byte[] outstr = new byte[3];
                    outstr[0] = (byte)((instr[0] << 2) ^ ((instr[1] & 0x30) >> 4));
                    if (instr[2] != 64)
                    {
                        outstr[1] = (byte)((instr[1] << 4) ^ ((instr[2] & 0x3c) >> 2));
                    }
                    else
                    {
                        outstr[2] = 0;
                    }
                    if (instr[3] != 64)
                    {
                        outstr[2] = (byte)((instr[2] << 6) ^ instr[3]);
                    }
                    else
                    {
                        outstr[2] = 0;
                    }
                    outMessage.Add(outstr[0]);
                    if (outstr[1] != 0)
                        outMessage.Add(outstr[1]);
                    if (outstr[2] != 0)
                        outMessage.Add(outstr[2]);
                }
                byte[] outbyte = (byte[])outMessage.ToArray(Type.GetType("System.Byte"));
                return encoding.GetString(outbyte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region BASE32(BASE64衍生出来的)
        /*一个字节就是八个二进制bit
         * 可以表示从 0 到 255 之间的任意一个数值（共 256 个数值）
         * 那么将一个字节分成高 4bit 低 4biy
         * 每个 bit 能表示 0 到 31 之间的任意一个数值（共 32 个数值）
         * 然后将分割开来的高低两个数值对着上面我们提到的表来进行索引
         * 最后将索引出来的值作为密文*/
        private const int InByteSize = 8;
        private const int OutByteSize = 5;
        private static readonly string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        public static string Base32Encode(byte[] data)
        {
            int i = 0, index = 0, digit = 0;
            var result = new StringBuilder((data.Length + 7) * InByteSize / OutByteSize);
            while (i < data.Length)
            {
                var currentByte = (data[i] >= 0) ? data[i] : (data[i] + 256);
                /* Is the current digit going to span a byte boundary? */
                if (index > (InByteSize - OutByteSize))
                {
                    int nextByte;
                    if ((i + 1) < data.Length)
                        nextByte = (data[i + 1] >= 0) ? data[i + 1] : (data[i + 1] + 256);
                    else
                        nextByte = 0;

                    digit = currentByte & (0xFF >> index);
                    index = (index + OutByteSize) % InByteSize;
                    digit <<= index;
                    digit |= nextByte >> (InByteSize - index);
                    i++;
                }
                else
                {
                    digit = (currentByte >> (InByteSize - (index + OutByteSize))) & 0x1F;
                    index = (index + OutByteSize) % InByteSize;
                    if (index == 0)
                        i++;
                }
                result.Append(Alphabet[digit]);
            }
            return result.ToString();
        }

        public static byte[] Base32Decode(string base32String)
        {
            // Ignore hyphens
            var str = base32String.Replace("-", "");
            // Convert it to bits
            var bits = new List<byte>();
            foreach (char c in str)
            {
                int i = Alphabet.IndexOf(c);
                bits.Add((byte)((i & 16) > 0 ? 1 : 0));
                bits.Add((byte)((i & 8) > 0 ? 1 : 0));
                bits.Add((byte)((i & 4) > 0 ? 1 : 0));
                bits.Add((byte)((i & 2) > 0 ? 1 : 0));
                bits.Add((byte)((i & 1) > 0 ? 1 : 0));
            }
            // Convert bits into bytes
            var bytes = new List<byte>();
            for (int i = 0; i < bits.Count; i += 8)
            {
                bytes.Add((byte)(
                  (bits[i + 0] << 7) +
                  (bits[i + 1] << 6) +
                  (bits[i + 2] << 5) +
                  (bits[i + 3] << 4) +
                  (bits[i + 4] << 3) +
                  (bits[i + 5] << 2) +
                  (bits[i + 6] << 1) +
                  (bits[i + 7] << 0)));
            }
            return bytes.ToArray();
        }
        public static string GenerateRandomBase32String(int length = 16)
        {
            var maxLength = Alphabet.Length;
            var random = new Random(Guid.NewGuid().GetHashCode());
            var sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(Alphabet[random.Next(0, maxLength)]);
            }
            return sb.ToString();
        }

        #endregion

        #region AES(Advanced Encryption Standard)

        /// <summary>AES加密</summary>
        /// <param name="data">被加密的明文</param>
        /// <param name="key">密钥</param>
        /// <param name="vector">向量</param>
        /// <returns>密文</returns>
        public static string AESEncrypt(string data, string key, string vector)
        {
            Byte[] plainBytes = Encoding.UTF8.GetBytes(data);

            Byte[] bKey = new Byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);
            Byte[] bVector = new Byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(vector.PadRight(bVector.Length)), bVector, bVector.Length);
            Byte[] cryptograph = null; // 加密后的密文
            Rijndael aes = Rijndael.Create();
            try
            {
                // 开辟一块内存流
                using (MemoryStream memory = new MemoryStream())
                {
                    // 把内存流对象包装成加密流对象
                    using (CryptoStream encryptor = new CryptoStream(memory,
                     aes.CreateEncryptor(bKey, bVector),
                     CryptoStreamMode.Write))
                    {
                        // 明文数据写入加密流
                        encryptor.Write(plainBytes, 0, plainBytes.Length);
                        encryptor.FlushFinalBlock();

                        cryptograph = memory.ToArray();
                    }
                }
            }
            catch
            {
                cryptograph = null;
            }
            return Convert.ToBase64String(cryptograph);
        }

        /// <summary>AES解密</summary>
        /// <param name="data">被解密的密文</param>
        /// <param name="key">密钥</param>
        /// <param name="vector">向量</param>
        /// <returns>明文</returns>
        public static string AESDecrypt(string data, string key, string vector)
        {
            Byte[] encryptedBytes = Convert.FromBase64String(data);
            Byte[] bKey = new Byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);
            Byte[] bVector = new Byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(vector.PadRight(bVector.Length)), bVector, bVector.Length);
            Byte[] original = null; // 解密后的明文
            Rijndael aes = Rijndael.Create();
            try
            {
                // 开辟一块内存流，存储密文
                using (MemoryStream memory = new MemoryStream(encryptedBytes))
                {
                    // 把内存流对象包装成加密流对象
                    using (CryptoStream decryptor = new CryptoStream(memory,
                    aes.CreateDecryptor(bKey, bVector),
                    CryptoStreamMode.Read))
                    {
                        // 明文存储区
                        using (MemoryStream originalMemory = new MemoryStream())
                        {
                            Byte[] buffer = new Byte[1024];
                            Int32 readBytes = 0;
                            while ((readBytes = decryptor.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                originalMemory.Write(buffer, 0, readBytes);
                            }
                            original = originalMemory.ToArray();
                        }
                    }
                }
            }
            catch
            {
                original = null;
            }
            return Encoding.UTF8.GetString(original);
        }

        /// <summary>AES加密(无向量)</summary>
        /// <param name="data">被加密的明文</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public static string AESEncrypt(string data, string key)
        {
            MemoryStream mStream = new MemoryStream();
            RijndaelManaged aes = new RijndaelManaged();
            byte[] plainBytes = Encoding.UTF8.GetBytes(data);
            Byte[] bKey = new Byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            //aes.Key = _key;
            aes.Key = bKey;
            //aes.IV = _iV;
            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            try
            {
                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }
        }

        /// <summary>AES解密(无向量)</summary>
        /// <param name="data">被加密的明文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static string AESDecrypt(string data, string key)
        {
            Byte[] encryptedBytes = Convert.FromBase64String(data);
            Byte[] bKey = new Byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);
            MemoryStream mStream = new MemoryStream(encryptedBytes);
            //mStream.Write( encryptedBytes, 0, encryptedBytes.Length );
            //mStream.Seek( 0, SeekOrigin.Begin );
            RijndaelManaged aes = new RijndaelManaged();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.Key = bKey;
            //aes.IV = _iV;
            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            try
            {
                byte[] tmp = new byte[encryptedBytes.Length + 32];
                int len = cryptoStream.Read(tmp, 0, encryptedBytes.Length + 32);
                byte[] ret = new byte[len];
                Array.Copy(tmp, 0, ret, 0, len);
                return Encoding.UTF8.GetString(ret);
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }
        }

        #endregion

        #region DES(Data Encryption Algorithm)

        /// <summary>DES加密数据 </summary> 
        /// <param name="text"></param> 
        /// <param name="key"></param> 
        /// <returns></returns> 
        public static string DesEncrypt(string text, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            var inputByteArray = Encoding.Default.GetBytes(text);
            des.Key =
                ASCIIEncoding.ASCII.GetBytes(
                    FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5")
                        .Substring(0, 8));
            des.IV =
                ASCIIEncoding.ASCII.GetBytes(
                    FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5")
                        .Substring(0, 8));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        /// <summary>DES解密数据 </summary> 
        /// <param name="text"></param> 
        /// <param name="key"></param> 
        /// <returns></returns> 
        public static string DesDecrypt(string text, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = text.Length / 2;
            byte[] inputByteArray = new byte[len];
            for (var x = 0; x < len; x++)
            {
                var i = Convert.ToInt32(text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key =
                ASCIIEncoding.ASCII.GetBytes(
                    FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5")
                        .Substring(0, 8));
            des.IV =
                ASCIIEncoding.ASCII.GetBytes(
                    FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5")
                        .Substring(0, 8));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion

        #region TripleDES

        //待补充

        #endregion

        #region SHA(Security Hash Algorithm)

        /// <summary>SHA512安全哈希算法</summary>
        /// <param name="security"></param>
        /// <returns></returns>
        public static string SHA512Encrypt(string security)
        {
            var code = new UnicodeEncoding();
            var message = code.GetBytes(security);
            var arithmetic = new SHA512Managed();
            var value = arithmetic.ComputeHash(message);
            return value.Aggregate("", (current, o) => current + ((int)o + "O"));
        }

        /// <summary>哈希加密一个字符串</summary>
        /// <param name="security"></param>
        /// <returns></returns>
        public static string SHA384Encrypt(string security)
        {
            var code = new UnicodeEncoding();
            var message = code.GetBytes(security);
            var arithmetic = new SHA384Managed();
            var value = arithmetic.ComputeHash(message);
            return value.Aggregate("", (current, o) => current + ((int)o + "O"));
        }

        /// <summary>SHA256安全哈希算法</summary>
        /// <param name="security"></param>
        /// <returns></returns>
        public static string SHA256Encrypt(string security)
        {
            var code = new UnicodeEncoding();
            var message = code.GetBytes(security);
            var arithmetic = new SHA256Managed();
            var value = arithmetic.ComputeHash(message);
            return value.Aggregate("", (current, o) => current + ((int)o + "O"));
        }

        /// <summary>SHA224安全哈希算法 </summary>
        /// <param name="security"></param>
        /// <remarks>SHA224是SHA256结果中的前28字节的内容</remarks>
        /// <returns></returns>
        public string SHA224Encrypt(string security)
        {
            var sha = new SHA256Managed(); // 用来计算 SHA256 哈希值
            var uen = new UTF8Encoding(); // 用来把char[]转换成byte[]
            var bytestr = uen.GetBytes(security.ToCharArray());
            sha.ComputeHash(bytestr); // 计算哈希值
            string sha224 = "";
            for (int i = 0; i < 28; ++i)
            {
                var dec = int.Parse(sha.Hash.GetValue(i).ToString()); // 十进制
                string bin = Convert.ToString(dec, 2).PadLeft(8, '0'); // 转成二进制数，是8位的，不足8位前面补0
                sha224 += bin;
            }
            return sha224;
        }

        /// <summary>SHA1安全哈希算法</summary>
        /// <param name="security"></param>
        /// <returns></returns>
        public static string SHAEncrypt(string security)
        {
            var code = new UnicodeEncoding();
            var message = code.GetBytes(security);
            var arithmetic = new SHA1Managed();
            var value = arithmetic.ComputeHash(message);
            return value.Aggregate("", (current, o) => current + ((int)o + "O"));
        }

        #endregion

        #region HMACSHA(Hash-based Message Authentication Code)

        /// <summary>HMACSHA1</summary>
        /// <param name="security"></param>
        /// <returns></returns>
        public static string HMacSHA512Encrypt(string security, string key)
        {
            var hmacsha512 = new HMACSHA512();
            hmacsha512.Key = System.Text.Encoding.ASCII.GetBytes(key);
            byte[] myWord = System.Text.Encoding.Default.GetBytes(security);
            byte[] result = hmacsha512.ComputeHash(myWord);
            var myResult = new StringBuilder();
            foreach (byte myChar in result)
            {
                myResult.AppendFormat("{0:x2}", myChar);
            }
            return myResult.ToString();
        }

        /// <summary>HMACSHA384</summary>
        /// <param name="security"></param>
        /// <returns></returns>
        public static string HMacSHA384Encrypt(string security, string key)
        {
            var hmacsha384 = new HMACSHA384();
            hmacsha384.Key = System.Text.Encoding.ASCII.GetBytes(key);
            byte[] myWord = System.Text.Encoding.Default.GetBytes(security);
            byte[] result = hmacsha384.ComputeHash(myWord);
            var myResult = new StringBuilder();
            foreach (byte myChar in result)
            {
                myResult.AppendFormat("{0:x2}", myChar);
            }
            return myResult.ToString();
        }

        /// <summary>HMACSHA256</summary>
        /// <param name="security"></param>
        /// <returns></returns>
        public static string HMacSHA256Encrypt(string security, string key)
        {
            var hmacsha256 = new HMACSHA256();
            hmacsha256.Key = System.Text.Encoding.ASCII.GetBytes(key);
            byte[] myWord = System.Text.Encoding.Default.GetBytes(security);
            byte[] result = hmacsha256.ComputeHash(myWord);
            var myResult = new StringBuilder();
            foreach (byte myChar in result)
            {
                myResult.AppendFormat("{0:x2}", myChar);
            }
            return myResult.ToString();
        }

        /// <summary>HMACSHA1</summary>
        /// <param name="security"></param>
        /// <returns></returns>
        public static string HMacSHAEncrypt(string security, string key)
        {
            var hmacsha1 = new HMACSHA1();
            hmacsha1.Key = System.Text.Encoding.ASCII.GetBytes(key);
            byte[] myWord = System.Text.Encoding.Default.GetBytes(security);
            byte[] result = hmacsha1.ComputeHash(myWord);
            var myResult = new StringBuilder();
            foreach (byte myChar in result)
            {
                myResult.AppendFormat("{0:x2}", myChar);
            }
            return myResult.ToString();
        }

        #endregion
    }
}