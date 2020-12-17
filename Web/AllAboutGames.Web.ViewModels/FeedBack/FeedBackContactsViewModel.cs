using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AllAboutGames.Web.ViewModels.FeedBack
{
    public class FeedBackContactsViewModel
    {
        [Required(ErrorMessage = "Text should be atleast 5 characters.")]
        [MinLength(5)]
        public string Text { get; set; }

        [Required(ErrorMessage = "About should be atleast 5 characters.")]
        [MinLength(5)]
        public string About { get; set; }
    }
}
