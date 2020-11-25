using System;
using System.Collections.Generic;
using System.Text;

namespace AllAboutGames.Web.ViewModels
{
    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public int GamesCount { get; set; }

        public int ItemsPerPage { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PagesCount => (int)Math.Ceiling((double)this.GamesCount / this.ItemsPerPage);

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;
    }
}
