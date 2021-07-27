import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:dio/dio.dart';

import 'package:retrofit/retrofit.dart';

part 'stellar_object_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/stellar-object')
abstract class StellarObjectApi {
  factory StellarObjectApi(Dio dio, {String baseUrl}) = _StellarObjectApi;

  @GET('/{id}')
  Future<StellarObject> getAsync(
    @Path('id') Guid id,
  );
}
