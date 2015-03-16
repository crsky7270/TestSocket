namespace SocketServer
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
         this.RecListBox = new System.Windows.Forms.ListBox();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // RecListBox
         // 
         this.RecListBox.FormattingEnabled = true;
         this.RecListBox.ItemHeight = 31;
         this.RecListBox.Location = new System.Drawing.Point(35, 169);
         this.RecListBox.Name = "RecListBox";
         this.RecListBox.Size = new System.Drawing.Size(845, 531);
         this.RecListBox.TabIndex = 3;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(35, 39);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(248, 97);
         this.button1.TabIndex = 2;
         this.button1.Text = "Start Listening";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(347, 39);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(248, 97);
         this.button2.TabIndex = 4;
         this.button2.Text = "Stop Listening";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // button3
         // 
         this.button3.Location = new System.Drawing.Point(674, 76);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(167, 60);
         this.button3.TabIndex = 5;
         this.button3.Text = "button3";
         this.button3.UseVisualStyleBackColor = true;
         this.button3.Click += new System.EventHandler(this.button3_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(908, 767);
         this.Controls.Add(this.button3);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.RecListBox);
         this.Controls.Add(this.button1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListBox RecListBox;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button3;
   }
}

