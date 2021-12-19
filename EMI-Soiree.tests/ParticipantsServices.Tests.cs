using System;
using EMI_Soiree;
using Xunit;

namespace EMI_Soiree.tests
{
    public class ParticipantsServices_Tests
    {
        [Fact]
        public void ParticipantsServices_TesterGetALL()
        {
            var depot = new ParticipantsService();

            var participants = depot.GetAll();

            Assert.NotNull(participants);

        }
        [Fact]
        public void Participants_TesterGetById()
        {
            var depot = new ParticipantsService();
            var participants = depot.GetByID(6);

            Assert.NotNull(participants);
            Assert.Equal(6, participants.ID);
            Assert.NotEmpty(participants.Nom);
            Assert.IsType<Participants>(participants);
        }
        [Fact]
        public void Participants_TesterInsert()
        {
            var participant = new Participants("Malherbe", "Eline", 2);
            var depot = new ParticipantsService();

            depot.Insert(participant);

            Assert.NotNull(participant);
            Assert.Equal("Malherbe",participant.Nom);
            Assert.Equal("Eline",participant.Prenom);
            Assert.Equal(2,participant.IdSoiree);
            Assert.IsType<Participants>(participant);

        }
        [Fact]
        public void Particpants_TesterUpdate()
        {
            var participant = new Participants("Contant", "Magalie", 2);
            var depot = new ParticipantsService();

            depot.Insert(participant);
            depot.Update(participant);

            Assert.NotNull(participant);
            Assert.Equal("Contant",participant.Nom);
            Assert.Equal("Magalie",participant.Prenom);
            Assert.Equal(2,participant.IdSoiree);
            Assert.IsType<Participants>(participant);
        }
        [Fact]
        public void Participants_TesterDelete()
        {
            var participant = new Participants("Contant", "Magalie", 2);
            var depot = new ParticipantsService();

            depot.Insert(participant);
            depot.Delete(participant);

            Assert.Throws<Exception>(() => depot.GetByID(participant.ID));

        }
    }
}
