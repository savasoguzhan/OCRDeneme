

using IronOcr;
using Newtonsoft.Json.Linq;

try
{
    //// Initializes IronTesseract for OCR and reads text from an image file.
    var ocr = new IronTesseract();
    //iamge path
    var result = ocr.Read("C:\\Users\\Bilgisayarim\\source\\pm\\OCRDeneme\\OCRDeneme\\bin\\Debug\\net8.0\\images\\market-fis.jpg");

    // Extracts the text result from the OCR operation and splits it into lines.
    string ocrResult = result.Text;
    string[] lines = ocrResult.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

    // Creates a new JSON object using JObject from the Newtonsoft.Json library.
    JObject jsonResponse = new JObject();

    //loop is adjusted to start from 1 instead of 0 to begin indexing from 1.
    for (int i = 1; i < lines.Length; i++)
    {
        jsonResponse[i.ToString()] = lines[i - 1];
    }

    // JSON Response
    Console.WriteLine($"JSON Response:\n{jsonResponse}");

    // Creates a new JSON object and adds the OCR text extracted from the result to it.
    JObject jsonResult = new JObject();
    jsonResult["OCRText"] = result.Text;

    // JSON result
    Console.WriteLine($"Json Result: \n{jsonResult}");

}
catch (Exception ex)
{
    Console.WriteLine("Error " + ex.Message);
    throw;
}

