namespace Ambulance_API_CQRS.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\", ({key}) Not Found") { }
      
    }
}
