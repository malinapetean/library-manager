using library_manager.controller;
using library_manager.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlUpdateBook : Panel
    {
        private Book book;
        private ControllerBooks books;
        private List<Book> listBooks;
        private Label updateBook;
        private Label id;
        private Label title;
        private Label author;
        private Label year;
        private Label description;
        private TextBox txtId;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtYear;
        private TextBox txtDescription;

        private Button cancel;
        private Button delete;
        private Button update;
        private Form1 form;

        public PnlUpdateBook(Book book, Form1 form)
        {
            this.Width = 633;
            this.Height = 355;
            this.Location = new System.Drawing.Point(198, 71);
            this.BackColor = Color.Gray;

            this.book = book;
           

            updateBook = new Label();
            updateBook.Location = new System.Drawing.Point(22, 12);
            updateBook.Width = 147;
            updateBook.Height = 34;
            updateBook.Text = "Update Book";
            Font smallFont = new Font("Times New Roman", 18);
            updateBook.BackColor = Color.RosyBrown;
            updateBook.Font = smallFont;
            this.Controls.Add(updateBook);

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
            txtId.Text = book.Id.ToString();
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
            txtTitle.Text = book.Title;
            txtTitle.Enabled = false;

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
            txtAuthor.Text = book.Author;
            txtAuthor.TextChanged += new EventHandler(update__TextChanged);

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
            txtYear.Text = book.Year.ToString();
            txtYear.TextChanged += new EventHandler(update__TextChanged);

            description = new Label();
            description.Width = 131;
            description.Height = 31;
            description.Location = new Point(318, 70);
            description.Text = "Description";
            description.Font = labels;
            this.Controls.Add(description);

            txtDescription = new TextBox();
            txtDescription.Location = new Point(318, 113);
            txtDescription.Width = 274;
            txtDescription.Height = 210;
            this.Controls.Add(txtDescription);
            txtDescription.Text = book.Description;
            txtDescription.TextChanged += new EventHandler(update__TextChanged);

            update = new Button();
            update.Location = new System.Drawing.Point(470, 276);
            update.Width = 150;
            update.Height = 29;
            update.Text = "Update book";
            update.Name = "updatebook";
            update.BackColor = Color.Gray;
            update.Click += new EventHandler(update_Click);
            this.Controls.Add(update);

            cancel = new Button();
            cancel.Location = new Point(350, 276);
            cancel.Width = 94;
            cancel.Height = 29;
            cancel.Text = "Cancel";
            cancel.BackColor = Color.RosyBrown;
            this.Controls.Add(cancel);
            cancel.Click += new EventHandler(cancel_Click);

            delete = new Button();
            delete.Location = new Point(470, 310);
            delete.Width = 94;
            delete.Height = 30;
            delete.Text = "Delete";
            delete.BackColor = Color.LightGray;
            this.Controls.Add(delete);
            delete.Click += new EventHandler(delete_Click);

            this.form = form;
            books = new ControllerBooks();


        }


        private void update_Click(object sender, EventArgs e)
        {

            if (!(txtAuthor.Text.Equals("") || txtDescription.Text.Equals("") || txtYear.Text.Equals("")))
            {
                this.books.updateBook(this.book);
                this.books.save();
                this.books.load();
                this.form.Controls.Add(new PnlMain(this.books.findAll(), form));
                this.form.Controls.Remove(this);
            }
            else
                MessageBox.Show(errorsCheck());

        }
        
        private void cancel_Click(object sender, EventArgs e)
        {
            this.form.Controls.Add(new PnlMain(this.books.findAll(),form));
            this.form.Controls.Remove(this);
        }
        private void delete_Click(object sender, EventArgs e)
        {
            this.books.delete(this.book);
            this.books.save();
            this.books.load();
            this.form.Controls.Add(new PnlMain(this.books.findAll(), form));
            this.form.Controls.Remove(this);
        }

        private void update__TextChanged(object sender,EventArgs e)
        {

            try
            {
                this.book.Author = txtAuthor.Text;
                this.book.Description = txtDescription.Text;
                this.book.Year = int.Parse(txtYear.Text);

            }
            catch(Exception exc)
            {

                MessageBox.Show("valoare invalida");
            }
        }

        private String errorsCheck()
        {
            String inf = "";
            if (txtAuthor.Text.Equals(""))
                inf += "Add author!";
            if (txtYear.Text.Equals(""))
                inf += "Add year!";
            if (txtDescription.Text.Equals(""))
                inf += "Add description!";
            return inf;
        }
    }
}
