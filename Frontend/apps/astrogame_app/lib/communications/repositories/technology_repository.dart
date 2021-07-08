import 'package:astrogame_app/communications/apis/technology_api.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/models/technologies/technology_value.dart';
import 'package:dio/dio.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class TechnologyRepository {
  Logger _logger;

  TechnologyApi _technologyApi;

  TechnologyRepository(Dio dio, this._logger) {
    _technologyApi = new TechnologyApi(dio);
  }

  Future<ServerResponseT<List<Technology>>> getAllAsync() async {
    try {
      _logger.d('Get all technologies');
      var response = await _technologyApi.getAllAsync();
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<List<TechnologyValue>>> getValuesAsync(
    Guid technologyId,
    int startLevel,
    int countLevels,
  ) async {
    try {
      _logger.d('Get all technology values');
      var response = await _technologyApi.getValuesAsync(
          technologyId, startLevel, countLevels);
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}
