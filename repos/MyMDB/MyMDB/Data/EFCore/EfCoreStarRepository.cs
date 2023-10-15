﻿using MyMDB.Data.Model;
using MyMDB.Model;

namespace MyMDB.Data.EFCore
{
    public class EfCoreStarRepository : EfCoreRepository<Star, MyMDBContext>
    {
        public EfCoreStarRepository(MyMDBContext context) : base(context)
        {

        }
    }
}

