import 'package:astrogame_app/models/resources/resource_snapshot.dart';
import 'package:dio/dio.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:retrofit/retrofit.dart';

part 'resource_snapshot_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/resource-snapshot')
abstract class ResourceSnapshotApi {
  factory ResourceSnapshotApi(Dio dio, {String baseUrl}) = _ResourceSnapshotApi;

  @GET('/stellar-object/{stellarObjectId}')
  Future<ResourceSnapshot> getAsync(
    @Path('stellarObjectId') Guid stellarObjectId,
  );
}
