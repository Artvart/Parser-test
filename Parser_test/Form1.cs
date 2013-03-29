using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Parser_test
{
    public partial class Form1 : Form
    {
        String Version = "v0.35";
        Form2 f = new Form2();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Clear code parser " + Version;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open file dialog box init.    
            openFileDialog1.InitialDirectory = "c:\\" ;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
            openFileDialog1.FilterIndex = 1 ;
            openFileDialog1.RestoreDirectory = true ;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open file info for debbuging
                textBox1.Text = openFileDialog1.FileName;
            }
}

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "c:\\" ;
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*" ;
            saveFileDialog1.FilterIndex = 1 ;
            saveFileDialog1.RestoreDirectory = true ;
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = saveFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int All_Lines = System.IO.File.ReadAllLines(textBox1.Text).Length;
            progressBar1.Value = 0;
            progressBar1.Maximum = All_Lines;

            try
            {
                //Open file info for debbuging
                //textBox1.Text = openFileDialog1.FileName;
                // Counter for strings in file
                string line;

                //
                // Stream for reading and writing initialized.
                // Files to read and write configurated. 
                //

                System.IO.StreamReader file =
                    new System.IO.StreamReader(textBox1.Text);
                System.IO.StreamWriter output =
                    new System.IO.StreamWriter(textBox2.Text);

                // Output file header generator
                output.WriteLine("\u0022" + "REPORTING TIME" + "\u0022" + "," +
                    "\u0022" + "REPORT NUMBER" + "\u0022" + "," +
                    "\u0022" + "RECORDING ENTITY" + "\u0022" + "," +
                    "\u0022" + "CALL ID" + "\u0022" + "," +
                    "\u0022" + "CALL START" + "\u0022" + "," +
                    "\u0022" + "CLEAR CODE" + "\u0022" + "," +
                    "\u0022" + "CLEAR INFO" + "\u0022" + "," +
                    "\u0022" + "EXT CLEAR CODE" + "\u0022" + "," +
                    "\u0022" + "CALLING NUMBER" + "\u0022" + "," +
                    "\u0022" + "CALLED NUMBER" + "\u0022" + "," +
                    "\u0022" + "CONNECTED NUMBER" + "\u0022" + "," +
                    "\u0022" + "ROAMING NUMBER" + "\u0022" + "," +
                    "\u0022" + "ADDRESS NUMBER" + "\u0022" + "," +
                    "\u0022" + "CGR/BSC/PCM-TSL" + "\u0022" + "," +
                    "\u0022" + "LAC/CI/CELL BAND" + "\u0022"
                    );

                // Start reading file line by line
                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                    progressBar1.Value++;
                    // Getting report time here

                    if (line.Contains("REPORTING TIME"))
                    {
                        //Write report time to the output file and some formating 
                        //for date and time like this - "2013-02-23  10:11:32.09",
                        output.Write("\u0022" + line.Substring(22, line.Length - 22) + "\u0022" + ",");
                        // richTextBox for debbuging
                        //richTextBox1.Text += "\u0022" + line.Substring(22, line.Length - 22) + "\u0022" + ",";
                    }

                    if (line.Contains("REPORT NUMBER"))
                    {
                        //Write report time to the output file and some formating 
                        //for date and time like this - "2013-02-23  10:11:32.09",
                        output.Write("\u0022" + line.Substring(22, line.Length - 22).Trim() + "\u0022" + ",");
                        // richTextBox for debbuging
                        //richTextBox1.Text += "\u0022" + line.Substring(22, line.Length - 22) + "\u0022" + ",";
                    }

                    if (line.Contains("RECORDING ENTITY"))
                    {
                        //Write report time to the output file and some formating 
                        //for date and time like this - "2013-02-23  10:11:32.09",
                        output.Write("\u0022" + line.Substring(22, line.Length - 22).Trim() + "\u0022" + ",");
                        // richTextBox for debbuging
                        //richTextBox1.Text += "\u0022" + line.Substring(22, line.Length - 22) + "\u0022" + ",";
                    }

                    if (line.Contains("CALL ID"))
                    {
                        //Write report time to the output file and some formating 
                        //for date and time like this - "2013-02-23  10:11:32.09",
                        output.Write("\u0022" + line.Substring(22, line.Length - 22).Trim() + "\u0022" + ",");
                        // richTextBox for debbuging
                        //richTextBox1.Text += "\u0022" + line.Substring(22, line.Length - 22) + "\u0022" + ",";
                    }

                    if (line.Contains("CALL START"))
                    {
                        //Write report time to the output file and some formating 
                        //for date and time like this - "2013-02-23  10:11:32.09",
                        output.Write("\u0022" + line.Substring(22, 24).Trim() + "\u0022" + ",");
                        // richTextBox for debbuging
                        //richTextBox1.Text += "\u0022" + line.Substring(22, line.Length - 22) + "\u0022" + ",";
                    }

                    // Get clear code from string
                    if (line.Contains("  CLEAR CODE"))
                    {
                        output.Write("\u0022" + line.Substring(line.Length - 5, 5) + "\u0022" + ",");
                        //richTextBox1.Text += "\u0022" + line.Substring(line.Length - 5, 5) + "\u0022" + ",";
                    }

                    // Same here for clear info
                    if (line.Contains("CLEAR INFO"))
                    {
                        output.Write("\u0022" + line.Substring(line.IndexOf("CLEAR INFO : ") + 13, 18) + "\u0022" + ",");
                        //richTextBox1.Text += "\u0022" + line.Substring(line.IndexOf("CLEAR INFO : ") + 13, 18) + "\u0022" + ",";
                    }

                    // Same
                    if (line.Contains("EXT CLEAR CODE"))
                    {
                        //richTextBox1.Text += "\u0022" + line.Substring(23, 5) + "\u0022" + ",";
                        output.Write("\u0022" + line.Substring(23, 4) + "\u0022" + ",");
                    }

                    // Again
                    if (line.Contains("CALLING NUMBER"))
                    {
                        //richTextBox1.Text += "\u0022" + line.Substring(23, 14) + "\u0022" + ",";
                        output.Write("\u0022" + line.Substring(22, line.Length - 22).Trim() + "\u0022" + ",");
                    }

                    // And again
                    if (line.Contains("CALLED NUMBER"))
                    {
                        //richTextBox1.Text += "\u0022" + line.Substring(23, 14) + "\u0022" + ",";
                        output.Write("\u0022" + line.Substring(22, line.Length - 22).Trim() + "\u0022" + ",");
                    }
                    if (line.Contains("CONNECTED NUMBER"))
                    {
                        output.Write("\u0022" + line.Substring(22, line.Length - 22).Trim() + "\u0022" + ",");
                    }
                    if (line.Contains("ROAMING NUMBER"))
                    {
                        output.Write("\u0022" + line.Substring(22, line.Length - 22).Trim() + "\u0022" + ",");
                    }
                    if (line.Contains("ADDRESS NUMBER"))
                    {
                        output.Write("\u0022" + line.Substring(22, line.Length - 22).Trim() + "\u0022" + ",");
                    }

                    // Almost done
                    if (line.Contains("CGR/BSC/PCM-TSL"))
                    {
                        //richTextBox1.Text += "\u0022" + line + "\u0022" + ",";
                        output.Write("\u0022" + line.Substring(21, line.Length - 21) + "\u0022" + ",");
                    }

                    // One more
                    if (line.Contains("LAC/CI/CELL BAND"))
                    {
                        //richTextBox1.Text += "\u0022" + line + "\u0022" + ",";
                        output.Write("\u0022" + line.Substring(21, line.Length - 21) + "\u0022" + ",");
                    }

                    // Uff. New line for the next report here.
                    if (line.Contains("END OF REPORT"))
                    {
                        //richTextBox1.Text += "\n";
                        output.WriteLine();
                    }
                }

                // End of read\write streams
                file.Close();
                output.Close();

                // Debuging message
                MessageBox.Show("Done.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oooops: Error happend here. Original error: " + ex.Message);
                MessageBox.Show("Error parsing string " + counter.ToString());
                if (counter == All_Lines)
                {
                    MessageBox.Show("Last report is not valid.");
                }
            }
            }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void howToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        }
}
   
