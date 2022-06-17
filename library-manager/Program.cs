using library_manager.controller;
using library_manager.model;
using System;

namespace library_manager
{
    class Program
    {
        static void Main(string[] args)
        {
            ControllerBooks controlerB = new ControllerBooks();
            Book b = new Book(2, "Namekagon", "Widdall", 2010, "Two00 brothers are fighting for the legacy");
            controlerB.updateBook(b);
       
            
        }
    }
}
