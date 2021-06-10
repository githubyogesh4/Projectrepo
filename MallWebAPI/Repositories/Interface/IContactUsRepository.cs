using BusinessEntities.Mall.RequestDto;
using Repositories.Mall;
using System.Collections.Generic;

namespace Repositories.Interface
{
    public interface IContactUsRepository
    {
        long Add(ContactUsRequest viewModel);
        long Delete(int ID);
        IEnumerable<DBContactUs> GetAll();
    }
}
