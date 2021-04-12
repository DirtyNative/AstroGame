import 'package:astrogame_app/communications/repositories/resource_repository.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class ResourceProvider {
  var _memoryCache = new MemoryCache(ttl: 3600);
  var _lock = new Lock();

  ResourceRepository _resourceRepository;

  ResourceProvider(this._resourceRepository);

  Future<List<Resource>> getAsync() async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('all');

      if (values != null) {
        return values;
      }

      var response = await _resourceRepository.getAllAsync();

      _memoryCache.put('all', response.data);
      return response.data;
    });
  }

  Future<List<Resource>> updateAsync() async {
    return await _lock.synchronized(() async {
      var response = await _resourceRepository.getAllAsync();

      _memoryCache.put('all', response.data);

      return response.data;
    });
  }
}
