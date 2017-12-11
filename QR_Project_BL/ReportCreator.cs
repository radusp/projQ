using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace QR_Project_BL
{
    public class ReportCreator
    {
        private Dictionary<Result, int> dictionary;
        private VideoInfo _videoInfo;
        private StringBuilder FinalResult = new StringBuilder();

        public ReportCreator(VideoInfo _videoInfo, Dictionary<Result, int> dictionary)
        {
            this._videoInfo = _videoInfo;
            this.dictionary = dictionary;
        }

        public bool generateReport(string path)
        {
            foreach (var pair in dictionary)
            {
                calculateResultsForReport(pair);
                try
                {
                    File.WriteAllText(path + @"\report.txt", FinalResult.ToString());
                }
                catch (Exception ex)
                {

                }
            }
            return false;
        }

        private void calculateResultsForReport(KeyValuePair<Result, int> pair)
        {
            string itemReuslt = "";
            itemReuslt += pair.Key.Text + "   ";
            double secondOfOccurence = pair.Value / _videoInfo.fpsValue;
            itemReuslt += secondOfOccurence.ToString();
            FinalResult.AppendLine(itemReuslt);
        }
    }
}
