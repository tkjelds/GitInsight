namespace GitInsight.app
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<IStrategy> strategies = new List<IStrategy> {
                new FrequenceMode(),
                new AuthorMode()
            };

            var strategy = strategies[Int16.Parse(args[1])];
            using(var repo = new Repository(args[0])){
                strategy.Assemble(repo);
                strategy.Print();
            }
        }
    }  
}
