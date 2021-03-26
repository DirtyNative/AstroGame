import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/dtos/add_player_species_request.dart';
import 'package:dio/dio.dart';
import 'package:flutter/widgets.dart';
import 'package:retrofit/retrofit.dart';

part 'player_species_api.g.dart';

@GuidConverter()
@RestApi(baseUrl: 'https://localhost:7555/api/v1/player-species')
abstract class PlayerSpeciesApi {
  factory PlayerSpeciesApi(Dio dio, {String baseUrl}) = _PlayerSpeciesApi;

  @PUT('/')
  Future addAsync({
    @required @Body() AddPlayerSpeciesRequest species,
  });

  //@GET('/image/{speciesId}/base64')
  //Future<String> getImageAsync({@required @Path('speciesId') Guid speciesId});
}
