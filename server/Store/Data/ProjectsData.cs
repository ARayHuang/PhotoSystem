using Microsoft.EntityFrameworkCore;
using Store.Context;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data
{
    class ProjectsData : IBulkData<Project>
    {
        private StoreContext m_Context;

        public ProjectsData(StoreContext context)
        {
            this.m_Context = context;
        }

        public void insertBulkData()
        {
            List<Project> _BulkData = generateData();

            m_Context.tblProjects.AddRange(_BulkData);
        }

        public List<Project> generateData()
        {
            List<Project> _BulkData = new List<Project>();

            User _User1 = new User
            {
                Id = 1,
                Username = "test01",
                Password = "123qwe",
                Role = 1,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            User _User2 = new User
            {
                Id = 2,
                Username = "test02",
                Password = "123qwe",
                Role = 2,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            _BulkData.Add(new Project
            {
                Id = 1,
                Name = "Project 1",
                Description = "Description for project 1",
                status = 1,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,

                Owner_id = _User1.Id,
            });

            _BulkData.Add(new Project
            {
                Id = 2,
                Name = "Project 2",
                Description = "Description for project 2",
                status = 2,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,

                Owner_id = _User2.Id,
            });


            return _BulkData;
        }
    }
}
