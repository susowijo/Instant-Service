using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace InstantService.API.Services.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class UtilService: IUtilService
    {
        #region Methodes (Public)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="separator"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public string JoinList(char separator, params string[] items)
        {
            return string.Join(separator, items);
        }

        /// <summary>
        /// Get location of file specify
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFilePath(string fileName)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return $"{directory}/Templates/{fileName}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetData(string fileName) => File.ReadAllText(GetFilePath(fileName));

        /// <summary>
        ///     This function generates a unique alpha numeric code containing limit characters
        /// </summary>
        /// <param name="limit">Represent the length of code</param>
        /// <returns></returns>
        public static string GenerateUniqueCode(int limit = 6)
        {
            StringBuilder builder = new StringBuilder();

            Enumerable
               .Range(65, 26) 
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(limit)
                .ToList().ForEach(e => builder.Append(e));

            return builder.ToString().ToUpper();
        }

        /// <summary>
        ///     This function generates a unique alpha numeric code containing limit characters
        /// </summary>
        /// <param name="limit">Represent the length of code</param>
        /// <param name="isString"> Is true if user want to generate aphanumeric chars</param>
        /// <returns></returns>
        public static string GenerateUniqueId(int limit = 6, bool isString = true)
        {
            Guid g = Guid.NewGuid();

            // Convert GUID to BigInteger
            BigInteger bigInt = new BigInteger(g.ToByteArray());

            var array = bigInt.ToString().ToCharArray().ToList();
            if (isString)
            {
                var strUnique = Guid.NewGuid().ToString().ToUpper().Replace("-", "").ToList();
                array.AddRange(strUnique);
            }

            var result = string.Join(" ", array.OrderBy(x => new Random().Next()).Take(limit)).Replace(" ", "");

            return result.ToString();
        }
        public static IEnumerable<string> GetDescriptions<T>()
        {
            var attributes = typeof(T).GetMembers()
                .SelectMany(member => member.GetCustomAttributes(typeof (DescriptionAttribute), true).Cast<DescriptionAttribute>())
                .ToList();

            return attributes.Select(x => x.Description);
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
        #endregion
    }
}