import 'package:astrogame_app/communications/apis/solar_system_api.dart';
import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class SolarSystemRepository {
  SolarSystemApi _solarSystemApi;

  SolarSystemRepository(Dio dio) {
    _solarSystemApi = new SolarSystemApi(dio);
  }

  Future<ServerResponseT<SolarSystem>> getBySystemNumberRecursiveAsync(
      int solarSystemNumber) async {
    try {
      var solarSystem = await _solarSystemApi.getBySystemNumberRecursiveAsync(
          systemNumber: solarSystemNumber);

      return ServerResponseT()..data = solarSystem;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}
