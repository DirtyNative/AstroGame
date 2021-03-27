// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'stellar_object_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _StellarObjectApi implements StellarObjectApi {
  _StellarObjectApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/stellar-object';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<StellarObject> getAsync({id}) async {
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
    final value = StellarObject.fromJson(_result.data);
    return value;
  }
}
