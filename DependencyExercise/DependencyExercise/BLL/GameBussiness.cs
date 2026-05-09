using DependencyExercise.DAL;
using DependencyExercise.Helpers;

namespace DependencyExercise.BLL
{
    public class GameBussiness
    {
        private readonly IDataAccessLayer _layer;
        private readonly ILogger _logger;

        public GameBussiness(IDataAccessLayer data, ILogger logger)
        {
            _layer = data;
            _logger = logger;
        }

        public string Play(long id)
        {
            var game = _layer.GetBy(id);
            game = game.ToUpper();
            _logger.Log($"Logger : {game}");
            return $"The Selected Game Is {game}";
        }
    }
}
