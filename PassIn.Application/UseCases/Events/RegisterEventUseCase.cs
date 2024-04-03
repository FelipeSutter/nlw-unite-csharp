using PassIn.Communication.Requests;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events
{
    public class RegisterEventUseCase
    {

        public void Execute(RequestEventJson request)
        {
            Validate(request);

            var dbContext = new PassInDbContext();

            var entity = new Infrastructure.Entities.Event
            {
                Title = request.Title,
                Details = request.Details,
                Maximum_Attendees = request.MaximumAttendees,
                // Slug é basicamente uma etiqueta, vai converter o titulo para minusculo,
                // tirar os espaços e colocar traço no lugar
                Slug = request.Title.ToLower().Replace(" ", "-"),
            };
            // System.Exception: 'You need to call SQLitePCL.raw.SetProvider().
            // If you are using a bundle package, this is done by calling SQLitePCL.Batteries.Init().'
            // Erro que está dando na hora de adicionar
            dbContext.Events.Add(entity);
            dbContext.SaveChanges();
        }

        private void Validate(RequestEventJson request)
        {
            if(request.MaximumAttendees <= 0)
            {
                throw new PassInException("The Maximum attendees is invalid.");
            }
            
            // Diferença do isEmpty é que os espaços vazios também são inválidos.
            if(string.IsNullOrWhiteSpace(request.Title))
            {
                throw new PassInException("The title is invalid");
            }

            if (string.IsNullOrWhiteSpace(request.Details))
            {
                throw new PassInException("The Details is invalid");
            }

        }

    }
}
