import 'package:astrogame_app/communications/apis/authorization_api.dart';
import 'package:astrogame_app/communications/server_error.dart';
import 'package:astrogame_app/models/authorization/authorization_token.dart';
import 'package:astrogame_app/models/authorization/login_request.dart';
import 'package:dio/dio.dart';
import 'package:flutter/foundation.dart';
import 'package:injectable/injectable.dart';

import '../server_response.dart';

@injectable
class AuthorizationRepository {
  AuthorizationApi _api;

  AuthorizationRepository(Dio dio) {
    _api = new AuthorizationApi(dio);
  }

  Future<ServerResponseT<AuthorizationToken>> loginAsync({
    @required LoginRequest request,
  }) async {
    try {
      var response = await _api.loginAsync(request);
      return ServerResponseT()..data = response;
    } catch (error) {
      return ServerResponseT()..error = ServerError.withError(error: error);
    }
  }
}
