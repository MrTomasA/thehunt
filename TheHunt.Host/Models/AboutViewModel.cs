namespace TheHunt.Host.Models
{
    public class AboutViewModel : BaseIndexViewModel
    {
        private static readonly string angularApplicationName = "angularApp";

        public AboutViewModel() : base(angularApplicationName) { }
    }
}