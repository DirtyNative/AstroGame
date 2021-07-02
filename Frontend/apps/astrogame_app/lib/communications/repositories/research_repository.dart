import 'package:astrogame_app/communications/apis/research_api.dart';

import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/researches/research_value.dart';
import 'package:astrogame_app/providers/http_header_provider.dart';
import 'package:dio/dio.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_connection.dart';
import '../server_error.dart';
import '../server_response.dart';

@injectable
class ResearchRepository {
  Logger _logger;

  HttpHeaderProvider _httpHeaderProvider;
  ServerConnection _serverConnection;

  ResearchApi _researchApi;

  ResearchRepository(
      Dio dio, this._logger, this._serverConnection, this._httpHeaderProvider) {
    _researchApi = new ResearchApi(dio);
  }

  Future<ServerResponseT<List<Research>>> getAllAsync() async {
    try {
      _logger.d('Get all researches');
      var response = await _researchApi.getAllAsync();
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<ImageProvider>> getImageAsync(
    Guid researchId,
  ) async {
    try {
      _logger.d('Get research image');
      return ServerResponseT()
        ..data = NetworkImage(
            _serverConnection.baseAdress + '/api/v1/research/image/$researchId',
            headers: _httpHeaderProvider.getHeaders());
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<List<ResearchValue>>> getValuesAsync(
    Guid researchId,
    int startLevel,
    int countLevels,
  ) async {
    try {
      _logger.d('Get research values by research id');
      var response = await _researchApi.getValuesAsync(
          researchId, startLevel, countLevels);
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}
