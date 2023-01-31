using DLLee.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DLLee.Modules
{
    public class DLLinfoEngine
    {


        public List<DLLinformation> dllInfo = new List<DLLinformation>();


        public List<DLLinformation> GetDLLinfoForAFolder(string path_to_folder, bool subfolders=true)
        {
            SearchOption so;
            if (subfolders)
            {
                so = SearchOption.AllDirectories;
            } else so = SearchOption.TopDirectoryOnly;

            string[] files;
            files = Directory.GetFiles(path_to_folder, "*.dll", so);

            dllInfo.Clear();
            foreach (string file in files)
            {
                DLLinformation dll = GetInitialDLLinfo(file);

                dllInfo.Add(dll);

            }

            return dllInfo;
        }



        private DLLinformation GetInitialDLLinfo(string path_to_file)
        {
            //declare result object
            DLLinformation r = new DLLinformation();
            r.filename = path_to_file;

            //Size
            FileInfo fi = new FileInfo(path_to_file);
            int sizeinKb = Convert.ToInt32(fi.Length / 1024);

            //Signature
            string signer = CryptographyHelper.GetDigitalSignature(path_to_file);
             bool IsSigned = signer != "n/a";

            //initial values
            r.SizeInKB = sizeinKb;
            r.CodeSigned = IsSigned;
            r.CodeSignerName = signer;

            //Get reflection, if available.
            r = UpdateReflectionInfo(r);


            



            return r;
            
        }

        private DLLinformation UpdateReflectionInfo(DLLinformation di)
        {
            var HasDebuggableAttribute = false;
            var IsJITOptimized = false;
            var IsJITTrackingEnabled = false;
            var BuildType = "";
            var DebugOutput = "";
            bool x64 = false;


            Assembly ReflectedAssembly;
            try
            {
                ReflectedAssembly = Assembly.LoadFrom(di.filename);
            }
            catch (Exception ex)
            {
                di.exception_info = ex.Message;
                return di;
            }

            object[] attribs = ReflectedAssembly.GetCustomAttributes(typeof(DebuggableAttribute), false);

            // If the 'DebuggableAttribute' is not found then it is definitely an OPTIMIZED build
            if (attribs.Length > 0)
            {
                // Just because the 'DebuggableAttribute' is found doesn't necessarily mean
                // it's a DEBUG build; we have to check the JIT Optimization flag
                // i.e. it could have the "generate PDB" checked but have JIT Optimization enabled
                DebuggableAttribute debuggableAttribute = attribs[0] as DebuggableAttribute;
                if (debuggableAttribute != null)
                {
                    HasDebuggableAttribute = true;
                    IsJITOptimized = !debuggableAttribute.IsJITOptimizerDisabled;


                    // IsJITTrackingEnabled - Gets a value that indicates whether the runtime will track information during code generation for the debugger.
                    IsJITTrackingEnabled = debuggableAttribute.IsJITTrackingEnabled;
                    BuildType = debuggableAttribute.IsJITOptimizerDisabled ? "Debug" : "Release";

                    // check for Debug Output "full" or "pdb-only"
                    DebugOutput = (debuggableAttribute.DebuggingFlags &
                                    DebuggableAttribute.DebuggingModes.Default) !=
                                    DebuggableAttribute.DebuggingModes.None
                                    ? "Full" : "pdb-only";
                }
            }
            else
            {
                IsJITOptimized = true;
                BuildType = "Release";
            }

            //CPU arch
            ProcessorArchitecture pa = ReflectedAssembly.GetName().ProcessorArchitecture;

            //set values
            di.HasDebuggableAttribute = HasDebuggableAttribute;
            di.IsJITOptimized = IsJITOptimized;
            di.IsJITTrackingEnabled = IsJITTrackingEnabled;
            di.BuildType = BuildType;
            di.DebugOutput = DebugOutput;

            di.x86 = pa.Equals(ProcessorArchitecture.Amd64);
            di.procArch = pa.ToString();

            return di;
        }


    }
}
