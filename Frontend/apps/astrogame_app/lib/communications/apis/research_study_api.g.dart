// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'research_study_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _ResearchStudyApi implements ResearchStudyApi {
  _ResearchStudyApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/research-study';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<ResearchStudy> getByPlayerAsync(playerId) async {
    ArgumentError.checkNotNull(playerId, 'playerId');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<Map<String, dynamic>>(
        '/player/$playerId',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = ResearchStudy.fromJson(_result.data);
    return value;
  }

  @override
  Future<ResearchStudy> getByCurrentPlayerAsync() async {
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<Map<String, dynamic>>('/player/current',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = ResearchStudy.fromJson(_result.data);
    return value;
  }
}
