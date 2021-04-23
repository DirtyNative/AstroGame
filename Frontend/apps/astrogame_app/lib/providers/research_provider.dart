import 'package:astrogame_app/communications/repositories/research_repository.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class ResearchProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 60);
  var _lock = new Lock();

  ResearchRepository _researchRepository;

  ResearchProvider(this._researchRepository);

  Future<List<Research>> get() async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('all');

      if (values != null) {
        return values;
      }

      var response = await _researchRepository.getAllAsync();

      _memoryCache.put('all', response.data);
      return response.data;
    });
  }
}
