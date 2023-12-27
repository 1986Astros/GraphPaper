namespace SharkInSeine
{
    partial class GraphPaperControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printDialog1 = new PrintDialog();
            SuspendLayout();
            // 
            // printDocument1
            // 
            printDocument1.BeginPrint += printDocument1_BeginPrint;
            printDocument1.EndPrint += printDocument1_EndPrint;
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printDialog1
            // 
            printDialog1.Document = printDocument1;
            printDialog1.UseEXDialog = true;
            // 
            // GraphPaperControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Name = "GraphPaperControl";
            Paint += GraphPaperControl_Paint;
            ResumeLayout(false);
        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintDialog printDialog1;
    }
}
