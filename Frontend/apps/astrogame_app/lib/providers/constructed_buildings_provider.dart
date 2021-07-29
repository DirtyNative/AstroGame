import 'package:astrogame_app/communications/repositories/finished_technology_repository.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';

import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class ConstructedBuildingsProvider {
  MemoryCache _memoryCache = MemoryCache();
  Lock _lock = new Lock();

  FinishedTechnologyRepository _finishedTechnologyRepository;

  ConstructedBuildingsProvider(this._finishedTechnologyRepository);

  Future<List<FinishedTechnology>> get() async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('all');

      if (values != null) {
        return values;
      }

      var response =
          await _finishedTechnologyRepository.getByCurrentStellarObjectAsync();

      _memoryCache.put('all', response.data);
      return response.data ?? [];
    });
  }

  Future<FinishedTechnology?> getByBuildingAsync(Guid technologyId) async {
    var buildings = await get();

    if (buildings.length == 0) {
      return null;
    }

    if (buildings.any((element) => element.technologyId == technologyId) ==
        false) {
      return null;
    }

    return buildings
        .firstWhere((element) => element.technologyId == technologyId);
  }

  Future updateAsync() async {
    return await _lock.synchronized(() async {
      var response =
          await _finishedTechnologyRepository.getByCurrentStellarObjectAsync();

      _memoryCache.put('all', response.data);
    });
  }
}
