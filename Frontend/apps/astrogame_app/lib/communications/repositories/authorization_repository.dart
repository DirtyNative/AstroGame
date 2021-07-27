import 'package:astrogame_app/communications/apis/authorization_api.dart';
import 'package:astrogame_app/communications/server_error.dart';
import 'package:astrogame_app/models/authorization/authorization_token.dart';
import 'package:astrogame_app/models/authorization/login_request.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

import '../server_response.dart';

@injectable
class AuthorizationRepository {
  late AuthorizationApi _api;
  Logger _logger;

  AuthorizationRepository(Dio dio, this._logger) {
    _api = new AuthorizationApi(dio);
  }

  Future<ServerResponseT<AuthorizationToken>> loginAsync(
    LoginRequest request,
  ) async {
    try {
      _logger.d('login');
      var response = await _api.loginAsync(request);
      return ServerResponseT()..data = response;
    } on DioError catch (error) {
      return ServerResponseT()..error = ServerError.withError(error);
    }
  }
}
