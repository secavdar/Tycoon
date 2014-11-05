using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Transactions;
using System.Web;
using System.Web.SessionState;
using System.Security.Cryptography;
using System.Text;

namespace Project.Domain.Base
{
    using Model;
    using Repository;
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork()
        {
            _context = new ProjectContext();
            _repositories = new List<object>();
        }
        private readonly ProjectContext _context;
        private readonly List<object> _repositories;
        private TransactionScope _transactionScope;
        private HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }
        private User CurrentUser
        {
            get { return Session["CurrentUser"] as User; }
        }
        private string ErrorMessage
        {
            set { Session["ErrorMessage"] = value; }
        }

        public BaseRepository<T> Call<T>() where T : class
        {
            BaseRepository<T> repository = null;

            foreach (var item in _repositories)
            {
                if (item is BaseRepository<T>)
                {
                    repository = item as BaseRepository<T>;
                    continue;
                }
            }

            if (repository == null)
            {
                repository = new BaseRepository<T>(_context);
                _repositories.Add(repository);
            }

            return repository;
        }

        public virtual void Begin()
        {
            _transactionScope = new TransactionScope();
        }
        public virtual void Commit()
        {
            try
            {
                _context.SaveChanges();

                if (_transactionScope != null)
                    _transactionScope.Complete();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var item in ex.EntityValidationErrors)
                    foreach (var item2 in item.ValidationErrors)
                        Log(item2.ErrorMessage, 1, 1);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                if (!String.IsNullOrEmpty(ex.Message) && ex.Message.Contains("duplicate"))
                    Log("Aynı kaydı birden fazla kez oluşturamazsınız.", 1, 1);
            }
            finally
            {
                if (_transactionScope != null)
                    _transactionScope.Dispose();
            }
        }
        public virtual void Log(string message, int statusID, int logTypeID)
        {
            //LogService.LogServiceClient service = new LogService.LogServiceClient();

            //service.Write(new LogService.UserLog()
            //{
            //    TargetUserName = CurrentUser.UserName,
            //    UserName = HttpContext.Current.User.Identity.Name.Split('\\').Last(),
            //    Description = message,
            //    StatusID = 1,
            //    LogTypeID = 1,
            //    ProjectID = 3,
            //    LogDate = DateTime.Now,
            //    IPAddress = HttpContext.Current.Request.UserHostAddress
            //});

            ErrorMessage = message;
        }
        public virtual void ExecuteSqlCommand(string query)
        {
            _context.Database.ExecuteSqlCommand(query);
        }
        public virtual void Truncate(string tableName)
        {
            ExecuteSqlCommand("delete from " + tableName);
        }
        public virtual string HashString(string input)
        {
            byte[] buffer = Encoding.GetEncoding(1254).GetBytes(input);
            SHA512 sha = new SHA512Managed();
            buffer = sha.ComputeHash(buffer);

            return Convert.ToBase64String(buffer);
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();

            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}