// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'research_study_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _ResearchStudyApi implements ResearchStudyApi {
  _ResearchStudyApi(this._dio, {this.baseUrl}) {
    baseUrl ??= 'https://localhost:7555/api/v1/research-study';
  }

  final Dio _dio;

  String? baseUrl;

  @override
  Future<ResearchStudy> getByPlayerAsync(playerId) async {
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.fetch<Map<String, dynamic>>(
        _setStreamType<ResearchStudy>(
            Options(method: 'GET', headers: <String, dynamic>{}, extra: _extra)
                .compose(_dio.options, '/player/$playerId',
                    queryParameters: queryParameters, data: _data)
                .copyWith(baseUrl: baseUrl ?? _dio.options.baseUrl)));
    final value = ResearchStudy.fromJson(_result.data!);
    return value;
  }

  @override
  Future<ResearchStudy> getByCurrentPlayerAsync() async {
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.fetch<Map<String, dynamic>>(
        _setStreamType<ResearchStudy>(
            Options(method: 'GET', headers: <String, dynamic>{}, extra: _extra)
                .compose(_dio.options, '/player/current',
                    queryParameters: queryParameters, data: _data)
                .copyWith(baseUrl: baseUrl ?? _dio.options.baseUrl)));
    final value = ResearchStudy.fromJson(_result.data!);
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
