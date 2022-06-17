using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace library_manager.model
{
    public class Book
    {
        private int id;
        private string title = "";
        private string author = "";
        private int year=0;
        private string description = "";

        public Book(string line)
        {
            this.id = int.Parse(line.Split(",")[0]);
            this.title = line.Split(",")[1];
            this.author = line.Split(",")[2];
            this.year = int.Parse(line.Split(",")[3]);
            this.description = line.Split(",")[4];
        }
        public Book(int id,string title,string author,int year,string description)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.year = year;
            this.description = description;

        }
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public string Title
        {
            get => this.title;
            set => this.title = value;
        }
        public string Author
        {
            get => this.author;
            set => this.author = value;
        }
        public int Year
        {
            get => this.year;
            set => this.year = value;
        }
        public string Description
        {
            get => this.description;
            set => this.description = value;
        }
        public string tosave()
        {
            string text = "";
            text += this.id + "," + this.title + "," + this.author + "," + this.year + "," + this.description;
            return text;
        }
    
        public string display()
        {
            string text = "";
            text += "The id is: " + this.id + "\n";
            text += "The title is: " + this.title+"\n";
            text += "The author is: " + this.author + "\n";
            text += "The year: " + this.year + "\n";
            text += "Description: " + this.description + "\n";
            return text;
        }

        public Book() { }
    }   
}
