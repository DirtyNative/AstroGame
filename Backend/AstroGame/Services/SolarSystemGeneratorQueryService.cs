using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Managers;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AstroGame.Api.Services
{
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
    }
}