using library_manager.controller;
using library_manager.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlMainAddBook:Panel
    {
        private Label newBook;
        private Label title;
        private Label author;
        private Label year;
        private Label id;
        private Label description;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtYear;
        private TextBox txtId;
        private TextBox txtDescription;
        private Button add;
        private Button cancel;
        private Book book;
        private PnlMainAddBook mainadd;
        private PnlMain main;
        private ControllerBooks books;
        private List<Book> listBooks;

    
      
        private Form1 form;

        
        public PnlMainAddBook(Form1 form)
        {
            books = new ControllerBooks();
            listBooks = new List<Book>();

            this.Width = 633;
            this.Height = 355;
            this.Location = new System.Drawing.Point(198, 71);
            this.BackColor = Color.Beige;

            

            newBook = new Label();
            newBook.Location = new System.Drawing.Point(22, 12);
            newBook.Width = 147;
            newBook.Height = 34;
            newBook.Text = "New Book";
            Font smallFont = new Font("Times New Roman",18);
            newBook.BackColor = Color.RosyBrown;
            newBook.Font = smallFont;
            this.Controls.Add(newBook);

            id = new Label();
            id.Location = new System.Drawing.Point(22, 70);
            id.Width = 34;
            id.Height = 31;
            id.Text = "Id";
            Font labels = new Font("Times New Roman", 14);
            id.Font = labels;
            this.Controls.Add(id);

            txtId = new TextBox();
            txtId.Location = new System.Drawing.Point(22, 104);
            txtId.Width = 84;
            txtId.Height = 27;
            this.Controls.Add(txtId);
            txtId.Text = books.nextId().ToString();
            txtId.Enabled = false;


            title = new Label();
            title.Location = new System.Drawing.Point(22, 134);
            title.Width = 58;
            title.Height = 31;
            title.Text = "Title";
            title.Font = labels;
            this.Controls.Add(title);

            txtTitle = new TextBox();
            txtTitle.Location = new System.Drawing.Point(23, 168);
            txtTitle.Width = 189; 
            txtTitle.Height = 27;
            this.Controls.Add(txtTitle);
            txtTitle.TextChanged += new EventHandler(details_TextChanged);

            author = new Label();
            author.Location = new System.Drawing.Point(22, 198);
            author.Width = 84; 
            author.Height = 31;
            author.Text = "Author";
            author.Font = labels;
            this.Controls.Add(author);

            txtAuthor = new TextBox();
            txtAuthor.Location = new System.Drawing.Point(23, 232);
            txtAuthor.Width = 189;
            txtAuthor.Height = 27;
            this.Controls.Add(txtAuthor);
            txtAuthor.TextChanged += new EventHandler(details_TextChanged);

            year = new Label();
            year.Location = new System.Drawing.Point(22, 262);
            year.Width = 57;
            year.Height = 31;
            year.Text = "Year";
            year.Font = labels;
            this.Controls.Add(year);

            txtYear = new TextBox();
            txtYear.Location = new System.Drawing.Point(23, 296);
            txtYear.Width = 125; 
            txtYear.Height = 27;
            this.Controls.Add(txtYear);
            txtYear.TextChanged += new EventHandler(details_TextChanged);

            description = new Label();
            description.Location = new System.Drawing.Point(318, 70);
            description.Width = 131;
            description.Height = 31;
            description.Text = "Description";
            description.Font = labels;
            this.Controls.Add(description);

            txtDescription = new TextBox();
            txtDescription.Location = new System.Drawing.Point(318, 113);
            txtDescription.Width = 274; 
            txtDescription.Height = 210;
            this.Controls.Add(txtDescription);
            txtDescription.TextChanged += new EventHandler(details_TextChanged);

            add =new Button();
            add.Location = new System.Drawing.Point(498, 296);
            add.Width = 94;
            add.Height = 29;
            add.Text = "Add book";
            add.Name = "addNewBook";
            add.BackColor = Color.RosyBrown;
            add.Click += new EventHandler(ana_Click);
            this.Controls.Add(add);

            cancel = new Button();
            cancel.Location = new Point(371, 296);
            cancel.Width = 94;
            cancel.Height = 29;
            cancel.Text = "Cancel";
            cancel.BackColor = Color.RosyBrown;
            this.Controls.Add(cancel);
            cancel.Click += new EventHandler(cancel_Click);

            this.book = new Book();
            this.book.Id = this.books.nextId();

            this.form = form;

            this.Name = "mainAdd";

            
        }


        private void details_TextChanged(object sender, EventArgs e)
        {

            if (!txtAuthor.Text.Equals(""))
            {
                this.book.Author = txtAuthor.Text;
            }
            if(!txtTitle.Text.Equals(""))
            {
                this.book.Title = txtTitle.Text;
            }
            if(!txtYear.Text.Equals(""))
            {
                try
                {
                    this.book.Year = int.Parse(txtYear.Text);

                }catch(Exception ex)
                {

                    MessageBox.Show("an invalid");
                }




            }
            if(!txtDescription.Text.Equals(""))
            {
                this.book.Description = txtDescription.Text;
            }

        }



        private void ana_Click(object sender, EventArgs e)
        {
            

            if (!(txtAuthor.Text.Equals("") || txtTitle.Text.Equals("") || txtYear.Text.Equals("") || txtDescription.Text.Equals("")))
            {
                this.books.addBook(book);
                this.books.save();
                this.books.load();
                this.form.Controls.Add(new PnlMain(this.books.findAll(),form));
                this.form.Controls.Remove(this);


            }
            else
            {
                MessageBox.Show(checkErrors());
            }


        }
        private void cancel_Click(object sender, EventArgs e)
        {
            this.form.Controls.Add(new PnlMain(this.books.findAll(),form));
            this.form.Controls.Remove(this);
        }   




        public String checkErrors()
        {

            String text = "";
            if (book.Title.Equals(""))
            {
                text += "Trebuie introdus titlu ";
            }
            if(book.Author.Equals(""))
            {
                text += "Trebuie introdus autorul ";

            }
            if(book.Year==0)
            {
                text += "Trebuie introdus anul ";
            }
            if(book.Description.Equals(""))
            {
                text += "Trebuie introdusa descrierea ";

            }

            return text;
        }






    }
}
