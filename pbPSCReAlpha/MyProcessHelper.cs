using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbPSCReAlpha
{
    class MyProcessHelper
    {
        private String _exePath = string.Empty;
        private String _cmdParam = string.Empty;
        private StringBuilder consoleOutput = null;
        private int numOutputLines = 0;
        private StringBuilder consoleError = null;
        private int numErrorLines = 0;

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

        private void ConsoleErrorHandler(object sendingProcess, DataReceivedEventArgs errLine)
        {
            // Collect the command output
            if (!String.IsNullOrEmpty(errLine.Data))
            {
                numErrorLines++;
                // Add the text to the collected output
                consoleError.Append(Environment.NewLine + /*"[" + numOutputLines.ToString() + "] - " +*/ errLine.Data);
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
            int iLen = _exePath.LastIndexOf('\\');
            if (iLen > 0)
            {
                pProcess.StartInfo.WorkingDirectory = _exePath.Substring(0, iLen);
            }

            // Redirect the standard err of the command
            pProcess.StartInfo.RedirectStandardError = true;
            consoleError = new StringBuilder("");

            // Redirect the standard output of the command
            // This stream is read asynchronously using an event handler
            pProcess.StartInfo.RedirectStandardOutput = true;
            consoleOutput = new StringBuilder("");

            // Set our event handler to asynchronously read the output
            pProcess.OutputDataReceived += new DataReceivedEventHandler(ConsoleOutputHandler);

            // Set our event handler to asynchronously read the err
            pProcess.ErrorDataReceived += new DataReceivedEventHandler(ConsoleErrorHandler);

            // Redirect standard input as well.  This stream is used synchronously
            pProcess.StartInfo.RedirectStandardInput = true;

            // Start the process
            pProcess.Start();

            // Start the asynchronous read of the output stream
            pProcess.BeginOutputReadLine();
            // Start the asynchronous read of the err stream
            pProcess.BeginErrorReadLine();

            // Wait for the sort process to write the lines
            pProcess.WaitForExit();

            if (numOutputLines > 0)
            {
                // sResult += "Process result= " + numOutputLines + " line(s)" + Environment.NewLine;
                sResult += consoleOutput.ToString();
            }
            else
            {
                sResult += " No output to be displayed.";
            }

            if (numErrorLines > 0)
            {
                sResult += Environment.NewLine + "--------- Errors ---------" + Environment.NewLine + consoleError.ToString();
                //FlexibleMessageBox.Show(consoleError.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // bad idea, pngquant outputs errors only
            }

            pProcess.Close();

            return sResult;
        }
    }
}