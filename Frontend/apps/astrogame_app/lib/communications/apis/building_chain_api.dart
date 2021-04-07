import 'package:astrogame_app/models/buildings/building_chain.dart';
import 'package:dio/dio.dart';
import 'package:retrofit/retrofit.dart';

part 'building_chain_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/building-chain')
abstract class BuildingChainApi {
  factory BuildingChainApi(Dio dio, {String baseUrl}) = _BuildingChainApi;

  @GET('/current')
  Future<BuildingChain> getByCurrentPlayerAsync();
}
