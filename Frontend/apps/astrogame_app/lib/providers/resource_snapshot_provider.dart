import 'package:astrogame_app/communications/repositories/resource_snapshot_repository.dart';
import 'package:astrogame_app/models/resources/resource_snapshot.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class ResourceSnapshotProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 10);
  var _lock = new Lock();

  ResourceSnapshotRepository _resourceSnapshotRepository;

  ResourceSnapshotProvider(this._resourceSnapshotRepository);

  Future<ResourceSnapshot> getAsync(Guid stellarObjectId) async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get(stellarObjectId.toString());

      if (values != null) {
        return values;
      }

      var response =
          await _resourceSnapshotRepository.getAsync(stellarObjectId);

      _memoryCache.put(stellarObjectId.toString(), response.data);
      return response.data;
    });
  }

  Future<ResourceSnapshot> updateAsync(Guid stellarObjectId) async {
    return await _lock.synchronized(() async {
      var response =
          await _resourceSnapshotRepository.getAsync(stellarObjectId);

      _memoryCache.put(stellarObjectId.toString(), response.data);
      return response.data;
    });
  }
}
