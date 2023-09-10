using ITicket.DAL.Entites;

namespace ITicket.MVC.ViewModels
{
    public class AllEventsViewModel
    {
        public List<Concert> Concerts = new List<Concert>();
        public List<KhayalKahvesi> KhayalKahvesis = new List<KhayalKahvesi>();
        public List<Kid> Kids = new List<Kid>();
        public List<MasterClass> MasterClasses = new List<MasterClass>();
        public List<Museum> Museums = new List<Museum>();
        public List<Other> Others = new List<Other>();
        public List<Pageant> Pageants = new List<Pageant>();
        public List<Seminar> Seminars = new List<Seminar>();
        public List<Sport> Sports = new List<Sport>();
        public List<Theatre> Theatres = new List<Theatre>();
        public List<Tourism> Tourisms = new List<Tourism>();

    }
}
