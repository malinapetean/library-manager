using library_manager.controller;
using library_manager.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace view
{
    public partial class Form1 : Form
    {
      
        //private Panel footer;
       
        private ControllerBooks books;
    

        private Button btnSort;
        private Button btnNewBook;
      

      
        public Form1()
        {
            InitializeComponent();
            this.books = new ControllerBooks();

            btnSort = new Button();
            this.btnSort.Click += new EventHandler(sort_Click);
            btnNewBook = new Button();
            this.btnNewBook.Click += new EventHandler(newBook_Click);

        
            this.Controls.Add(new PnlHeader());

          
            this.Controls.Add(new PnlAsside(btnSort, btnNewBook));

       
            this.Controls.Add(new PnlMain(books.findAll(),this));

            

           
            //footer = new Panel();
            //footer.Width = 633;
            //footer.Height = 68;
            //footer.Location = new Point(200, 422);
            //footer.BackColor = Color.BlueViolet;
            //footer.Name = "Created by Petean Anamaria";
            //this.Controls.Add(footer);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sort_Click(object sender, EventArgs e)
        {
            books.load();
            List<Book> sortedBook = books.sortBooks();

            erasePanel("main");
        
            this.Controls.Add(new PnlMain(sortedBook,this));

        }
        private void newBook_Click(object sender, EventArgs e)
        {
            erasePanel("main");
           this.Controls.Add( new PnlMainAddBook(this));
           
        }



        public void erasePanel(String name)
        {
                        
            Control cautat=null;

            foreach(Control aux in this.Controls)
            {
                if (aux.Name.Equals(name))
                {
                    cautat = aux;
                }
            }

            if(cautat!=null)
                this.Controls.Remove(cautat);
        }







    }
}
