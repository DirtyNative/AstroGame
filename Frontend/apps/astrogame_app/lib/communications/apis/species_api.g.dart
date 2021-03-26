// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'species_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _SpeciesApi implements SpeciesApi {
  _SpeciesApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/species';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<List<Species>> getAllAsync() async {
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
        .map((dynamic i) => Species.fromJson(i as Map<String, dynamic>))
        .toList();
    return value;
  }

  @override
  Future<Species> getAsync({id}) async {
    ArgumentError.checkNotNull(id, 'id');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    queryParameters.removeWhere((k, v) => v == null);
    final _data = <String, dynamic>{};
    final _result = await _dio.request<Map<String, dynamic>>('/$id',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = Species.fromJson(_result.data);
    return value;
  }
}
