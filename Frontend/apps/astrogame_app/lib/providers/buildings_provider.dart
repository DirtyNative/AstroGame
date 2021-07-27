import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class BuildingsProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 60);
  var _lock = new Lock();

  BuildingRepository _buildingRepository;

  BuildingsProvider(this._buildingRepository);

  Future<List<Building>> get() async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('all');

      if (values != null) {
        return values;
      }

      var response =
          await _buildingRepository.getForCurrentStellarObjectAsync();

      _memoryCache.put('all', response.data);
      return response.data ?? [];
    });
  }
}
