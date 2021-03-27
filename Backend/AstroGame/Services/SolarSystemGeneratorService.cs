using AstroGame.Generator.Generators.SystemGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AstroGame.Storage.Database;
using AstroGame.Storage.Repositories.Stellar;

namespace AstroGame.Api.Services
{
    public class SolarSystemGeneratorService : BackgroundService
    {
        private const int TaskCount = 2;

        private uint _index;
        private readonly List<Task> _tasks;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SolarSystemGeneratorService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;

            _tasks = new List<Task>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested == false)
            {
                for (uint i = 0; i < TaskCount; i++)
                {
                    var i1 = i;

                    //var task = new Task<Task>(async () => await GenerateSolarSystem(_index + i1, stoppingToken));
                    // task.Start();
                    //var task = Task.Factory.StartNew(async () => await GenerateSolarSystem(_index + i1, stoppingToken), stoppingToken);

                    var task = GenerateSolarSystem(_index + i1, stoppingToken);

                    _tasks.Add(task);
                }

                Task.WaitAll(_tasks.ToArray(), stoppingToken);

                _tasks.Clear();

                _index += TaskCount;
                await Task.Delay(10, stoppingToken);
            }
        }

        private async Task GenerateSolarSystem(uint index, CancellationToken stoppingToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<AstroGameDataContext>();
            var solarSystemRepository = scope.ServiceProvider.GetService<SolarSystemRepository>();
            var solarSystemGenerator = scope.ServiceProvider.GetService<SolarSystemGenerator>();

            try
            {
                var solarSystem = await solarSystemRepository.GetBySystemNumberAsync(index);

                if (solarSystem == null)
                {
                    Console.WriteLine($"SolarSystem {index} not found");
                    return;
                }

                if (solarSystem.IsGenerated)
                {
                    Console.WriteLine($"SolarSystem {index} is already generated");
                    return;
                }

                solarSystemGenerator.GenerateChildren(solarSystem, solarSystem.Coordinates);

                await context.SaveChangesAsync(stoppingToken);
                await context.Database.CloseConnectionAsync();

                Console.WriteLine($"SolarSystem {index} generated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}