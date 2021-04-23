// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'studied_research_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _StudiedResearchApi implements StudiedResearchApi {
  _StudiedResearchApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/studied-research';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<List<StudiedResearch>> getByCurrentPlayerAsync() async {
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
        .map((dynamic i) => StudiedResearch.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }

  @override
  Future<StudiedResearch> getByResearchAndCurrentPlayerAsync(researchId) async {
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
    final value = StudiedResearch.fromJson(_result.data);
    return value;
  }
}
