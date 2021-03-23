import 'package:astrogame_app/models/authorization/authorization_token.dart';
import 'package:astrogame_app/models/authorization/login_request.dart';
import 'package:dio/dio.dart';
import 'package:retrofit/retrofit.dart';

part 'authorization_api.g.dart';

@RestApi(baseUrl: 'https://localhost:7555/api/v1/authorizations')
abstract class AuthorizationApi {
  factory AuthorizationApi(Dio dio, {String baseUrl}) = _AuthorizationApi;

  @POST('/login')
  Future<AuthorizationToken> loginAsync(
    @Body() LoginRequest request,
  );
}
