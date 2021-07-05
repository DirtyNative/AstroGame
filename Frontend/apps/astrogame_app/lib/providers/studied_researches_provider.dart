import 'package:astrogame_app/communications/repositories/finished_technology_repository.dart';
import 'package:astrogame_app/models/technologies/finished_technology.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class StudiedResearchesProvider {
  MemoryCache _memoryCache = MemoryCache();
  var _lock = new Lock();

  FinishedTechnologyRepository _finishedTechnologyRepository;

  StudiedResearchesProvider(
    this._finishedTechnologyRepository,
  );

  Future<List<FinishedTechnology>> get() async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('all');

      if (values != null) {
        return values;
      }

      var response =
          await _finishedTechnologyRepository.getByCurrentPlayerAsync();

      _memoryCache.put('all', response.data);
      return response.data;
    });
  }

  Future<FinishedTechnology> getByResearchAsync(Guid technologyId) async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get(technologyId.toString());

      if (values != null) {
        return values;
      }

      var response = await _finishedTechnologyRepository
          .getByResearchAndCurrentPlayerAsync(technologyId);

      _memoryCache.put(technologyId.toString(), response.data);
      return response.data;
    });
  }

  Future<List<FinishedTechnology>> updateAsync() async {
    return await _lock.synchronized(() async {
      var response =
          await _finishedTechnologyRepository.getByCurrentPlayerAsync();

      _memoryCache.put('all', response.data);

      return response.data;
    });
  }
}
