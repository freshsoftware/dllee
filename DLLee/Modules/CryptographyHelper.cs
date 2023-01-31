using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DLLee.Modules
{
    public static class CryptographyHelper
    {
        public static string GetMD5hashOfFile(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }


        public static string GetDigitalSignature(string filename)
        {
            //https://stackoverflow.com/questions/25676538/how-do-i-read-the-common-name-from-the-client-certificate
            try
            {
                var cert = X509Certificate.CreateFromSignedFile(filename);
                var cert2 = new X509Certificate2(cert.Handle);
                bool valid = cert2.Verify();
                if (valid)
                {
                    //return cert2.GetName();
                    //var kvs = cert.Subject.Split(',').Select(x => new KeyValuePair<string, string>(x.Split('=')[0], x.Split('=')[1])).ToList();
                    //return kvs[0];

                    return GetCNfromSubjectArray(cert2.Subject);
                    //X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                    //store.Open(OpenFlags.ReadOnly);
                    //store.Certificates
                }
                else
                {

                    return GetCNfromSubjectArray(cert2.Subject) + "?";// return "??";
                }
            }
            catch
            {
                return "n/a";
            }

        }

        public static string GetCNfromSubjectArray(string subject)
        {
            // split the subject into its parts
            string[] subjectArray = subject.Split(',');
            string[] nameParts;
            string CN = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;

            foreach (string item in subjectArray)
            {
                string[] oneItem = item.Split('=');
                // Split the Subject CN information
                if (oneItem[0].Trim() == "CN")
                {
                    CN = oneItem[1];
                    if (CN.IndexOf(".") > 0)
                    {// Split the name information
                        nameParts = CN.Split('.');
                        lastName = nameParts[0];
                        firstName = nameParts[1];
                    }

                    return CN;
                }
            }
            return "";
        }
    }
}
