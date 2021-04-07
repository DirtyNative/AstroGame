// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'built_building_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _BuiltBuildingApi implements BuiltBuildingApi {
  _BuiltBuildingApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/built-building';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<List<BuiltBuilding>> getAsync() async {
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<List<dynamic>>('/',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    var value = _result.data
        .map((dynamic i) => BuiltBuilding.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }

  @override
  Future<BuiltBuilding> getByBuilding(buildingId) async {
    ArgumentError.checkNotNull(buildingId, 'buildingId');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<Map<String, dynamic>>(
        '/building/$buildingId',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = BuiltBuilding.fromJson(_result.data);
    return value;
  }
}
