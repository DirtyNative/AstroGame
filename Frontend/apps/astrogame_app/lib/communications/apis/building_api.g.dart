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
}
