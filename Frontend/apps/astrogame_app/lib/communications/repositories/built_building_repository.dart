import 'package:astrogame_app/communications/apis/built_building_api.dart';
import 'package:astrogame_app/models/buildings/built_building.dart';
import 'package:dio/dio.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class BuiltBuildingRepository {
  Logger _logger;

  BuiltBuildingApi _builtBuildingApi;

  BuiltBuildingRepository(
    Dio dio,
    this._logger,
  ) {
    _builtBuildingApi = new BuiltBuildingApi(dio);
  }

  Future<ServerResponseT<List<BuiltBuilding>>> getAsync() async {
    try {
      _logger.d('Get built buildings');
      var response = await _builtBuildingApi.getAsync();
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<BuiltBuilding>> getByBuildingAsync(
      Guid buildingId) async {
    try {
      _logger.d('Get built building');
      var response = await _builtBuildingApi.getByBuilding(buildingId);
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}
