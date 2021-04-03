// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'stored_resource_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _StoredResourceApi implements StoredResourceApi {
  _StoredResourceApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/stored-resource';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<List<StoredResource>> getOnCurrentStellarObjectAsync() async {
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<List<dynamic>>('/stellar-object',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    var value = _result.data
        .map((dynamic i) => StoredResource.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }

  @override
  Future<List<StoredResource>> getOnStellarObjectAsync(stellarObjectId) async {
    ArgumentError.checkNotNull(stellarObjectId, 'stellarObjectId');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<List<dynamic>>(
        '/stellar-object/$stellarObjectId',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    var value = _result.data
        .map((dynamic i) => StoredResource.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }
}
