import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';
import 'package:dio/dio.dart';

import 'package:retrofit/retrofit.dart';

part 'finished_technology_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/finished-technology')
abstract class FinishedTechnologyApi {
  factory FinishedTechnologyApi(Dio dio, {String baseUrl}) =
      _FinishedTechnologyApi;

  @GET('/stellar-object/current')
  Future<List<FinishedTechnology>> getByCurrentStellarObjectAsync();

  @GET('/stellar-object/current/technology/{technologyId}')
  Future<FinishedTechnology> getByCurrentStellarObjectAndTechnologyAsync(
    @Path('technologyId') Guid technologyId,
  );

  @GET('/player/current')
  Future<List<FinishedTechnology>> getByCurrentPlayerAsync();

  @GET('/research/{researchId}/player/current')
  Future<FinishedTechnology> getByResearchAndCurrentPlayerAsync(
    @Path('researchId') Guid researchId,
  );
}
