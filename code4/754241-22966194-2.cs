    using System;
    using System.IO;
    using System.Linq;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    
    namespace WordMergeProject
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                byte[] word1 = File.ReadAllBytes(@"..\..\word1.docx");
                byte[] word2 = File.ReadAllBytes(@"..\..\word2.docx");
    
                byte[] result = Merge(word1, word2);
    
                File.WriteAllBytes(@"..\..\word3.docx", result);
            }
    
            private static byte[] Merge(byte[] dest, byte[] src)
            {
                string altChunkId = "AltChunkId" + DateTime.Now.Ticks.ToString();
    
                var memoryStreamDest = new MemoryStream();
                memoryStreamDest.Write(dest, 0, dest.Length);
                memoryStreamDest.Seek(0, SeekOrigin.Begin);
                var memoryStreamSrc = new MemoryStream(src);
    
                using (WordprocessingDocument doc = WordprocessingDocument.Open(memoryStreamDest, true))
                {
                    MainDocumentPart mainPart = doc.MainDocumentPart;
                    AlternativeFormatImportPart altPart =
                        mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                    altPart.FeedData(memoryStreamSrc);
                    var altChunk = new AltChunk();
                    altChunk.Id = altChunkId;
                                  OpenXmlElement lastElem = mainPart.Document.Body.Elements<AltChunk>().LastOrDefault();
                if(lastElem == null)
                {
                    lastElem = mainPart.Document.Body.Elements<Paragraph>().Last();
                }
                //Page Brake einfügen
                Paragraph pageBreakP = new Paragraph();
                Run pageBreakR = new Run();
                Break pageBreakBr = new Break() { Type = BreakValues.Page };
                pageBreakP.Append(pageBreakR);
                pageBreakR.Append(pageBreakBr);                
    
                return memoryStreamDest.ToArray();
            }
        }
    }
