namespace DependencyExercise.DAL
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private readonly Dictionary<long, string> _Games = new Dictionary<long, string>()
        {
            {1, "Call Of Duty" },
            {2, "Fifa 26" },
            {3, "Dota 2" }
        };

        public string GetBy(long id)
        {
            return _Games[id];
        }
    }
}
