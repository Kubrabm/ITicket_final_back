using ITicket.DAL.Entites;

namespace ITicket.MVC.ViewModels
{
    public class HomeViewModel
    {
        public List<SliderImg> SliderImgs = new List<SliderImg>();
        public List<PopularEvent> PopularEvents = new List<PopularEvent>();
        public List<Tourism> Tourisms = new List<Tourism>();
        public List<Pageant> Pageants = new List<Pageant>();
        public List<Kid> Kids = new List<Kid>();
        public List<Weekend> Weekends = new List<Weekend>();
        public List<Novelty> Novelties = new List<Novelty>();
    }
}
