// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'research_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _ResearchApi implements ResearchApi {
  _ResearchApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/research';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<List<Research>> getAllAsync() async {
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
        .map((dynamic i) => Research.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }
}
