
using Tabula;
using Tabula.Detectors;
using Tabula.Extractors;
using UglyToad.PdfPig;


SimpleNurminenDetectionTest(@"pdfs/issue.pdf", 1);
SimpleNurminenDetectionTest(@"pdfs/issue2.pdf", 98);


void SimpleNurminenDetectionTest(string inputFile, int page)
{
    using (PdfDocument doc = PdfDocument.Open(inputFile, new ParsingOptions() { ClipPaths = false }))
    {
        // IExtractionAlgorithm ea = new SpreadsheetExtractionAlgorithm();
        // PageIterator pageIterator = ObjectExtractor.Extract(document);
        IDetectionAlgorithm da = new SimpleNurminenDetectionAlgorithm();
        var area = ObjectExtractor.ExtractPage(doc, page);
        var regions = da.Detect(area);
        Console.WriteLine($"Regions Found: {regions.Count}");
    }
}

