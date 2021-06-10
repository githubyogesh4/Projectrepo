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
    public  class ContactUsRepository : IContactUsRepository
    {
        protected ApplicationDbContext _Context;
        public ContactUsRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        [Obsolete]
        public long Add(ContactUsRequest viewModel)
        {
                var lst = _Context.Database.ExecuteSqlCommand(" EXECUTE  InsertContactUs @FirstName,@LastName,@Email,@PhoneNumber,@Message,@CreatedOn",
                     new SqlParameter("@FirstName", viewModel.FirstName),
                     new SqlParameter("@LastName", viewModel.LastName),
                     new SqlParameter("@Email", viewModel.Email),
                     new SqlParameter("@PhoneNumber", viewModel.PhoneNumber),
                     new SqlParameter("@Message", viewModel.Message),
                     new SqlParameter("@CreatedOn", viewModel.CreatedOn)
                 );
                return lst;
        }
        [Obsolete]
        public long Delete(int Id)
        {
            var lst = _Context.Database.ExecuteSqlCommand(" EXECUTE  DeleteContactUs @ContactId",
                    new SqlParameter("@ContactId", Id)
                );

            return lst;
        }
        [Obsolete]
        public IEnumerable<DBContactUs> GetAll()
        {
            List<DBContactUs> lst = _Context.ContactUss.FromSql("GetAllContactUs").ToList();
            return lst;
        }
    }
}
