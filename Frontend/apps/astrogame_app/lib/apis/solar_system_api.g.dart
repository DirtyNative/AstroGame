// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'solar_system_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _SolarSystemApi implements SolarSystemApi {
  _SolarSystemApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/solar-system';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<SolarSystem> getBySystemNumberRecursiveAsync({systemNumber}) async {
    ArgumentError.checkNotNull(systemNumber, 'systemNumber');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    queryParameters.removeWhere((k, v) => v == null);
    final _data = <String, dynamic>{};
    final _result = await _dio.request<Map<String, dynamic>>(
        '/system-number/$systemNumber/recursive',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = SolarSystem.fromJson(_result.data);
    return value;
  }
}
