// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'player_species_api.dart';

// **************************************************************************
// RetrofitGenerator
// **************************************************************************

class _PlayerSpeciesApi implements PlayerSpeciesApi {
  _PlayerSpeciesApi(this._dio, {this.baseUrl}) {
    ArgumentError.checkNotNull(_dio, '_dio');
    baseUrl ??= 'https://localhost:7555/api/v1/player-species';
  }

  final Dio _dio;

  String baseUrl;

  @override
  Future<dynamic> addAsync({species}) async {
    ArgumentError.checkNotNull(species, 'species');
    const _extra = <String, dynamic>{};
    final queryParameters = <String, dynamic>{};
    queryParameters.removeWhere((k, v) => v == null);
    final _data = <String, dynamic>{};
    _data.addAll(species?.toJson() ?? <String, dynamic>{});
    final _result = await _dio.request('/',
        queryParameters: queryParameters,
        options: RequestOptions(
            method: 'PUT',
            headers: <String, dynamic>{},
            extra: _extra,
            baseUrl: baseUrl),
        data: _data);
    final value = _result.data;
    return value;
  }
}
