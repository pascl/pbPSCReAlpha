using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace pbPSCReAlpha
{
    class MyProcessHelper
    {
        private String _exePath = string.Empty;
        private String _cmdParam = string.Empty;
        private StringBuilder consoleOutput = null;
        private int numOutputLines = 0;

        public MyProcessHelper(String sExePath)
        {
            _exePath = sExePath;
        }

        public MyProcessHelper(String sExePath, String sCmdParam)
        {
            _exePath = sExePath;
            _cmdParam = sCmdParam;
        }

        private void ConsoleOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            // Collect the command output
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                numOutputLines++;
                // Add the text to the collected output
                consoleOutput.Append(Environment.NewLine + /*"[" + numOutputLines.ToString() + "] - " +*/ outLine.Data);
            }
        }

        public String DoIt()
        {
            String sResult = String.Empty;
            Process pProcess = new Process();
            pProcess.StartInfo.FileName = _exePath;
            if(!String.IsNullOrEmpty(_cmdParam))
            {
                pProcess.StartInfo.Arguments = _cmdParam;
            }

            pProcess.StartInfo.UseShellExecute = false;

            // Redirect the standard output of the command
            // This stream is read asynchronously using an event handler
            pProcess.StartInfo.RedirectStandardOutput = true;
            consoleOutput = new StringBuilder("");

            // Set our event handler to asynchronously read the output
            pProcess.OutputDataReceived += new DataReceivedEventHandler(ConsoleOutputHandler);

            // Redirect standard input as well.  This stream is used synchronously
            pProcess.StartInfo.RedirectStandardInput = true;

            // Start the process
            pProcess.Start();

            // Start the asynchronous read of the output stream
            pProcess.BeginOutputReadLine();

            // Wait for the sort process to write the lines
            pProcess.WaitForExit();

            if (numOutputLines > 0)
            {
                // sResult += "Process result= " + numOutputLines + " line(s)" + Environment.NewLine;
                sResult += consoleOutput.ToString();
            }
            else
            {
                sResult += " No lines to be displayed.";
            }
            pProcess.Close();

            return sResult;
        }
    }
}