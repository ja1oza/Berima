using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models.UserViewModels
{
    public class HistoryViewModel
    {
        public IEnumerable<Purchase> Purchases { get; set; }

        public int CurrentPage { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
