import 'package:astrogame_app/models/players/player.dart';
import 'package:dio/dio.dart';
import 'package:flutter/widgets.dart';
import 'package:retrofit/retrofit.dart';

part 'player_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/player')
abstract class PlayerApi {
  factory PlayerApi(Dio dio, {String baseUrl}) = _PlayerApi;

  @GET('/current')
  Future<Player> getCurrentAsync();

  @GET('/{email}')
  Future<Player> getByEmailAsync({
    @required @Path('email') String email,
  });
}
