import 'package:astrogame_app/communications/apis/technology_api.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/models/technologies/technology_value.dart';
import 'package:dio/dio.dart';

import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class TechnologyRepository {
  Logger _logger;

  late TechnologyApi _technologyApi;

  TechnologyRepository(Dio dio, this._logger) {
    _technologyApi = new TechnologyApi(dio);
  }

  Future<ServerResponseT<List<Technology>>> getAllAsync() async {
    try {
      _logger.d('Get all technologies');
      var response = await _technologyApi.getAllAsync();
      return ServerResponseT()..data = response;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
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
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }

  Future<ServerResponseT<bool>> hasConditionsFulfilledAsync(
    Guid technologyId,
  ) async {
    try {
      _logger.d('Does technology has fulfilled conditions');
      var response =
          await _technologyApi.hasConditionsFulfilledAsync(technologyId);
      return ServerResponseT()..data = response;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }

  Future<ServerResponse> upgradeAsync(
    Guid technologyId,
  ) async {
    try {
      _logger.d('Upgrading technology');
      await _technologyApi.upgradeAsync(technologyId);
      return ServerResponse();
    } on DioError catch (error) {
      return ServerResponse()..error = ServerError.withError(error);
    }
  }
}
