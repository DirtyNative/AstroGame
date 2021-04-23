import 'package:astrogame_app/models/researches/studied_research.dart';
import 'package:dio/dio.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:retrofit/retrofit.dart';

part 'studied_research_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/studied-research')
abstract class StudiedResearchApi {
  factory StudiedResearchApi(Dio dio, {String baseUrl}) = _StudiedResearchApi;

  @GET('/player/current')
  Future<List<StudiedResearch>> getByCurrentPlayerAsync();

  @GET('/research/{researchId}/player/current')
  Future<StudiedResearch> getByResearchAndCurrentPlayerAsync(
    @Path('researchId') Guid researchId,
  );
}
