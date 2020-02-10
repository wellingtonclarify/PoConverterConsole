using System;
using System.IO;

namespace PoConverter
{
    public static class PoFileReader
    {
        public static PoFile Read(string filePath)
        {
            var file = new PoFile();
            var lines = File.ReadAllLines(filePath);
            PoRecord currentRecord = null;
            for (int i = PoFile.StartLine; i < lines.Length; i++)
            {
                var currentLine = lines[i];
                if(currentRecord == null)
                {
                    if(currentLine.StartsWith(PoFile.KeyIdentifier))
                    {
                        currentRecord = new PoRecord() { msgid = ExtractTextFromLine(currentLine) };
                    }
                }
                else if(currentLine.StartsWith(PoFile.ValueIdentifier))
                {
                    currentRecord.msgstr = ExtractTextFromLine(currentLine);
                    file.AddRecord(currentRecord);
                    currentRecord = null;
                }
                else
                {
                    currentRecord = null;
                }
            }
            return file;
        }

        private static string ExtractTextFromLine(string currentLine)
        {
            var startIndex = currentLine.IndexOf('"') + 1;
            return currentLine.Substring(startIndex, currentLine.Length - startIndex - 1);
        }
    }
}
