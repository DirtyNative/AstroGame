// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'resource_snapshot_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _ResourceSnapshotApi implements ResourceSnapshotApi {
  _ResourceSnapshotApi(this._dio, {this.baseUrl}) {
    baseUrl ??= 'https://localhost:7555/api/v1/resource-snapshot';
  }

  final Dio _dio;

  String? baseUrl;

  @override
  Future<ResourceSnapshot> getAsync(stellarObjectId) async {
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.fetch<Map<String, dynamic>>(
        _setStreamType<ResourceSnapshot>(
            Options(method: 'GET', headers: <String, dynamic>{}, extra: _extra)
                .compose(_dio.options, '/stellar-object/$stellarObjectId',
                    queryParameters: queryParameters, data: _data)
                .copyWith(baseUrl: baseUrl ?? _dio.options.baseUrl)));
    final value = ResourceSnapshot.fromJson(_result.data!);
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
