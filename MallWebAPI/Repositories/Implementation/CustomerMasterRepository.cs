using BusinessEntities.Mall.RequestDto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories.dbContext;
using Repositories.Interface;
using Repositories.Mall;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Implementation
{
    public class CustomerMasterRepository : ICustomerMasterRepository
    {
        protected ApplicationDbContext _Context;
        public CustomerMasterRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        [Obsolete]
        public long Add(CustomerMasterRequest viewModel)
        {
                var lst = _Context.Database.ExecuteSqlCommand(" EXECUTE  InsertCustomerMaster @FirstName,@LastName,@Email,@Password",
                     new SqlParameter("@FirstName", viewModel.FirstName),
                     new SqlParameter("@LastName", viewModel.LastName),
                     new SqlParameter("@Email", viewModel.EmailId),
                     new SqlParameter("@Password", viewModel.Password)
                 );
                return lst;
        }
        [Obsolete]
        public long Update(CustomerMasterRequest viewModel)
        {
                var lst = _Context.Database.ExecuteSqlCommand(" EXECUTE  UpdateCustomerMaster @CustomerId,@FirstName,@LastName,@Email,@Password",
                     new SqlParameter("@CustomerId", viewModel.Id),
                     new SqlParameter("@FirstName", viewModel.FirstName),
                     new SqlParameter("@LastName", viewModel.LastName),
                     new SqlParameter("@Email", viewModel.EmailId),
                     new SqlParameter("@Password", viewModel.Password)
                    // new SqlParameter("@ModifiedBy", 1),
                    // new SqlParameter("@ModifiedOn", Convert.ToDateTime(DateTime.Now.ToString()))
                 );
                return lst;
        }
        [Obsolete]
        public long Delete(int Id)
        {
            var lst = _Context.Database.ExecuteSqlCommand(" EXECUTE  DeleteCustomerMaster @CustomerId",
                    new SqlParameter("@CustomerId", Id)
                );

            return lst;
        }
        [Obsolete]
        public IEnumerable<DBCustomerMaster> GetAll()
        {
            List<DBCustomerMaster> lst = _Context.CustomerMasters.FromSql("GetAllUsers").ToList();
            
            return lst;
        }
        [Obsolete]
        public DBCustomerMaster GetbyId(int Id)
        {
             DBCustomerMaster lst = _Context.CustomerMasters.FromSql("GetCustomerbyId @CustomerId",
             new SqlParameter("@CustomerId", Id)).AsEnumerable(
             ).FirstOrDefault();
          
            return lst;
        }
        [Obsolete]
        public DBLogin Login(LoginRequest viewModel)
        {
            DBLogin lst = _Context.Logins.FromSql("GetCustomerLogin @UserName,@Password",
             new SqlParameter("@UserName", viewModel.UserName),
             new SqlParameter("@Password", viewModel.Password)
             ).FirstOrDefault();
            return lst;
        }
    }
}

