using library_manager.controller;
using library_manager.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlAsside:Panel
    {
        private Button addBook;
        private Button sortBooks;
       
       
        public PnlAsside(Button btnSort,Button btnAdd)
        {
            sortBooks = btnSort;
            sortBooks.Width = 90;
            sortBooks.Height = 30;
            sortBooks.Location = new System.Drawing.Point(48, 32);
            sortBooks.Text = "Sort Books";
            sortBooks.Name ="sort";
            sortBooks.BackColor = Color.White;
            this.Controls.Add(sortBooks);

            addBook= btnAdd; 
            addBook.Width = 110; 
            addBook.Height = 30;
            addBook.Location = new System.Drawing.Point(48, 80);
            addBook.Text = "Add New Book";
            addBook.Name = "newBook";
            addBook.BackColor = Color.White;
            this.Controls.Add(addBook);


            this.Width = 200;
            this.Height = 418;
            this.Location = new Point(0, 72);
            this.BackColor = Color.DarkBlue;

            this.Name = "asside";
            
        }

        
       

    }
}
