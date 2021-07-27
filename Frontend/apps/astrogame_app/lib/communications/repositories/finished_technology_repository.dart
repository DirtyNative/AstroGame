import 'package:astrogame_app/communications/apis/finished_technology_api.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';
import 'package:dio/dio.dart';

import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class FinishedTechnologyRepository {
  Logger _logger;

  late FinishedTechnologyApi _finishedTechnologyApi;

  FinishedTechnologyRepository(
    Dio dio,
    this._logger,
  ) {
    _finishedTechnologyApi = new FinishedTechnologyApi(dio);
  }

  Future<ServerResponseT<List<FinishedTechnology>>>
      getByCurrentStellarObjectAsync() async {
    try {
      _logger.d('Get finished technologies by current stellar object');
      var response =
          await _finishedTechnologyApi.getByCurrentStellarObjectAsync();
      return ServerResponseT()..data = response;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }

  Future<ServerResponseT<FinishedTechnology>>
      getByCurrentStellarObjectAndTechnologyAsync(Guid technologyId) async {
    try {
      _logger.d(
          'Get finished technology by current stellar object and technology');
      var response = await _finishedTechnologyApi
          .getByCurrentStellarObjectAndTechnologyAsync(technologyId);
      return ServerResponseT()..data = response;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }

  Future<ServerResponseT<List<FinishedTechnology>>>
      getByCurrentPlayerAsync() async {
    try {
      _logger.d('Get finished technologies by current player');
      var response = await _finishedTechnologyApi.getByCurrentPlayerAsync();
      return ServerResponseT()..data = response;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }

  Future<ServerResponseT<FinishedTechnology>>
      getByResearchAndCurrentPlayerAsync(Guid technologyId) async {
    try {
      _logger.d('Get finished technology by current player and technology');
      var response = await _finishedTechnologyApi
          .getByResearchAndCurrentPlayerAsync(technologyId);
      return ServerResponseT()..data = response;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }
}
