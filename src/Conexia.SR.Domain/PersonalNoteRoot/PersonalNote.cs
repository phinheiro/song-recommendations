using Conexia.Core.DomainObjects;
using System;

namespace Conexia.SR.Domain.PersonalNoteRoot
{
    public class PersonalNote : Entity
    {
        public string Title { get; private set; }
        public string Body { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid UserId { get; private set; }

        protected PersonalNote() 
        { }
        public PersonalNote(string title, string body, DateTime createdAt, Guid userId)
        {
            Title = title;
            Body = body;
            CreatedAt = createdAt;
            UserId = userId;

            Validate();
        }

        public void ChangeTitle(string title)
        {
            Validations.ValidateFill(Title, "The field 'Title' is required");
            Title = title;
        }

        public void ChangeBody(string body)
        {
            Validations.ValidateFill(Body, "The field 'Body' is required");
            Body = body;
        }

        public void Validate()
        {
            Validations.ValidateFill(Title, "The field 'Title' is required");
            Validations.ValidateFill(Body, "The field 'Body' is required");
            Validations.ValidateEmptyGuid(UserId, "The field 'UserId' is required");
        }
    }
}
