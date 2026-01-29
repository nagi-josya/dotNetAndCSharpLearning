using Day6ofLearning.Domain;
using Day6ofLearning.Infrastructure;
using Day6ofLearning.Processors;
using Day6ofLearning.Services;

class Program
{
    static void Main()
    {
        var reader = new UserReadRepository();
        var writer = new EntityWriteRepository();
        var processor = new EntityLogger();

        var service = new GenericService<User>(
            reader,     // covariance
            writer,     // contravariance
            processor); // contravariance

        service.Execute(1);
    }
}