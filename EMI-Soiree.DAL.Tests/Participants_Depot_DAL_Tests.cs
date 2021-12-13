using EMI_Soiree.DAL;
using System;
using Xunit;

namespace EMI_Soiree.DAL.Tests
{
    public class Participants_Depot_DAL_Tests
    {
        [Fact]
        public void Participants_Depot_DAL_TesterGetAll()
        {
            var depot = new Participants_Depot_DAL();

            var participants = depot.GetAll();

            Assert.NotNull(participants);
        }

        [Fact]
        public void Participants_Depot_DAL_TesterGetByID()
        {
            var depot = new Participants_Depot_DAL();

            var participant = depot.GetByID(2);

            Assert.NotNull(participant);
            Assert.Equal(2, participant.ID);
            Assert.NotEmpty(participant.Nom);
           
        }

        [Fact]
        public void Participants_Depot_DAL_TesterInsert()
        {

            var participant = new Participants_DAL("Contant", "Magalie", 2);

            var depot = new Participants_Depot_DAL();

            depot.Insert(participant);

            Assert.NotNull(participant);
            //on vérifie si on a un Nom 
            Assert.NotNull(participant.Nom);
        }

        [Fact]
        public void Participants_Depot_DAL_TesterUpdate()
        {
            var participant = new Participants_DAL("Boucard", "Ines", 2);
            var depot = new Participants_Depot_DAL();

            depot.Insert(participant);
            depot.Update(participant);

            Assert.NotNull(participant);
            Assert.NotNull(participant.Nom); 
        }

        [Fact]
        public void Participants_Depot_DAL_TesterDelete()
        {

            var participant = new Participants_DAL("Leducq", "Erwann", 2);

            var depot = new Participants_Depot_DAL();

            depot.Insert(participant);

            depot.Delete(participant);

            Assert.Throws<Exception>(() => depot.GetByID(participant.ID)); //si je le récupère bien l'exception c'est bon
        }



    }
}
