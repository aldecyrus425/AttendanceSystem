using MyApp.Domain.Exceptions;
namespace MyApp.Domain.Entities
{
    public class GradeLevel
    {
        public int GradeLevelId { get; internal set; }
        public string Name { get; internal set; }
        public string? Description { get; internal set; }

        protected GradeLevel() { } //For ORM

        public GradeLevel(string name, string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Grade level name is required");

            if (name.Length > 100)
                throw new DomainException("Grade level name must not exceed 100 characters");

            Name = name;
            Description = description;
        }


        public void Update(string name, string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Grade level name is required");

            if (name.Length > 100)
                throw new DomainException("Grade level name must not exceed 100 characters");

            Name = name;
            Description = description;
        }
    }
}
