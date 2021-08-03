using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroProjectNew.Logging
{
    public static class Logings
    {
        public static void Logdetails(String Info, int ErrorFlag, int Heading, String Unused1, String Unused2, String Unused3)
        {
            Log.Logger = new LoggerConfiguration()
              .WriteTo.File(@"c:\Temp\XeroProject.txt", fileSizeLimitBytes: null, shared: true, retainedFileCountLimit: 7)
         .CreateLogger();

            var ErrorChar = "*******";
            var BeginningChars = "";
            if (Heading == 1)
            {
                BeginningChars = "-----------";
                Info = BeginningChars + Info + BeginningChars;
            }
            else if (Heading == 2)
            { BeginningChars = ""; }
            else if (Heading == 3)
            { BeginningChars = "    "; }
            else
                BeginningChars = "      ";


            switch (ErrorFlag)
            {
                case 0:
                    Log.Logger.Information(BeginningChars + Info);
                    break;
                case 1:
                    Log.Logger.Information(BeginningChars + ErrorChar + ' ' + Info + ErrorChar);
                    break;
            }

        }
    }
}
