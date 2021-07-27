import 'package:astrogame_app/communications/repositories/resource_snapshot_repository.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/resources/resource_snapshot.dart';

import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

import 'selected_colonized_stellar_object_provider.dart';

@singleton
class ResourceSnapshotProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 10);
  var _lock = new Lock();

  ResourceSnapshotRepository _resourceSnapshotRepository;
  SelectedColonizedStellarObjectProvider
      _selectedColonizedStellarObjectProvider;

  ResourceSnapshotProvider(
    this._resourceSnapshotRepository,
    this._selectedColonizedStellarObjectProvider,
  );

  Future<ResourceSnapshot?> getAsync(Guid stellarObjectId) async {
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

  Future<ResourceSnapshot?> getOnCurrentStellarObject() async {
    var selectedStellarObject =
        await _selectedColonizedStellarObjectProvider.getSelectedObject();

    if (selectedStellarObject == null) {
      return null;
    }

    return await getAsync(selectedStellarObject.stellarObjectId);
  }

  Future<ResourceSnapshot?> updateAsync(Guid stellarObjectId) async {
    return await _lock.synchronized(() async {
      var response =
          await _resourceSnapshotRepository.getAsync(stellarObjectId);

      _memoryCache.put(stellarObjectId.toString(), response.data);
      return response.data;
    });
  }
}
