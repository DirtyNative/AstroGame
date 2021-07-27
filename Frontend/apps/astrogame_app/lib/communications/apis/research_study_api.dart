import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/researches/research_study.dart';
import 'package:dio/dio.dart';

import 'package:retrofit/retrofit.dart';

part 'research_study_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/research-study')
abstract class ResearchStudyApi {
  factory ResearchStudyApi(Dio dio, {String baseUrl}) = _ResearchStudyApi;

  @GET('/player/{playerId}')
  Future<ResearchStudy> getByPlayerAsync(
    @Path('playerId') Guid playerId,
  );

  @GET('/player/current')
  Future<ResearchStudy> getByCurrentPlayerAsync();
}
