import 'package:astrogame_app/apis/solar_system_api.dart';
import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';

@injectable
class SolarSystemRepository {
  SolarSystemApi _solarSystemApi;

  SolarSystemRepository() {
    _solarSystemApi = new SolarSystemApi(new Dio());
  }

  Future<SolarSystem> getBySystemNumberRecursiveAsync(
      int solarSystemNumber) async {
    var solarSystem = await _solarSystemApi.getBySystemNumberRecursiveAsync(
        systemNumber: solarSystemNumber);

    return solarSystem;
  }
}
