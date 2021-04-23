import 'package:astrogame_app/communications/repositories/studied_research_repository.dart';
import 'package:astrogame_app/models/researches/studied_research.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class StudiedResearchesProvider {
  MemoryCache _memoryCache = MemoryCache();
  var _lock = new Lock();

  StudiedResearchRepository _studiedResearchRepository;

  StudiedResearchesProvider(
    this._studiedResearchRepository,
  );

  Future<List<StudiedResearch>> get() async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('all');

      if (values != null) {
        return values;
      }

      var response = await _studiedResearchRepository.getByCurrentPlayerAsync();

      _memoryCache.put('all', response.data);
      return response.data;
    });
  }

  Future<StudiedResearch> getByResearchAsync(Guid researchId) async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get(researchId.toString());

      if (values != null) {
        return values;
      }

      var response = await _studiedResearchRepository.getByResearchAndCurrentPlayerAsync(researchId);

      _memoryCache.put(researchId.toString(), response.data);
      return response.data;
    });
  }

  Future<List<StudiedResearch>> updateAsync() async {
    return await _lock.synchronized(() async {
      var response = await _studiedResearchRepository.getByCurrentPlayerAsync();

      _memoryCache.put('all', response.data);

      return response.data;
    });
  }
}
