import 'package:astrogame_app/communications/repositories/technology_repository.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class TechnologiesProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 60);
  var _lock = new Lock();

  TechnologyRepository _technologyRepository;

  TechnologiesProvider(this._technologyRepository);

  Future<List<Technology>> get() async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('all');

      if (values != null) {
        return values;
      }

      var response = await _technologyRepository.getAllAsync();

      _memoryCache.put('all', response.data);
      return response.data;
    });
  }

  Future<List<Building>> getBuildingsAsync() async {
    var technologies = await get();

    return technologies.whereType<Building>().toList();
  }

  Future<List<Research>> getResearchesAsync() async {
    var technologies = await get();

    return technologies.whereType<Research>().toList();
  }
}
