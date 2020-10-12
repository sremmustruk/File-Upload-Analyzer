using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace TextFileAnalysis
{
    public class WordModel
    {
        public int TotalWordCount { get; set; }
        public int TotalMatchingCount { get; set; }
        public double WordOccuranceInPercentage { get; set; }
    }
}