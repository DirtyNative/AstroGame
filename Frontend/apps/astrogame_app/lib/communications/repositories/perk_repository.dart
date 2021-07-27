import 'package:astrogame_app/communications/apis/perk_api.dart';
import 'package:astrogame_app/models/players/perk.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class PerkRepository {
  Logger _logger;

  late PerkApi _perkApi;

  PerkRepository(Dio dio, this._logger) {
    _perkApi = new PerkApi(dio);
  }

  Future<ServerResponseT<List<Perk>>> getAllAsync() async {
    try {
      _logger.d('Get all perks');
      var response = await _perkApi.getAllAsync();
      return ServerResponseT()..data = response;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }
}
