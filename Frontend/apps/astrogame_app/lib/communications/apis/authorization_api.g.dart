// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'authorization_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _AuthorizationApi implements AuthorizationApi {
  _AuthorizationApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/authorizations';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<AuthorizationToken> loginAsync(request) async {
    ArgumentError.checkNotNull(request, 'request');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    _data.addAll(request?.toJson() ?? <String, dynamic>{});
    final _result = await _dio.request<Map<String, dynamic>>('/login',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'POST',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = AuthorizationToken.fromJson(_result.data);
    return value;
  }
}
