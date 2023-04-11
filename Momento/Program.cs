using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book()
            {
                Isbn = "1234",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };
            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "54683";
            book.Title = "Victor Hugo";
            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();

            Console.ReadLine();

        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _Isbn;
        private DateTime _lastEdited;

        public string Title
        {
            get => _title;
            set
            {
                SetLastEdited();
                _title = value;
            }
        }
        public string Author
        {
            get => _author;
            set
            {
                SetLastEdited();
                _author = value;
            }
        }
        public string Isbn
        {
            get => _Isbn;
            set
            {
                SetLastEdited();
                _Isbn = value;
            }
        }        

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_Isbn, _author, _title,_lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _lastEdited = memento.LastEdited;
            _Isbn = memento.Isbn;
        }

        public void ShowBook()
        {
            Console.WriteLine($"{Isbn} {Title} {Author} Edited: {_lastEdited}");
        }
        
    }

    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn, string title, string author, DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}

    
