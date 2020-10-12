using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TextFileAnalysis.Interface;

namespace TextFileAnalysis
{
    public class FileUpload : IFileUpload
    {
        public WordModel GetFilesMatchingWord(string result, string word)
        {
            var options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            result = result.Trim();
            var sentence = regex.Replace(result, " ");

            var arr = sentence.Split(new char[] { ' ' });
            var totalMatchingCount = Array.FindAll(arr, s => s.Trim().ToLower().Equals(word.Trim().ToLower())).Length;

            return new WordModel()
            {
                TotalWordCount = arr.Length,
                TotalMatchingCount = totalMatchingCount,
                WordOccuranceInPercentage = (totalMatchingCount * 100) / arr.Length,
            };
        }

        public string GetFileContent(IFormFile file)
        {
            var result = string.Empty;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    if (string.IsNullOrEmpty(result))
                    {
                        result = reader.ReadLine();
                    }
                    else
                    {
                        result = result + ' ' + reader.ReadLine();
                    }
                }
            }

            return result;
        }
    }
}