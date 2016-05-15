namespace Airports
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.get_flights = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.routesTextBox = new System.Windows.Forms.RichTextBox();
            this.startingAirportCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // get_flights
            // 
            this.get_flights.Location = new System.Drawing.Point(364, 402);
            this.get_flights.Name = "get_flights";
            this.get_flights.Size = new System.Drawing.Size(75, 23);
            this.get_flights.TabIndex = 1;
            this.get_flights.Text = "Get Flights";
            this.get_flights.UseVisualStyleBackColor = true;
            this.get_flights.Click += new System.EventHandler(this.get_flights_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Starting Airport:";
            // 
            // routesTextBox
            // 
            this.routesTextBox.Location = new System.Drawing.Point(12, 26);
            this.routesTextBox.Name = "routesTextBox";
            this.routesTextBox.Size = new System.Drawing.Size(427, 355);
            this.routesTextBox.TabIndex = 4;
            this.routesTextBox.Text = "";
            // 
            // startingAirportCombo
            // 
            this.startingAirportCombo.FormattingEnabled = true;
            this.startingAirportCombo.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G"});
            this.startingAirportCombo.Location = new System.Drawing.Point(112, 402);
            this.startingAirportCombo.Name = "startingAirportCombo";
            this.startingAirportCombo.Size = new System.Drawing.Size(203, 21);
            this.startingAirportCombo.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 522);
            this.Controls.Add(this.startingAirportCombo);
            this.Controls.Add(this.routesTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.get_flights);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button get_flights;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox routesTextBox;
        private System.Windows.Forms.ComboBox startingAirportCombo;
    }
}

