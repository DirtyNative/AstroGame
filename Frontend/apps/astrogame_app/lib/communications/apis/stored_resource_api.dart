import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:dio/dio.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:retrofit/retrofit.dart';

part 'stored_resource_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/stored-resource')
abstract class StoredResourceApi {
  factory StoredResourceApi(Dio dio, {String baseUrl}) = _StoredResourceApi;

  @GET('/stellar-object')
  Future<List<StoredResource>> getOnCurrentStellarObjectAsync();

  @GET('/stellar-object/{stellarObjectId}')
  Future<List<StoredResource>> getOnStellarObjectAsync(
    @Path('stellarObjectId') Guid stellarObjectId,
  );
}
