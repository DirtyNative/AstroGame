import 'package:astrogame_app/communications/apis/solar_system_api.dart';
import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class SolarSystemRepository {
  Logger _logger;

  SolarSystemApi _solarSystemApi;

  SolarSystemRepository(Dio dio, this._logger) {
    _solarSystemApi = new SolarSystemApi(dio);
  }

  Future<ServerResponseT<SolarSystem>> getBySystemNumberRecursiveAsync(int solarSystemNumber) async {
    try {
      _logger.d('Get SolarSystem by number');
      var solarSystem = await _solarSystemApi.getBySystemNumberRecursiveAsync(systemNumber: solarSystemNumber);

      return ServerResponseT()..data = solarSystem;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<List<SolarSystem>>> getInRangeAsync(double minX, double maxX, double minZ, double maxZ) async {
    try {
      _logger.d('Get SolarSystem in range');
      var solarSystems = await _solarSystemApi.getInRangeAsync(minX, maxX, minZ, maxZ);

      return ServerResponseT()..data = solarSystems;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}
