import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/building_value.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';
import 'package:dio/dio.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:retrofit/retrofit.dart';

part 'building_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/building')
abstract class BuildingApi {
  factory BuildingApi(Dio dio, {String baseUrl}) = _BuildingApi;

  @GET('/')
  Future<List<Building>> getAllAsync();

  @GET('/current')
  Future<List<Building>> getForCurrentStellarObjectAsync();

  @GET('/type/{type}')
  Future<List<Building>> getAllByTypeAsync(
    @Path('type') StellarObjectType type,
  );

  @PUT('/build/{buildingId}')
  Future buildAsync(
    @Path('buildingId') Guid buildingId,
  );

  @GET('/values/building/{buildingId}/level/{startLevel}')
  Future<List<BuildingValue>> getValuesAsync(
    @Path('buildingId') Guid buildingId,
    @Path('startLevel') int startLevel,
    @Query('countLevels') int countLevels,
  );
}
