import 'package:astrogame_app/communications/repositories/research_repository.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class ResearchImageProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 60);
  var _lock = new Lock();

  ResearchRepository _researchRepository;

  ResearchImageProvider(this._researchRepository);

  Future<ImageProvider> get(Guid researchId) async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get(researchId.toString());

      if (values != null) {
        return values;
      }

      var response = await _researchRepository.getImageAsync(researchId);

      if (response.hasError) {
        throw Exception('Failed to load research image $researchId');
      }

      _memoryCache.put(researchId.toString(), response.data);
      return response.data;
    });
  }
}
