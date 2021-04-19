// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'building_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _BuildingApi implements BuildingApi {
  _BuildingApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/building';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<List<Building>> getAllAsync() async {
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
        .map((dynamic i) => Building.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }

  @override
  Future<List<Building>> getForCurrentStellarObjectAsync() async {
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<List<dynamic>>('/current',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    var value = _result.data
        .map((dynamic i) => Building.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }

  @override
  Future<List<Building>> getAllByTypeAsync(type) async {
    ArgumentError.checkNotNull(type, 'type');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<List<dynamic>>('/type/$type',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    var value = _result.data
        .map((dynamic i) => Building.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }

  @override
  Future<dynamic> buildAsync(buildingId) async {
    ArgumentError.checkNotNull(buildingId, 'buildingId');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request('/build/$buildingId',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'PUT',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = _result.data;
    return value;
  }

  @override
  Future<List<BuildingValue>> getValuesAsync(
      buildingId, startLevel, countLevels) async {
    ArgumentError.checkNotNull(buildingId, 'buildingId');
    ArgumentError.checkNotNull(startLevel, 'startLevel');
    ArgumentError.checkNotNull(countLevels, 'countLevels');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{r'countLevels': countLevels};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<List<dynamic>>(
        '/values/building/$buildingId/level/$startLevel',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    var value = _result.data
        .map((dynamic i) => BuildingValue.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }
}
