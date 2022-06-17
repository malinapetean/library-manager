using library_manager.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace library_manager.controller
{
    public class ControllerBooks
    {
        private List<Book> books;
        private Book book;
        public ControllerBooks()
        {
            books = new List<Book>();
            book = new Book();
            this.load();
        }
        
        public void load()
        {
            books.Clear();
            StreamReader read = new StreamReader(@"D:\mycode\Incapsularea\panels\library-manager\library-manager\sources\books.txt");
            string text = "";
            while((text=read.ReadLine())!=null)
            {
                this.books.Add(new Book(text));
            }
            read.Close();
        }
        public void display()
        {
            foreach(Book b in books)
            {
                Console.WriteLine(b.display());
            }
        }

        public List<Book> findAll()
        {

            return this.books;
        }

        public List<Book> sortBooks()
        {
            List<Book> alphabet =books;
            int sch = 0;
            while(sch==0)
            {
                sch = 1;
                for(int i=0;i<alphabet.Count-1;i++)
                {
                    if(alphabet[i].Title.CompareTo(alphabet[i+1].Title)>0)
                    {
                        Book b = alphabet[i];
                        alphabet[i] = alphabet[i + 1];
                        alphabet[i + 1] = b;
                        sch = 0;
                    }
                }
            }
            return alphabet;
        }
        public int nextId()
        {
            int nr = books.Count;
            return books[nr - 1].Id + 1;
        }
        public bool addBook(Book b)
        {
            if(existence(b)==false)
            {
                this.books.Add(b);
                return true;
            }
            return false;
            
        }
        public String toSave()
        {

            String text = "";
            int nr = books.Count;
            int i;

            for ( i = 0; i < nr-1;i++)
            {

                text += books[i].tosave()+"\n";
            }
            text += books[i].tosave();

            return text;
        }
        public bool existence(Book b)
        {
            for(int i=0;i<books.Count;i++)
            {
                if(books[i].Title.Equals(b.Title))
                {
                    return true;
                }
            }
            return false;
        }

        public bool existenceByTitle(string title)
        {
            for(int i=0;i<books.Count;i++)
            {
                if(books[i].Title.Equals(title))
                    return true;
            }
            return false;
        }
        public Book getbookByTitle(string title)
        {
            foreach(Book b in books)
            {
                if(b.Title.Equals(title))
                {
                    return b;
                }
            }
            return null;
        }
        public void updateBook(Book book)
        {
            foreach(Book b in books)
            {
                if(b.Title.Equals(book.Title))
                {
                    b.Author = book.Author;
                    b.Year = book.Year;
                    b.Description = book.Description;
                }
            }
            this.save();
        }
        public void delete(Book b)
        {

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.Equals(b.Title))
                {
                    books.RemoveAt(i);
                }
            }

            this.save();
        }
        public void save()
        {
            StreamWriter write = new StreamWriter(@"D:\mycode\Incapsularea\panels\library-manager\library-manager\sources\books.txt");
            write.Write(this.toSave());
            write.Close();
        }
    }
}
