import 'package:astrogame_app/models/players/perk.dart';
import 'package:dio/dio.dart';
import 'package:retrofit/retrofit.dart';

part 'perk_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/perk')
abstract class PerkApi {
  factory PerkApi(Dio dio, {String baseUrl}) = _PerkApi;

  @GET('/')
  Future<List<Perk>> getAllAsync();
}
