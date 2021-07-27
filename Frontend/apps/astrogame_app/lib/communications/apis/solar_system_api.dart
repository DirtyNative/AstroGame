import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:dio/dio.dart';
import 'package:retrofit/retrofit.dart';

part 'solar_system_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/solar-system')
abstract class SolarSystemApi {
  factory SolarSystemApi(Dio dio, {String baseUrl}) = _SolarSystemApi;

  @GET('/system-number/{systemNumber}/recursive')
  Future<SolarSystem> getBySystemNumberRecursiveAsync(
    @Path('systemNumber') int systemNumber,
  );

  @GET('/range/{minX}/{maxX}/{minZ}/{maxZ}')
  Future<List<SolarSystem>> getInRangeAsync(
    @Path('minX') double minX,
    @Path('maxX') double maxX,
    @Path('minZ') double minZ,
    @Path('maxZ') double maxZ,
  );
}
