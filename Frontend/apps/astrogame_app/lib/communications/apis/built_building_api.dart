import 'package:astrogame_app/models/buildings/built_building.dart';
import 'package:dio/dio.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:retrofit/retrofit.dart';

part 'built_building_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/building')
abstract class BuiltBuildingApi {
  factory BuiltBuildingApi(Dio dio, {String baseUrl}) = _BuiltBuildingApi;

  @GET('/building/{buildingId}')
  Future<BuiltBuilding> getByBuilding(
    @Path('buildingId') Guid buildingId,
  );
}
