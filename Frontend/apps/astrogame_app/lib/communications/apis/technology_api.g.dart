// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'technology_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _TechnologyApi implements TechnologyApi {
  _TechnologyApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/technology';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<List<Technology>> getAllAsync() async {
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
        .map((dynamic i) => Technology.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }

  @override
  Future<List<TechnologyValue>> getValuesAsync(
      technologyId, startLevel, countLevels) async {
    ArgumentError.checkNotNull(technologyId, 'technologyId');
    ArgumentError.checkNotNull(startLevel, 'startLevel');
    ArgumentError.checkNotNull(countLevels, 'countLevels');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{r'countLevels': countLevels};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<List<dynamic>>(
        '/values/technology/$technologyId/level/$startLevel',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    var value = _result.data
        .map((dynamic i) => TechnologyValue.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }
}
