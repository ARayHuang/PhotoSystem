using server.Helper;
using Store.Context;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Service
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
    public class UserService : IUserService
    {
        private IApplicationDbContext m_Context;

        public UserService(IApplicationDbContext context)
        {
            m_Context = context;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = m_Context.tblUsers.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return m_Context.tblUsers;
        }

        public User GetById(int id)
        {
            return m_Context.tblUsers.Find(id);
        }

        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (m_Context.tblUsers.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");  

            m_Context.tblUsers.Add(user);
            m_Context.Instance.SaveChanges();

            return user;
        }

        public void Update(User userParam, string password = null)
        {
            var user = m_Context.tblUsers.Find(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (m_Context.tblUsers.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");
            }

            // update user properties
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                user.Password = password;
            }

            m_Context.tblUsers.Update(user);
            m_Context.Instance.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = m_Context.tblUsers.Find(id);
            if (user != null)
            {
                m_Context.tblUsers.Remove(user);
                m_Context.Instance.SaveChanges();
            }
        }

        private static bool VerifyPasswordHash(string password)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            //if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            //if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            //using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            //{
            //    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            //    for (int i = 0; i < computedHash.Length; i++)
            //    {
            //        if (computedHash[i] != storedHash[i]) return false;
            //    }
            //}

            return true;
        }
    }
}
