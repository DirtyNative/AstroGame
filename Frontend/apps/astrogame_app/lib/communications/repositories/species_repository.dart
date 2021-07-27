import 'package:astrogame_app/communications/apis/species_api.dart';
import 'package:astrogame_app/models/players/species.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class SpeciesRepository {
  Logger _logger;

  late SpeciesApi _speciesApi;

  SpeciesRepository(Dio dio, this._logger) {
    _speciesApi = new SpeciesApi(dio);
  }

  Future<ServerResponseT<List<Species>>> getAllAsync() async {
    try {
      _logger.d('Get all species');
      var response = await _speciesApi.getAllAsync();
      return ServerResponseT()..data = response;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }
}
