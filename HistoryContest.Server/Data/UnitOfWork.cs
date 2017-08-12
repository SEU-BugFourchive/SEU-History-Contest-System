﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HistoryContest.Server.Data.Repositories;

namespace HistoryContest.Server.Data
{
    public class UnitOfWork : IDisposable
    {
        public ContestContext context;
        private StudentRepository studentRepository;
        private QuestionSeedRepository questionSeedRepository;
        
        public UnitOfWork(ContestContext context)
        {
            this.context = context;
        }

        #region Repository Properties
        public StudentRepository StudentRepository
        {
            get { return studentRepository ?? (studentRepository = new StudentRepository(context)); }
            set { studentRepository = value; }
        }

        public QuestionSeedRepository QuestionSeedRepository
        {
            get { return questionSeedRepository ?? (questionSeedRepository = new QuestionSeedRepository(context)); }
            set { questionSeedRepository = value; }
        }
        #endregion

        public int Save()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        
        #region Disposal Setting
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!disposed && disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true); // 调用context的回收方法
            GC.SuppressFinalize(this); // 阻止系统自己回收
        }
        #endregion
    }
}