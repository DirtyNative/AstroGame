// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'resource_snapshot_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _ResourceSnapshotApi implements ResourceSnapshotApi {
  _ResourceSnapshotApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/resource-snapshot';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<ResourceSnapshot> getAsync(stellarObjectId) async {
    ArgumentError.checkNotNull(stellarObjectId, 'stellarObjectId');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<Map<String, dynamic>>(
        '/stellar-object/$stellarObjectId',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = ResourceSnapshot.fromJson(_result.data);
    return value;
  }
}
