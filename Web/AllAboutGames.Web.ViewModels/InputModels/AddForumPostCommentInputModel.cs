using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AllAboutGames.Web.ViewModels.InputModels
{
    public class AddForumPostCommentInputModel
    {
        [Required]
        public string Text { get; set; }

        public string PostId { get; set; }
    }
}
