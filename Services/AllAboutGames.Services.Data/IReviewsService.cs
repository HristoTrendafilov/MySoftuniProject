﻿namespace AllAboutGames.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Reviews;

    public interface IReviewsService
    {
        Task AddAsync(AddReviewInputModel model);

        IEnumerable<AllReviewsViewModel> GetAll();
    }
}