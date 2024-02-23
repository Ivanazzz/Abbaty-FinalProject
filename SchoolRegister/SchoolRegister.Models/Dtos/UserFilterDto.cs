using SchoolRegister.Models.Common;
using SchoolRegister.Models.Entities;

namespace SchoolRegister.Models.Dtos
{
    public class UserFilterDto : IFilter<User>
    {
        public string Username { get; set; }

        public string Phone { get; set; }

        public string SchoolName { get; set; }

        public IQueryable<User> WhereBuilder(IQueryable<User> query)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                query = query.Where(u => u.Username == Username);
            }

            if (!string.IsNullOrEmpty(Phone))
            {
                query = query.Where(u => u.Phone == Phone);
            }

            if (!string.IsNullOrEmpty(SchoolName))
            {
                query = query.Where(u => u.School.Name == SchoolName);
            }

            query = query.Where(u => u.IsActive == true);

            return query;
        }
    }
}
