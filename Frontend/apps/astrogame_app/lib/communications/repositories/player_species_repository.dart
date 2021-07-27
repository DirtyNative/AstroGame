import 'package:astrogame_app/communications/apis/player_species_api.dart';
import 'package:astrogame_app/communications/dtos/add_player_species_request.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class PlayerSpeciesRepository {
  Logger _logger;

  late PlayerSpeciesApi _playerSpeciesApi;

  PlayerSpeciesRepository(Dio dio, this._logger) {
    _playerSpeciesApi = new PlayerSpeciesApi(dio);
  }

  Future<ServerResponse> addAsync(AddPlayerSpeciesRequest species) async {
    try {
      _logger.d('Add player species');
      await _playerSpeciesApi.addAsync(species);
      return ServerResponse();
    } on DioError catch (error) {
      return ServerResponse()..error = ServerError.withError(error);
    }
  }
}
