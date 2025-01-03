﻿using ASIptvServer.Api.Models;

namespace ASIptvServer.Api.Interfaces
{
    public interface ITvService
    {
        List<TvModel> GetTv();
        TvModel GetTvId(int id);
        void SetTv(TvModel tvModel);
        List<CategoriesModel> GetCategoryTv();
        List<TvModel> GetCategoryTvId(string category);
        void SetCategoryTv(CategoriesModel categories);
    }
}
