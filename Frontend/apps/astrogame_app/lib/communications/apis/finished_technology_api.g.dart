// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'finished_technology_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _FinishedTechnologyApi implements FinishedTechnologyApi {
  _FinishedTechnologyApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/finished-technology';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<List<FinishedTechnology>> getByCurrentStellarObjectAsync() async {
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<List<dynamic>>('/stellar-object/current',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    var value = _result.data
        .map((dynamic i) =>
            FinishedTechnology.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }

  @override
  Future<FinishedTechnology> getByCurrentStellarObjectAndTechnologyAsync(
      technologyId) async {
    ArgumentError.checkNotNull(technologyId, 'technologyId');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<Map<String, dynamic>>(
        '/stellar-object/current/technology/$technologyId',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = FinishedTechnology.fromJson(_result.data);
    return value;
  }

  @override
  Future<List<FinishedTechnology>> getByCurrentPlayerAsync() async {
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<List<dynamic>>('/player/current',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    var value = _result.data
        .map((dynamic i) =>
            FinishedTechnology.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }

  @override
  Future<FinishedTechnology> getByResearchAndCurrentPlayerAsync(
      researchId) async {
    ArgumentError.checkNotNull(researchId, 'researchId');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<Map<String, dynamic>>(
        '/research/$researchId/player/current',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = FinishedTechnology.fromJson(_result.data);
    return value;
  }
}
