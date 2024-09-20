using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MergePdf
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public static string PathSelected;

        private void btnMerge_Click(object sender, EventArgs e)
        {







            //// Create a document for the merged result.
            //Document mergedDocument = new Document();

            //// Keep a list of input streams to close when done.
            //List<FileStream> streams = new List<FileStream>();
            //foreach (FileInfo fileInfo in allPDFs)
            //{
            //    // Open input stream and add to list of streams.
            //    FileStream stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read);
            //    streams.Add(stream);

            //    // Open input document.
            //    Document document = new Document(stream);

            //    // Append all pages to target document.
            //    // The target document holds references to data in the input stream.
            //    // For efficiency it does not copy this data so the input streams
            //    // should not be closed before the merged document is saved.
            //    mergedDocument.Pages.AddRange(document.Pages.CloneToArray());
            //   }

            //// Save merged document.
            //using (FileStream output = new FileStream(@"..\..\output.pdf", FileMode.Create, FileAccess.Write))
            //{
            //    mergedDocument.Write(output);
            //}

            //// Close all input streams.
            //streams.ForEach(stream => stream.Close());




            try
            {

                DirectoryInfo directoryInfo = new DirectoryInfo(PathSelected);

                FileInfo[] allPDFs = directoryInfo.GetFiles("*.pdf");

                List<string> files = new List<string>();


                foreach (var item in allPDFs)
                {
                    files.Add(item.FullName);
                }

                var fileArray = files.ToArray();
                PdfDocumentBase doc = PdfDocument.MergeFiles(fileArray);


                string Outpath=PathSelected+"\\output.pdf";

                doc.Save(fileName: Outpath, FileFormat.PDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }









        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnMerge.Enabled = false;

        }

        private void btnFolderBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialogMain.ShowDialog();

            PathSelected = folderBrowserDialogMain.SelectedPath;

            if (PathSelected != null)
            {
                txtPath.Text = PathSelected;
                btnMerge.Enabled = true;
            }


        }
    }
}
