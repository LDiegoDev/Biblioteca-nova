namespace Biblioteca.Business.Models
{
    public abstract class EntityModel
    {
        public Guid Id { get; set; }

        protected EntityModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
