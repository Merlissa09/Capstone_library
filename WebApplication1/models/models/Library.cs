using System;

namespace capstone_library.Models
{
    public abstract class LibraryItem
    {
        private int _id;
        private string _title;
        private bool _isAvailable;

        // Constructor to initialize the non-nullable fields
        public LibraryItem(string title)
        {
            _title = title;
            _isAvailable = true; // Initialize to a default value
        }

        public int Id
        {
            get => _id;
            protected set => _id = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public bool IsAvailable
        {
            get => _isAvailable;
            set => _isAvailable = value;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Item ID: {Id}, Title: {Title}, Available: {IsAvailable}");
        }
    }
}
