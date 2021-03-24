using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Managers;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using AstroGame.Api.Managers.Stellars;

namespace AstroGame.Api.Services
{
    /*
    [ScopedService]
    public class SolarSystemGeneratorQueryService
    {
        private const int PauseMilliseconds = 1000;

        private readonly SolarSystemManager _solarSystemManager;

        private static int _hasStartedFlag;

        public SolarSystemGeneratorQueryService(SolarSystemManager solarSystemManager)
        {
            _solarSystemManager = solarSystemManager;
        }

        private static bool TrySetStarted()
            => Interlocked.CompareExchange(ref _hasStartedFlag, 1, 0) == 0;

        private static void SetFinished()
            => Interlocked.Exchange(ref _hasStartedFlag, 0);

        public async Task<SolarSystem> TryExecute(uint systemNumber)
        {
            // Run a loop as long as there is a generator job running
            while (TrySetStarted() == false)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(PauseMilliseconds));
            }

            var solarSystem = await _solarSystemManager.GetBySystemNumberRecursiveAsync(systemNumber);

            SetFinished();
            return solarSystem;
        }
    } */

    [ScopedService]
    public class SolarSystemGeneratorQueryService
    {
        private const int PauseMilliseconds = 1000;

        private readonly SolarSystemManager _solarSystemManager;

        private static readonly ConcurrentBag<uint> List = new ConcurrentBag<uint>();

        public SolarSystemGeneratorQueryService(SolarSystemManager solarSystemManager)
        {
            _solarSystemManager = solarSystemManager;
        }

        private static bool TryAdd(uint index)
        {
            if (List.Contains(index))
            {
                return false;
            }

            List.Add(index);
            return true;
        }

        private static bool TryRemove(uint index)
        {
            return List.TryTake(out index);
        }

        public async Task<SolarSystem> TryExecute(uint systemNumber)
        {
            // Run a loop as long as there is a generator job running
            while (TryAdd(systemNumber) == false)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(PauseMilliseconds));
            }

            var solarSystem = await _solarSystemManager.GetBySystemNumberRecursiveAsync(systemNumber);

            while (TryRemove(systemNumber) == false)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(PauseMilliseconds));
            }

            return solarSystem;
        }
    }
}