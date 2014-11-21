namespace Client
{
    partial class FormClient
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbMessages = new System.Windows.Forms.TextBox();
            this.tbMessageToSend = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbMessages, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbMessageToSend, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btSend, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(524, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbMessages
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbMessages, 2);
            this.tbMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessages.Location = new System.Drawing.Point(3, 3);
            this.tbMessages.Multiline = true;
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.Size = new System.Drawing.Size(518, 165);
            this.tbMessages.TabIndex = 0;
            // 
            // tbMessageToSend
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbMessageToSend, 2);
            this.tbMessageToSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessageToSend.Location = new System.Drawing.Point(3, 174);
            this.tbMessageToSend.Multiline = true;
            this.tbMessageToSend.Name = "tbMessageToSend";
            this.tbMessageToSend.Size = new System.Drawing.Size(518, 54);
            this.tbMessageToSend.TabIndex = 1;
            // 
            // btSend
            // 
            this.btSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSend.Location = new System.Drawing.Point(427, 234);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(94, 24);
            this.btSend.TabIndex = 2;
            this.btSend.Text = "Отправить";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormClient";
            this.Text = "Сообщения";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClient_FormClosed);
            this.Load += new System.EventHandler(this.FormClient_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbMessages;
        private System.Windows.Forms.TextBox tbMessageToSend;
        private System.Windows.Forms.Button btSend;
    }
}

