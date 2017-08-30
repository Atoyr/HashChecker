using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Util
{
    public class HashUtil
    {
        /// <summary>
        /// ファイルのハッシュを計算する
        /// </summary>
        /// <typeparam name="T">HashAlgorithm</typeparam>
        /// <param name="fileName">ファイル名</param>
        /// <param name="hashAlgorithm">ハッシュアルゴリズム Nullの場合、Tの既定ハッシュアルゴリズムを使用</param>
        /// <returns></returns>
        public static byte[] GetHashFromFile<T>(string fileName, T hashAlgorithm) where T : HashAlgorithm, new()
        {
            try
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    if (hashAlgorithm == null)
                    {
                        using (var hashProvider = new T())
                        {
                            return hashProvider.ComputeHash(fileStream);
                        }
                    }
                    else
                    {
                        return hashAlgorithm.ComputeHash(fileStream);
                    }

                }
            }
            catch (Exception)
            {
                // FileStream周りでExceptionが発生する可能性あり
                // 例外処理をそのままスローする
                throw;
            }
        }

        public static string ConvertHashString(byte[] hash)
        {
            if (hash == null)
            {
                throw new ArgumentNullException("hash");
            }

            return BitConverter.ToString(hash).ToLower(CultureInfo.CurrentCulture).Replace("-", "");
        }
    }
}
