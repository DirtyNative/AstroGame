import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/models/technologies/technology_value.dart';
import 'package:dio/dio.dart';

import 'package:retrofit/retrofit.dart';

part 'technology_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/technology')
abstract class TechnologyApi {
  factory TechnologyApi(Dio dio, {String baseUrl}) = _TechnologyApi;

  @GET('/')
  Future<List<Technology>> getAllAsync();

  @GET('/values/technology/{technologyId}/level/{startLevel}')
  Future<List<TechnologyValue>> getValuesAsync(
    @Path('technologyId') Guid technologyId,
    @Path('startLevel') int startLevel,
    @Query('countLevels') int countLevels,
  );

  @GET('/conditions/fulfilled/technology/{technologyId}')
  Future<bool> hasConditionsFulfilledAsync(
    @Path('technologyId') Guid technologyId,
  );

  @POST('/upgrade/{technologyId}')
  Future upgradeAsync(
    @Path('technologyId') Guid technologyId,
  );
}
