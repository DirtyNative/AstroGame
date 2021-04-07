// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'building_chain_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _BuildingChainApi implements BuildingChainApi {
  _BuildingChainApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/building-chain';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<BuildingChain> getByCurrentPlayerAsync() async {
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    final _data = <String, dynamic>{};
    final _result = await _dio.request<Map<String, dynamic>>('/current',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'GET',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = BuildingChain.fromJson(_result.data);
    return value;
  }
}
