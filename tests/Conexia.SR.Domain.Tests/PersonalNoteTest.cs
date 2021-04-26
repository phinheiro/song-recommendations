using Conexia.Core.DomainObjects;
using Conexia.SR.Domain.PersonalNoteRoot;
using System;
using Xunit;

namespace Conexia.SR.Domain.Tests
{
    public class PersonalNoteTest
    {
        [Fact]
        public void PersonalNote_ValidationsShouldReturnExceptions()
        {
            // Ttile validation
            var ex = Assert.Throws<DomainException>(() =>
                new PersonalNote("", "Esta é uma nota", DateTime.Now, Guid.NewGuid()));

            Assert.Equal("The field 'Title' is required", ex.Message);

            // Body validation
            ex = Assert.Throws<DomainException>(() =>
                new PersonalNote("Nova nota", "", DateTime.Now, Guid.NewGuid()));

            Assert.Equal("The field 'Body' is required", ex.Message);

            // UserId validation
            ex = Assert.Throws<DomainException>(() =>
                new PersonalNote("Nova nota", "Está é uma nota", DateTime.Now, Guid.Empty));

            Assert.Equal("The field 'UserId' is required", ex.Message);
        }

        [Fact]
        public void PersonalNote_ShouldChangeNoteTitle()
        {
            var note = new PersonalNote("Nova nota", "Esta é uma nota", DateTime.Now, Guid.NewGuid());
            var newTitle = "Titulo alterado";

            note.ChangeTitle(newTitle);
            Assert.Equal(newTitle, note.Title);
        }

        [Fact]
        public void PersonalNote_ShouldChangeNoteBody()
        {
            var note = new PersonalNote("Nova nota", "Esta é uma nota", DateTime.Now, Guid.NewGuid());
            var newBody = "Esta é uma nota alterada";

            note.ChangeBody(newBody);
            Assert.Equal(newBody, note.Body);
        }
    }
}
