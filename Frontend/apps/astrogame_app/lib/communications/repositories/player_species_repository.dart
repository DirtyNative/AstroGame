import 'package:astrogame_app/communications/apis/player_species_api.dart';
import 'package:astrogame_app/communications/dtos/add_player_species_request.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class PlayerSpeciesRepository {
  PlayerSpeciesApi _playerSpeciesApi;

  PlayerSpeciesRepository(Dio dio) {
    _playerSpeciesApi = new PlayerSpeciesApi(dio);
  }

  Future<ServerResponse> addAsync(AddPlayerSpeciesRequest species) async {
    try {
      await _playerSpeciesApi.addAsync(species: species);
      return ServerResponse();
    } catch (error) {
      return ServerResponse()..error = ServerError.withError(error: error);
    }
  }
}
