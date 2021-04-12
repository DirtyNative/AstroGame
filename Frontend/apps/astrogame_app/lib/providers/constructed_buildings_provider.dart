import 'package:astrogame_app/communications/repositories/built_building_repository.dart';
import 'package:astrogame_app/models/buildings/built_building.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class ConstructedBuildingsProvider {
  MemoryCache _memoryCache = MemoryCache();
  Lock _lock = new Lock();

  BuiltBuildingRepository _builtBuildingRepository;

  ConstructedBuildingsProvider(this._builtBuildingRepository);

  Future<List<BuiltBuilding>> get() async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('all');

      if (values != null) {
        return values;
      }

      var response = await _builtBuildingRepository.getAsync();

      _memoryCache.put('all', response.data);
      return response.data;
    });
  }

  Future<BuiltBuilding> getByBuildingAsync(Guid buildingId) async {
    var buildings = await get();

    if (buildings == null || buildings.length == 0) {
      return null;
    }

    if (buildings.any((element) => element.buildingId == buildingId) == false) {
      return null;
    }

    return buildings.firstWhere((element) => element.buildingId == buildingId);
  }

  Future updateAsync() async {
    return await _lock.synchronized(() async {
      var response = await _builtBuildingRepository.getAsync();

      _memoryCache.put('all', response.data);
    });
  }
}
