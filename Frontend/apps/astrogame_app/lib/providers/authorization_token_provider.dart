import 'package:astrogame_app/models/authorization/authorization_token.dart';
import 'package:injectable/injectable.dart';

@singleton
class AuthorizationTokenProvider {
  AuthorizationToken? _token;

  AuthorizationToken? getToken() {
    return _token;
  }

  void setToken(AuthorizationToken token) {
    _token = token;
  }
}
