import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/researches/research_value.dart';
import 'package:dio/dio.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:retrofit/retrofit.dart';

part 'research_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/research')
abstract class ResearchApi {
  factory ResearchApi(Dio dio, {String baseUrl}) = _ResearchApi;

  @GET('/')
  Future<List<Research>> getAllAsync();

  @GET('/values/research/{researchId}/level/{startLevel}')
  Future<List<ResearchValue>> getValuesAsync(
    @Path('researchId') Guid researchId,
    @Path('startLevel') int startLevel,
    @Query('countLevels') int countLevels,
  );
}
