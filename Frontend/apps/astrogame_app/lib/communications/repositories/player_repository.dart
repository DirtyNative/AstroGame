import 'package:astrogame_app/communications/apis/player_api.dart';
import 'package:astrogame_app/models/players/player.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';

import '../server_error.dart';
import '../server_response.dart';

@injectable
class PlayerRepository {
  PlayerApi _playerApi;

  PlayerRepository(Dio dio) {
    _playerApi = new PlayerApi(dio);
  }

  Future<ServerResponseT<Player>> getCurrentAsync() async {
    try {
      var response = await _playerApi.getCurrentAsync();
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }

  Future<ServerResponseT<Player>> getByEmailAsync(
    String email,
  ) async {
    try {
      var response = await _playerApi.getByEmailAsync(email: email);
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}
