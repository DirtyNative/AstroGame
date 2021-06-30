import 'package:astrogame_app/communications/repositories/solar_system_repository.dart';
import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class SolarSystemsProvider {
  MemoryCache _memoryCache = MemoryCache();
  var _lock = new Lock();

  SolarSystemRepository _solarSystemRepository;

  SolarSystemsProvider(
    this._solarSystemRepository,
  );

  Future<List<SolarSystem>> get(double minX, double maxX, double minZ, double maxZ) async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('$minX/$maxX/$minZ/$maxZ');

      if (values != null) {
        return values;
      }

      var response = await _solarSystemRepository.getInRangeAsync(minX, maxX, minZ, maxZ);

      _memoryCache.put('$minX/$maxX/$minZ/$maxZ', response.data);
      return response.data;
    });
  }
}
