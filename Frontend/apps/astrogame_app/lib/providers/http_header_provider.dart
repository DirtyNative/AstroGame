import 'dart:io';
import 'package:injectable/injectable.dart';
import 'authorization_token_provider.dart';
import 'selected_colonized_stellar_object_provider.dart';

@injectable
class HttpHeaderProvider {
  AuthorizationTokenProvider _authorizationTokenProvider;
  SelectedColonizedStellarObjectProvider _selectedStellarObjectProvider;

  HttpHeaderProvider(
    this._authorizationTokenProvider,
    this._selectedStellarObjectProvider,
  );

  Map<String, String> getHeaders() {
    Map<String, String> customHeaders = {
      HttpHeaders.contentTypeHeader: 'application/json',

      /*HttpHeaders.authorizationHeader:
          '${_authorizationTokenProvider.getToken()?.tokenType} ${_authorizationTokenProvider.getToken()?.accessToken}',
      'selected-stellar-object':
          _selectedStellarObjectProvider.getSelectedObject()?.id?.toString() */
    };

    if (_authorizationTokenProvider.getToken() != null) {
      var token = _authorizationTokenProvider.getToken();

      customHeaders.addAll({
        HttpHeaders.authorizationHeader:
            '${token?.tokenType} ${token?.accessToken}'
      });
    }

    if (_selectedStellarObjectProvider.getSelectedObject() != null) {
      var selectedObject = _selectedStellarObjectProvider.getSelectedObject();

      customHeaders.addAll({
        'selected-stellar-object':
            selectedObject?.stellarObjectId.toString() ?? ''
      });
    }

    return customHeaders;
  }
}
