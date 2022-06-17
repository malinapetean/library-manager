using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using library_manager.controller;
using library_manager.model;

namespace view
{
    class PnlBook:Panel
    {
        private Book book;
        private PictureBox picture;
        private Label title;
        private TextBox description;
        private ControllerBooks control;
        private PnlUpdateBook pnlUpdate;
        private Form1 form;


        public PnlBook(Book book,Form1 form)
        {

            this.book = book;
            this.Location = new System.Drawing.Point(55, 55);
            this.Width = 180;
            this.Height = 230;
            this.BackColor = Color.BlueViolet;
            
            

            picture = new PictureBox();
            picture.Location = new System.Drawing.Point(26, 21);
            picture.Width =125;
            picture.Height =105;
            this.Controls.Add(picture);

            title = new Label();
            title.Location = new System.Drawing.Point(57,145);
            title.Width =70;
            title.Height =20;
            title.Text = book.Title;
            this.Controls.Add(title);
            

            description = new TextBox();
            description.Location = new System.Drawing.Point(13, 170);
            description.Width = 155;
            description.Height = 45;
            description.Multiline= true;
            description.Enabled = false;
            
            description.Text = book.Description;
            this.Controls.Add(description);

            this.Name = "books";

            this.Click += new EventHandler(book_Click);
            control = new ControllerBooks();

            this.form = form;
        }

        private void book_Click(object sender, EventArgs e)
        {

            this.form.erasePanel("main");
            //pnlUpdate = new PnlUpdateBook(control.getbookByTitle(book.Title),form);
            this.form.Controls.Add(new PnlUpdateBook(control.getbookByTitle(book.Title), form));
            //bool x = this.form != null;
            //MessageBox.Show(x.ToString());
  
        }

        



    }
}
