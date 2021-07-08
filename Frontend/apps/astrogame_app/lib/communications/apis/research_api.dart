import 'package:astrogame_app/models/researches/research.dart';
import 'package:dio/dio.dart';
import 'package:retrofit/retrofit.dart';

part 'research_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/research')
abstract class ResearchApi {
  factory ResearchApi(Dio dio, {String baseUrl}) = _ResearchApi;

  @GET('/')
  Future<List<Research>> getAllAsync();
}
