using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbPSCReAlpha
{
    public static class ClPbHelper
    {
        public static String RemoveQuotes(String s)
        {
            String sR = s.Trim();
            if (s.StartsWith("\"") && s.EndsWith("\""))
            {
                sR = s.Substring(1, s.Length - 2).Trim();
            }
            else if (s.StartsWith("'") && s.EndsWith("'"))
            {
                sR = s.Substring(1, s.Length - 2).Trim();
            }
            return sR;
        }

        public static long GetDirectorySize(string p)
        {
            string[] a = Directory.GetFiles(p, "*.*", SearchOption.AllDirectories);
            long b = 0;
            foreach (string name in a)
            {
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            return b;
        }

        public static String FormatBytes(long lsize)
        {
            String s = "--";
            if (lsize > -1)
            {
                float f = lsize;
                String[] ss = new String[] { "B", "kB", "MB", "GB", "TB", "PB", "EB" };
                int i = 0;
                while (f > 1024)
                {
                    f = f / 1024;
                    i++;
                }
                if (i < ss.Length)
                {
                    s = f.ToString("0.00") + " " + ss[i];
                }
                else
                {
                    s = lsize.ToString() + " " + ss[0];
                }
            }
            return s;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        public static int LongestCommonSubstring(string str1, string str2, out string sequence)
        {
            sequence = string.Empty;
            if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
                return 0;

            int[,] num = new int[str1.Length, str2.Length];
            int maxlen = 0;
            int lastSubsBegin = 0;
            StringBuilder sequenceBuilder = new StringBuilder();

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] != str2[j])
                        num[i, j] = 0;
                    else
                    {
                        if ((i == 0) || (j == 0))
                            num[i, j] = 1;
                        else
                            num[i, j] = 1 + num[i - 1, j - 1];

                        if (num[i, j] > maxlen)
                        {
                            maxlen = num[i, j];
                            int thisSubsBegin = i - num[i, j] + 1;
                            if (lastSubsBegin == thisSubsBegin)
                            {//if the current LCS is the same as the last time this block ran
                                sequenceBuilder.Append(str1[i]);
                            }
                            else //this block resets the string builder if a different LCS is found
                            {
                                lastSubsBegin = thisSubsBegin;
                                sequenceBuilder.Length = 0; //clear it
                                sequenceBuilder.Append(str1.Substring(lastSubsBegin, (i + 1) - lastSubsBegin));
                            }
                        }
                    }
                }
            }
            sequence = sequenceBuilder.ToString();
            return maxlen;
        }

        public static void SaveGameIni(String sfilename, Dictionary<String, String> dcInfos, SimpleLogger sl)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(sfilename))
                {
                    sw.WriteLine("[Game]");
                    sw.WriteLine("Discs=" + dcInfos["discs"].Trim());
                    sw.WriteLine("Title=" + dcInfos["title"].Trim());
                    sw.WriteLine("Publisher=" + dcInfos["publisher"].Trim());
                    sw.WriteLine("Developer=" + dcInfos["developer"].Trim());
                    sw.WriteLine("Players=" + dcInfos["players"].Trim());
                    sw.WriteLine("Year=" + dcInfos["year"].Trim());
                    if (!String.IsNullOrEmpty(dcInfos["alphatitle"].Trim()))
                    {
                        sw.WriteLine("AlphaTitle=" + dcInfos["alphatitle"].Trim());
                    }
                }
            }
            catch(Exception ex)
            {
                if (null != sl)
                    sl.Fatal(ex.Message);
            }
        }
    }
}
