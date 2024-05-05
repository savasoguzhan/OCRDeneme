using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Tesseract;
using static TesserNet.Tesseract;

using var engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);

// JSON dosyasını okuyun (örneğin)
string jsonContent = File.ReadAllText("path/to/your/json/file.json");
JObject json = JObject.Parse(jsonContent);
string description = json["description"].ToString();

// Görüntüyü yükleyin ve OCR ile işleyin
using (var image = Pix.LoadFromFile("path/to/your/image.jpg"))
{
    using (var page = engine.Process(image))
    {
        // Tanımlanan metni alın
        var text = page.GetText();

        // Görüntüden ve JSON'dan alınan metinleri birleştirin
        string combinedText = CombineText(description, text);

        // Çıktıyı ekrana yazdırın
        Console.WriteLine(combinedText);
    }
}


static string CombineText(string description, string ocrText)
{
    // JSON'dan alınan metni başlangıçta ekleyin
    string combinedText = description + Environment.NewLine;

    // OCR'dan alınan metni ekleyin
    combinedText += ocrText;

    return combinedText;
}

