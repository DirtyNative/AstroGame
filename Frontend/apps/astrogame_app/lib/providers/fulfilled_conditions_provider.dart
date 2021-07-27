import 'package:astrogame_app/communications/repositories/technology_repository.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class FulfilledConditionsProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 60);
  var _lock = new Lock();

  TechnologyRepository _technologyRepository;

  FulfilledConditionsProvider(this._technologyRepository);

  Future<bool> get(Guid technologyId) async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get(technologyId.value);

      if (values != null) {
        return values;
      }

      var response =
          await _technologyRepository.hasConditionsFulfilledAsync(technologyId);

      _memoryCache.put(technologyId.value, response.data);
      return response.data ?? false;
    });
  }
}
