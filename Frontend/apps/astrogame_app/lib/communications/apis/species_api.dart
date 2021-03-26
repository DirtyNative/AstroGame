import 'package:astrogame_app/models/players/species.dart';
import 'package:dio/dio.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:retrofit/retrofit.dart';

part 'species_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/species')
abstract class SpeciesApi {
  factory SpeciesApi(Dio dio, {String baseUrl}) = _SpeciesApi;

  @GET('/')
  Future<List<Species>> getAllAsync();

  @GET('/{id}')
  Future<Species> getAsync({
    @required @Path('id') Guid id,
  });

  //@GET('/image/{speciesId}/base64')
  //Future<String> getImageAsync({@required @Path('speciesId') Guid speciesId});
}
