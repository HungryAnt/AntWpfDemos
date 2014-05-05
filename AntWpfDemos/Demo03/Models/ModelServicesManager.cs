using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo03.Models
{
    class ModelServicesManager
    {
        private static ModelServicesManager _manager = new ModelServicesManager();

        public static ModelServicesManager Manager
        {
            get { return _manager; }
        }

        public ModelServicesManager()
        {
            BookService = new BookService();
        }

        public BookService BookService { get; set; }
    }
}
