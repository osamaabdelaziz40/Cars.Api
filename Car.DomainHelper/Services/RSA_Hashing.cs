using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DomainHelper.Services
{
    public static class RSA_Hashing
    {
        private static string ComposeData(Dictionary<string, string> requestParameters)
        {
            try
            {
                if (requestParameters == null)
                    return string.Empty;

                string concatRequest = string.Empty;

                //The field names are sorted in ascending of parameter name. Specifically,
                requestParameters = requestParameters.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

                int parametersCount = 0;

                //Construct a string by concatenating the string form of the sorted field name-value pairs. 
                foreach (var item in requestParameters)
                {
                    if (item.Value != null && !string.IsNullOrWhiteSpace(item.Value))
                    {

                        if (parametersCount < requestParameters.Count - 1)
                        {
                            concatRequest += string.Format("{0}={1}&", item.Key, item.Value);
                        }
                        else
                        {
                            concatRequest += string.Format("{0}={1}", item.Key, item.Value);
                        }
                    }

                    parametersCount++;
                }

                return concatRequest;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Generates the secure hash.
        /// Merchant integrations are required to generate a secure hash using the SHA-256 HMAC algorithm.
        /// </summary>
        /// <param name="requestParameters">The request parameters.</param>
        /// <returns></returns>
        /// 

        public static string Generate(string secretKey, object model)
        {
            var json = new JavaScriptSerializer().Serialize(model);
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            data.Remove("SecureHashValue");
            string composedDate = ComposeData(data);
            var secureHash2 = GenerateSecureHash(composedDate, secretKey);
            return secureHash2;

        }

        public static string GenerateSecureHash(string concatRequest, string secretKey)
        {
            try
            {
                string secureHash = string.Empty;

                //generate Hash
                using (HMACSHA256 hmac = new HMACSHA256(HexStringToByteArray(secretKey)))
                {

                    // Compute the hash of the input parameters.
                    byte[] hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(concatRequest));

                    secureHash = ByteArrayToHexString(hashValue);
                }

                return secureHash;

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        public static string ByteArrayToHexString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", string.Empty);
        }

        public static byte[] HexStringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

    }
}
