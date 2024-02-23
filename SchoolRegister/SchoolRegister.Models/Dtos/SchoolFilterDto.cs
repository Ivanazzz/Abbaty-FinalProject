using SchoolRegister.Models.Common;
using SchoolRegister.Models.Entities;
using SchoolRegister.Models.Enums;

namespace SchoolRegister.Models.Dtos
{
    public class SchoolFilterDto : IFilter<School>
    {
        public string Name { get; set; }

        public SchoolType? Type { get; set; }

        public string Settlement { get; set; }

        public IQueryable<School> WhereBuilder(IQueryable<School> query)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(s => s.Name == Name);
            }

            if (Type.HasValue)
            {
                query = query.Where(s => s.Type == Type);
            }

            if (!string.IsNullOrEmpty(Settlement))
            {
                query = query.Where(s => s.Settlement.Name == Settlement);
            }

            query = query.Where(s => s.IsActive == true);

            return query;
        }
    }
}
