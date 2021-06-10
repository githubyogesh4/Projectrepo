using System;

namespace BusinessEntities
{
    public class BaseRequest
    {
        public BaseRequest()
        {
           // CreatedBy = 1;
           // ModifiedBy = 1;
            CreatedOn = DateTime.Now;
        }
        public int IsActive { get; set; }
       
        public DateTime? CreatedOn { get; set; }
        
    }
}
