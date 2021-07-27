// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'authorization_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _AuthorizationApi implements AuthorizationApi {
  _AuthorizationApi(this._dio, {this.baseUrl}) {
    baseUrl ??= 'https://localhost:7555/api/v1/authorizations';
  }

  final Dio _dio;

  String? baseUrl;

  @override
  Future<AuthorizationToken> loginAsync(request) async {
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    _data.addAll(request.toJson());
    final _result = await _dio.fetch<Map<String, dynamic>>(
        _setStreamType<AuthorizationToken>(
            Options(method: 'POST', headers: <String, dynamic>{}, extra: _extra)
                .compose(_dio.options, '/login',
                    queryParameters: queryParameters, data: _data)
                .copyWith(baseUrl: baseUrl ?? _dio.options.baseUrl)));
    final value = AuthorizationToken.fromJson(_result.data!);
    return value;
  }

  RequestOptions _setStreamType<T>(RequestOptions requestOptions) {
    if (T != dynamic &&
        !(requestOptions.responseType == ResponseType.bytes ||
            requestOptions.responseType == ResponseType.stream)) {
      if (T == String) {
        requestOptions.responseType = ResponseType.plain;
      } else {
        requestOptions.responseType = ResponseType.json;
      }
    }
    return requestOptions;
  }
}
