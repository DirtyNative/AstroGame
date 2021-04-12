import 'package:astrogame_app/communications/repositories/stored_resource_repository.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class StoredResourceProvider {
  var _memoryCache = new MemoryCache();
  var _lock = new Lock();

  StoredResourceRepository _storedResourceRepository;

  StoredResourceProvider(this._storedResourceRepository);

  Future<List<StoredResource>> getAsync() async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('all');

      if (values != null) {
        return values;
      }

      var response =
          await _storedResourceRepository.getOnCurrentStellarObjectAsync();

      _memoryCache.put('all', response.data);
      return response.data;
    });
  }

  Future<List<StoredResource>> updateAsync() async {
    return await _lock.synchronized(() async {
      var response =
          await _storedResourceRepository.getOnCurrentStellarObjectAsync();

      _memoryCache.put('all', response.data);

      return response.data;
    });
  }
}
