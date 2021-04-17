import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class BuildingImageProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 60);
  var _lock = new Lock();

  BuildingRepository _buildingRepository;

  BuildingImageProvider(this._buildingRepository);

  Future<ImageProvider> get(Guid buildingId) async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get(buildingId.toString());

      if (values != null) {
        return values;
      }

      var response = await _buildingRepository.getImageAsync(buildingId: buildingId);

      if (response.hasError) {
        throw Exception('Failed to load building image $buildingId');
      }

      _memoryCache.put(buildingId.toString(), response.data);
      return response.data;
    });
  }
}
