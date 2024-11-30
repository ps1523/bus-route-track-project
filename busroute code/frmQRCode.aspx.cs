using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using IronBarCode;
using System.Drawing;

public partial class frmQRCode : System.Web.UI.Page
{
    dbconnectDataContext db = new dbconnectDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string busNumber = txt_busno.Text.Trim();
            
// Query for Route Details
var routeDetails = from stop in db.StopMasters
                   where stop.BusNumber == busNumber
                   orderby stop.Stop_no ascending
                   select new
                   {
                       stop.Stop_no,
                       stop.Stop_name,
                       stop.Arrival_time,
                       stop.Charges
                   };

// Concatenate route details into a single string
StringBuilder qrMessageBuilder = new StringBuilder();
qrMessageBuilder.AppendLine("Bus Number: {busNumber}");

foreach (var stop in routeDetails)
{
    qrMessageBuilder.AppendLine("{stop.Stop_name}({stop.Arrival_time}) - Charge: {stop.Charges}");
}

string qrMessage = qrMessageBuilder.ToString();


        // Creating a barcode is as simple as:
        var myBarcode = BarcodeWriter.CreateBarcode("qrMessage", BarcodeWriterEncoding.EAN8);

        // And save our barcode as in image:
        myBarcode.SaveAsImage("~/Images/" + txt_busno.Text + ".jpg");
        QRImage.ImageUrl = Server.MapPath("~/Images/" + txt_busno.Text + ".jpg"); 


        //Image myBarcodeImage = myBarcode.Image; // Can be used as Image
        //Bitmap myBarcodeBitmap = myBarcode.ToBitmap(); // Can be used as Bitmap

        //// Reading a barcode is easy with IronBarcode:
        //var resultFromFile = BarcodeReader.Read(@"file/barcode.png"); // From a file
        //var resultFromBitMap = BarcodeReader.Read(new Bitmap("barcode.bmp")); // From a bitmap
        //var resultFromImage = BarcodeReader.Read(Image.FromFile("barcode.jpg")); // From an image
        //var resultFromPdf = BarcodeReader.ReadPdf(@"file/mydocument.pdf"); // From PDF use ReadPdf

        //// After creating a barcode, we may choose to resize and save which is easily done with:
        //var myNewBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);
        //myNewBarcode.ResizeTo(400, 100);
        //myNewBarcode.SaveAsImage("myBarcodeResized.jpeg");

        //// To set more options and optimization with your Barcode Reading,
        //// Please utilize the BarcodeReaderOptions paramter of read:
        //var myOptionsExample = new BarcodeReaderOptions
        //{
        //    // Choose a speed from: Faster, Balanced, Detailed, ExtremeDetail
        //    // There is a tradeoff in performance as more Detail is set
        //    Speed = ReadingSpeed.Balanced,

        //    // Reader will stop scanning once a barcode is found, unless set to true
        //    ExpectMultipleBarcodes = true,

        //    // By default, all barcode formats are scanned for.
        //    // Specifying one or more, performance will increase.
        //    ExpectBarcodeTypes = BarcodeEncoding.AllOneDimensional,

        //    // Utilizes multiple threads to reads barcodes from multiple images in parallel.
        //    Multithreaded = true,

        //    // Maximum threads for parallel. Default is 4
        //    MaxParallelThreads = 2,

        //    // The area of each image frame in which to scan for barcodes.
        //    // Will improve performance significantly and avoid unwanted results and avoid noisy parts of the image.
        //    CropArea = new Rectangle(),

        //    // Special Setting for Code39 Barcodes.
        //    // If a Code39 barcode is detected. Try to use extended mode for the full ASCII Character Set
        //    UseCode39ExtendedMode = true
        //};

        //// And, apply:
        //var results = BarcodeReader.Read("barcode.png", myOptionsExample);
    }
}