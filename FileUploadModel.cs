using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TextFileAnalysis
{
    public class FileUploadModel
    {
        public IFormFile AnalysisFile { get; set; }

        public string Word { get; set; }
    }
}