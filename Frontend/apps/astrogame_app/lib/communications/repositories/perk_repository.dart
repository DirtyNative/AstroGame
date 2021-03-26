import 'package:astrogame_app/communications/apis/perk_api.dart';
import 'package:astrogame_app/models/players/perk.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class PerkRepository {
  PerkApi _perkApi;

  PerkRepository(Dio dio) {
    _perkApi = new PerkApi(dio);
  }

  Future<ServerResponseT<List<Perk>>> getAllAsync() async {
    try {
      var response = await _perkApi.getAllAsync();
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}
