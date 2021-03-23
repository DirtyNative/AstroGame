import 'dart:io';
import 'package:injectable/injectable.dart';
import 'authorization_token_provider.dart';

@injectable
class HttpHeaderProvider {
  AuthorizationTokenProvider _authorizationTokenProvider;

  HttpHeaderProvider(
    this._authorizationTokenProvider,
  );

  Map<String, String> getHeaders() {
    Map<String, String> customHeaders = {
      HttpHeaders.contentTypeHeader: 'application/json',
      HttpHeaders.authorizationHeader:
          '${_authorizationTokenProvider.getToken()?.tokenType} ${_authorizationTokenProvider.getToken()?.accessToken}',
    };

    return customHeaders;
  }
}
