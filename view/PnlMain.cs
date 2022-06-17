using library_manager.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlMain:Panel
    {
        private List<Book> books;
        private Book book;
        private List<PnlBook> pnlBooks;
        private PnlUpdateBook panelupdate;
        private Form1 form;
        
        public PnlMain(List<Book> books, Form1 form)
        {
            this.pnlBooks = new List<PnlBook>();
            this.Width = 633;
            this.Height = 355;
            this.Location = new Point(200, 72);
            this.BackColor = Color.Gray;
            this.form = form;
            this.books = books;
            createCards();
            ///panelupdate = new PnlUpdateBook(book);
            this.Name = "main";

           

        }
        

        public void createCards()
        {
            int x = 0, y = 0, ct = 0;

            foreach(Book book in books)
            {
                ct++;
                PnlBook pnlBoo = new PnlBook(book,form);
                
                pnlBoo.Location = new Point(x, y);
                
                this.Controls.Add(pnlBoo);
                this.pnlBooks.Add(pnlBoo);

                x += 200;
                if (ct % 3 == 0)
                {
                    x = 0;
                    y += 250;
                }

                if (y > this.Height)
                {
                    this.AutoScroll = true;
                   
                }

            }
           
        }
        private void book_Click(object sender, EventArgs e)
        {

            this.Controls.Clear();
            
            this.Controls.Add(panelupdate);
            

        }
        private void showTitle_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(book.Title);
            
        }









    }
}
