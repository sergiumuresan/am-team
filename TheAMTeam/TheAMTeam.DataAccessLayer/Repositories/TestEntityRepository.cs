﻿using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class TestEntityRepository
    {
        public TestEntity Create(TestEntity testEntity)
        {
            TestEntity dbTestEntity;
            try
            {
                using (var context = new AppContext())
                {
                    //Create a new entry in table, and get the new object
                    dbTestEntity = context.TestEntities.Add(testEntity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //todo exeption handling
                throw ex;
            }

            return dbTestEntity;
        }

        public List<TestEntity> GetAll()
        {

            using (var context = new AppContext())
            {
                var result = context.TestEntities.ToList();
                return result;
            }

        }
    }
}
