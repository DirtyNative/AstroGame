import 'package:astrogame_app/communications/apis/building_api.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/building_value.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';
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
class BuildingRepository {
  Logger _logger;

  HttpHeaderProvider _httpHeaderProvider;
  ServerConnection _serverConnection;

  BuildingApi _buildingApi;

  BuildingRepository(Dio dio, this._logger, this._serverConnection, this._httpHeaderProvider) {
    _buildingApi = new BuildingApi(dio);
  }

  Future<ServerResponseT<List<Building>>> getAllAsync() async {
    try {
      _logger.d('Get all buildings');
      var response = await _buildingApi.getAllAsync();
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<List<Building>>> getAllByTypeAsync(
    StellarObjectType type,
  ) async {
    try {
      _logger.d('Get all buildings by type');
      var response = await _buildingApi.getAllByTypeAsync(type);
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<ImageProvider>> getImageAsync({
    @required Guid buildingId,
  }) async {
    try {
      _logger.d('Get building image');
      return ServerResponseT()
        ..data = NetworkImage(_serverConnection.baseAdress + '/api/v1/building/image/$buildingId', headers: _httpHeaderProvider.getHeaders());
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponse> buildAsync(
    Guid buildingId,
  ) async {
    try {
      _logger.d('Build building');
      await _buildingApi.buildAsync(buildingId);
      return ServerResponse();
    } catch (error) {
      return ServerResponse()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<List<BuildingValue>>> getValuesAsync(
    Guid buildingId,
    int startLevel,
    int countLevels,
  ) async {
    try {
      _logger.d('Get all buildings by type');
      var response = await _buildingApi.getValuesAsync(buildingId, startLevel, countLevels);
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}
