using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PoConverter
{
    public static class PoFileWriter
    {
        public static void Override(string filePath, PoSheet sourceFile)
        {
            var linesToRead = File.ReadAllLines(filePath);
            var linesToWrite = new string[linesToRead.Length];
            linesToRead.CopyTo(linesToWrite, 0);
            PoRecord currentRecord = null;
            for (int i = PoFile.StartLine; i < linesToRead.Length; i++)
            {
                var currentLine = linesToRead[i];
                if(currentRecord == null)
                {
                    if(currentLine.StartsWith(PoFile.KeyIdentifier))
                    {
                        currentRecord = new PoRecord() { msgid = ExtractTextFromLine(currentLine) };
                    }
                }
                else if(currentLine.StartsWith(PoFile.ValueIdentifier))
                {
                    var sourceRecord = sourceFile.Records.FirstOrDefault(x => x.msgid == currentRecord.msgid);
                    if(sourceRecord != null)
                    {
                        linesToWrite[i] = BuildValueLine(sourceRecord.msgstr);
                    }
                    currentRecord = null;
                }
                else
                {
                    currentRecord = null;
                }
            }
            File.WriteAllLines(filePath, linesToWrite);
        }

        private static string BuildValueLine(string value)
        {
            return string.Format("{0} \"{1}\"", PoFile.ValueIdentifier, value);
        }

        private static string ExtractTextFromLine(string currentLine)
        {
            var startIndex = currentLine.IndexOf('"') + 1;
            return currentLine.Substring(startIndex, currentLine.Length - startIndex - 1);
        }
    }
}
