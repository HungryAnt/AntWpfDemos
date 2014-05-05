using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo03.Models;
using Gods.Foundation;

namespace Demo03.ViewModels
{
    class BookViewModel : NotificationObject
    {
        private BookEntity _bookEntity;

        public BookViewModel(BookEntity bookEntity)
        {
            _bookEntity = bookEntity;
        }

        public string Titile
        {
            get { return _bookEntity.Title; }
            set
            {
                _bookEntity.Title = value;
                RaisePropertyChanged("Titile");
            }
        }

        public string Author
        {
            get { return _bookEntity.Author; }
            set
            {
                _bookEntity.Author = value;
                RaisePropertyChanged("Author");
            }
        }

        public double Price
        {
            get { return _bookEntity.Price; }
            set
            {
                _bookEntity.Price = value;
                RaisePropertyChanged("Price");
            }
        }

        
    }
}
