import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:dio/dio.dart';

import 'package:retrofit/retrofit.dart';

part 'resource_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/resource')
abstract class ResourceApi {
  factory ResourceApi(Dio dio, {String baseUrl}) = _ResourceApi;

  @GET('/')
  Future<List<Resource>> getAllAsync();

  @GET('/{id}')
  Future<List<Resource>> getAsync(
    @Path('id') Guid id,
  );
}
