
using DependencyExercise.BLL;
using DependencyExercise.DAL;

var Game = new GameBussiness(new DataAccessLayer());
var ShowName = Game.Play(2);
Console.WriteLine(ShowName);