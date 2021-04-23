import 'package:astrogame_app/communications/apis/studied_research_api.dart';
import 'package:astrogame_app/models/researches/studied_research.dart';
import 'package:dio/dio.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class StudiedResearchRepository {
  Logger _logger;

  StudiedResearchApi _studiedResearchApi;

  StudiedResearchRepository(
    Dio dio,
    this._logger,
  ) {
    _studiedResearchApi = new StudiedResearchApi(dio);
  }

  Future<ServerResponseT<List<StudiedResearch>>> getByCurrentPlayerAsync() async {
    try {
      _logger.d('Get studied research by player');
      var response = await _studiedResearchApi.getByCurrentPlayerAsync();
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<StudiedResearch>> getByResearchAndCurrentPlayerAsync(Guid researchId) async {
    try {
      _logger.d('Get studied research by research and player');
      var response = await _studiedResearchApi.getByResearchAndCurrentPlayerAsync(researchId);
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}
