import 'package:astrogame_app/communications/repositories/research_study_repository.dart';
import 'package:astrogame_app/models/researches/research_study.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class ResearchStudyProvider {
  MemoryCache _memoryCache = MemoryCache();
  var _lock = new Lock();

  ResearchStudyRepository _researchStudyRepository;

  ResearchStudyProvider(
    this._researchStudyRepository,
  );

  Future<ResearchStudy> get() async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get('all');

      if (values != null) {
        return values;
      }

      var response = await _researchStudyRepository.getByCurrentPlayerAsync();

      _memoryCache.put('all', response.data);
      return response.data;
    });
  }

  Future updateAsync() async {
    return await _lock.synchronized(() async {
      var response = await _researchStudyRepository.getByCurrentPlayerAsync();

      _memoryCache.put('all', response.data);
    });
  }
}
