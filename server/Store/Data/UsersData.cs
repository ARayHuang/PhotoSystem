using Microsoft.EntityFrameworkCore;
using Store.Context;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data
{
    public class UsersData : IBulkData<User>
    {
        private StoreContext m_Context;

        public UsersData(StoreContext context)
        {
            this.m_Context = context;
        }    

        public void insertBulkData()
        {
            List<User> _BulkData = generateData();

            m_Context.tblUsers.AddRange(_BulkData);
        }

        public List<User> generateData()
        {
            List<User> _BulkData = new List<User>();

            _BulkData.Add(new User
            {
                Id = 1,
                Username = "test01",
                Password = "123qwe",
                Role = 1,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            });

            _BulkData.Add(new User
            {
                Id = 2,
                Username = "test02",
                Password = "123qwe",
                Role = 2,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            });

            _BulkData.Add(new User
            {
                Id = 3,
                Username = "test03",
                Password = "123qwe",
                Role = 3,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            });

            _BulkData.Add(new User
            {
                Id = 4,
                Username = "test04",
                Password = "123qwe",
                Role = 4,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            });

            return _BulkData;
        }
    }
}
